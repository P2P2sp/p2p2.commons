namespace TH.Commons
{
    /// <summary>
    /// Provides converting methods.
    /// </summary>
    public static class ConvertHelpers
    {
        /// <summary>
        /// Converts byte array to hexadecimal notation.
        /// </summary>
        /// <param name="bytes">Input array of bytes</param>
        /// <returns>Hexadecimal notation</returns>
        public static string ToHex(byte[] bytes)
        {
            var c = new char[bytes.Length * 2];

            byte b;
            for (int bx = 0, cx = 0; bx < bytes.Length; ++bx, ++cx)
            {
                b = ((byte)(bytes[bx] >> 4));
                c[cx] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);

                b = ((byte)(bytes[bx] & 0x0F));
                c[++cx] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);
            }
            return new string(c);
        }

        /// <summary>
        /// Converts hexadecimal notation to array of bytes.
        /// </summary>
        /// <param name="hex">Input hexadecimal notation</param>
        /// <returns>Array of bytes</returns>
        public static byte[] FromHex(string hex)
        {
            if (hex.Length == 0 || hex.Length % 2 != 0) return new byte[0];

            var buffer = new byte[hex.Length / 2];
            char c;
            for (int bx = 0, sx = 0; bx < buffer.Length; ++bx, ++sx)
            {
                // Convert first half of byte
                c = hex[sx];
                buffer[bx] = (byte)((c > '9' ? (c > 'Z' ? (c - 'a' + 10) : (c - 'A' + 10)) : (c - '0')) << 4);

                // Convert second half of byte
                c = hex[++sx];
                buffer[bx] |= (byte)(c > '9' ? (c > 'Z' ? (c - 'a' + 10) : (c - 'A' + 10)) : (c - '0'));
            }
            return buffer;
        }
    }
}