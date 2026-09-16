# OpenCoreBuilder Roadmap

The current goal is to preserve a clean, understandable prototype first and return later for deeper implementation work.

## Phase 0 — Clean baseline ✅

- source-only public repository
- generated Visual Studio / build output excluded
- project status and current limitations documented
- architecture documented
- security and third-party boundaries documented
- CI / repository-health checks added

## Phase 1 — Stabilize the prototype

- add unit tests for the rule engine
- add tests for build-plan generation
- add tests for settings serialization
- add tests around hardware-profile mapping
- remove remaining placeholder / sample classes
- improve failure handling in hardware detection
- document supported Windows/.NET versions

## Phase 2 — Compatibility data

- replace hardcoded example rules with structured compatibility data
- trace each compatibility recommendation to a documented source/version
- model CPU, GPU, chipset, audio, network, storage, and firmware requirements explicitly
- distinguish warnings, unsupported combinations, and unknown hardware
- version rule data independently from the UI

## Phase 3 — Real build planning

- deterministic EFI build plan
- explicit OpenCore version selection
- explicit kext / driver versions
- dependency relationships between components
- human-readable explanation for every generated choice
- dry-run mode that produces a plan without downloading anything

## Phase 4 — Safe component acquisition

- download manager with clear upstream URLs
- checksums / integrity verification where available
- cache with version metadata
- preserve upstream license / notice files
- offline / cached-build behavior
- failure recovery for partial downloads

## Phase 5 — Config generation and validation

- structured `config.plist` generation
- schema-aware editing instead of string templates
- validation before export
- compare generated entries with selected OpenCore version
- backup / rollback of previous generated output
- final build report with warnings and unresolved items

## Phase 6 — Product polish

- refined WPF UX
- richer hardware inventory
- import/export profiles
- screenshots and demo flow
- release packaging
- automated Windows builds
- versioned release notes

## Current rule

Do not describe generated output as boot-ready until the real build, validation, component-integrity, and compatibility-data layers are implemented and tested.
