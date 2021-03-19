using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace focus
{
    class Program
    {
        static void Main(string[] args)
        {
            string server = null;
            server = Dns.GetHostName();
            float version = 0.1f;
            var mode = "DEBUG";
            var isWaitingCommand_debug = true;
            var isSearching = false;
            var isResult = false;
            var networkAvailable = NetworkInterface.GetIsNetworkAvailable();
            var IsAvaiable = false; 
            if (!networkAvailable)
            {
                IsAvaiable = false;
            } else if (networkAvailable)
            {
                IsAvaiable = true;
            }
        isWaiting_gt: while (isWaitingCommand_debug)
            {
                server = Dns.GetHostName();
                mode = "DEBUG";
                Console.Clear();
                writeTitle();
                Console.WriteLine("                                                         MODE = [" + mode + "]");
                Console.WriteLine("                                                         VERSION = [" + version + "]");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                         NETWORK = [" + IsAvaiable + "]");
                InterfaceSpeedAgent();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                        HOSTNAME = [" + server + "]");
                getIPAddress(server);
                IPAdressAdditionalInfo();
                var read = Console.ReadLine();
                switch (read)
                {
                    case "search":
                        isWaitingCommand_debug = false;
                        isSearching = true;
                        mode = "SEARCH";
                        break;
                }
            }
            while (isWaitingCommand_debug)
            {
                Console.Clear();
                writeTitle();
                Console.WriteLine("                                                         MODE = [" + mode + "]");
                Console.WriteLine("                                                         VERSION = [" + version + "]");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                         NETWORK = ["+IsAvaiable+"]");
                InterfaceSpeedAgent();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                        HOSTNAME = ["+server+"]");
                getIPAddress(server);
                IPAdressAdditionalInfo();
                var read = Console.ReadLine();
                switch (read)
                {
                    case "search":
                        isWaitingCommand_debug = false;
                        isSearching = true;
                        mode = "SEARCH";
                        break;
                }
            }
            string server_hs = null;
            while (isSearching)
            {
                Console.Clear();
                writeTitle();
                Console.Clear();
                writeTitle();
                Console.WriteLine("                                                         MODE = [" + mode + "]");
                Console.WriteLine("                                                         VERSION = [" + version + "]");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                         NETWORK = [" + IsAvaiable + "]");
                InterfaceSpeedAgent();
                IPAdressAdditionalInfo();
                Console.WriteLine(">>Enter hostname");
                var read = Console.ReadLine();
                if(read != "")
                {
                    try
                    {
                        server = read;
                        Console.Clear();
                        writeTitle();
                        Console.WriteLine("                                                         MODE = [" + mode + "]");
                        Console.WriteLine("                                                         VERSION = [" + version + "]");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        Console.WriteLine("                                                         NETWORK = [" + IsAvaiable + "]");
                        InterfaceSpeedAgent();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        Console.WriteLine("                                                        HOSTNAME = [" + server + "]");
                        getIPAddress(server);
                        IPAdressAdditionalInfo();
                        isSearching = false;
                        isResult = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(">>Exception:" + e.ToString());
                        server = null;
                    }
                }
            }

            while (isResult)
            {
                try
                {
                    Console.Clear();
                    writeTitle();
                    Console.WriteLine("                                                         MODE = [" + mode + "]");
                    Console.WriteLine("                                                         VERSION = [" + version + "]");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                                                         NETWORK = [" + IsAvaiable + "]");
                    //InterfaceSpeedAgent();
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                                                        HOSTNAME = [" + server + "]");
                    getIPAddress(server);
                    IPAdressAdditionalInfo();
                    var read = Console.ReadLine();
                    switch (read)
                    {
                        case "ok":
                            isWaitingCommand_debug = true;
                            isResult = false;
                            goto isWaiting_gt;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(">>Exception:" + e.ToString());
                    server = null;
                }
            }
        }

        static void writeTitle()
        {
            Console.WriteLine("         ________   __________   __________   ___    ___   __________     ");
            Console.WriteLine("        /  _____/  /  ____   /  /  _______/  /  /   /  /  /  _______/     ");
            Console.WriteLine("       /  /____   /  /   /  /  /  /         /  /   /  /  /  /______       ");
            Console.WriteLine("      /  _____/  /  /   /  /  /  /         /  /   /  /  /______   /       ");
            Console.WriteLine("     /  /       /  /___/  /  /  /______   /  /__ /  /  _______/  /        ");
            Console.WriteLine("    /__/       /_________/  /_________/  /_________/  /_________/         \n");
        }

        protected static void InterfaceSpeedAgent()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach(NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                IPv4InterfaceStatistics stats = adapter.GetIPv4Statistics();
                Console.WriteLine(adapter.Description);
                Console.WriteLine("                                                        Speed = [" + adapter.Speed + "]");
                Console.WriteLine("                                                        Output length = ["+stats.OutputQueueLength+"]");
            }
        }

        protected static void getIPAddress(string server)
        {
            var ipadress = "";
            try
            {
                //System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
                IPHostEntry heserver = Dns.GetHostEntry(server);
                foreach(IPAddress curAdd in heserver.AddressList)
                {
                    //Console.WriteLine("AddressFamily:" + curAdd.AddressFamily.ToString());
                    Console.WriteLine("                                                        IPAdress = [" + curAdd.ToString() + "]") ;
                    //Console.WriteLine("AddressBytes:  ");

                    Byte[] bytes = curAdd.GetAddressBytes();
                    for(int i = 0; i < bytes.Length; i++)
                    {
                        //Console.WriteLine(bytes[i]);
                    }
                    //Console.WriteLine("\r\n");
                }
                //Console.WriteLine("                                                        IPAdress = [" + heserver.AddressList[3]+"]");
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception:" + e.ToString());
            }

        }

        protected static void IPAdressAdditionalInfo()
        {
            try
            {
                Console.WriteLine("                                                        SupportsIPv4 = [" + Socket.SupportsIPv4+"]");
                Console.WriteLine("                                                        SupportsIPv6 = [" + Socket.SupportsIPv6+ "]");

                if (Socket.SupportsIPv6)
                {
                    //Console.WriteLine("\r\nIPv6any:" + IPAddress.IPv6Any.ToString());
                    //Console.WriteLine("IPv6Loopback:" + IPAddress.IPv6Loopback.ToString());
                    //Console.WriteLine("IPv6None:" + IPAddress.IPv6None.ToString());
                    //Console.WriteLine("IsLoopback:" + IPAddress.IsLoopback(IPAddress.Loopback));
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("%IPAddress%Exception:" + e.ToString());
            }
        }
    }
}
