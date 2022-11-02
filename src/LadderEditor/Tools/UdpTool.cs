using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LadderEditor.Tools
{
    public class UdpTool
    {
        public static Dictionary<string, string> SendReceive(int LocalPort, string TargetIP, int TargetPort, string Data, int Timeout = 1000)
        {
            Dictionary<string, string> ret = null;
            var ls = new List<byte>();
            ls.Add(2);
            ls.AddRange(Encoding.UTF8.GetBytes("FB"));
            ls.Add(3);

            var ep = new IPEndPoint(IPAddress.Parse(TargetIP), TargetPort);
            var v = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            v.Bind(new IPEndPoint(IPAddress.Any, LocalPort));
            v.SendTo(ls.ToArray(), ep);

            var sendTime = DateTime.Now;
            List<byte> ls2 = new List<byte>();
            byte[] data = new byte[8192];

            while ((DateTime.Now - sendTime).TotalMilliseconds < Timeout)
            {
                try
                {
                    if (v.Available > 0)
                    {
                        EndPoint ip = new IPEndPoint(IPAddress.Any, TargetPort);
                        var len = v.ReceiveFrom(data, ref ip);
                        for (int i = 0; i < len; i++)
                        {
                            if (data[i] == 2) ls2.Clear();
                            else if (data[i] == 3)
                            {
                                var s = Encoding.UTF8.GetString(ls2.ToArray());
                                if (ret == null) ret = new Dictionary<string, string>();

                                var ipaddr = ((IPEndPoint)ip).Address.ToString();
                                if (!ret.ContainsKey(ipaddr)) ret.Add(ipaddr, s);
                                else ret[ipaddr] = s;
                            }
                            else ls2.Add(data[i]);
                        }
                    }
                }
                catch { }
                System.Threading.Thread.Sleep(10);
            }

            v.Dispose();
            v.Close();

            return ret;
        }
    }
}
