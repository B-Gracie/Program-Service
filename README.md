

# Program WorkFlow Service
[Bukola Ayangunna, gracieayan@gmail.com]

## Table of Contents
- [Introduction]
- [Task Description]
- [Requirements]
  - [Functional Requirements]
  - [Non-functional Requirements]
- [Getting Started]
  - [Prerequisites]
  - [Installation]
- [API Endpoints]
- [Testing]
- [Technologies Used]
- [Contributing]


## Introduction
Welcome to the Program WorkFlow Service project! The Program API is a comprehensive tool that facilitates the management of various programs, application templates, 
workflows, and program previews. It serves as a central hub for handling program-related data and processes. It consist of 3 layers which are, the Data Access Layer, The Service Layer and
the API.
The Data Access Layer consist of the Models, CosmosClientProvider and the Repository. This layer handles interaction with the database.
The Service Layer consist of the service interface and the interface implememntation. Using Dependency Injection to inject the repository. This layer handles the logic, thereby allowing the Repository
focus solely on interaction with the database.
The API exposes the endpoints which allows client interact with the application.

## Task Description

 - Program:

- **Operations**: [POST/GET/PUT]
- **Description**: This tab enables the creation, retrieval, and updating of program details. Programs represent various opportunities such as internships, 
     job openings, or training courses. You can use this tab to manage program-related information efficiently.

 - Application Template:

- **Operations**: [GET/PUT]
- **Description**: Associated with programs created in Tab 1, this tab focuses on application templates. It includes a customizable application form  
      with additional questions of various types (e.g., Paragraph, ShortAnswer, YesNo, Dropdown). You can modify the application form to suit your needs.

 - Workflow:

- **Operations**: [GET/PUT]
- **Description**: This tab is linked to programs from Tab 1 and deals with the application process workflow. 
      You can define and manage the stages applicants go through, including Shortlisting, Video Interview, and Placement stages. 
      Customize the workflow to streamline the application process.

- Preview:

- **Operations**: [GET]
- **Description**: The Preview tab provides a summary endpoint that offers a comprehensive overview of a program. It includes program details, application templates, workflow stages, and more. Use this tab to get a quick snapshot of a program's attributes.

The Program API simplifies program management and application processes, making it a valuable resource for organizations offering various opportunities. 

---

## Requirements

### Functional Requirements

1. **Create Program (POST)**:
   - The API should allow users to create a new program by sending a POST request.
   - The request should include program details such as program title, summary, description, key skills required, program type, start date, application open and close dates, duration, location, and maximum number of applications.
   - Upon successful creation, the API should return the newly created program with a unique identifier (ID).

2. **Get Programs (GET)**:
   - The API should provide an endpoint to retrieve a list of all available programs.
   - Users should be able to filter programs based on criteria such as program type or location.
   - The API should return a list of program details in response to a GET request.

3. **Get Program by ID (GET)**:
   - Users should be able to retrieve detailed information about a specific program by providing its unique identifier (ID) in the URL.
   - The API should return the program details if the specified program ID exists; otherwise, it should return an error.

4. **Update Program (PUT)**:
   - The API should allow users to update program information by sending a PUT request with the program's unique identifier (ID).
   - Users should be able to modify program details such as title, description, or application open date.
   - Upon successful update, the API should return the updated program information.

5. **Delete Program (DELETE)**:
   - The API should support the deletion of a program by specifying its unique identifier (ID) in a DELETE request.
   - After successful deletion, the API should return a confirmation message.

6. **Error Handling**:
   - The API should handle and return appropriate error messages for various scenarios, such as invalid input data, program not found, or server errors.
   - Error responses should include meaningful status codes and error descriptions.
   
   P.S. A middleware called CustomExceptionFilter was created solely for error handling.

8. **Validation**:
   - The API should validate incoming data to ensure that it adheres to specified rules and constraints. For example, it should validate date formats, check for required fields, and enforce data type constraints.

### Non-functional Requirements
- **Data Format**: Input/output data must be in JSON format.
- **Build and Run**: The project must be buildable and runnable.
- **Database**: Use Azure CosmosDB for NoSQL for data storage.
- **Unit Tests**: Implement unit tests to ensure the correctness of the application.
- **Framework**: Use a modern and popular framework for development.

## Getting Started

### Prerequisites
- Before you begin, make sure you have the following prerequisites installed on your system:

.NET SDK - Make sure you have .NET SDK installed. You can verify this by running dotnet --version in your terminal or command prompt.
Docker - Install Docker to run the Azure CosmosDB Emulator container.

