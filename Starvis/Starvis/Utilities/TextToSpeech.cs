using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace Starvis
{
    public static class TextToSpeech
    {
        public static SpeechSynthesizer speaker = new SpeechSynthesizer();
        public static void Speak(string text)
        {
            speaker.Speak(text);
        }
    }
}
