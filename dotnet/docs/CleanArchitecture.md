## Backend

Applying Clean Architecture
    
### Core

#### Domain
    
1. Folder Structure

```
- Abstractions
    - IUnitOfWork
    - I[Domain]Repository
- Entities
    - ...
- Exceptions
    - Base
        - BadRequestException
        - NotFoundException
    - [Domain]Exception (ex: UserNotFoundException)
- Primitives
    - [Entity] ...
```

#### Application

1. Folder Structure

```
- Abstractions
    - Messaging: **MediatR** Command Query abstractions
- Behavior
    - Validate: **FluentValidation** 
- Exception
    - ValidationException
- [Domain] (ex: User, ..)
    - Commands
        - [WriteAction] (ex: CreateUser)
            - [Action]Command
            - [Action]Handler
            - [Action]Validator
            - [Action]Request
        ...
    - Queries
        - [ReadAction] (ex: GetUserById)
            -[ReadAction]Query
            -[ReadAction]Handler
            -[ReadAction]Response
        ...
```

2. Lib Usage:

- MediatR: CQRS
- FluentValidation: Validate


### External

### Infrastructure

1. Folder Structure

```
- Configurations
    - [Domain]Configuration
    - ...
- Repositories
    - [Domain]Repository
    - ...
- ApplicationDbContext
```

2. Lib Usage:

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Ralational ( .ToTable() )


### Presentation

1. Folder Structure

```
- Controllers
    - ApiController
    - [Domain]Controller
```

2. Lib Usage:

- Change sdk to: Microsoft.NET.Sdk.Web
- MediatR
- Mapster


## Web

3. Lib Usage:

- FluentValidation.DependencyInjectionExtensions ( .AddValidatorsFromAssembly() )
- MediatR.Extensions.Microsoft.DependencyInjection ( .AddMediatR(applicationAssembly) )
- Microsoft.EntityFrameworkCore.Design