# Sample Aus-E-Mart Web App

This is a basic e-commerce web app built using ASP.NET Core Razor Pages. Originally created to help demonstrate content in various Azure courses at [learn.cloudlee.io](https://learn.cloudlee.io), it has been enhanced with e-commerce functionality.

## Features

- Product catalog with categories
- Shopping cart functionality
- Checkout process
- Admin panel for product management
- In-memory data store (for demo purposes)
- RESTful API backend (optional)

## Usage

### Getting Started

#### Running the Web App Only

1. Ensure you have .NET 6.0 SDK or later installed
2. Clone this repository
3. Run the web application:

```bash
dotnet run
```

4. Open your browser and navigate to `https://localhost:5001` or `http://localhost:5000`

#### Running with Docker Compose (Web + API)

1. Ensure you have Docker and Docker Compose installed
2. Clone this repository
3. Run both the web app and API:

```bash
docker-compose up
```

4. Access the web application at `http://localhost:5000`
5. Access the API documentation at `http://localhost:5050/swagger`

### Shopping

1. Browse products on the Products page
2. Add items to your cart
3. Review your cart and adjust quantities as needed
4. Proceed to checkout

### Administration

1. Navigate to the Admin page from the navigation menu
2. Add, edit, or delete products
3. Manage product details including name, description, price, and stock

## Application Structure

### Web Application

- **Models/** - Contains data models for Products and Cart
- **Services/** - Contains services for managing products and cart
- **Pages/** - Razor Pages for the frontend
  - **Admin/** - Admin pages for product management
  - **Checkout/** - Checkout process pages
  - **Shared/** - Shared components and layouts

### API Backend (in AusemartApi directory)

- **Controllers/** - API endpoints for Products and Orders
- **Models/** - Data models
- **Services/** - Business logic and data storage

## API Endpoints

- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get a specific product
- `POST /api/products` - Create a product
- `PUT /api/products/{id}` - Update a product
- `DELETE /api/products/{id}` - Delete a product
- `GET /api/orders` - Get all orders
- `GET /api/orders/{id}` - Get a specific order
- `POST /api/orders` - Create an order
- `PATCH /api/orders/{id}/status` - Update order status

## Next Steps for Enhancement

1. Add user authentication and authorization
2. Implement a persistent database
3. Add order history and tracking
4. Implement payment processing integration
5. Add product reviews and ratings
6. Implement search functionality
7. Add more detailed product categories and filtering
8. Integrate the web frontend with the API backend

Refer to the course lessons for more information on how to use this sample web app.

