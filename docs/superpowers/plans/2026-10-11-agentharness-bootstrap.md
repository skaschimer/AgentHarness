# AgentHarness Bootstrap Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Create a small, runnable C# learning shell and the open-source repository guidance needed to build AgentHarness in public.

**Architecture:** One .NET 10 console app provides a local echo loop. The root README explains how to run it and the planned learning stages. GitHub Actions restores and builds the solution without requiring external services or credentials.

**Tech Stack:** C#, .NET 10 LTS, GitHub Actions.

**Spec:** `docs/superpowers/specs/2026-10-11-agentharness-learning-bootstrap-design.md`

## Global Constraints

- Target `net10.0` and pin the installed .NET 10 SDK in `global.json`.
- Keep the first shell deterministic, local, and independent of model-provider packages and credentials.
- Keep the first scaffold to one console application.
- Use MIT licensing with the initial attribution `skaschimer`.
- CI restores and builds the solution; this bootstrap does not add a test project.
- Work hands-on: the user runs commands and edits files, and the assistant explains and reviews each task before moving on.

## Review Focus

- `exit` and end-of-input must end the loop cleanly; manually verify during Task 1's run check.
- Empty input must not crash or terminate the loop; manually verify during Task 1's run check.
- README commands and CI must target the same solution and .NET version; compare them during Tasks 2 and 3, then run the local build in Task 3.

---

### Task 1: Create the interactive console shell

**Files:**
- Create: `global.json`
- Create: `.gitignore`
- Create: `.editorconfig`
- Create: `AgentHarness.sln`
- Create: `src/AgentHarnessConsole/AgentHarness.csproj`
- Create: `src/AgentHarnessConsole/Program.cs`

**Interfaces:**
- Consumes: .NET 10 SDK and standard input/output.
- Produces: a `net10.0` console application in `src/AgentHarnessConsole` that reads lines until `exit` and prints a deterministic local response for each other line.

- [x] **Step 1: Check the installed SDK**

Run `rtk dotnet --list-sdks`. Select an installed `10.0.xxx` SDK and record its full version for `global.json`. If .NET 10 is not installed, pause here and install the .NET 10 SDK before continuing.

- [x] **Step 2: Create the solution and console project**

Run:

```powershell
rtk dotnet new sln --name AgentHarness --format sln
rtk dotnet new console --name AgentHarness --output src/AgentHarnessConsole --framework net10.0
rtk dotnet sln AgentHarness.sln add src/AgentHarnessConsole/AgentHarness.csproj
```

- [x] **Step 3: Pin SDK and add C# repository defaults**

Create `global.json` with the full SDK version recorded in Step 1 and `"rollForward": "latestPatch"`. Add a standard .NET `.gitignore` and `.editorconfig` with four-space C# indentation and UTF-8 files.

- [x] **Step 4: Implement the first local interaction loop**

In `src/AgentHarnessConsole/Program.cs`, read one line at a time, stop on end-of-input or when the input equals `exit` ignoring case, and print `You said: <input>` for other inputs. Ignore empty or whitespace-only input and continue reading.

- [x] **Step 5: Build and run it by hand**

Run `rtk dotnet build AgentHarness.sln`. For the interactive run, use `dotnet run --project src/AgentHarnessConsole` without RTK so terminal input reaches the program. Enter `hello`, an empty line, and `exit`; confirm the app prints `You said: hello`, keeps running after the empty line, and exits after `exit`. In a second run, send end-of-input and confirm the app exits.

- [x] **Step 6: Review and commit this slice**

Review the project and commands together, then the user can commit with:

```powershell
rtk git add global.json .gitignore .editorconfig AgentHarness.sln src/AgentHarnessConsole
rtk git commit -m "feat: scaffold interactive learning shell"
```

### Task 2: Add open-source project guidance

**Files:**
- Modify: `README.md`
- Create: `LICENSE`
- Create: `CONTRIBUTING.md`
- Create: `CODE_OF_CONDUCT.md`
- Create: `SECURITY.md`

**Interfaces:**
- Consumes: the application and run command from Task 1.
- Produces: root-level project, contribution, conduct, licensing, and security guidance.

- [x] **Step 1: Rewrite the README for a new learner**

Document the project's personal learning purpose, .NET 10 prerequisite, the commands `dotnet build AgentHarness.sln` and `dotnet run --project src/AgentHarnessConsole`, the local echo behavior, and the roadmap: interaction loop, model connection, tool calls, state, and safety boundaries. Explain that the current shell makes no external model calls.

- [x] **Step 2: Add the MIT license and contributor guidance**

Add the standard MIT license text with `Copyright (c) 2026 skaschimer`. In `CONTRIBUTING.md`, explain how to build the solution, check formatting with `dotnet format AgentHarness.sln --verify-no-changes`, and submit a focused pull request.

- [x] **Step 3: Add conduct and security guidance**

Use Contributor Covenant 2.1 in `CODE_OF_CONDUCT.md` and identify the maintainer as `@skaschimer`. In `SECURITY.md`, ask reporters not to publish exploitable details in public issues and direct them to GitHub private vulnerability reporting when enabled; otherwise ask them to contact the maintainer privately through GitHub.

- [x] **Step 4: Review and commit the documentation**

Check that the README commands match Task 1 and that all policy files are discoverable from the README. The user can commit with:

```powershell
rtk git add README.md LICENSE CONTRIBUTING.md CODE_OF_CONDUCT.md SECURITY.md
rtk git commit -m "docs: add open-source project guidance"
```

### Task 3: Add build CI

**Files:**
- Create: `.github/workflows/ci.yml`

**Interfaces:**
- Consumes: `global.json` and `AgentHarness.sln` from Task 1.
- Produces: a GitHub Actions workflow that restores and builds the solution on pushes and pull requests.

- [x] **Step 1: Create the workflow**

Trigger on `push` and `pull_request`. Use `ubuntu-latest`, set `permissions: contents: read`, check out with `actions/checkout@v7`, and configure .NET with `actions/setup-dotnet@v6` using `global-json-file: global.json`. Run `dotnet restore AgentHarness.sln` followed by `dotnet build AgentHarness.sln --configuration Release --no-restore`.

- [x] **Step 2: Verify locally and review the workflow**

Run `rtk dotnet build AgentHarness.sln --configuration Release`. Confirm the workflow uses the same pinned SDK and solution as the README. CI will provide the remote run evidence after the user pushes the branch.

- [x] **Step 3: Commit the workflow**

The user can commit with:

```powershell
rtk git add .github/workflows/ci.yml
rtk git commit -m "ci: build solution with GitHub Actions"
```

## References

- .NET 10 is an LTS release supported through November 2028: [Microsoft .NET releases and support](https://learn.microsoft.com/en-us/dotnet/core/releases-and-support).
- GitHub's maintained action examples use `actions/checkout@v7` and `actions/setup-dotnet@v6`: [actions/setup-dotnet](https://github.com/actions/setup-dotnet).
