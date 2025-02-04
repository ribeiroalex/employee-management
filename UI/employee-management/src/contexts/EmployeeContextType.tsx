import { Employee } from "../Models/Employee";


export interface EmployeeContextType {
    addEmployee(employee : Employee): boolean;
    getEmployees(): Employee[];

}


