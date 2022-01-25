# CQRS

Simple project that uses mediator pattern with MediatR library 

## Installation

Use the Nuget package manager to install [MediatR](https://www.nuget.org/packages/MediatR/).

```bash
dotnet add package MediatR --version 10.0.1
dotnet add package MediatR.Extensions.Microsoft.DependencyInjection --version 10.0.1
```

## Usage

```python
# query handler
public class Handler : IRequestHandler<Query, Response>

# command handler
public class Handler : IRequestHandler<Command, int>

```

## Contributing
Not open to contributions at the moment