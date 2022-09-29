using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;


[assembly: InternalsVisibleTo("ModelAppLib_UnitTests")]


namespace ModelAppLib
{
    public class SecureRandomizer : IRandomizer
    {
        public int GetRandomInt(int min, int max)
        {
            byte[] four_bytes = new byte[4];
            RandomNumberGenerator.Create().GetBytes(four_bytes);
            UInt32 scale = BitConverter.ToUInt32(four_bytes, 0);
            return (int)(min + (max - min) * (scale / (uint.MaxValue + 1.0)));
        }
    }
}
