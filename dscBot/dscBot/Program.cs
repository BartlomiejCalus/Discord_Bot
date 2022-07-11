using System;

namespace dscBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Bot();
            bot.RunA().GetAwaiter().GetResult();
            
        }
    }
}