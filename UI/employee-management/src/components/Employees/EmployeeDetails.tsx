import React, { useContext, useEffect, useState } from "react";
import { Employee } from "../../Models/Employee";
import axios from "axios";
import EmployeeSelectList from "./EmployeeSelectList";
import { EmployeeContextType } from "../../contexts/EmployeeContextType";
import { EmployeeContext } from "../../contexts/EmployeeContext";
import { IEmployeeProps } from "./IEmployeeProps";


const EmployeeDetails = (props: IEmployeeProps) => {
    const [employees , setEmployees] = useState<Employee[]>([]);
    const {getEmployees} = useContext<EmployeeContextType>(EmployeeContext);
    useEffect(() => {
        const fetchEmployees = async () => {
            const employees = await getEmployees();
            setEmployees(employees);
        };
        fetchEmployees();
    }, []);

    return(
    <div className="uk-card uk-card-body">
        <form className="uk-form-stacked">
            <div className="uk-margin">
                <label className="uk-form-label" htmlFor="first-name">First Name</label>
                <div className="uk-form-controls">
                    <input className="uk-input" id="first-name"type="text" placeholder="First Name">{props?.employee?.firstName}</input>
                </div>
            </div>
            <div className="uk-margin">
                <label className="uk-form-label" htmlFor="last-name">Last Name</label>
                <div className="uk-form-controls">
                    <input className="uk-input" id="last-name"type="text" placeholder="Last Name">{props?.employee?.lastName}</input>
                </div>
            </div>
            <div className="uk-margin">
                <label className="uk-form-label" htmlFor="document-number">Document Number</label>
                <div className="uk-form-controls">
                    <input className="uk-input" id="document-number"type="text" placeholder="Document Number">{props?.employee?.documentNumber}</input>
                </div>
            </div>

            <div className="uk-margin">
                <label className="uk-form-label" htmlFor="document-number">Created By</label>
                <div className="uk-form-controls">
                    { employees?.map(employee => <EmployeeSelectList key={employee?.id} employee={employee}></EmployeeSelectList>)}
                </div>
            </div>
        </form>
    </div>)
}

export default EmployeeDetails;