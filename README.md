```markdown
# Trade Categorization API

This project provides an API for categorizing trades based on specific rules. The solution is built using .NET 8, follows the DDD pattern, and includes JWT authentication for securing the endpoints.

## Architecture and Patterns Used

### SOLID Principles

- **Single Responsibility Principle (SRP)**: Each class has a single responsibility, such as `Trade`, `TradeRepository`, and `TradeCategorizerService`.
- **Open/Closed Principle (OCP)**: The system uses the Strategy Pattern for trade categorization, allowing new strategies to be added without modifying existing code.
- **Liskov Substitution Principle (LSP)**: All trade categorization strategies implement the `ITradeCategoryStrategy` interface and can be used interchangeably.
- **Interface Segregation Principle (ISP)**: The `ITradeCategoryStrategy` interface is focused and specific.
- **Dependency Inversion Principle (DIP)**: The system uses dependency injection to depend on abstractions rather than concrete implementations.

### Design Patterns

- **Strategy Pattern**: Used for defining trade categorization strategies.
- **Repository Pattern**: Used for data access in the `TradeRepository`.
- **Dependency Injection**: Used to manage dependencies and configurations.

## Technologies Used

- **.NET 8**: Main framework for developing the API.
- **C#**: Programming language used.
- **Entity Framework Core**: ORM for data access.
- **SQL Server**: Relational database used.
- **Docker**: Containers for development, testing, and deployment.
- **Docker Compose**: Container orchestration for local development.
- **Azure Web App**: Hosting service used for deployment.
- **JWT (JSON Web Tokens)**: User authentication and authorization.
- **GitHub Actions**: CI/CD automation.
- **XUnit**: Unit testing framework.
- **Postman**: Tool for API testing and documentation.

## Project Components

### Directory Structure

```
TradeCategorization/
│
├── Application/
│   ├── CategorizeTrades/
│   ├── UseCases/
│   └── ...
│
├── Domain/
│   ├── Entities/
│   ├── Interfaces/
│   └── ...
│
├── Infrastructure/
│   ├── Data/
│   ├── Repositories/
│   └── ...
│
├── TradeCategorization.API/
│   ├── Controllers/
│   ├── Startup.cs
│   └── ...
│
├── TradeCategorization.Tests/
│   ├── TradeCategorizerServiceTests.cs
│   └── ...
│
├── docker-compose.yml
├── .github/
│   └── workflows/
│       └── deploy.yml
│
└── README.md
```

## Requirements and Prerequisites

- **.NET 8 SDK**: Used to build and run the project.
- **Docker**: Used for running containers and local development.
- **Azure Web App (optional)**: For production deployment.

## Setup and Installation

### Local Environment Setup

1. Clone the repository:

    ```bash
    git clone https://github.com/andregsantos/TradeCategorization.git
    cd TradeCategorization
    ```

2. Configure the environment variables:

    Create a `.env` file at the root of the project with the following content:

    ```env
    DefaultConnection=Server=localhost,1433;Database=TradeDb;User Id=sa;Password=YourStrong!Passw0rd;
    DOTNET_ENVIRONMENT=Production
    JWT_KEY=3DAA9B05206964019C7C08A344095843C6B1A8974F902B04063A494B
    JWT_ISSUER=trade
    ```

3. Run the application using Docker Compose:

    ```bash
    docker-compose up --build
    ```

    The API will be available at `http://localhost:8080`.

## Using the API

### Available Endpoints

- **POST /api/user/login**: Authenticate and receive a JWT token.
- **POST /api/trade/categorize**: Categorize trades. Requires a Bearer token for authorization.

### Additional Documentation

Detailed API documentation can be found in the Postman collection available at `docs/TradeCategorization.postman_collection.json`.

## Testing

### Running Unit Tests

To run the unit tests:

```bash
dotnet test TradeCategorization.Tests
```

## CI/CD Pipeline

The project includes a GitHub Actions workflow for CI/CD. The workflow:

1. Builds the solution.
2. Runs the tests.
3. Publishes the API.
4. Builds and pushes a Docker image to Docker Hub.
5. Deploys the API to an Azure Web App.

The workflow file is located at `.github/workflows/deploy.yml`.

You can run application at `https://tradecategorization.azurewebsites.net/swagger/index.html`.

## Contribution

Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

## License

This project is licensed under the MIT License.
```

This updated README provides a comprehensive overview of the Trade Categorization API project, including the architecture, technologies used, setup instructions, and details on the CI/CD pipeline and testing.