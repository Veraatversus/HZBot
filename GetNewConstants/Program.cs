using Hina.IO.Zlib;
using Newtonsoft.Json;
using RtmpSharp;
using RtmpSharp.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNewConstants
{
    class Program
    {
        static void Main(string[] args)
        {
            var ConstansUrl = "http://hz-static-2.akamaized.net/assets/data/constants.data?cfeb208c39166420a536c2dcc146a277146";
            var zlibstream = new System.Net.Http.HttpClient().GetStreamAsync(ConstansUrl).GetAwaiter().GetResult();
            AmfReader amfreader;
            using (var amfstream = new ZlibStream(zlibstream, System.IO.Compression.CompressionMode.Decompress))
            {
                amfreader = new AmfReader(ReadFully(amfstream), new SerializationContext());
            }
            var output = JsonConvert.SerializeObject(amfreader.ReadAmf3Object());
            File.WriteAllText("constantsReadable.json", output);
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
