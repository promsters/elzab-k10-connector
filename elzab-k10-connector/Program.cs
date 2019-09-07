using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO.Ports;

namespace ElzabK10Connector
{
    class Program
    {
        //deklaracja funkcji z dwoma parametrami
        [DllImport("WinIP.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte __DrukRapD(string inputfile, string outputfile);

        static int Main(string[] args)
        {
            SerialPort port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            port.Open();

            port.WriteLine("123456");

            return 1;
        }

        static int Mainxd(string[] args)
        {
            byte error;

            //wywołanie funkcji z dwoma parametrami
            error = __DrukRapD("drukrapd.in", "drukrapd.out");
            if (error != 0)
            {
                Console.WriteLine(error);
                Console.In.ReadLine();
                //obsługa błędów
                return error;
            }

            return error;
        }
    }
}
