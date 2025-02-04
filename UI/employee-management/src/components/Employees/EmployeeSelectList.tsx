import React, { useEffect } from "react";
import { IEmployeeProps } from "./IEmployeeProps";

const EmployeeSelectList = (props: IEmployeeProps) => {
    

    return(<select className="uk-select" id="form-stacked-select">
        <option value={props?.employee?.id}>{props?.employee?.firstName + " " + props?.employee?.firstName}</option>
    </select>)
}

export default EmployeeSelectList;