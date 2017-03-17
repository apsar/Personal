using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.CognitiveServices.SpeechRecognition;
using System.Windows.Threading;
using Starvis.Models;
using System.Text.RegularExpressions;
using System.Media;

namespace Starvis.Utilities
{
    class SpeechToText
    {

        private static MicrophoneRecognitionClient micClient;

        public static DbRecord result = new DbRecord();

        public static void ConverSpeechToText()

        {
            try
            {
                if (micClient == null)
                {
                    CreateMicrophoneRecoClient();
                    micClient.StartMicAndRecognition();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Nothing");
            }
        }
        private static void OnDataShortPhraseResponseReceivedHandler(object sender, SpeechResponseEventArgs e)
        {
            WriteResponseResult(e);

        }
        private static void WriteResponseResult(SpeechResponseEventArgs e)
        {
            if (e.PhraseResponse.Results.Length == 0)
            {
                Console.WriteLine("No phrase response is available.");
            }
            else
            {
                Console.WriteLine("********* Final n-BEST Results *********");
                for (int i = 0; i < e.PhraseResponse.Results.Length; i++)
                {
                    Console.WriteLine(
                        "[{0}] Confidence={1}, Text=\"{2}\"",
                        i,
                        e.PhraseResponse.Results[i].Confidence,
                        e.PhraseResponse.Results[i].DisplayText);
                }
               
                for (int i = 0; i < e.PhraseResponse.Results.Length; i++)
                {
                    string sentence = Regex.Replace(e.PhraseResponse.Results[i].DisplayText, "[^a-zA-Z0-9_]+", ""),prefix;
                    if (sentence.Contains(" "))
                    {
                        prefix = sentence.Substring(0, sentence.IndexOf(" "));
                    }
                    else
                    {
                        prefix = sentence;
                    }
                    string resultTable = MatchPrefix(prefix);
                    result.tableName = resultTable;
                    if (!result.tableName.Equals("INVALID", StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }
                }
                for (int i = 0; i < e.PhraseResponse.Results.Length; i++)
                {
                    string sentence = Regex.Replace(e.PhraseResponse.Results[i].DisplayText, "[^a-zA-Z0-9_]+", "");
                    string[] words = sentence.Split(' ');
                    words = words.Skip(1).ToArray();

                }


                }
        }


        private static void CreateMicrophoneRecoClient()
        {
            micClient = SpeechRecognitionServiceFactory.CreateMicrophoneClient(
                SpeechRecognitionMode.ShortPhrase,
                 "en-IN",
                "f078735144bb444d93025bfcc860894b");
            micClient.AuthenticationUri = string.Empty;

            // Event handlers for speech recognition results
            micClient.OnMicrophoneStatus += OnMicrophoneStatus;

            micClient.OnResponseReceived += OnMicShortPhraseResponseReceivedHandler;

        }
        private static void OnMicrophoneStatus(object sender, MicrophoneEventArgs e)
        {

            Console.WriteLine("--- Microphone status change received by OnMicrophoneStatus() ---");
            Console.WriteLine("********* Microphone status: {0} *********", e.Recording);

            if (e.Recording)
            {
                PlayStartingBeep();
                Console.WriteLine("Please start speaking.");
            }
        }
        private static void OnMicShortPhraseResponseReceivedHandler(object sender, SpeechResponseEventArgs e)
        {
            micClient.EndMicAndRecognition();
            WriteResponseResult(e);

        }

        public static DbRecord ListenSpeechAndGetDbRecord()
        {
            ConverSpeechToText();
            return result;
        }
        public static string MatchPrefix(string prefix)
        {

            string result = string.Empty;
            if (prefix.Equals("ARENA", StringComparison.InvariantCultureIgnoreCase))
            {
                return "ARENA";
            }
            else if (prefix.Equals("BROWSE", StringComparison.InvariantCultureIgnoreCase))
            {
                return "BROWSE";
            }
            else if (prefix.Equals("HOTKEY", StringComparison.InvariantCultureIgnoreCase))
            {
                return "HOTKEY";
            }
            else if (prefix.Equals("OUTLOOK", StringComparison.InvariantCultureIgnoreCase))
            {
                return "OUTLOOK";
            }
            else if (prefix.Equals("PROFILE", StringComparison.InvariantCultureIgnoreCase))
            {
                return "PROFILE";
            }
            else if (prefix.Equals("JIRA", StringComparison.InvariantCultureIgnoreCase))
            {
                return "JIRA";
            }
            else if (prefix.Equals("CODE", StringComparison.InvariantCultureIgnoreCase))
            {
                return "CODE";
            }
            else
            {
                int minDistance = int.MaxValue, distance;
                TextAnalysis textAnalysis = new TextAnalysis();
                List<string> features = AddFeatures();
                foreach (var item in features)
                {
                    distance = TextAnalysis.ComputeDistance(prefix, item.ToString());
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        result = item.ToString();
                    }


                }
                if (minDistance <= 2)
                {
                    return result;
                }
                else
                {
                    return "INVALID";
                }
            }
        }

        public static List<string> AddFeatures()
        {
            List<string> features = new List<string>();
            features.Add("ARENA");
            features.Add("OUTLOOK");
            features.Add("BROWSE");
            features.Add("HOTKEY");
            features.Add("CODE");
            features.Add("PROFILE");
            features.Add("JIRA");
            return features;
        }

        public static void PlayStartingBeep()
        {
            SoundPlayer audio = new SoundPlayer(Starvis.Properties.Resources.beep); 
            audio.Play();
        }

    }

}
