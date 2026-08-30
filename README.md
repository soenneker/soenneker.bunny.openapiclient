[![](https://img.shields.io/nuget/v/soenneker.bunny.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.bunny.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.bunny.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.bunny.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.bunny.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.bunny.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.bunny.openapiclient/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.bunny.openapiclient/actions/workflows/codeql.yml)

# Soenneker.Bunny.OpenApiClient

A Kiota-generated .NET client containing request builders and models for bunny.net APIs.

## Installation

```bash
dotnet add package Soenneker.Bunny.OpenApiClient
```

## Creating the client

```csharp
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Bunny.OpenApiClient;

httpClient.BaseAddress = new Uri("https://api.bunny.net");
httpClient.DefaultRequestHeaders.Add("AccessKey", accessKey);

var adapter = new HttpClientRequestAdapter(
    new AnonymousAuthenticationProvider(),
    httpClient: httpClient);

var client = new BunnyOpenApiClient(adapter);
```

For dependency-injection setup and cached client creation, use [`Soenneker.Bunny.OpenApiClientUtil`](https://www.nuget.org/packages/Soenneker.Bunny.OpenApiClientUtil).

## Usage

```csharp
using Soenneker.Bunny.OpenApiClient.Models;

List<PullZoneModel>? pullZones = await client
    .Core
    .Pullzone
    .GetAsync(cancellationToken: cancellationToken);
```

The root client groups request builders under `Core`, `Storage`, `Stream`, `CdnLogging`, `EdgeScripting`, `MagicContainers`, `OriginErrors`, and `Shield`.

## Important behavior

- Those products use different hosts and can require different access keys or authentication formats. One client has one request adapter; create a separate configured client for each host and credential set.
- The main API commonly uses a raw `AccessKey` header. Some endpoints accept authorization tokens or product-specific keys instead.
- Request and response types are in `Soenneker.Bunny.OpenApiClient.Models`.
- Generated methods expose Kiota request configuration for headers, query parameters, and middleware options where supported.
- Kiota surfaces mapped non-success responses through generated error models and `ApiException` behavior.
- The source is generated. Configure authentication, retries, and logging in the adapter or HTTP pipeline instead of editing generated files.
