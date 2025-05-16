# Ambev.DeveloperEvaluation

## Description
**Ambev.DeveloperEvaluation** is a REST API project developed in **.NET**, following the **Layer** architectural pattern. The API aims to manage sales, allowing CRUD operations (Create, Read, Update, Delete) and other additional functionalities.

## Technologies Used
- **.NET 8+** (C#)
- **Entity Framework Core**
- **PostgreSQL**
- **Swagger** (for API documentation and testing)
- **FluentValidation** (for data validation)
- **Docker / Docker Compose**

## Installation and Configuration

### Requirements
- .NET 8+ installed
- Docker installed

### How to Run the Project

1. Clone the repository:
    ```sh
    git clone https://github.com/werleyss/Ambev.DeveloperEvaluation.git
    cd Ambev.DeveloperEvaluation
    ```
2. Run the application:
    ```sh
    docker-compose up -d
    ```
3. The API will be available at `https://localhost:8081`

## API Endpoints
Below are the main endpoints of the **Cart** API.

### Create a Cart
- **POST** `/api/v1/Carts`
- **Body:**
  ```json
    {
        "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "date": "2025-05-16T12:31:12.020Z",
        "products": [
            {
            "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "quantity": 0
            }
        ]
    }
  ```
- **Reponse**
  ```json
    {
        "success": true,
        "message": "string",
        "errors": [
            {
            "error": "string",
            "detail": "string"
            }
        ],
        "data": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "date": "2025-05-16T12:32:26.568Z",
            "totalValue": 0,
            "products": [
                {
                    "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    "quantity": 0,
                    "unitPrice": 0,
                    "discount": 0,
                    "totalPrice": 0
                }
            ]
        }
    }
  ```

### Get All Carts
- **GET** `/api/v1/Carts`
- **Reponse**
  ```json
    {
        "success": true,
        "message": "string",
        "errors": [
            {
            "error": "string",
            "detail": "string"
            }
        ],
        "data": [
            {
                "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                "date": "2025-05-16T12:41:43.955Z",
                "totalValue": 0,
                "products": [
                    {
                        "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                        "quantity": 0,
                        "unitPrice": 0,
                        "discount": 0,
                        "totalPrice": 0
                    }
                ]
            }
        ],
        "currentPage": 0,
        "totalPages": 0,
        "totalCount": 0
    }
  ```

### Get a Cart by ID
- **GET** `/api/v1/Carts/{id}`
- **Reponse**
  ```json
    {
        "success": true,
        "message": "string",
        "errors": [
            {
            "error": "string",
            "detail": "string"
            }
        ],
        "data": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "date": "2025-05-16T12:46:32.726Z",
            "totalValue": 0,
            "products": [
                {
                    "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    "quantity": 0,
                    "unitPrice": 0,
                    "discount": 0,
                    "totalPrice": 0
                }
            ]
        }
    }
  ```

### Update a Cart
- **PUT** `/api/v1/Carts/{id}`
- **Body:**
  ```json
    {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "date": "2025-05-16T12:45:05.195Z",
        "products": [
            {
            "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "quantity": 0
            }
        ]
    }
  ```
- **Reponse**
  ```json
    {
        "success": true,
        "message": "string",
        "errors": [
            {
            "error": "string",
            "detail": "string"
            }
        ],
        "data": {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "date": "2025-05-16T12:45:05.196Z",
            "products": [
                {
                    "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    "quantity": 0,
                    "unitPrice": 0,
                    "discount": 0,
                    "totalPrice": 0
                }
            ]
        }
    }
  ```
### Delete a Cart
- **DELETE** `/api/v1/Carts/{id}`
- **Response**
   ```json
    {
        "success": true,
        "message": "string",
        "errors": [
            {
            "error": "string",
            "detail": "string"
            }
        ]
    }
  ```

## Testing the API
To test the API, you can use:
- **Swagger**: Go to `https://localhost:8081/swagger`
- **Postman** Or **Insomnia** for HTTPs calls

## License
This project is licensed under the MIT license.