# Municipality App

A small WinForms desktop application for reporting and viewing municipal issues. The application is implemented in C# targeting .NET 8 and designed to be opened and developed in Visual Studio 2022.

## Overview

MunicipalityApp allows users to create issue reports (category, location, description and optional file attachment) and view previously submitted reports in a styled, owner-drawn list. The project demonstrates a simple repository pattern for storing `Issue` objects and a compact WinForms UI.

## Features

	- Create and submit issue reports via `IssueReportingForm`.
- View existing reports in `ViewReportsForm` using an owner-drawn `ListBox` with multi-line cards.
- Simple `Repository<T>` abstraction for storing and retrieving `Issue` objects.
- Attachment support (file path stored on the `Issue`).

## Prerequisites

- Visual Studio 2022 (recommended) or later
- .NET 8 SDK
- Windows OS for running WinForms applications

The solution targets C# language version 12 and .NET 8.

## Build and run

Using Visual Studio 2022

1. Open `MunicipalityApp.sln` in Visual Studio 2022.
2. Let NuGet restore packages if prompted.
3. Set `MunicipalityApp` as the startup project.
4. Press F5 (Debug) or Ctrl+F5 (Run without debugging).

Using the .NET CLI

1. Open a terminal in the repository root (where the solution file is located).
2. Run `dotnet restore`.
3. Run `dotnet build`.
4. Run the app with `dotnet run --project MunicipalityApp\\MunicipalityApp.csproj`.

## Usage

- Main menu: navigate between reporting and viewing functionality.
- Issue reporting: fill in category, location, description and optionally attach a file. Submitting creates an `Issue` stored in the application's repository instance.
- View reports: open the reports viewer to see submitted issues displayed as cards. Each card shows category, location, truncated multi-line description, and attachment filename (if present).

Note: The repository implementation and data lifetime are part of the `ClassLibrary` project. Depending on the `Repository<T>` implementation, data may be stored in-memory for the running session or persisted.

## Project layout (key files)

- `MunicipalityApp/Program.cs` — application entry point.
- `MunicipalityApp/MainMenu.*` — main navigation form and designer.
- `MunicipalityApp/IssueReportingForm.*` — form to create and submit new issues.
- `MunicipalityApp/ViewReportsForm.*` — owner-drawn list for browsing saved issues.
- `ClassLibrary/Issue.cs` — `Issue` model.
- `ClassLibrary/Repository.cs` — generic repository abstraction used by the app.

## Coding standards

This repository includes an `.editorconfig` and `CONTRIBUTING.md` at the root. Follow those files for formatting, naming, and contribution guidelines. Configure Visual Studio settings if you rely on editor formats not enforced by `.editorconfig`.

Recommended Visual Studio settings to check:
- Ensure code formatting follows `.editorconfig`.
- Confirm target framework (.NET 8) for projects.

