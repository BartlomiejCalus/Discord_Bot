using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Lavalink;

namespace dscBot
{
    public static class MyQueue
    {
        private static readonly Queue<LavalinkTrack> queue = new Queue<LavalinkTrack>();

        public static void addTruck(LavalinkTrack track)
        {
            queue.Enqueue(track);
        }

        public static LavalinkTrack getTruck()
        {
            if (queue.Any())
            {
                return queue.Dequeue();
            }
            return null;
           
        }

        public static string playList()
        {
            string pl = string.Empty;

            for (int i = 0; i<queue.Count; ++i)
            {
                pl += $"{queue.ToList()[i].Title}\n";
            }


            return pl;
        }

        public static int it()
        {
            return queue.Count();
        }


    }
}
