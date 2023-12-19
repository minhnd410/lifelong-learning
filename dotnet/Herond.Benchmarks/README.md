```sh
sudo dotnet run -c Release
```


## ProtobufLib
BenchmarkDotNet v0.13.11, macOS Ventura 13.5 (22G74) [Darwin 22.6.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
[Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
DefaultJob : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD

| Method                               | Mean      | Error     | StdDev    | Gen0      | Allocated  |
|------------------------------------- |----------:|----------:|----------:|----------:|-----------:|
| ProtobufNet_DeserializeFromBase64Url | 18.114 ms | 0.3613 ms | 0.5297 ms | 3843.7500 | 24240093 B |
| ProtobufGG_DeserializeFromBase64Url  | 10.989 ms | 0.1657 ms | 0.1469 ms | 4359.3750 | 27440948 B |
| ProtobufNet_Serialize                | 13.702 ms | 0.0848 ms | 0.0708 ms |         - |       38 B |
| ProtobufGG_Serialize                 |  2.797 ms | 0.0460 ms | 0.0384 ms |         - |        9 B |



## StringFormatVsInterpolation

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, macOS Ventura 13.5 (22G74) [Darwin 22.6.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 7.0.307
[Host]     : .NET 7.0.10 (7.0.1023.36312), Arm64 RyuJIT AdvSIMD
DefaultJob : .NET 7.0.10 (7.0.1023.36312), Arm64 RyuJIT AdvSIMD


| Method              | Mean     | Error   | StdDev   | Gen0   | Allocated |
|-------------------- |---------:|--------:|---------:|-------:|----------:|
| Format              | 166.1 ns | 4.88 ns | 13.77 ns | 0.0355 |     224 B |
| Interpolate         | 142.2 ns | 2.49 ns |  3.64 ns | 0.0176 |     112 B |
| InterpolateExplicit | 124.3 ns | 4.09 ns | 11.55 ns | 0.0279 |     176 B |



## IfVsSwitch

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, macOS Ventura 13.5 (22G74) [Darwin 22.6.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 7.0.307
[Host]     : .NET 7.0.10 (7.0.1023.36312), Arm64 RyuJIT AdvSIMD
DefaultJob : .NET 7.0.10 (7.0.1023.36312), Arm64 RyuJIT AdvSIMD


| Method           | value                | Mean        | Error      | StdDev     | Median      | Gen0   | Allocated |
|----------------- |--------------------- |------------:|-----------:|-----------:|------------:|-------:|----------:|
| IfElseStatement  | ?                    |   0.6425 ns |  0.1060 ns |  0.2956 ns |   0.5482 ns |      - |         - |
| SwitchStatement  | ?                    |   0.7380 ns |  0.1737 ns |  0.4814 ns |   0.5939 ns |      - |         - |
| SwitchExpression | ?                    |   0.9757 ns |  0.2053 ns |  0.5858 ns |   0.7438 ns |      - |         - |
| IfElseStatement  | 10.234               | 124.9324 ns |  6.5573 ns | 19.0239 ns | 122.4752 ns | 0.0063 |      40 B |
| SwitchStatement  | 10.234               |  86.0164 ns |  2.6759 ns |  7.5911 ns |  84.0693 ns | 0.0063 |      40 B |
| SwitchExpression | 10.234               |  83.2926 ns |  1.8851 ns |  5.4088 ns |  82.1181 ns | 0.0063 |      40 B |
| IfElseStatement  | 10/26/2023 23:24:19  | 113.5190 ns |  1.8254 ns |  1.8745 ns | 113.2696 ns | 0.0280 |     176 B |
| SwitchStatement  | 10/26/2023 23:24:19  | 124.8312 ns |  4.2615 ns | 12.2271 ns | 120.2166 ns | 0.0280 |     176 B |
| SwitchExpression | 10/26/2023 23:24:19  | 126.6523 ns |  5.0949 ns | 14.2866 ns | 124.9505 ns | 0.0279 |     176 B |
| IfElseStatement  | 10000                |  15.4703 ns |  0.3188 ns |  0.5829 ns |  15.3700 ns | 0.0051 |      32 B |
| SwitchStatement  | 10000                |  14.5874 ns |  0.2053 ns |  0.1714 ns |  14.6323 ns | 0.0051 |      32 B |
| SwitchExpression | 10000                |  15.1868 ns |  0.3065 ns |  0.3530 ns |  15.0838 ns | 0.0051 |      32 B |
| IfElseStatement  | Heron(...)quest [37] | 467.5329 ns |  6.8485 ns |  7.3278 ns | 465.2465 ns | 0.1411 |     888 B |
| SwitchStatement  | Heron(...)quest [37] | 548.3489 ns | 10.2536 ns |  9.0895 ns | 545.2556 ns | 0.1411 |     888 B |
| SwitchExpression | Heron(...)quest [37] | 472.4548 ns |  7.6616 ns |  7.5247 ns | 472.3099 ns | 0.1411 |     888 B |
| IfElseStatement  | temp                 |  27.9854 ns |  0.4591 ns |  0.3834 ns |  27.7997 ns | 0.0063 |      40 B |
| SwitchStatement  | temp                 |  28.0019 ns |  0.4263 ns |  0.3779 ns |  27.9530 ns | 0.0063 |      40 B |
| SwitchExpression | temp                 |  28.2766 ns |  0.6116 ns |  0.6280 ns |  28.0061 ns | 0.0063 |      40 B |


## ToListVsNewList

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, macOS Ventura 13.5 (22G74) [Darwin 22.6.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 7.0.307
[Host]     : .NET 7.0.10 (7.0.1023.36312), Arm64 RyuJIT AdvSIMD
DefaultJob : .NET 7.0.10 (7.0.1023.36312), Arm64 RyuJIT AdvSIMD


| Method  | Mean     | Error     | StdDev    | Gen0   | Allocated |
|-------- |---------:|----------:|----------:|-------:|----------:|
| ToList  | 5.603 ns | 0.1435 ns | 0.2234 ns | 0.0051 |      32 B |
| NewList | 4.973 ns | 0.1480 ns | 0.2513 ns | 0.0051 |      32 B |


## ListVsArray

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, macOS Ventura 13.5 (22G74) [Darwin 22.6.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 7.0.307
[Host]     : .NET 7.0.10 (7.0.1023.36312), Arm64 RyuJIT AdvSIMD
DefaultJob : .NET 7.0.10 (7.0.1023.36312), Arm64 RyuJIT AdvSIMD


| Method   | Mean      | Error     | StdDev   | Median    | Gen0   | Allocated |
|--------- |----------:|----------:|---------:|----------:|-------:|----------:|
| MemList  | 55.887 ns | 1.1594 ns | 1.969 ns | 55.607 ns | 0.0343 |     216 B |
| MemArray |  9.763 ns | 0.4038 ns | 1.152 ns |  9.334 ns | 0.0102 |      64 B |


## SpanBenchmarks

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, macOS Ventura 13.5 (22G74) [Darwin 22.6.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 7.0.307
[Host]     : .NET 7.0.10 (7.0.1023.36312), Arm64 RyuJIT AdvSIMD
DefaultJob : .NET 7.0.10 (7.0.1023.36312), Arm64 RyuJIT AdvSIMD


| Method                 | Mean     | Error    | StdDev   | Allocated |
|----------------------- |---------:|---------:|---------:|----------:|
| PassSpanByValue        | 33.20 us | 0.532 us | 0.445 us |         - |
| PassSpanByRef          | 33.06 us | 0.401 us | 0.335 us |         - |
| PassLargeStructByValue | 33.58 us | 0.653 us | 0.611 us |         - |
| PassLargeStructByRef   | 33.14 us | 0.271 us | 0.226 us |         - |
| PassListByValue        | 33.16 us | 0.611 us | 0.510 us |         - |
| PassListByRef          | 33.00 us | 0.297 us | 0.232 us |         - |


## SpanListJoin

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, macOS Ventura 13.5 (22G74) [Darwin 22.6.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 7.0.307
[Host]     : .NET 7.0.10 (7.0.1023.36312), Arm64 RyuJIT AdvSIMD
DefaultJob : .NET 7.0.10 (7.0.1023.36312), Arm64 RyuJIT AdvSIMD


| Method      | Mean     | Error    | StdDev   | Gen0        | Gen1      | Allocated |
|------------ |---------:|---------:|---------:|------------:|----------:|----------:|
| ListJoin    | 492.7 ms |  7.57 ms |  9.84 ms | 246000.0000 | 3000.0000 |   1.44 GB |
| SpanJoin    | 477.2 ms |  9.42 ms | 13.20 ms | 224000.0000 | 2000.0000 |   1.31 GB |
| ListJoinRef | 518.1 ms | 10.22 ms | 20.42 ms | 246000.0000 | 3000.0000 |   1.44 GB |
| SpanJoinRef | 476.6 ms |  9.43 ms | 10.09 ms | 224000.0000 | 2000.0000 |   1.31 GB |


## RefBenchmarks

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, macOS Ventura 13.5 (22G74) [Darwin 22.6.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 7.0.307
[Host]     : .NET 7.0.10 (7.0.1023.36312), Arm64 RyuJIT AdvSIMD
DefaultJob : .NET 7.0.10 (7.0.1023.36312), Arm64 RyuJIT AdvSIMD


| Method      | Mean      | Error     | StdDev    | Median    | Gen0   | Gen1   | Allocated |
|------------ |----------:|----------:|----------:|----------:|-------:|-------:|----------:|
| PassAsRef   |  1.925 us | 0.0270 us | 0.0225 us |  1.925 us | 0.4578 |      - |   2.81 KB |
| PassAsValue |  2.085 us | 0.0535 us | 0.1518 us |  2.036 us | 0.4578 |      - |   2.81 KB |
| Return      | 77.812 us | 1.4950 us | 2.0958 us | 77.347 us | 3.6621 | 0.3662 |  22.91 KB |
