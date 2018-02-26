using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient {
    class Program {
        [STAThread]
        static void Main (string[] args) {
            Console.Title = "Client";

            TcpClient client = new TcpClient ();
            Console.WriteLine ("Connecting...");

            client.Connect ("127.0.0.1", 8080);

            Console.WriteLine ("Connected");

            NetworkStream netstream = client.GetStream ();
            StreamWriter streamWriter = new StreamWriter (netstream);
            StreamReader streamReader = new StreamReader (netstream);

            Console.Read ();

        }
    }
}