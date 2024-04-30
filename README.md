# StockViewer

StockViewer is a full-stack application designed to provide real-time stock data visualization and management. The application utilizes .NET for both the backend and frontend, with the frontend specifically leveraging the capabilities of Blazor for a rich interactive user experience.

## Technology Stack

- **Backend:**
  - **.NET Core**: Framework for building high-performance web APIs.
  - **Entity Framework Core**: ORM for .NET used for database operations.
  - **SQLite**: Database system for storing users data.

- **Frontend:**
  - **Blazor**: A .NET framework used for building interactive client-side web UIs using C# instead of JavaScript.

## Prerequisites

Before setting up the project, ensure you have the following installed on your system:
- [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) or later. This SDK includes support for Blazor.

## Setup

### Cloning the Repository

Clone the repository to your local machine:
```bash
git clone https://github.com/yourusername/StockViewer.git
cd StockViewer
```

### Dependency Restoration

Navigate to each project directory and restore the .NET dependencies:

**Backend:**
```bash
cd backend/StockViewer.Api
dotnet restore
```

**Frontend:**
```bash
cd ../frontend/StockViewer.Frontend
dotnet restore
```

## Running the Project

The project includes pre-configured scripts that start both the backend and frontend with a single command:

### Using Pre-configured Scripts

**For Windows Users:**
Execute the batch file by double-clicking on `start.bat` or through the command line:
```bash
start.bat
```

**For Linux/Mac Users:**
Ensure the shell script is executable, and then run it:
```bash
chmod +x start.sh
./start.sh
```

These scripts will start:
- The backend API on [http://localhost:5085](http://localhost:5085)
- The frontend Blazor app on [http://localhost:5220](http://localhost:5220)

## Running automatic documentation

The project includes pre-configured scripts that start doxygen for automatic documentation of both frontend and backend part

### Using Pre-configured Scripts

**For Windows Users:**
Execute the batch file by double-clicking on `run_doc.bat` or through the command line:
```bash
run_doc.bat
```
