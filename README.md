# FinalAppYuval

A student grade management web application built with ASP.NET Core MVC that fetches and displays student grades from an external API.

## Overview

FinalAppYuval is a web application designed to manage and visualize student grades. The application retrieves student data including assignments, midterm, and final exam scores, calculates totals, determines pass/fail status, and provides statistical summaries.

## Features

- **Student Grade Display**: View a comprehensive list of all students with their individual assignment scores, midterm, and final exam grades
- **Automatic Grade Calculation**: Automatically calculates total scores based on:
  - Assignment 1
  - Assignment 2
  - Midterm
  - Final Exam
- **Pass/Fail Status**: Automatically determines pass/fail status (passing grade: 50 or above)
- **Grade Summary Statistics**: View summary statistics including:
  - Total number of students
  - Number of students who passed
  - Number of students who failed
  - Average score across all students
- **External API Integration**: Fetches real-time student data from an external API

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download) or later
- A code editor (e.g., Visual Studio, Visual Studio Code, or JetBrains Rider)

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Dryader/FinalAppYuval.git
   cd FinalAppYuval
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

## Running the Application

1. Navigate to the project directory:
   ```bash
   cd FinalAppYuval
   ```

2. Run the application:
   ```bash
   dotnet run
   ```

3. Open your web browser and navigate to:
   - HTTPS: `https://localhost:5001`
   - HTTP: `http://localhost:5000`

4. The application will automatically redirect to the Grade Index page showing all students and their grades.

## Project Structure

```
FinalAppYuval/
├── FinalAppYuval/              # Main application directory
│   ├── Controllers/            # MVC Controllers
│   │   ├── GradeController.cs  # Handles grade display and summary
│   │   └── HomeController.cs   # Home page controller
│   ├── Models/                 # Data models
│   │   ├── StudentGrade.cs     # Student grade model
│   │   ├── GradeSummary.cs     # Grade summary model
│   │   └── ErrorViewModel.cs   # Error handling model
│   ├── Services/               # Business logic services
│   │   ├── IGradeService.cs    # Grade service interface
│   │   └── GradeService.cs     # Grade service implementation
│   ├── Views/                  # Razor views
│   │   ├── Grade/              # Grade-related views
│   │   ├── Home/               # Home page views
│   │   └── Shared/             # Shared layouts and components
│   ├── wwwroot/                # Static files (CSS, JS, images)
│   ├── Program.cs              # Application entry point
│   ├── appsettings.json        # Application configuration
│   └── FinalAppYuval.csproj    # Project file
└── FinalAppYuval.slnx          # Solution file
```

## Technology Stack

- **Framework**: ASP.NET Core MVC (.NET 10.0)
- **Language**: C#
- **HTTP Client**: Built-in HttpClient for API integration
- **Dependency Injection**: ASP.NET Core DI Container
- **Front-end**: Razor Views with HTML/CSS/JavaScript

## API Endpoint

The application fetches student grade data from:
```
https://mohameom.dev.fast.sheridanc.on.ca/demo/grades.json
```

## Grading Logic

- **Total Score**: Sum of Assignment1 + Assignment2 + Midterm + Final
- **Pass Threshold**: 50 points or above
- **Status**: 
  - "Pass" if total score >= 50
  - "Fail" if total score < 50

## License

This project is available for educational purposes.
