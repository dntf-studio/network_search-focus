using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;

namespace focus
{
    class Program
    {
        static void Main(string[] args)
        {
            string server = null;
            server = Dns.GetHostName();
            float version = 0.5f;
            var mode = "START";
            var isWaitingCommand_debug = true;
            var isSearching = false;
            var isResult = false;
            var isSpeed = false;
            var isResult_of_ping = false;
            var isHelping = false;
            var networkAvailable = NetworkInterface.GetIsNetworkAvailable();
            var IsAvaiable = false; 
            if (!networkAvailable)
            {
                IsAvaiable = false;
            } else if (networkAvailable)
            {
                IsAvaiable = true;
            }
            string address = null;

        isWaiting_gt: while (isWaitingCommand_debug)
            {
                server = Dns.GetHostName();
                mode = "START";
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
                    case "/search":
                        isWaitingCommand_debug = false;
                        isSearching = true;
                        mode = "SEARCH";
                        break;
                    case "/help":
                        isWaitingCommand_debug = false;
                        isHelping = true;
                        mode = "HELP";
                        break;
                    case "/exit":
                        Environment.Exit(0);
                        break;
                }
            }
        

        isResultOfPing: while (isResult_of_ping)
            {
                try
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Ping sender = new Ping();
                        PingReply reply = sender.Send(address);
                        if (reply.Status == IPStatus.Success)
                        {
                            try
                            {
                                Console.WriteLine("Reply from {0}: bytes = {1} time{2}ms TTL ={3}",
                                    reply.Address,
                                    reply.Buffer.Length,
                                    reply.RoundtripTime,
                                    reply.Options.Ttl);
                            }catch(Exception e)
                            {
                                Console.WriteLine("Exception :"+e.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine(reply.Status);
                        }

                        if (i < 3)
                        {
                            Thread.Sleep(1000);
                            if(i >= 3)
                            {
                                break;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(">>Exception : " + e.ToString());
                }
                var read = Console.ReadLine();
                switch (read)
                {
                    case "/ok":
                        isResult_of_ping = false;
                        isWaitingCommand_debug = true;
                        goto isWaiting_gt;
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
                    case "/search":
                        isWaitingCommand_debug = false;
                        isSearching = true;
                        mode = "SEARCH";
                        break;
                    case "/help":
                        isWaitingCommand_debug = false;
                        isHelping = true;
                        mode = "HELP";
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
                        case "/ok":
                            isWaitingCommand_debug = true;
                            isResult = false;
                            goto isWaiting_gt;
                            break;
                        case "/ping":
                            isResult = false;
                            isSpeed = true;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(">>Exception:" + e.ToString());
                    server = null;
                }
            }

            while (isSpeed)
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
                }
                catch (Exception e)
                {
                    Console.WriteLine(">>Exception:" + e.ToString());
                    server = null;
                }
                Console.WriteLine(">>Enter IPAdress");

                var read = Console.ReadLine();
                if(read != "")
                {
                    address = read;
                    isSpeed = false;
                    isResult_of_ping = true;
                    goto isResultOfPing;
                }
            }

            while (isHelping)
            {
                Console.Clear();
                writeTitle();
                Console.WriteLine("                                                         MODE = [" + mode + "]");
                Console.WriteLine("                                                         VERSION = [" + version + "]");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("  [Commands]");
                Console.WriteLine("   +/help  --> open information(this)");
                Console.WriteLine("   +/search --> Enter hostname to know IPAddress");
                Console.WriteLine("       --> +/ping --> Enter IPAddress ");
                Console.WriteLine("   +/ok --> back to START mode");
                var read = Console.ReadLine();
                switch (read)
                {
                    case "/ok":
                        isHelping = false;
                        isWaitingCommand_debug = true;
                        goto isWaiting_gt;
                        break;
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
