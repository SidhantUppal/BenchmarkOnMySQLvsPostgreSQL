
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i5-8250U CPU 1.60GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.103
  [Host]     : .NET Core 3.1.12 (CoreCLR 4.700.21.6504, CoreFX 4.700.21.6905), X64 RyuJIT
  Job-SPWWSK : .NET Core 3.1.12 (CoreCLR 4.700.21.6504, CoreFX 4.700.21.6905), X64 RyuJIT

IterationCount=2  WarmupCount=1  

               Method | IterationCount |         Mean | Error |    StdDev | Ratio |
--------------------- |--------------- |-------------:|------:|----------:|------:|
      GetAllMySQLData |              1 | 10,072.78 ms |    NA | 12.140 ms | 1.000 |
 GetAllPostgreSQLData |              1 |     18.69 ms |    NA |  7.969 ms | 0.002 |
