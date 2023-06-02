using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YallaKora.API.Settings
{
    public static class EncryptionInfo
    {
        private const string key = "D4Gfdm4)9cfklkj(*0@1sq'c";
        private const string iv = "h&3jk!6lPzvb@8$*";

        public static byte[] Key { get => Encoding.UTF8.GetBytes(key); }
        public static byte[] IV { get => Encoding.UTF8.GetBytes(iv); }
    }
}
