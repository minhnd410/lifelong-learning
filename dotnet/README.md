## Roadmap
[Roadmap backend](https://roadmap.sh/backend)
[Roadmap Dotnet](https://roadmap.sh/aspnet-core)

# [C# Language Reference](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
## Modifier
- [**abstract**](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract) là lớp bị hạn chế, không thể dùng để tạo đối tượng (để truy cập được thì phải kế thừa từ lớp khác)
- [**sealed**](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/sealed) biểu thị khi khai báo một class nhằm ngăn ngừa sự dẫn xuất từ một class, điều này cũng giống như việc ngăn cấm một class nào đó có class con. Một class sealed cũng không thể là một class trừu tượng
## Access Modifier
- [**Protected**](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/protected) Truy cập bị giới hạn trong phạm vi định nghĩa của Class và bất kỳ các class con thừa kế từ class này

# Design Pattern
These 26 can be classified into 3 types
- Creational: These patterns are designed for class instantiation. They can be either class-creation patterns or object-creational patterns.
- Structural: These patterns are designed with regard to a class's structure and composition. The main goal of most of these patterns is to increase the functionality of the class(es) involved, without changing much of its composition.
- Behavioral: These patterns are designed depending on how one class communicates with others.

# Stucture Architecture
## Vertical Slice Architecture
### Docs
- [Vertical Slice Architecture in ASP.NET Core](https://code-maze.com/vertical-slice-architecture-aspnet-core/)

## Clean Architecture
### Docs
- [Clean Architecture In ASP.NET Core Web API](https://www.c-sharpcorner.com/article/clean-architecture-in-asp-net-core-web-api/)
- [Clean Architecture Project Setup From Scratch With .NET 7 - YouTube](https://www.youtube.com/watch?v=fe4iuaoxGbA)

### Project structure
├──[] Domain
├──[] Application
├──[] Infrastructure (handle other external systems, ex: email, notification, msg queue, storage services)
├──[] Persistence (handle anything related to database access)
├──[] Presentation

### With DI (Dependencies Inversion)

![image](https://github.com/minhnd410/lifelong-learning/assets/91967823/6611bf63-059c-469e-bd58-14d3fcf70255)

## Domain Driven Design:
### Docs
- [CRUD REST API With Clean Architecture & DDD In .NET 7 - YouTube](https://www.youtube.com/watch?v=nE2MjN54few) Two Entity considered equal if they have the same identifier even though the object reference might be different 

## CQRS Pattern (Command Query Responsibility Segregation)
- Logically splitting the objects responsible for writing/reading the data from 

## Unit of Work Pattern

## Mediator Design Pattern
- [Overview of Mediator Design Pattern](https://viblo.asia/p/mediator-design-pattern-tro-thu-dac-luc-cua-developers-m68Z0jVj5kG)


## Dotnet Template
### Docs
- [dotnet-new](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new) Creates a new project, configuration file, or solution based on the specified template.


### Command
```
dotnet new <template>
```

## Containerize
### Docs
- [Containerize a .NET app](https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=windows&pivots=dotnet-7-0)


### Command
```
# Test publish 
dotnet publish -c Release

# Build docker image
docker build -t counter-image -f Dockerfile .
```

## Dapper
### Example
- https://github.dev/lenardchristopher/ASP.NET-Core-with-Dapper


## Unit of Work
### Docs
- https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application

### Example
- https://github.dev/iammukeshm/Dapper.WebApi


## Unit Test
### Docs
- https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test


## Worker | Job Scheduler
### Docs
- https://learn.microsoft.com/en-us/dotnet/core/extensions/workers?pivots=dotnet-7-0
- https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services
- https://www.quartz-scheduler.net/


## EF Core
### Docs
- https://learn.microsoft.com/en-us/ef/core/get-started/overview/install
- https://learn.microsoft.com/en-us/ef/core/cli/dotnet
- https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli
- https://learn.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli


## Data Type
### Docs
https://www.c-sharpcorner.com/UploadFile/d3e4b1/practical-usage-of-namevaluecollection-in-C-Sharp-part1/
https://learn.microsoft.com/en-us/dotnet/api/system.memory-1?view=net-7.0
https://learn.microsoft.com/en-us/dotnet/api/system.span-1?view=net-7.0
https://learn.microsoft.com/en-us/dotnet/api/system.buffers.arraypool-1?view=net-7.0
https://www.infoworld.com/article/3596289/how-to-use-arraypool-and-memorypool-in-c.html
