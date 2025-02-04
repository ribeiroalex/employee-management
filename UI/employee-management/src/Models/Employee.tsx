import { Person } from "./Person";
import { Role } from "./Role";

export class Employee extends Person {
    public managerId?: string;
    public manager?: Employee;
    private employeesList: Employee[] = [];
    private employeeRoles: Role[] = [];

    constructor(
        firstName: string,
        lastName: string,
        documentNumber?: string
    ) {
        super(firstName, lastName, documentNumber);
    }

}