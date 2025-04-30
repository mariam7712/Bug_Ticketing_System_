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

## Tech Stack

- Backend: ASP.NET Core
- Database: SQL Server
- ORM: Entity Framework Core
- Authentication: JWT (JSON Web Tokens)
- Frontend: React.js
- UI Framework: Material-UI
- State Management: Redux

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

### Tickets

#### GET /api/tickets

Get all tickets (with optional filtering).

#### GET /api/tickets/{id}

Get specific ticket details.

#### POST /api/tickets

Create a new ticket.

#### PUT /api/tickets/{id}

Update an existing ticket.

#### DELETE /api/tickets/{id}

Delete a ticket.

### Comments

#### GET /api/tickets/{ticketId}/comments

Get all comments for a ticket.

#### POST /api/tickets/{ticketId}/comments

Add a comment to a ticket.

### Users

#### GET /api/users

Get all users.

#### GET /api/users/{id}

Get specific user details.

## Database Schema

### Users

- Id (PK)
- Username
- Email
- PasswordHash
- Role
- CreatedAt

### Tickets

- Id (PK)
- Title
- Description
- Status
- Priority
- AssignedTo (FK)
- CreatedBy (FK)
- CreatedAt
- UpdatedAt

### Comments

- Id (PK)
- TicketId (FK)
- UserId (FK)
- Content
- CreatedAt


