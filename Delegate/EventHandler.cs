
//EventHandler EventArgs 用法例子
namespace 标准事件用法
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank jianhang = new Bank("建设银行", 10000);
            People dong = new People("1", jianhang);
            jianhang.PlayByCard(100);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
    public class CarEventArgs : EventArgs
    {
        public int Yue { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
    class Bank
    {
        public string BankName { set; get; }
        public int Balance { set; get; }
        public Bank(string s, int i)
        {
            this.BankName = s;
            this.Balance = i;
        }
        public event EventHandler<CarEventArgs> MyEvent;
        public void PlayByCard(int i)
        {
            CarEventArgs cc = new CarEventArgs();
            cc.Amount = i;
            cc.Yue = this.Balance - i;
            cc.Name = this.BankName;
            if (MyEvent != null)
            {
                MyEvent(this, cc); //调用事件只能在其中加Object和EventArgs
            }
            else
            {
                Console.WriteLine("系统故障，请紧急联系客服看看你的钱还有没有！");
            }
        }
    }
    class People
    {
        public string id;
        public People(string ID, Bank bb)
        {
            this.id = ID;
            bb.MyEvent += Paycard; //通过匿名方法，将方法给EventHandler委托，再给事件
        }
        private void Paycard(object o, CarEventArgs e)
        {
            Console.WriteLine($"尊敬的{id},您好，您从{e.Name}银行消费了{e.Amount}元，余额为{e.Yue}");
        }
    }
}

