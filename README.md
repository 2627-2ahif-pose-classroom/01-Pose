# OutAndParams

## Learning Objectives

- Understand and apply the `out` parameter
- Use dynamic (variable-length) parameters in a method
- Test-Driven Development

> :robot: Stuck? Ask the [OutAndParams Tutor](https://novedu.at/x69m7t8zpn) - it gives you hints and guiding questions, not the finished solution.

## Project Structure

- `OutAndParams/` – console application; the `Add`, `Multiply` and `Divide` methods live in the `Calculator` class
- `OutAndParams.Test/` – xUnit unit tests (`CalculatorTests`) for the methods above

## Tasks

### 1. Create the Solution & Projects (CLI)

This is the first step: set up the solution structure with the `dotnet` CLI before writing any code (all commands are run from the `solution/` folder).

```bash
# Empty solution file (.NET 10 defaults to the leaner .slnx format over the classic .sln)
dotnet new sln -n OutAndParams

# Console app as the main project
dotnet new console -o OutAndParams

# xUnit test project
dotnet new xunit -o OutAndParams.Test

# Add both projects to the solution
dotnet sln add OutAndParams/OutAndParams.csproj
dotnet sln add OutAndParams.Test/OutAndParams.Test.csproj

# Reference the main project from the test project so tests can access Calculator
dotnet add OutAndParams.Test/OutAndParams.Test.csproj reference OutAndParams/OutAndParams.csproj

# Confirm everything fits together
dotnet build OutAndParams.slnx
dotnet test OutAndParams.slnx
```

### 2. Implement the Methods

Methods with dynamic parameters:

- Define a method `Add` that takes a parameter `sum` as an `out` parameter, 2 summands, and an arbitrary number of additional summands. The summands are all of type `double`.
- Write unit tests for this method with the following desired behavior: the result is stored in the `sum` parameter, and the method returns the number of summands that were added together.
- Implement the method so that all unit tests pass, one after another.

**Examples:**

```csharp
double sum;
int count;

count = Add(out sum, 12, 24);                                    // count == 2
count = Add(out sum, 5.5, 12.77, 4, 6, 9);                        // count == 5
count = Add(out sum, 99.75, 24, 12, 652, 383, 39.67, 34.9);       // count == 7
count = Add(out sum, 12, 24, new double[]{ 12, 45, 68, 99 });     // count == 6
```

Additional methods:

- Write a method `Multiply` following the same scheme as `Add`, and consider how to handle special cases.
- Write a method `Divide` following the same scheme as `Add`, and consider how to handle special cases.

### 3. Quality Requirements

- Check the code coverage: 100% code coverage is required (see [Checking Code Coverage](#checking-code-coverage) below).
- Document the semantics of the methods in method comments.

## Build & Test

The project has been migrated to .NET 10 and uses the `.slnx` solution format. To build and test:

```bash
dotnet build OutAndParams.slnx
dotnet test OutAndParams.slnx
```

## Checking Code Coverage

> :bulb: Code coverage shows which lines/branches your tests actually exercise, revealing untested (and thus unverified) code paths — a key signal for test suite quality, not just quantity of tests.

### Via the CLI

The test project already references `coverlet.collector`, so coverage can be collected without any extra setup.

1. Run the tests with coverage collection enabled:

   ```bash
   dotnet test OutAndParams.slnx --collect:"XPlat Code Coverage"
   ```

   This produces a Cobertura XML report per test run, e.g.:

   ```
   OutAndParams.Test/TestResults/<guid>/coverage.cobertura.xml
   ```

2. (Optional) Turn the XML report into a readable HTML report using the `ReportGenerator` global tool:

   ```bash
   dotnet tool install -g dotnet-reportgenerator-globaltool   # once
   reportgenerator -reports:"OutAndParams.Test/TestResults/**/coverage.cobertura.xml" -targetdir:"CoverageReport" -reporttypes:Html
   ```

   Then open `CoverageReport/index.html` in a browser to see line/branch coverage per file, including which lines are still uncovered.

### Via JetBrains Rider

Rider ships with the dotCover coverage engine built in, so no plugin or extra package is needed beyond what's already in the solution.

1. Open `OutAndParams.slnx` in Rider (`File > Open`). Recent Rider versions open `.slnx` solutions natively.
2. In the **Unit Tests** window (or Solution Explorer), right-click the `OutAndParams.Test` project, the `CalculatorTests` class, or an individual `[Fact]`/`[Theory]` method, and choose **Cover Tests** (alternatively, use the coverage icon — a play button with a small bar chart — next to the regular _Run_/_Debug_ icons in the gutter or toolbar) instead of a normal _Run_.
3. After the run finishes, the **Unit Tests Coverage** tool window opens, showing coverage percentages per assembly, namespace, class and method. The editor gutter also highlights covered lines in green and uncovered lines in red/orange directly in `Calculator.cs`.
4. To share the result outside Rider, use the export button in the Coverage tool window (**Generate Coverage Report**) to produce an HTML or XML report on disk.

### Via Microsoft Visual Studio

**Visual Studio Enterprise** has a built-in code coverage tool, no extra setup required:

1. Open `OutAndParams.slnx` in Visual Studio (`File > Open > Project/Solution`). Recent VS 2022 releases open `.slnx` solutions natively.
2. Build the solution and open `Test > Test Explorer` to confirm the `CalculatorTests` tests are discovered.
3. Run `Test > Analyze Code Coverage for All Tests` (or right-click a specific class/method in Test Explorer and choose **Analyze Code Coverage for Selected Tests**).
4. The **Code Coverage Results** window opens, listing coverage percentages per assembly, namespace, class and method. Toggle **Show Code Coverage Coloring** in its toolbar to highlight covered (blue) and uncovered (red) lines directly in `Calculator.cs`.
5. Use the export button in the Code Coverage Results window to save the results as a `.coveragexml` file for sharing.

**Visual Studio Community/Professional** don't include that built-in tool. Since the test project already references `coverlet.collector`, coverage can still be collected from inside VS by opening the Developer PowerShell (`View > Terminal`) and running the same command as in [Via the CLI](#via-the-cli):

```bash
dotnet test OutAndParams.slnx --collect:"XPlat Code Coverage"
```

To see the result inline in the editor, install a free extension such as **Fine Code Coverage** (`Extensions > Manage Extensions`), which reads the generated Cobertura report and highlights covered/uncovered lines automatically after each test run.
