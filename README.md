🚀 Restful API Test Automation Project

This repository contains an automated test suite for the Restful-API.dev public sandbox. The project follows a Page Object Model (POM) inspired architecture, adapted for API testing with a Service Layer and Data Factories.
🛠 Tech Stack

    Language: C#

    Test Framework: xUnit

    HTTP Client: RestSharp

    Assertions: FluentAssertions & xUnit Asserts

    Ordering: xUnit.Priority (to handle CRUD operation sequence)

📋 Prerequisites

    .NET 8.0 SDK (or higher)

    IDE: Visual Studio 2022

🚀 How to Execute the Tests- Using Visual Studio 2022

    Open the .sln (Solution) file.

    Build the solution (Ctrl + Shift + B).

    Open Test Explorer (Test > Test Explorer).

    Click Run All to execute the CRUD sequence.

🏗 Project Structure

    APIModels/: C# classes representing JSON request and response.

    APIServices/: Logic for HTTP requests (GET, POST, PUT, DELETE) using RestSharp and setting up RestClient.

    APITests/: The actual xUnit test cases with the relevant assertions.

    Support: Test data generators,Test data according to the API request format, BaseURL, API end points.

⚠️ Important Notes

    Rate Limiting: This public API has a daily limit of 50 requests. If you see MethodNotAllowed with a 
    "daily request limit" error, please wait for the reset or switch your IP.

    Test Ordering: Because the tests follow a CRUD flow (Create -> Read -> Update -> Delete), 
    I have used xUnit.Priority to ensure they run in the correct logical sequence.
