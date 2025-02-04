import axios from "axios";
import { Employee } from "../Models/Employee";

const API_BASE_URL = "https://api:8080/v1/employees";

export const get = async () : Promise<Employee[]> =>{
    

    const employeeList  = await axios.get(API_BASE_URL).then(
            (response) => {
                if(response.data){
                    
                return response.data as Employee[]
                }}
    );

    return employeeList || [];
} 