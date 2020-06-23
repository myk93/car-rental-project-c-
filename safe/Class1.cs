
using System;
using System.Globalization;
using System.Text;
using System.Collections;


namespace CryptoRC4
{
	/// <summary>
	/// Summary description for RC4Engine.
	/// </summary>
    public class RC4Engine  
	{

		public RC4Engine()
		{
           encripted= RC4(("Meni6970"), "manny");
		}
        public RC4Engine(int a)
        {
            encripted = RC4((12345678).ToString(), "ezra");
        }
        public RC4Engine(bool b)
        {
            encripted = RC4((12345678).ToString(), "pinchas");
        }
        public bool istrue(string t,string key)
        {
            return encripted == RC4(t, key);
        }


        public static string RC4(string input, string key)
        {
            StringBuilder result = new StringBuilder();
            int x, y, j = 0;
            int[] box = new int[256];

            for (int i = 0; i < 256; i++)
            {
                box[i] = i;
            }

            for (int i = 0; i < 256; i++)
            {
                j = (key[i % key.Length] + box[i] + j) % 256;
                x = box[i];
                box[i] = box[j];
                box[j] = x;
            }

            for (int i = 0; i < input.Length; i++)
            {
                y = i % 256;
                j = (box[y] + j) % 256;
                x = box[y];
                box[y] = box[j];
                box[j] = x;

                result.Append((char)(input[i] ^ box[(box[y] + box[j]) % 256]));
            }
            return result.ToString();
        }
        
        public string encripted { get; set; }
    }
}