### Installation
-Restore Dependencies: In the project directory, run the following command to restore the project's dependencies:
-Ensure that your application's configuration (usually found in appsettings.json or a similar file) is correctly set up to connect to your Azure CosmosDB Emulator. 
the connection string is properly configured in the project. [See Program.API project for reference].


## API Endpoints

###Program Endpoints

GET Programs: Retrieve a list of all programs.
Endpoint: GET /api/programs/GetPrograms
Example: GET https://localhost:7215/api/programs/GetPrograms

GET Program by ID: Retrieve details of a specific program by its ID.
Endpoint: GET /api/programs/GetProgramById/{id}
Example: GET https://localhost:7215/api/programs/GetProgramById/123

Create Program: Register a new program.
Endpoint: POST /api/programs/CreateProgram
Example: POST https://localhost:7215/api/programs/CreateProgram
Request Body: Include program details in the request body.

Delete Program by ID: Delete a specific program by its ID.
Endpoint: DELETE /api/programs/{id}
Example: DELETE https://localhost:7215/api/programs/123

### Application Template Endpoints
GET Application Template by ID: Retrieve details of a specific application template by its ID.
Endpoint: GET /api/applicationtemplates/{id}
Example: GET https://localhost:7215/api/applicationtemplates/123


Add Question to Template: Add a new question to an application template.
Endpoint: POST /api/applicationtemplates/{templateId}/questions
Example: POST https://localhost:7215/api/applicationtemplates/456/questions
Request Body: Include the question details in the request body.

GET Question by ID: Retrieve details of a specific question within an application template by its ID.
Endpoint: GET /api/applicationtemplates/{templateId}/questions/{questionId}
Example: GET https://localhost:7215/api/applicationtemplates/456/questions/789

Update Question: Update a question within an application template.
Endpoint: PUT /api/applicationtemplates/{templateId}/questions/{questionId}
Example: PUT https://localhost:7215/api/applicationtemplates/456/questions/789
Request Body: Include the updated question details in the request body.

Delete Question: Delete a question within an application template.
Endpoint: DELETE /api/applicationtemplates/{templateId}/questions/{questionId}
Example: DELETE https://localhost:7215/api/applicationtemplates/456/questions/789

### WorkFlow Endpoints
GET Workflow by ID: Retrieve details of a specific workflow by its ID.
Endpoint: GET /api/workflows/{workFlowId}
Example: GET https://localhost:7215/api/workflows/123

GET Stage by ID within a Workflow: Retrieve details of a specific stage within a workflow by its ID.
Endpoint: GET /api/workflows/{workFlowId}/stages/{stageId}
Example: GET https://localhost:7215/api/workflows/123/stages/456

Create or Update Stage: Create or update a stage within a workflow.
Endpoint: POST /api/workflows/{workFlowId}/stages
Example: POST https://localhost:7215/api/workflows/123/stages
Request Body: Include the stage details in the request body.

Delete Stage: Delete a stage within a workflow.
Endpoint: DELETE /api/workflows/{workFlowId}/stages/{stageId}
Example: DELETE https://localhost:7215/api/workflows/123/stages/456

### ProgramPreview Endpoints
GET Program Preview by Program ID: Retrieve program preview details by its associated program ID.
Endpoint: GET /api/program-previews/{programId}
Example: GET https://localhost:7215/api/program-previews/123


### Testing

To run the unit tests for this project, follow these steps:

#### 1. Test Setup Instructions
- **Prerequisites**: Ensure that you have .NET Core SDK installed on your machine.

- **Installing Testing Libraries**: Make sure you have the necessary NuGet packages installed for testing, including:
   - `xunit` and `xunit.runner.visualstudio` for the xUnit testing framework.
   - 'Moq' to mock dependencies

#### 2. Command to Run Tests
To run the unit tests, follow these steps:

- Open a terminal or command prompt.

- Navigate to the root directory of the test project.

- Use the following command to run the tests:

   ```bash
   dotnet test
   ```

   This command will discover and execute the unit tests in the project.


## Technologies Used
- Docker: Used for containerization of the Azure CosmosDB Emulator and managing dependencies.

- C#: The primary programming language for developing the application.

- ASP.NET Core: Used for building the RESTful API.

- Azure CosmosDB for NoSQL: The chosen database management system.

- xUnit: The testing framework used for unit testing.

- Postman and Swagger: tool for API testing.

## Contributing
Contributions are welcome! Please feel free.

##
To clone this repository to your local machine, open your terminal or command prompt and run the following command:

```bash
git clone https://github.com/B-Gracie/Program-Template-Service.git


##Project Developed By:

Bukola Ayangunna
gracieayan@gmail
=======
# program-workflow-service

