using System;

namespace HammaCipherTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var manager = new HammaCipherManager();
                manager.DemonstrateWork();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
