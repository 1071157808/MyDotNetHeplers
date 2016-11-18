using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace observerPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConcreteSubject subject = new ConcreteSubject();
            subject.Attach(new ConcreteObserver(subject, "水壶"));
            subject.Attach(new ConcreteObserver(subject, "报警器"));
            subject.waterTemp = "25";
            for (int i = 25; i < 90; i++)
            {
                subject.waterTemp = i.ToString() ;
                if (i >= 85)
                {
                    subject.Notify();
                }

            }
            Console.ReadKey();
        }
    }
    //抽象观察类
    public abstract class Observer
    {
        public abstract void Update();
    }
    // 抽象主题类
    public abstract class Subject
    {
        private IList<Observer> observers = new List<Observer>();
        //增加观察者
        public void Attach(Observer ob)
        {
            observers.Add(ob);
        }
        //删除观察者
        public void Delete(Observer ob)
        {
            observers.Remove(ob);
        }
        // 向观察者们发出通知
        public void Notify()
        {
            foreach (Observer item in observers)
            {
                item.Update();
            }
        }
    }

    //具体的主题类
    public class ConcreteSubject : Subject
    {
        public string waterTemp { get; set; }
    }
    // 具体的观察者模式，水壶
    public class ConcreteObserver : Observer
    {
        public string bottleTemp { get; set; }
        public string name { get; set; }

        public ConcreteObserver(ConcreteSubject Subject, string name)
        {
            this.Con = Subject;
            this.name = name;
        }
        public ConcreteSubject Con { get; set; }
        public override void Update()
        {
            bottleTemp = Con.waterTemp;
            Console.WriteLine("{0}现在监测到的温度是{1}", name, bottleTemp);
        }

    }


}



