import React from "react";
import NavBar from "./NavBar/NavBar";
import EmployeeList from "./Employees/EmployessList";
import EmployeeContextProvider from "../contexts/EmployeeContext";
import {  BrowserRouter as Router } from "react-router-dom";
import { Routes, Route } from "react-router-dom";
import EmployeeDetails from "./Employees/EmployeeDetails";

const App    = () =>{
    return (
    <EmployeeContextProvider>
        <Router>
        <div className="uk-container">        
            <NavBar></NavBar>
            <Routes>
                <Route path="/create" element={<EmployeeDetails employee={undefined} />} />
                <Route path="/" element={
                    <>
                        <h4>Employees</h4>
                        <EmployeeList />
                    </>
                } />
            </Routes>
        </div>
        </Router>
    </EmployeeContextProvider>
    )
}

export default App;