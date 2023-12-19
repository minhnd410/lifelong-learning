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
