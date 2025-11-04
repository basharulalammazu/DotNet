# ADVANCED PROGRAMMING WITH .NET

Course: **ADVANCED PROGRAMMING WITH .NET**  
Instructor: **TANVIR AHMED**

---

## Purpose

This repository README is a day-by-day learning journal for the course _ADVANCED PROGRAMMING WITH .NET_. Use it to record class notes, exercises, code snippets, reading, and next steps. Update this file every day (or after each lecture/lab) so the course progress is easy to review.

## How to structure daily updates

For every new class/lab day, add a new section using the format below. Keep entries chronological and prefix headings with the date (YYYY-MM-DD) so the log is sortable.

Template for each day

### YYYY-MM-DD — Day N — [Short title]

- **Goals for today:** (what you want to learn / accomplish)
- **Topics covered:** (bullet list of lecture/lab topics)
- **Code / commands:** (short snippets or references to files/commits)
- **Resources & references:** (links to slides, docs, web pages)
- **Problems / issues encountered:** (bugs, confusion, TODOs)
- **What I learned (summary):** (2–4 concise bullets)
- **Next steps / Homework:** (what to prepare before next class)

Example entry (Day 1)

### 2025-10-29 — Day 01 — Course intro & environment setup

- **Goals for today:** Get course overview and set up the development environment for .NET development.
- **Topics covered:**
  - Course syllabus and assessment (brief)
  - Overview of .NET ecosystem and CLR
  - Visual Studio and project templates (ASP.NET MVC) used in labs
  - NuGet packages and package.config
- **Code / commands:**
  - Created a new ASP.NET MVC project in Visual Studio (see project `Lab 1/`)
  - Basic git usage to save daily logs (example commands below)
- **Resources & references:**
  - Official .NET docs: https://learn.microsoft.com/dotnet/
  - ASP.NET MVC docs: https://learn.microsoft.com/aspnet/mvc
- **Problems / issues encountered:**
  - None major — Visual Studio project opened successfully.
- **What I learned (summary):**
  - Course structure and expectations.
  - Project template used for labs is an ASP.NET MVC application.
- **Next steps / Homework:**
  - Review MVC controllers and views prior to the next lab.
  - Implement a small controller action and commit the change.

## Quick instructions — Updating this README daily (PowerShell examples)

1. Open a PowerShell terminal in the repository root.
2. Edit this `README.md` and add a new section for the current date following the template above.
3. Save and commit with a clear message:

```powershell
git add README.md
git commit -m "chore: daily log 2025-10-30 — Day 02 — [short title]"
git push
```

Tips for commit messages

- Use the prefix `chore: daily log` followed by the ISO date and a short title. This keeps daily updates discoverable in the commit history.

## Suggested small conventions

- Start each heading with the ISO date (YYYY-MM-DD) and a Day counter.
- Keep summaries short and actionable.
- If code is substantial, place it in the repository (e.g., under `Labs/Day02/`) and reference the path here.

## Where to add files and exercises

- Use a clear folder structure for lab artifacts, e.g., `Labs/Day01/`, `Labs/Day02/` or `Projects/ProjectName/`.
- Reference files by relative path in this README for quick navigation.

## Future improvements (follow-ups)

- Add a course schedule table with lecture topics and dates.
- Add quick badges (build/test) if auto-build is available.
- Add a CONTRIBUTING.md with more detailed commit/branching rules for team projects.

---

If you'd like, I can also:

- create `Labs/` folders and add a starter sample for Day 2, or
- generate a weekly schedule table in this README, or
- add a small CONTRIBUTING.md with precise commit message templates.

Thank you — keep this file updated after each lecture or lab so your course notes remain useful and searchable.
