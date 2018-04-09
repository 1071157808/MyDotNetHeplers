using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPServer {
    class Program {
        static Socket client;
        static NetworkStream netstream;

        [STAThread]
        static void Main (string[] args) {
            Console.Title = "Server";

            IPAddress ipAddress = IPAddress.Parse ("127.0.0.1");
            TcpListener tcpListener = new TcpListener (ipAddress, 8080);
            tcpListener.Start ();
            Console.WriteLine ("Server is running");

            try {
                while (true) {
                    client = tcpListener.AcceptSocket ();

                    if (client.Connected) {
                        Console.WriteLine ("Client connected " + client.RemoteEndPoint.ToString ());
                        Thread thread = new Thread (new ParameterizedThreadStart (listenClient));
                        thread.Start (client);
                    }
                }
            } catch (Exception e) {
                Console.WriteLine (e.ToString ());
            }

        }

        static void listenClient (object data) {
            while (client.Connected) {
                try {
                    client = (Socket) data;
                    netstream = new NetworkStream (client);
                    StreamWriter streamWriter = new StreamWriter (netstream); // to client
                    StreamReader streamReader = new StreamReader (netstream); // from client
                } catch (Exception e) {

                }
            }
        }
    }
}