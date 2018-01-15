/*  QQ群：166843154  http://www.cnblogs.com/1996V/p/8127576.html */
using Microsoft.AspNet.SignalR;

namespace Demo
{
    public class SocketHub : Hub
    {
        private readonly LazyObj _lazyObj;

        public SocketHub() : this(LazyObj.Instance) { }

        public SocketHub(LazyObj lazyObj)
        {
            _lazyObj = lazyObj;
        }
        public void start()
        {
            _lazyObj.Start();
        }

        public void Hello()
        {
            Clients.All.hello();
        }
    }
}