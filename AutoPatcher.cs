using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Coffeed
{
    internal static class AutoPatcher
    {
        static WebClient client = new WebClient();
        
        internal static void Patch()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            client.Headers.Add("User-Agent: Other");
            client.Encoding = Encoding.UTF8;

            client.DownloadString()
        }
    }
}
