# Security Policy

This repository, AgentHarness, is currently a small local echo application that reads user input from the terminal and prints it back. It does not execute shell commands, agent actions, or network requests at this stage.

As the learning project expands to include tools, model connections, and external integrations, the security posture will become more complex. At that point, the project may interact with local environments and external services, and we will take those risks seriously.

## Supported Versions

This repository currently supports only the latest commit on `main`. There are no maintained release branches at this time. If you are unsure whether a vulnerability affects your current checkout, please report it and we will assess it.

## Reporting a Vulnerability

Please do not open a public GitHub issue for any suspected security vulnerability.

Instead, report it privately through one of the following channels:

- GitHub Security Advisories for this repository (preferred), if enabled in the repository settings. You can find this under the repository's Security tab, then "Report a vulnerability".
- A direct private email to the maintainer at `info@skratsch.com` as a fallback. Please use a clear subject such as "AgentHarness security report".

When reporting, please include:

- A detailed description of the issue
- Steps to reproduce it
- The affected version or commit SHA
- Any proof-of-concept or exploit details
- Your assessment of impact and severity

We aim to acknowledge valid reports within a reasonable timeframe and will work with you to validate and remediate the issue.

## Responsible Disclosure

We ask that you:

- Give us a reasonable opportunity to fix the issue before disclosing it publicly
- Avoid accessing, modifying, or deleting data beyond what is necessary to validate the vulnerability
- Do not perform any destructive testing or denial-of-service attacks

## Security Considerations for This Project

`AgentHarness` is currently a minimal echo loop, but the project is intended to evolve toward agent actions, tool invocations, and external integrations. Please treat those future capabilities as high-risk surfaces. We strongly recommend:

- Using least-privilege credentials and scoped tokens
- Avoiding execution of untrusted or unreviewed agent instructions in production environments
- Reviewing all tool and command invocation paths before enabling them in shared or sensitive environments

Thanks for helping keep AgentHarness and its users safe.
