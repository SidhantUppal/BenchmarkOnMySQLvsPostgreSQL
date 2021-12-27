``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i5-8250U CPU 1.60GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.103
  [Host]     : .NET Core 3.1.12 (CoreCLR 4.700.21.6504, CoreFX 4.700.21.6905), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 3.1.12 (CoreCLR 4.700.21.6504, CoreFX 4.700.21.6905), X64 RyuJIT


```
|    Method |   A |  B |     Mean |   Error |  StdDev | Allocated |
|---------- |---- |--- |---------:|--------:|--------:|----------:|
| **Benchmark** | **100** | **10** | **124.0 ms** | **0.73 ms** | **0.68 ms** |     **248 B** |
| **Benchmark** | **100** | **20** | **134.8 ms** | **2.60 ms** | **2.90 ms** |   **3,574 B** |
| **Benchmark** | **200** | **10** | **220.2 ms** | **2.07 ms** | **1.94 ms** |         **-** |
| **Benchmark** | **200** | **20** | **233.3 ms** | **1.66 ms** | **1.55 ms** |         **-** |
