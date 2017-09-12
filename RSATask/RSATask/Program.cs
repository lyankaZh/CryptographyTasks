using System;

namespace RSATask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var manager = new RSAManager();
            manager.DemonstrateWork();
            Console.ReadLine();
        }
    }
}
