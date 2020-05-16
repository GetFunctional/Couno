using System;
using System.Threading;

namespace GF.Couno.CardGameProtoWpf
{
    public static class RandomExtensions
    {
        [field: ThreadStatic]
        public static Random ThisThreadsRandom { get; } =
            new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId));
    }
}