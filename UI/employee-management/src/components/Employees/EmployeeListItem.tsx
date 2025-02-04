import React from "react";
import { Employee } from "../../Models/Employee";
import { IEmployeeProps } from "./IEmployeeProps";

const API_BASE_URL = "https://localhost:60768/v1/employees";


const EmplopyeeListItem = ( props: IEmployeeProps)  =>{



    return (
    <tr className="uk-animation-slide-bottom-medium">
        <td className="uk-width-auto">
            <label>{props?.employee?.id}</label>
        </td>
        <td className="uk-width-expand">
            <span>{props?.employee?.firstName + " " + props?.employee?.lastName }</span>
        </td>
        <td className="uk-width-expand">
            <span>{props?.employee?.documentNumber}</span>
        </td>
        <td className="uk-width-auto">
            <button className="uk-icon-button uk-button-secondary" uk-icon="user"></button>
        </td>
    </tr>
    )

}


export default EmplopyeeListItem;