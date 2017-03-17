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
using Starvis.ResultModels;
using System.Text.RegularExpressions;
using System.Media;
using StarvisDB;
namespace Starvis.Utilities
{
    class SpeechToText
    {

        private static MicrophoneRecognitionClient micClient;

        public static DbRecord result = new DbRecord();
        [STAThread]
        public static void ConverSpeechToText()

        {
            try
            {
                if (micClient == null)
                {
                    CreateMicrophoneRecoClient();
                    micClient.StartMicAndRecognition();
                }
                else
                {
                    micClient.StartMicAndRecognition();
                }
            }
            catch (Exception e)
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
                result.tableName = "INVALID";
                result.rowID = -1;
                micClient.EndMicAndRecognition();
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
                string prefix=string.Empty,resultTable="INVALID";
                int resultRowRecord =-1;
                List<string> response = new List <string>();
                foreach(var item in e.PhraseResponse.Results)
                {
                    response.Add(item.DisplayText);
                }
                resultTable = GetDirectMatchingPrefix(response);
                result.tableName = resultTable;
                for (int i = 0; i < e.PhraseResponse.Results.Length; i++)
                {
                    if(!resultTable.Equals("INVALID",StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }
                    string sentence = Regex.Replace(e.PhraseResponse.Results[i].DisplayText, "[^a-zA-Z0-9_ ]+", "");
                    if (sentence.Contains(" "))
                    {
                        prefix = sentence.Substring(0, sentence.IndexOf(" "));
                    }
                    else
                    {
                        prefix = sentence;
                    }
                 
                    resultTable = GetMatchingPrefix(prefix);
                    result.tableName = resultTable;
                  
                }
                resultRowRecord = GetDirectMatchingRowRecord(response,result.tableName);
                result.rowID = resultRowRecord;
                for (int i = 0; i < e.PhraseResponse.Results.Length; i++)
                {
                    if(resultRowRecord != -1)
                    {
                        break;
                    }
                    string sentence = Regex.Replace(e.PhraseResponse.Results[i].DisplayText, "[^a-zA-Z0-9_  ]+", "");
                    if (sentence.Length > 0)
                    {
                        int j = sentence.IndexOf(" ") + 1;
                        sentence = sentence.Substring(j);
                        resultRowRecord = GetMatchingRow(result.tableName, sentence);
                        result.rowID = resultRowRecord;
                    }
                  

                }
                


            }
            CommandExecution cmdExec = new CommandExecution();
            if (result == null || result.tableName == "INVALID" || result.rowID == -1)
            {
                TextToSpeech.Speak("Sorry! I did not get you.");
            }
            else if (result.tableName == "BROWSE")
            {
                cmdExec.Run(result.rowID);
                TextToSpeech.Speak("Your website is launched");
            }
            else if (result.tableName == "CLIPBOARD")
            {
                cmdExec.CopyToClipBoard(result.rowID);
                TextToSpeech.Speak("Copied your text to clipboard");
            }
            else if (result.tableName == "JIRA")
            {
                cmdExec.ExecuteResult(result.rowID);
            }
            else if (result.tableName == "OUTLOOK")
            {
                new OutlookUtils().HandleOutlookOperations(result.rowID);
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

        
        public static string GetMatchingPrefix(string prefix)
        {

            
                List<string> features = AddFeatures();
                prefix = GetClosestString(prefix, features, 2);
                return prefix;
                
        }

        public static List<string> AddFeatures()
        {
            List<string> features = new List<string>();
            features.Add("ARENA");
            features.Add("OUTLOOK");
            features.Add("BROWSE");
            features.Add("CLIPBOARD");
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
        public static int GetMatchingRow(string prefix, string sentence)
        {
            var db = new Models();
            int resultRecord =-1;
            string closeVoiceCommand;
           
            if (prefix.Equals("ARENA", StringComparison.InvariantCultureIgnoreCase))
            {
               
                    List<string> allCommands = new List<string>();
                    var allRecords = db.ArenaDB.ToList();
                    if (allRecords != null)
                    {
                        foreach (var item in allRecords)
                        {
                            allCommands.Add(item.VoiceCommand);
                        }
                        closeVoiceCommand = GetClosestString(sentence, allCommands, 3);
                        if (!closeVoiceCommand.Equals("INVALID", StringComparison.InvariantCultureIgnoreCase))
                        {
                            resultRecord = db.ArenaDB.Where(a => closeVoiceCommand.Equals(a.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().ArenaID;
                        }
                    }
                
            }
            else if (prefix.Equals("BROWSE", StringComparison.InvariantCultureIgnoreCase))
            {
                
                    List<string> allCommands = new List<string>();
                    var allRecords = db.WebDB.ToList();
                    if (allRecords != null)
                    {
                        foreach (var item in allRecords)
                        {
                            allCommands.Add(item.VoiceCommand);
                        }
                        closeVoiceCommand = GetClosestString(sentence, allCommands, 3);
                        if (!closeVoiceCommand.Equals("INVALID", StringComparison.InvariantCultureIgnoreCase))
                        {
                            resultRecord = db.WebDB.Where(a => closeVoiceCommand.Equals(a.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().WebID;
                        }
                    }

                
            }
            else if (prefix.Equals("CLIPBOARD", StringComparison.InvariantCultureIgnoreCase))
            {
              
                    List<string> allCommands = new List<string>();
                    var allRecords = db.HotKeyDB.ToList();
                    if (allRecords != null)
                    {
                        foreach (var item in allRecords)
                        {
                            allCommands.Add(item.VoiceCommand);
                        }
                        closeVoiceCommand = GetClosestString(sentence, allCommands, 3);
                        if (!closeVoiceCommand.Equals("INVALID", StringComparison.InvariantCultureIgnoreCase))
                        {
                            resultRecord = db.HotKeyDB.Where(a => closeVoiceCommand.Equals(a.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().HotKeyID;
                        }
                    }

                
            }
            else if (prefix.Equals("OUTLOOK", StringComparison.InvariantCultureIgnoreCase))
            {
               
                    List<string> allCommands = new List<string>();
                    var allRecords = db.OutlookDB.ToList();
                    if (allRecords != null)
                    {
                        foreach (var item in allRecords)
                        {
                            allCommands.Add(item.VoiceCommand);
                        }
                        closeVoiceCommand = GetClosestString(sentence, allCommands, 3);
                        if (!closeVoiceCommand.Equals("INVALID", StringComparison.InvariantCultureIgnoreCase))
                        {
                            resultRecord = db.OutlookDB.Where(a => closeVoiceCommand.Equals(a.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().OutlookID;
                        }
                    }

                
            }
            else if (prefix.Equals("PROFILE", StringComparison.InvariantCultureIgnoreCase))
            {
               
                    List<string> allCommands = new List<string>();
                    var allRecords = db.ProfileDB.ToList();
                    if (allRecords != null)
                    {
                        foreach (var item in allRecords)
                        {
                            allCommands.Add(item.VoiceCommand);
                        }
                        closeVoiceCommand = GetClosestString(sentence, allCommands, 3);
                        if (!closeVoiceCommand.Equals("INVALID", StringComparison.InvariantCultureIgnoreCase))
                        {
                            resultRecord = db.ProfileDB.Where(a => closeVoiceCommand.Equals(a.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().ProfileDBID;
                        }
                    }

                
            }
            else if (prefix.Equals("JIRA", StringComparison.InvariantCultureIgnoreCase))
            {
                if (db.JIRADB.Any(j => sentence.Equals(j.VoiceCommand, StringComparison.InvariantCultureIgnoreCase))) 
                {
                    resultRecord = db.JIRADB.Where(j => sentence.Equals(j.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().JIRAID;
                }
                else
                {
                    List<string> allCommands = new List<string>();
                    var allRecords = db.JIRADB.ToList();
                    if (allRecords != null)
                    {
                        foreach (var item in allRecords)
                        {
                            allCommands.Add(item.VoiceCommand);
                        }
                        closeVoiceCommand = GetClosestString(sentence, allCommands, 3);
                        if (!closeVoiceCommand.Equals("INVALID", StringComparison.InvariantCultureIgnoreCase))
                        {
                            resultRecord = db.JIRADB.Where(a => closeVoiceCommand.Equals(a.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().JIRAID;
                        }
                    }

                }
            }
            else if (prefix.Equals("CODE", StringComparison.InvariantCultureIgnoreCase))
            {
               
                    List<string> allCommands = new List<string>();
                    var allRecords = db.CodeBaseDB.ToList();
                    if (allRecords != null)
                    {
                        foreach (var item in allRecords)
                        {
                            allCommands.Add(item.VoiceCommand);
                        }
                        closeVoiceCommand = GetClosestString(sentence, allCommands, 3);
                        if (!closeVoiceCommand.Equals("INVALID", StringComparison.InvariantCultureIgnoreCase))
                        {
                            resultRecord = db.CodeBaseDB.Where(a => closeVoiceCommand.Equals(a.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().CodeBaseID;
                        }
                    }

                
            }
            else
            {
                return -1;
            }
            return resultRecord;

        }

        public static string GetClosestString(string inputString , List<string> dictionary , int threshold)
        {
            string result=string.Empty;
            int minDistance = int.MaxValue, distance;
            TextAnalysis textAnalysis = new TextAnalysis();
            List<string> features = AddFeatures();
            foreach (var item in dictionary)
            {
                distance = TextAnalysis.ComputeDistance(inputString, item.ToString());
                if (distance < minDistance)
                {
                    minDistance = distance;
                    result = item.ToString();
                }


            }
            if (minDistance <= threshold)
            {
                return result;
            }
            else
            {
                return "INVALID";
            }
        }
       
        public static string GetDirectMatchingPrefix(List<string> prefix)
        {
            foreach (var item in prefix)
            {
                string i = Regex.Replace(item, "[^a-zA-Z0-9_ ]+", "");
                i.Replace(".", "");
                i.Replace(",", "");
                i.Replace("?", "");
                i.Replace("!", "");
                if (i.Contains(" "))
                {
                    i = i.Substring(0, i.IndexOf(" "));
                }
                else
                {
                    i = item;
                }
                if (i.Equals("ARENA", StringComparison.InvariantCultureIgnoreCase))
                {
                    return "ARENA";
                }
                else if (i.Equals("BROWSE", StringComparison.InvariantCultureIgnoreCase))
                {
                    return "BROWSE";
                }
                else if (i.Equals("CLIPBOARD", StringComparison.InvariantCultureIgnoreCase))
                {
                    return "CLIPBOARD";
                }
                else if (i.Equals("OUTLOOK", StringComparison.InvariantCultureIgnoreCase))
                {
                    return "OUTLOOK";
                }
                else if (i.Equals("PROFILE", StringComparison.InvariantCultureIgnoreCase))
                {
                    return "PROFILE";
                }
                else if (i.Equals("JIRA", StringComparison.InvariantCultureIgnoreCase))
                {
                    return "JIRA";
                }
                else if (i.Equals("CODE", StringComparison.InvariantCultureIgnoreCase))
                {
                    return "CODE";
                }
               
            }
            return "INVALID";
        }

        public static int GetDirectMatchingRowRecord(List<string> response,string prefix)
        {
            var db = new Models();
            int resultRecord = -1;
            string closeVoiceCommand;
            foreach (var item in response)
            {
                string sentence = Regex.Replace(item, "[^a-zA-Z0-9_ ]+", "");
                sentence.Replace(".", "");
                sentence.Replace(",", "");
                sentence.Replace("?", "");
                sentence.Replace("!", "");
                if (sentence.Length > 0)
                {
                    int j = sentence.IndexOf(" ") + 1;
                    sentence = sentence.Substring(j);
                   
                }
                if (prefix.Equals("ARENA", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (db.ArenaDB.Any(a => sentence.Equals(a.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        resultRecord = db.ArenaDB.Where(a => sentence.Equals(a.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().ArenaID;
                        return resultRecord;
                    }

                }
                else if (prefix.Equals("BROWSE", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (db.WebDB.Any(w => sentence.Equals(w.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        resultRecord = db.WebDB.Where(w => sentence.Equals(w.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().WebID;
                        return resultRecord;
                    }

                }
                else if (prefix.Equals("CLIPBOARD", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (db.HotKeyDB.Any(h => sentence.Equals(h.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        resultRecord = db.HotKeyDB.Where(h => sentence.Equals(h.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().HotKeyID;
                        return resultRecord;
                    }

                }
                else if (prefix.Equals("OUTLOOK", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (db.OutlookDB.Any(o => sentence.Equals(o.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        resultRecord = db.OutlookDB.Where(o => sentence.Equals(o.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().OutlookID;
                        return resultRecord;
                    }

                }
                else if (prefix.Equals("PROFILE", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (db.ProfileDB.Any(p => sentence.Equals(p.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        resultRecord = db.ProfileDB.Where(p => sentence.Equals(p.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().ProfileDBID;
                        return resultRecord;
                    }

                }
                else if (prefix.Equals("JIRA", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (db.JIRADB.Any(j => sentence.Equals(j.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        resultRecord = db.JIRADB.Where(j => sentence.Equals(j.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().JIRAID;
                        return resultRecord;
                    }

                }
                else if (prefix.Equals("CODE", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (db.CodeBaseDB.Any(c => sentence.Equals(c.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        resultRecord = db.CodeBaseDB.Where(c => sentence.Equals(c.VoiceCommand, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().CodeBaseID;
                        return resultRecord;
                    }

                }
                
            }
            return resultRecord;
        }

    }
}

