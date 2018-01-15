
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            // 如果是XP系统，并且没有安装 TTS 5.1 语言包的话，上面的朗读，会忽略所有的中文的
            //第一种方法
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("你好，这里net3.0的用法？");
            synth.Dispose();
            //第二种方法
            Type type = Type.GetTypeFromProgID("SAPI.SpVoice");
            dynamic spVoice = Activator.CreateInstance(type);
            spVoice.Speak("你好,欢迎使用 CSharp 4.0！");
            Console.Read();
        }
    }
}
