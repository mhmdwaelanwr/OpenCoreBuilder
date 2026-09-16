# Security Policy

OpenCoreBuilder is an early experimental desktop tool. It is not currently a hardened build system and its generated output should not be trusted as boot-ready without independent review.

## Current security assumptions

- the application runs locally on a trusted Windows machine
- the repository does not currently bundle OpenCore, kext, driver, or EFI binaries
- the current build flow creates only a directory skeleton and placeholder `config.plist`
- compatibility logic is prototype-level and may be incomplete or wrong

## Future high-risk boundaries

When real downloads and build generation are implemented, changes in these areas require extra review:

- downloading executable / firmware-adjacent components
- selecting third-party release assets
- validating checksums and origin
- writing `config.plist`
- replacing or deleting existing EFI folders
- mounting or modifying removable media / EFI partitions
- handling user-supplied archives or configuration files
- applying compatibility rules that can affect bootability

## Reporting

Do not publish private machine data, serial numbers, credentials, tokens, or personal configuration details in public issues. Share only the minimum logs or hardware details needed to reproduce a problem.

## Deployment note

The project is currently intended for development and experimentation, not unattended or production use.
