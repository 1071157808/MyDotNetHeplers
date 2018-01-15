

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateIsEventSignature
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.DoSpeakEvents += SlowSpeak;
            p1.DoSpeakEvents += LoudlySpeak;
            p1.DoIt();
            Console.ReadKey();
        }
        static void SlowSpeak(object a, EventArgs e)
        {
            Console.WriteLine("asdfasdfasdf    " + a.ToString());
        }
        static void LoudlySpeak(object a, EventArgs e)
        {
            Console.WriteLine("i am louderly speak   " + a.ToString());
        }
    }
    public class Person
    {
        public delegate void Speak(object o, EventArgs e);
        public event Speak DoSpeakEvents;
        //可以写成下面的这种格式，就不用写delegate了，简写模式
        public EventHandler<EventArgs> TestSpeak;
        //DoIt相当于Nofity，通知所有的挂载函数
        public void DoIt()
        {
            DoSpeakEvents(this, EventArgs.Empty);
        }
    }
}

