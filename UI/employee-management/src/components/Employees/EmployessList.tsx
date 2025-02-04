import React, { useContext, useEffect, useState } from "react";
import { Employee } from "../../Models/Employee";
import { Button, Link } from "uikit-react";
import axios from "axios";
import EmplopyeeListItem from "./EmployeeListItem";
import { EmployeeContextType } from "../../contexts/EmployeeContextType";
import { EmployeeContext } from "../../contexts/EmployeeContext";

//const API_BASE_URL = "https://localhost:60768/v1/employees";

const EmployeeList = () =>{
    const [employees , setEmployees] = useState<Employee[]>([]);
    const {getEmployees} = useContext<EmployeeContextType>(EmployeeContext);

    useEffect(() => {
            const fetchEmployees = async () => {
                const employees = await getEmployees();
                setEmployees(employees);
            };
            fetchEmployees();
        }, []);

    return (
        <table className="uk-table">
            <caption>Employee List</caption>
            <thead>
                <th>#</th>
                <th>Name</th>
                <th>Document</th>
                <th></th>
            </thead>
            <tbody>
                {
                    employees.map( employee => <EmplopyeeListItem key={employee.id} employee={employee}></EmplopyeeListItem>)
                }
                <td></td>
            </tbody>
        </table>)
}


export default EmployeeList;