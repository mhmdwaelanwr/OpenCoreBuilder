# Contributing

OpenCoreBuilder is currently a prototype baseline. Keep changes focused and avoid expanding feature claims beyond what the code actually implements.

## Before opening a pull request

On Windows with the .NET 10 SDK installed:

```powershell
dotnet restore OpenCoreBuilder.sln
dotnet build OpenCoreBuilder.sln --configuration Release
```

## Repository hygiene

Do not commit:

- `.vs`, `bin`, `obj`, IDE metadata, or generated build output
- packaged binaries or release archives unless intentionally added through a release process
- credentials, tokens, signing material, or private machine data
- generated EFI folders or personal `config.plist` files

## Upstream components

If a change adds external OpenCore-related components, kexts, drivers, documentation-derived datasets, or binaries, document their origin, version, license, and redistribution terms. Prefer resolving external components during a controlled build step rather than committing binary copies to this repository.

## Compatibility rules

Compatibility changes should include a reproducible explanation and tests. Avoid presenting heuristic or unverified rules as authoritative hardware support guidance.
