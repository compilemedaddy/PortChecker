using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PortChecker
{
    class Program
    {
        private static string IP = "";

        private static int[] ports = new int[]
        {
            21,
            22,
            23,
            25,
            53,
            80,
            110,
            115,
            135,
            139,
            143,
            195,
            443,
            445,
            1433,
            3306,
            3389,
            5632,
            5900,
        };

        static void Main(string[] args)
        {
            UserInput();
            PortScan();
            Console.ReadKey();
        }

        private static void UserInput()
        {
            Console.WriteLine("Enter IP-Address:");
            IP = Console.ReadLine();
        }

        private static void PortScan()
        {
            Console.Clear();
            TcpClient scan = new TcpClient();
            
            foreach (int s in ports)
            {
                
                {
                    try
                    {
                        scan.Connect(IP, s);
                        Console.WriteLine($"[{s}] | OPEN", Console.ForegroundColor = ConsoleColor.Green);
                    }
                    catch
                    {
                        Console.WriteLine($"[{s}] | CLOSED", Console.ForegroundColor = ConsoleColor.Red);
                    }
                }
            }
        }
    }
}
