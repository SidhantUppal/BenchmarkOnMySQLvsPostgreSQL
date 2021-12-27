``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i5-8250U CPU 1.60GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.103
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT  [AttachedDebugger]

IterationCount=2  WarmupCount=1  

```
|         Method | IterationCount | Mean | Error | Ratio | RatioSD |
|--------------- |--------------- |-----:|------:|------:|--------:|
| MySQLInsertion |              1 |   NA |    NA |     ? |       ? |

Benchmarks with issues:
  BenchmarkHarness.MySQLInsertion: Job-SBNXTD(IterationCount=2, WarmupCount=1) [IterationCount=1]
