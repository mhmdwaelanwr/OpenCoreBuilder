# Third-Party Notices

OpenCoreBuilder uses third-party packages and references concepts/components from the broader OpenCore ecosystem.

## NuGet dependencies currently referenced

The tracked project files reference packages including:

- `CommunityToolkit.Mvvm`
- `Microsoft.Extensions.DependencyInjection`
- `System.Management`

These packages remain subject to their own licenses and terms.

## OpenCore ecosystem components

The current repository does **not** track OpenCore binaries, kext binaries, driver binaries, or generated EFI output.

The prototype rule/build-plan code mentions component names such as `Lilu.kext`, `VirtualSMC.kext`, `AppleALC.kext`, and `RealtekRTL8111.kext`. Those names identify external projects/components; mentioning them in a build plan does not transfer ownership or licensing to this repository.

If future versions download, bundle, modify, or redistribute external components, preserve their upstream copyright, license, notice, and redistribution requirements and record the exact source/version used.

This file should be expanded whenever new third-party source, binary assets, datasets, or redistributed components are introduced.
