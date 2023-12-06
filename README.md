# BookManagement
Project is configured to execute the Web API, oppening Swagger for testing.

Please execute the script "BookManagementDB" to create the database, then update the connection string if needed in the file "BookManagement\BookManagement.Web\appsettings.json", in the "ConnectionStrings" section, as shown:

"ConnectionStrings": {
    "DefaultConnection": "CONNECTION STRING HERE"
  }

  Unit testing wasn't implemented because in the project I'm using dependency injection, and I'm currently studying how to use xUnit testing with DI.