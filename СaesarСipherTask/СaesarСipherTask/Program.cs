using System;

namespace СaesarСipherTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var manager = new CaesarCipherManager();
            manager.DemonstrateWork();
            Console.ReadLine();
        }
    }
}
