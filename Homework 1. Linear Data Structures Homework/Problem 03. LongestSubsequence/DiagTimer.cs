namespace Problem_03.LongestSubsequence
{
    using System;
    using System.Diagnostics;

    public static class DiagTimer
    {
        private static Stopwatch watch = new Stopwatch();

        public static void Start()
        {
            watch.Start();
            var elapsedTicks = watch.ElapsedTicks;
        }

        public static void StopAndShowResult()
        {
            watch.Stop();
            var elapsedTicks = watch.ElapsedTicks;
            watch.Reset();
            Console.WriteLine("Executed in (ticks): " + elapsedTicks);
        }
    }
}
