[![](https://img.shields.io/nuget/v/soenneker.healthsherpa.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.healthsherpa.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.healthsherpa.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.healthsherpa.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.healthsherpa.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.healthsherpa.httpclients/)

# Soenneker.HealthSherpa.HttpClients

A .NET thread-safe singleton HttpClient for.

## Install

```bash
dotnet add package Soenneker.HealthSherpa.HttpClients
```

## Quick start

```csharp
using Soenneker.HealthSherpa.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddHealthSherpaOpenApiHttpClientAsSingleton();
```

Adds `HealthSherpaOpenApiHttpClient` as a singleton service.

## What you get

- `IHealthSherpaOpenApiHttpClient` — A .NET thread-safe singleton HttpClient for.
- `HealthSherpaOpenApiHttpClientRegistrar` — Registers the OpenAPI HttpClient wrapper for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `HealthSherpaOpenApiHttpClientRegistrar.AddHealthSherpaOpenApiHttpClientAsSingleton(services)` | Adds `HealthSherpaOpenApiHttpClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `HealthSherpaOpenApiHttpClientRegistrar.AddHealthSherpaOpenApiHttpClientAsScoped(services)` | Adds `HealthSherpaOpenApiHttpClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
