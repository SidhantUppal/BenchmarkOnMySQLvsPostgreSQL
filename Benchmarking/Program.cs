using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Runtime.CompilerServices;

namespace Benchmarking
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkHarness>();
            Console.WriteLine("Start ---- BenchmarkHarness ");
        }
    }

    //[StopOnFirstError]
    //[RyuJitX86Job]
    public class IntroStopOnFirstError
    {
        private static readonly bool s_coolFeatureEnabled = GetCoolFeatureEnabled();

        private static bool GetCoolFeatureEnabled()
        {
            string envVar = Environment.GetEnvironmentVariable("EnableCoolFeature");
            return envVar == "1" || "true".Equals(envVar, StringComparison.OrdinalIgnoreCase);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void UsedWhenCoolEnabled() { }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void UsedWhenCoolNotEnabled() { }

        [Benchmark]
        public void CallCorrectMethod()
        {
            if (s_coolFeatureEnabled)
            {
                UsedWhenCoolEnabled();
            }
            else
            {
                UsedWhenCoolNotEnabled();
            }
        }

        //[Benchmark(Baseline = true)]
        //public int FirstMethod() => throw new Exception("Example exception.");

        //[Benchmark]
        //public int SecondMethod() => 1;
    }
}
