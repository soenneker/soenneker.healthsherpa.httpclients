[![](https://img.shields.io/nuget/v/soenneker.healthsherpa.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.healthsherpa.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.healthsherpa.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.healthsherpa.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.healthsherpa.httpclients/build-and-test.yml?style=for-the-badge&label=build)](https://github.com/soenneker/soenneker.healthsherpa.httpclients/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.healthsherpa.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.healthsherpa.httpclients/actions/workflows/codeql.yml)
[![](https://img.shields.io/nuget/dt/soenneker.healthsherpa.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.healthsherpa.httpclients/)

# Soenneker.HealthSherpa.HttpClients

Provides a cached `HttpClient` configured with HealthSherpa's API base address and API-key header.

## Installation

```bash
dotnet add package Soenneker.HealthSherpa.HttpClients
```

## Configuration

```json
{
  "HealthSherpa": {
    "ApiKey": "<API key>"
  }
}
```

The default base address is `https://api.one.healthsherpa.com`, and the default authentication header is `x-api-key: {token}`. Override them when using another HealthSherpa environment or authentication gateway:

```json
{
  "HealthSherpa": {
    "ClientBaseUrl": "https://api.one.healthsherpa.com",
    "AuthHeaderName": "x-api-key",
    "AuthHeaderValueTemplate": "{token}"
  }
}
```

`{token}` is replaced with `HealthSherpa:ApiKey` when the client is created.

## Registration and usage

```csharp
using Soenneker.HealthSherpa.HttpClients.Abstract;
using Soenneker.HealthSherpa.HttpClients.Registrars;

services.AddHealthSherpaOpenApiHttpClientAsSingleton();

IHealthSherpaOpenApiHttpClient provider =
    serviceProvider.GetRequiredService<IHealthSherpaOpenApiHttpClient>();

HttpClient client = await provider.Get(cancellationToken);
```

`Get()` lazily creates and then reuses the client for the provider's lifetime. Dispose the provider, not the returned `HttpClient`, when you own the provider.

`AddHealthSherpaOpenApiHttpClientAsScoped()` gives each dependency-injection scope an independent cache and client. Higher-level scoped API utilities should use the singleton provider registration when the transport must remain alive after an individual utility scope is disposed.
