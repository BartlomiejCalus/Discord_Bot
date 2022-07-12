using System;

namespace dscBot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var bot = new Bot();
                bot.RunA().GetAwaiter().GetResult();
            }catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}