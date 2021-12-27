``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i5-8250U CPU 1.60GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.103
  [Host]     : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT  [AttachedDebugger]
  Job-SMTBKO : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

IterationCount=2  WarmupCount=1  

```
|                             Method | IterationCount |         Mean | Error |       StdDev | Ratio | RatioSD |
|----------------------------------- |--------------- |-------------:|------:|-------------:|------:|--------:|
|                     MySQLInsertion |              1 |    642.94 ms |    NA |    364.48 ms |  1.00 |    0.00 |
|                        PGInsertion |              1 |     54.89 ms |    NA |     34.72 ms |  0.08 |    0.01 |
|              MySQLSelectPlusUpdate |              1 | 27,591.34 ms |    NA |  3,948.02 ms | 53.20 |   36.30 |
|                 PGSelectPlusUpdate |              1 |  1,065.32 ms |    NA |    129.39 ms |  2.04 |    1.36 |
| MySQLSelectPlusUpdatePlusInsertion |              1 |           NA |    NA |           NA |     ? |       ? |
|    PGSelectPlusUpdatePlusInsertion |              1 | 46,100.03 ms |    NA | 21,000.63 ms | 96.46 |   87.35 |

Benchmarks with issues:
  BenchmarkHarness.MySQLSelectPlusUpdatePlusInsertion: Job-SMTBKO(IterationCount=2, WarmupCount=1) [IterationCount=1]
