# Student Inventory API
This is a RESTful API built with ASP.NET Core for managing student records. The API provides endpoints for performing CRUD (Create, Read, Update, Delete) operations on student data. The system uses Entity Framework Core for data access and includes Swagger documentation for easy testing.

## Features

- Get all students
- Get a specific student by ID
- Add new students
- Update existing student records
- Delete students
- Swagger UI for API documentation and testing
- Data validation using DTOs (Data Transfer Objects)

## Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI for documentation
- DTO pattern for data transfer

## API Endpoints

| Method | Endpoint                | Description                          |
|--------|-------------------------|--------------------------------------|
| GET    | /api/student            | Get all students                     |
| GET    | /api/student/{id}       | Get a specific student by ID         |
| POST   | /api/student            | Add a new student                    |
| PUT    | /api/student/{id}       | Update an existing student           |
| DELETE | /api/student/{id}       | Delete a student                     |


## Setup Instructions

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/student-inventory-api.git
   cd student-inventory-api
   ```

2. **Database Setup**:
   - Update the connection string in `appsettings.json` to point to your SQL Server instance:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=Students;Trusted_Connection=True;TrustServerCertificate=True;"
     }
     ```
   - Run the application to automatically create the database (EF Core will create it if it doesn't exist).

3. **Run the Application**:
   - Using Visual Studio:
     - Open the solution file
     - Press F5 to run
   - Using command line:
     ```bash
     dotnet run
     ```

4. **Access the API**:
   - The API will be available at `https://localhost:7251` or `http://localhost:5071`
   - Swagger UI will be available at `/swagger`

## Project Structure

- `Controllers/StudentController.cs`: Contains all API endpoints
- `Models/Students.cs`: Defines the Student entity model
- `Models/AddStudentDTO.cs`: DTO for adding new students
- `Models/UpdateStudentDTO.cs`: DTO for updating students
- `Data/ApplicationDbContext.cs`: Database context for Entity Framework
- `Program.cs`: Application startup and configuration
- `appsettings.json`: Configuration file with database connection string

## Sample Requests

### Add a new student (POST /api/student)
```json
{
  "name": "John Doe",
  "email": "john.doe@abc.com",
  "phone": "1234567890",
  "enroll_Date": "2023-01-15",
  "address": "123 Main St"
}
```

### Update a student (PUT /api/student/{id})
```json
{
  "name": "John Doe Updated",
  "email": "john.doe.updated@abc.com",
  "phone": "0987654321",
  "enroll_Date": "2023-01-15",
  "address": "456 Oak Ave"
}
```

## Testing the API

The API includes Swagger UI for easy testing:
1. Run the application
2. Navigate to `/swagger` in your browser
3. Use the interactive UI to test all endpoints

## License

This project is open-source and available under the [MIT License](LICENSE).

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your changes.

## Support

For any issues or questions, please open an issue in the GitHub repository.
