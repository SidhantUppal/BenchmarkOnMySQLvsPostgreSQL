``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i5-8250U CPU 1.60GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.103
  [Host] : .NET Core 3.1.12 (CoreCLR 4.700.21.6504, CoreFX 4.700.21.6905), X64 RyuJIT  [AttachedDebugger]


```
|         Method | Mean | Error | Ratio | RatioSD |
|--------------- |-----:|------:|------:|--------:|
| MySQLInsertion |   NA |    NA |     ? |       ? |

Benchmarks with issues:
  WeatherForecastController.MySQLInsertion: DefaultJob
