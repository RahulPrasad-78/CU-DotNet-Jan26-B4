# Capgemini .NET Core with Azure Training Program

Welcome to the central repository for the **Capgemini .NET Core with Azure Training Program** (Batch: CU-DotNet-Jan26-B4). This repository serves as a comprehensive portfolio containing all training notes, daily hands-on assignments, weekly assessments, and full-scale projects developed over the 5-month intensive curriculum.

---

## 📂 Repository Structure

The workspace is organized into four main directories:

*   **[`/Projects`](file:///D:/Dotnet/CU-DotNet-Jan26-B4/Projects)** – Main application solutions and capstone projects.
*   **[`/Assessments`](file:///D:/Dotnet/CU-DotNet-Jan26-B4/Assessments)** – Weekly and milestone-based assessments verifying concepts.
*   **[`/Assignments`](file:///D:/Dotnet/CU-DotNet-Jan26-B4/Assignments)** – Daily practical tasks and exercises mapped by training days.
*   **[`/Notes`](file:///D:/Dotnet/CU-DotNet-Jan26-B4/Notes)** – Conceptual explanations, cheatsheets, interview Q&As, and curriculum documentation.

---

## 🚀 Key Capstone Projects (`/Projects`)

### 1. 🏦 SmartBank (Microservices Architecture)
A modern, microservice-based online banking application designed using ASP.NET Core 8.0/9.0. It demonstrates service isolation, inter-service routing, and centralized security.

*   **`SmartBank.Gateway`** – API Gateway using **YARP (Yet Another Reverse Proxy)** to route client requests to backend services. Secured with centralized JWT Bearer authentication.
*   **`AuthService`** – Handles secure identity management (user registration, login, token generation) using ASP.NET Core Identity and JWT tokens.
*   **`AccountServices`** – Manages customer bank accounts, balances, and account details. It uses the Repository-Service pattern and handles CRUD operations via Entity Framework Core.
*   **`SmartBank.TransactionService`** – Manages banking transactions (deposits, withdrawals, and transfers) with proper database state updates.
*   **`SmartBank.Web`** – ASP.NET Core MVC-based frontend dashboard presenting registration/login, account summaries, and transactional portals.

### 2. 🎮 WordGuess (Console C# Game)
A console-based word guessing (Hangman) game showcasing fundamental C# programming logic:
*   Random word selection from predefined datasets.
*   State management for player lives and letters guessed using `HashSet<char>`.
*   Input validation and error handling using custom try-catch blocks.

---

## 📝 Reference Notes (`/Notes`)

A collection of quick-reference guides, summaries, and cheatsheets explaining core engineering concepts:

*   **Language & OOP Fundamentals**: `ASYNC.txt`, `Threads.txt`, `why we use const.txt`, `D - DIP(Dependency Inversion Principle).txt`
*   **Collections & Data Structures**: `ArrayList - Non generic collections.txt`, `Create a Collections of words.md`
*   **Database & ORM**: `SQL Server.txt`, `Entity framework - EF core.txt`
*   **Web API & MVC**: `Web API.txt`, `Web Designing.txt`, `MVC Questions.md`, `Model.md`
*   **Testing & Diagnostics**: `Unit Testing.txt`, `Tracing vs Debugging.txt`
*   **Curriculum Reference**: `Capgemini - .NET Core with Azure_Curriculum.docx`

---

## 📅 Weekly Assessments (`/Assessments`)

These milestones evaluate skills developed throughout the training weeks:

| Week | Assessment Project / Content | Core Technologies demonstrated |
|:---|:---|:---|
| **Week 01** | `GreetingApp` & `GreetingLibrary` | Basic C# Console App, Class Libraries, Assembly References |
| **Week 02** | `InsurancePremiumSummarySystem` | Complex logical rules, structured summaries |
| **Week 04** | `Memorial` & HackerRank challenges | Algorithms, arrays, and standard math problem solving |
| **Week 05** | `SwiftRoute` | Basic Routing logic, string structures |
| **Week 08** | `BonusCalculator` & `TestBonus` | Business logic testing using **Unit Testing** frameworks |
| **Week 10** | `FinTrackPro` | Object-oriented domain modeling for finances |
| **Week 11** | `GlobalMart` | Web API Controllers, CRUD operations, database integrations |
| **Week 12** | `LogTrack` (Identity & Tracking Services) | Distributed microservice logging, architecture diagrams |
| **Week 13** | `VagaBondTravel` (Web API + MVC client) | Frontend MVC integration with backend REST APIs |
| **Week 14** | `Assessment 14.pdf` | Theoretical review and system design evaluations |
| **Week 15** | `Week15_NorthwindCatalog` (Services & Tests) | Advanced EF Core mappings, unit testing with test databases |
| **Week 16** | `CourseAPI` | Fluent validation, DTO patterns, custom middleware error handling |
| **Week 17** | `The_Horizon` (Complete Microservices solution)| Gateway routing, MVC Client integration, Service patterns, Unit Tests |

---

## 🛠️ Daily Assignments (`/Assignments`)

Below is the structured breakdown of the daily lab assignments:

### 🧩 Phase 1: C# OOPs and Data Structures (Days 2 - 35)
*   **Day 02**: `ValueTypes_Conversions_Exercises.cs` – Variables, casting, value type checks.
*   **Day 04 - 05**: MVC foundations, `GreetingApp` class library configuration.
*   **Day 07 - 10**: Smart access controllers, transactions, sales systems (`SalesAnalysisSystem`, `OrderProcessingSystem`).
*   **Day 13 - 16**: Basic geometry (`LineMethod`), gym chargers, inheritance, static configs.
*   **Day 18 - 20**: Compensation calculation, loan inheritance rules, abstract overrides, custom sorting using `IComparer`.
*   **Day 21 - 24**: HashTables, Dictionaries, Exception Handling exercises, OLA Driver simulator.
*   **Day 25 - 27**: File I/O (`CSVFile`), stream readers, logging utilities (`DailyLogger`).
*   **Day 29 - 31**: Domain splitters (`ExpenseSplitter`), Kitchen system queues, and **LINQ** query syntax exercises.
*   **Day 34 - 35**: Advanced structures – Graph simulations (`GraphSocailNetwork`), Tree hierarchies (`TreeOrg`).

### 🗄️ Phase 2: Database, Web Design, and Core MVC (Days 36 - 64)
*   **Day 36 - 38**: SQL Server queries (`Exercise - SQL Queries.sql`), string parsers (`VowelsShiftClipper.cs`).
*   **Day 43 - 47**: Multi-tenant SAAS architecture, financial portfolios, and shipping systems (`Cargo`).
*   **Day 48 - 52**: Web Designing - HTML structures, form processing, DOM inputs (`BulbOnOff.html`, `LoanEMI.html`, Sum forms).
*   **Day 54 - 56**: Company Portals, loan eligibility systems (`QuickLoan`).
*   **Day 60 - 64**: ASP.NET Core MVC with Entity Framework, ViewModels (`MVC_EF_VM`), Car Management, Student Console Management, and logging utilities.

### 🌐 Phase 3: REST APIs, EF Core Fluent API, and Microservices (Days 69 - 90)
*   **Day 69 - 72**: Database design constraints using **Fluent API** (`FluentAPI`), Volt Gear System, Library Management project.
*   **Day 75 - 87**: Intensive API and Cloud Architecture studies (documented via detailed PDFs covering Web API, Identity Services, and Azure Deployment).
*   **Day 88**: `Week15_NorthwindCatalog` – Service models and Integration tests.
*   **Day 90**: `CourseAPI` – Clean architecture endpoints, DTO mapping, validations, and custom logging middleware.

---

## ⚙️ How to Build and Run Projects

### Prerequisites
*   [.NET SDK 8.0 / 9.0](https://dotnet.microsoft.com/download)
*   [SQL Server / LocalDB](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
*   [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [VS Code](https://code.visualstudio.com/)

### Step-by-Step Execution

1.  **Clone the Repository**
    ```bash
    git clone https://github.com/<username>/CU-DotNet-Jan26-B4.git
    cd CU-DotNet-Jan26-B4
    ```

2.  **Restore NuGet Packages**
    Go to any project folder (e.g. `Projects/SmartBank` or `Assignments/Day 90/CourseAPI`) and run:
    ```bash
    dotnet restore
    ```

3.  **Build the Solution**
    ```bash
    dotnet build
    ```

4.  **Run the Application**
    To run the console game `WordGuess`:
    ```bash
    cd Projects/WordGuess
    dotnet run
    ```
    To launch the microservice platform `SmartBank`:
    *   Set up SQL Server connection strings in each service's `appsettings.json`.
    *   Apply migrations to generate database tables:
        ```bash
        dotnet ef database update --project AuthService
        dotnet ef database update --project AccountServices
        ```
    *   Launch the Gateway, Auth, Account, Transaction, and Web projects simultaneously (using Visual Studio multiple startup projects or running `dotnet run` in each terminal folder).

---

> [!NOTE]
> All code guidelines follow Microsoft's official PascalCase naming conventions for namespaces, classes, and methods, and camelCase for local variables and parameters.
