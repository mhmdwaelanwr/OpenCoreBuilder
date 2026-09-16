# OpenCoreBuilder

Experimental Windows desktop tooling for exploring hardware detection, rule-driven compatibility checks, and future OpenCore-oriented build planning.

> **Status:** early prototype / clean baseline. The current repository is not a complete OpenCore configurator and should not be treated as producing boot-ready EFI folders yet.

## What exists today

- WPF desktop UI built on .NET 10 for Windows
- MVVM-oriented UI structure with dependency injection
- hardware detection through Windows Management Instrumentation (WMI)
- a small rule engine and validation model
- build-plan models for kexts, drivers, ACPI entries, and explanations
- settings and theme services
- dashboard, hardware, rules, build, settings, and about views

## Important limitation

The current build path is intentionally incomplete. `BuildService` creates an EFI/OC directory skeleton and a placeholder `config.plist`; it does not yet download, validate, or assemble a production-ready OpenCore configuration.

The current rule set is also minimal and heuristic. Compatibility decisions must not be treated as authoritative until the rule data and generated output are backed by proper tests and upstream documentation.

## Architecture

```text
OpenCoreBuilder.UI
    │
    ├── ViewModels / WPF Views
    └── Dependency Injection
            │
            ▼
OpenCoreBuilder.Application
    │
    ├── RuleEngine
    ├── BuildService
    └── SessionContext
            │
            ▼
OpenCoreBuilder.Core
    │
    ├── Models
    ├── Interfaces
    ├── Enums
    └── Rules
            ▲
            │
OpenCoreBuilder.Infrastructure
    ├── HardwareDetector
    └── SettingsService
```

See [`docs/ARCHITECTURE.md`](docs/ARCHITECTURE.md) for more detail.

## Repository structure

```text
src/
├── OpenCoreBuilder.Core/
├── OpenCoreBuilder.Application/
├── OpenCoreBuilder.Infrastructure/
└── OpenCoreBuilder.UI/
```

## Build

Requirements:

- Windows
- .NET 10 SDK

```powershell
dotnet restore OpenCoreBuilder.sln
dotnet build OpenCoreBuilder.sln --configuration Release
```

Run the WPF application with:

```powershell
dotnet run --project src/OpenCoreBuilder.UI/OpenCoreBuilder.UI.csproj
```

## Third-party / upstream boundary

This repository currently contains the OpenCoreBuilder application source and NuGet dependencies; it does not bundle OpenCore binaries, kext binaries, or generated EFI artifacts in the tracked source tree.

If future versions download or redistribute OpenCore, kexts, drivers, documentation-derived data, or other upstream components, their respective licenses, notices, and attribution requirements must be preserved. See [`THIRD_PARTY_NOTICES.md`](THIRD_PARTY_NOTICES.md).

OpenCoreBuilder is an independent experimental project and is not presented as an official OpenCore or Apple product.

## Roadmap

See [`ROADMAP.md`](ROADMAP.md). The next development pass should focus on tests, trustworthy compatibility data, and a safe build pipeline before adding more UI surface.

## Security

See [`SECURITY.md`](SECURITY.md). Generated EFI/configuration output should be treated as untrusted until validated.

## License

Original OpenCoreBuilder project-specific source and documentation are copyright © 2026 Mohamed Anwar. All rights reserved. Third-party components remain subject to their own licenses and terms.
