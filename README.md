# Aus-E-Mart Web Store from Cloudlee

This is an e-commerce web application built using ASP.NET Core Razor Pages, designed to demonstrate a functional online store for Australian souvenirs. The application was originally created for Azure courses at [learn.cloudlee.io](https://learn.cloudlee.io).

## Features

- Browse products by category
- Search and filter products
- Shopping cart with session storage
- Admin dashboard for product management
- Responsive design for all devices
- Order processing simulation

## Technologies Used

- ASP.NET Core 6.0
- Razor Pages
- Bootstrap 5
- Session-based data storage
- C# in-memory repositories

## Getting Started

### Prerequisites

- .NET 6.0 SDK or later
- Visual Studio 2022, Visual Studio Code, or any preferred IDE

### Running the Application

#### Option 1: Using .NET CLI

1. Clone the repository
2. Navigate to the project directory
3. Run the application:

```bash
dotnet restore
dotnet run
```

4. Open your browser and navigate to `https://localhost:7034` or `http://localhost:5034`

#### Option 2: Using Docker Compose

1. Clone the repository
2. Navigate to the project directory
3. Build and run using Docker Compose:

```bash
docker-compose up --build
```

4. Open your browser and navigate to `http://localhost:8080`
5. To stop the containers, press Ctrl+C or run:

```bash
docker-compose down
```

## Project Structure

- `Models/` - Contains data models (Product, Cart, CartItem)
- `Services/` - Contains service classes for product and cart management
- `Pages/` - Razor Pages for the frontend
  - `Admin/` - Admin dashboard pages
  - `Shared/` - Shared layout and partial views
- `wwwroot/` - Static assets (CSS, JS, images)

## Extending the Application

### Adding Database Persistence

To add database persistence:

1. Add Entity Framework Core packages
2. Create a database context
3. Update the service implementations to use EF Core
4. Configure the connection string in `appsettings.json`
5. Migrate and update the database

### Adding User Authentication

To add user authentication:

1. Add ASP.NET Core Identity
2. Configure Identity in `Program.cs`
3. Create login/register pages
4. Add authorization attributes to admin pages

## License

This project is licensed under the MIT License

