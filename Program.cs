using nanoFramework.M5Stack;
using nanoFramework.Presentation.Media;
using System;
using System.Diagnostics;
using System.Threading;
using System.Security.Cryptography;
using System.Text;

namespace NanoFrameworkCore2
{
    public class Program
    {
        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework!");

            M5Core2.InitializeScreen();

            ushort[] toSend = new ushort[100];
            ushort blue = ColorUtility.To16Bpp(Color.Blue);

            for (int i = 0; i < toSend.Length; i++)
            {
                toSend[i] = blue;
            }

            Screen.Write(0, 0, 10, 10, toSend);

            var sharedAccessKey = "3132333435363738393031323334353637383930313233343536373839303132";
            var data = "0000000027BC86AA";

            string hexIpAddress = "0A010248"; // 10.1.2.72 => "0A010248"
            byte[] bytes = new byte[hexIpAddress.Length / 2];

            for (int i = 0; i < hexIpAddress.Length; i += 2)
                bytes[i / 2] = Convert.ToByte(hexIpAddress.Substring(i, 2), 16);

            var hmacsha256 = new HMACSHA256(Convert.FromBase64String(sharedAccessKey));

            byte[] hmac = hmacsha256.ComputeHash(Convert.FromBase64String(data));
            string sig = Convert.ToBase64String(hmac);

            System.Console.WriteLine(sig);

            Thread.Sleep(Timeout.Infinite);

            // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T
        }
    }
}
