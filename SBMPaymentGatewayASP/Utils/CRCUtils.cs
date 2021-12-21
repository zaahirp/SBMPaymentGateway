using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SBMPaymentGatewayASP.Utils
{
    public class CRCUtils
    {
        public static string Crc16Ccitt(string str)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            ushort poly = 0x1021;
            ushort[] table = new ushort[256];
            ushort initialValue = 0xFFFF;
            ushort temp, a;
            ushort crc = initialValue;
            for (int i = 0; i < table.Length; ++i)
            {
                temp = 0;
                a = (ushort)(i << 8);
                for (int j = 0; j < 8; ++j)
                {
                    if (((temp ^ a) & 0x8000) != 0)
                        temp = (ushort)((temp << 1) ^ poly);
                    else
                        temp <<= 1;
                    a <<= 1;
                }
                table[i] = temp;
            }
            for (int i = 0; i < bytes.Length; ++i)
            {
                crc = (ushort)((crc << 8) ^ table[((crc >> 8) ^ (0xff & bytes[i]))]);
            }
            return crc.ToString("X4");
        }
    }
}