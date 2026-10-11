# Contributing

Thanks for your interest in contributing to this repository.

## How to contribute

- Fork the repository and create your branch from `main`.
- Keep changes focused and scoped to the issue or feature you are working on.
- Add or update tests when a test project is available.
- Run the relevant validation commands before opening a pull request.

## Development workflow

1. Clone the repository.
2. Install the .NET 10 SDK.
3. Make your changes.
4. Run the project's checks.
    - dotnet build AgentHarness.sln
    - dotnet run --project src/AgentHarnessConsole
        - - Manual check: confirm it echoes non-empty input, then type `exit`.
5. Submit a pull request with a clear description of the change.

## Code of conduct

Be respectful and constructive in all interactions. We expect contributors to maintain a welcoming and professional environment.

## Pull request guidelines

- Include a concise summary of the change.
- Explain why the change is needed.
- Link any related issues or discussions.
- Ensure the branch is up to date with the base branch before submission.

Thank you for helping improve the project.
