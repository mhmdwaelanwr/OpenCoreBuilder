# Architecture

OpenCoreBuilder is currently a four-project .NET solution with a desktop UI separated from application, domain, and infrastructure concerns.

## Projects

### `OpenCoreBuilder.Core`

Contains the shared domain model:

- hardware profile models
- build-plan models
- validation results and severities
- application-facing interfaces
- compatibility rules

The current rule catalog is intentionally small and should be treated as prototype logic.

### `OpenCoreBuilder.Application`

Coordinates domain behavior:

- `RuleEngine` applies registered rules and creates a basic build plan
- `BuildService` owns the current build flow
- `SessionContext` carries current session state

The current `BuildService` only creates an EFI/OC directory skeleton and placeholder `config.plist`. It does not yet perform a real OpenCore build.

### `OpenCoreBuilder.Infrastructure`

Provides platform-facing implementations:

- `HardwareDetector` uses WMI / `System.Management` on Windows
- `SettingsService` handles local application settings

Hardware detection currently captures a limited set of CPU, GPU, motherboard, and memory information and uses simple heuristics.

### `OpenCoreBuilder.UI`

WPF desktop application targeting `net10.0-windows`.

The UI uses dependency injection and MVVM-oriented view models for dashboard, hardware, rules, build, settings, and about flows.

## Dependency direction

```text
UI ──────► Application ──────► Core
 │                ▲
 └──────► Infrastructure ─────┘
```

`Core` should remain independent of WPF, WMI, filesystem UI behavior, and concrete download implementations.

## Future build boundary

A trustworthy real build pipeline should separate these stages:

1. hardware inventory
2. compatibility/rule evaluation
3. deterministic build plan
4. upstream component resolution
5. download + checksum/signature validation where available
6. config generation
7. schema / sanity validation
8. EFI assembly
9. human-readable report and warnings

External binaries and upstream data should not be silently embedded into the repository. Their origin, version, checksum, and license should remain traceable.
