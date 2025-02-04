import React , {createContext}from "react";
import { EmployeeContextType } from "./EmployeeContextType";
import { Employee } from "../Models/Employee";
import { get } from "../Services/EmployeeService";

export const EmployeeContext = createContext<EmployeeContextType>({
    addEmployee: () => false,
    getEmployees: () => []
});


const EmployeeContextProvider = (props: any) => {

    const addEmployee = ( employee: Employee) =>
    {
            return true
    }

    const getEmployees = () => {
        let employeeList: Employee[] = [];
        get().then(data => {
            employeeList = data;
        }).catch(error => {
            console.error("Failed to fetch employees", error);
        });
        return employeeList;
    }

    return(

        <EmployeeContext.Provider value={{addEmployee,getEmployees }}>
            {props.children}
        </EmployeeContext.Provider>
    )

}

export default EmployeeContextProvider;

