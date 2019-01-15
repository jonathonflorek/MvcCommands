# MvcCommands

A library enabling command-based architecture and eliminating the need for manual controller creation.

## Overview

This library introduces the concepts of Routed Command and Command Handlers. A Routed Command is a DTO that defines the data to be sent from a client for a number of routes. A Command Handler is a service that processes an instance of this DTO and returns a result.

## Configuration

To enable Routed Commands, invoke `AddCommandControllerRouting` after calling `AddMvc` in the `Startup` class's `ConfigureServices` method:

```csharp
services.AddMvc().AddCommandControllerRouting();
```

## Routed Commands

To create a routed command, create a data class decorated with the `RoutedCommandAttribute` attribute and specify the route template and accepted HTTP verbs. Optionally, specify the route's name for link generation elsewhere.

Decorate the class's properties with the `FromRoute`, `FromQuery`, `FromBody`, etc. attributes to tell ASP.NET where to bind the properties from.

```csharp
[RoutedCommand("foo/{id}", "GET", "POST", Name = "MyCommand")]
public class MyCommand
{
    [FromRoute]
    public String Id { get; set; }

    [FromQuery]
    public String Name { get; set; }

    [FromBody]
    public MyCommandBody Body { get; set; }

    // other properties
}
```

## Command Handlers

Each routed command requires an `ICommandHandler<TCommandModel>` implementation registered in the application's DI configuration.

```csharp
public class MyCommandHandler : ICommandHandler<MyCommand>
{
    public MyCommandHandler(IDependency dependency)
    {
        Dependency = dependency;
    }

    public IDependency Dependency { get; }

    public async Task<IActionResult> ExecuteCommand(MyCommand commandModel, ControllerBase sender)
    {
        await Dependency.Delay(1000);
        return sender.NoContent();
    }
}
```

Command handlers are also provided the `ControllerBase` that initially handled the request to allow access to its `ModelState`, `HttpContext`, and other properties.

## Advanced

This library uses generic types of the `CommandController<TCommandModel>` class as controllers for each of the discovered Routed Commands. When applying a custom controller model convention, all controllers registered by this library are generic types of this generic type definition. The routed command model type is the single generic type argument of all registered controllers.
