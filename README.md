# employee-management


run "docker compose up" from a command line to get the project up and running.


you can navigate the api documentation from localhost:8080/swagger


there are initially four roles:

CEO
Admin
Manager
Employee

they can create employees based on their role privileges.

a CEO can create and ADMIN, Manager and Employee
an Admin can create Manager and Employee
and a Manager can create Employees only
