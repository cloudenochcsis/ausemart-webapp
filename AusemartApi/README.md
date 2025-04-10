# Aus-E-Mart API

A lightweight API backend for the Aus-E-Mart e-commerce application.

## Features

- Product management (CRUD operations)
- Order processing
- In-memory data storage (for demo purposes)

## API Endpoints

### Products

- `GET /api/products` - Get all products
- `GET /api/products?category={category}` - Get products by category
- `GET /api/products/{id}` - Get a specific product by ID
- `POST /api/products` - Create a new product
- `PUT /api/products/{id}` - Update an existing product
- `DELETE /api/products/{id}` - Delete a product

### Orders

- `GET /api/orders` - Get all orders
- `GET /api/orders/{id}` - Get a specific order by ID
- `POST /api/orders` - Create a new order
- `PATCH /api/orders/{id}/status` - Update the status of an order

## Running the API

### Development

```bash
cd AusemartApi
dotnet run
```

The API will be available at `http://localhost:5050`.

### Docker

```bash
docker build -t ausemart-api -f AusemartApi/Dockerfile .
docker run -p 5050:80 ausemart-api
```

## Using with Docker Compose

The API is configured to work with the Aus-E-Mart web frontend using Docker Compose. To run both together:

```bash
docker-compose up
```

This will:
- Start the API at `http://localhost:5050`
- Start the web frontend at `http://localhost:5000`