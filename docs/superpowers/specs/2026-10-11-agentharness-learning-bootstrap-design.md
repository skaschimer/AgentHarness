# AgentHarness Learning Repository Bootstrap

## Purpose

AgentHarness is a personal learning workspace for building an agent harness from first principles and then interacting with it. The initial repository should make the learning path approachable and runnable while keeping the harness internals visible.

## Initial approach

Start with a small C#/.NET console application. It provides an interactive shell with a deterministic local response so the user can run and change the interaction loop without configuring an external model or API key. Keep provider integration for a later learning stage.

The README explains the purpose, prerequisites, build and run commands, and a staged roadmap. The first roadmap stages cover the interaction loop, model connection, tool calls, state, and safety boundaries. The source remains small enough to follow directly.

## Repository baseline

- Use the current supported .NET LTS SDK, pinned with `global.json` and used consistently by local instructions and CI.
- Include a .NET-oriented `.gitignore` and `.editorconfig`.
- Include an MIT `LICENSE`, initially attributed to `skaschimer` based on the repository owner.
- Include concise `CONTRIBUTING.md`, `CODE_OF_CONDUCT.md`, and `SECURITY.md` guidance suitable for a small public learning project.
- Add GitHub Actions CI that restores and builds the solution on pushes and pull requests.
- Keep the initial project to one console application; do not introduce an agent framework, model-provider package, database, or deployment configuration.

## Success criteria

- A new contributor can understand the repository's purpose and learning sequence from the README.
- A contributor with the pinned .NET SDK can build and run the console shell using documented commands.
- The initial interaction works without network access, credentials, or external services.
- CI verifies that the application restores and builds.
- Contribution and security expectations are discoverable from the repository root.

## Scope boundaries

This bootstrap does not implement model access, agent planning, tools, persistent memory, or deployment. Those are future learning stages. It does not change GitHub repository settings or publish a release.

## Open assumption

MIT is the proposed license because this is a personal learning project intended to be open source. The initial attribution uses the repository owner's GitHub handle; the owner can replace it with another preferred name before publication.
