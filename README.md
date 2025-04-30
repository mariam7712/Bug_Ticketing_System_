# Bug Ticketing System

A robust bug tracking and ticketing system built to help teams manage and track software issues efficiently.

## Features

- User authentication and authorization
- Create, update, and track bug tickets
- Assign tickets to team members
- Priority and status management
- Comment system on tickets
- Dashboard with ticket statistics
- Email notifications
- Search and filter functionality


## Getting Started

### Prerequisites

- .NET 7.0 SDK or later
- SQL Server
- Node.js and npm
- Visual Studio 2022 or VS Code

### Installation

1. Clone the repository
   bash
   git clone https://github.com/yourusername/bug-ticketing-system.git

2. Navigate to the project directory
   bash
   cd bug-ticketing-system

3. Restore NuGet packages
   bash
   dotnet restore

4. Update database connection string in `appsettings.json`
   json
   {
   "ConnectionStrings": {
   "DefaultConnection": "Server=YOUR_SERVER;Database=BugTracker;Trusted_Connection=True;"
   }
   }

5. Apply database migrations
   bash
   dotnet ef database update

6. Run the application
   bash
   dotnet run

## API Endpoints

### Authentication

#### POST /api/auth/register

Create a new user account.

#### POST /api/auth/login

Login to existing account.


### Users

#### GET /api/users

Get all users.

#### GET /api/users/{id}

Get specific user details.




