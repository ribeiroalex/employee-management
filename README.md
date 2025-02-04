# employee-management (API)

there are two ways to run the application

run "docker compose up" from a command line within the project root where the compose.yml file lives to get the project up and running.

you can also run the application from Visual Studio using the docker-compose option.

you can navigate the api documentation from localhost:8080/swagger

if you are running from Visual Studio a new browser windows will open for swagger navigation.

there are initially four roles:

| Role Name  | Id |
| ------------- | ------------- |
| CEO  | 1  |
| Admin  | 2  |
| Manager  | 3  |
| Employee  | 4  |

they can create employees based on their role privileges.

a CEO can create and ADMIN, Manager and Employee
an Admin can create Manager and Employee
and a Manager can create Employees only
Employees cannot create any kind of employee.


here's an create employee payload example

POST

/v1/employees

```
{
  "firstName": "string",
  "lastName": "string",
  "documentNumber": "38924517880",
  "password": "@Aas1231516sad",
  "createdById": "8ff9d42b-7458-4cd8-9058-28903762faaf",
  "managerId": "8ff9d42b-7458-4cd8-9058-28903762faaf",
  "roleId": 4,
  "phone": [
    "Line 1"
  ],
  "address": [
    "Line 2"
  ]
}
```

PUT
/v1/employees/{id}
```
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "firstName": "string",
  "lastName": "string"
}
```

the address and phones data should get updates into a different endpoint to follow rest standards

GET
/v1/employees/{id}/address

/v1/employees/{id}/phones

```
/v1/employees/{id}/address/{id}

/v1/employees/{id}/phones/{id}
```

# employee-management (UI)

you can run the UI Application from localhost:3000

The app should load the employee list as initial screen

click the plus sign in top right to add new employee

there are open activities to this UI  to get fully functional but code structure
like components, services and context are there so code structe can be verified.
