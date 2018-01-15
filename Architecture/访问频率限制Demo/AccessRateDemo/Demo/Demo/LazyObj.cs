/*  QQ群：166843154  http://www.cnblogs.com/1996V/p/8127576.html */
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Demo
{
    public class LazyObj
    {
        private readonly static Lazy<LazyObj> _instance = new Lazy<LazyObj>(() => new LazyObj(GlobalHost.ConnectionManager.GetHubContext<SocketHub>().Clients));
        private IHubConnectionContext<dynamic> Clients { get; set; }
        public static LazyObj Instance => _instance.Value;

        private LazyObj(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            Show1();
            Show2();
            Show3();
            Show4();
        }

        #region 显示容器

        private void Show1()
        {
            ThreadPool.QueueUserWorkItem(e =>
            {
                while (true)
                {
                    if (Factory.ContainerList[0].dic.Count == 0)
                    {
                        Clients.All.clear1();
                        Thread.Sleep(200);
                    }
                    else
                    {
                        List<HubModel> lc = new List<HubModel>();
                        var icc = Factory.ContainerList[0].dic.ToArray();
                        for (int i = 0; i < icc.Length; i++)
                        {
                            HubModel m = new HubModel()
                            {
                                UserId = icc[i].Key,
                                Count = icc[i].Value.Count()
                            };
                            lc.Add(m);
                        }
                        Clients.All.update1(lc);
                    }
                }
            });
        }

        private void Show2()
        {
            ThreadPool.QueueUserWorkItem(e =>
            {
                while (true)
                {
                    if (Factory.ContainerList[1].dic.Count == 0)
                    {
                        Clients.All.clear2();
                        Thread.Sleep(200);
                    }
                    else
                    {
                        List<HubModel> lc = new List<HubModel>();
                        var icc = Factory.ContainerList[1].dic.ToArray();
                        for (int i = 0; i < icc.Length; i++)
                        {
                            HubModel m = new HubModel()
                            {
                                UserId = icc[i].Key,
                                Count = icc[i].Value.Count()
                            };
                            lc.Add(m);
                        }
                        Clients.All.update2(lc);
                    }
                }
            });
        }

        private void Show3()
        {
            ThreadPool.QueueUserWorkItem(e =>
            {
                while (true)
                {
                    if (Factory.ContainerList[2].dic.Count == 0)
                    {
                        Clients.All.clear3();
                        Thread.Sleep(200);
                    }
                    else
                    {
                        List<HubModel> lc = new List<HubModel>();
                        var icc = Factory.ContainerList[2].dic.ToArray();
                        for (int i = 0; i < icc.Length; i++)
                        {
                            HubModel m = new HubModel()
                            {
                                UserId = icc[i].Key,
                                Count = icc[i].Value.Count()
                            };
                            lc.Add(m);
                        }
                        Clients.All.update3(lc);
                    }
                }
            });
        }

        private void Show4()
        {
            ThreadPool.QueueUserWorkItem(e =>
            {
                while (true)
                {
                    if (Factory.ContainerList[3].dic.Count == 0)
                    {
                        Clients.All.clear4();
                        Thread.Sleep(200);
                    }
                    else
                    {
                        List<HubModel> lc = new List<HubModel>();
                        var icc = Factory.ContainerList[3].dic.ToArray();
                        for (int i = 0; i < icc.Length; i++)
                        {
                            HubModel m = new HubModel()
                            {
                                UserId = icc[i].Key,
                                Count = icc[i].Value.Count()
                            };
                            lc.Add(m);
                        }
                        Clients.All.update4(lc);
                    }
                }
            });
        }

        #endregion

        #region Client端调用服务
        static Random ra = new Random();
        public void Start()
        {
            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem(e =>
                {
                    for (int x = 0; x < 10; x++)
                    {
                        Factory.Add(ra.Next(0, 40));
                    }
                });
            }
        }

        #endregion

        #region 需要的Model
        public class HubModel
        {
            public string UserId { get; set; }
            public int Count { get; set; }
        }
        #endregion
    }
}