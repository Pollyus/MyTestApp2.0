//import React, {useState, useRef} from 'react';
import ReactDOM from 'react-dom/client';

import Header from './Header/header';
//import axios from 'axios';
import theme from './Style/theme';
import { BrowserRouter, Route, Routes } from 'react-router-dom';

import { Button, Container } from "@mui/material";


import Profile from './Profile/Profile';
import Project from './Project/project';
import {Home} from './Home/home';
import TestResult from './TestResult/testResult';
import {InputData} from './InputData/inputdata';
import TestReport from './TestReport/testReport';

const App = () => {
  
  return (
    <Container>
      <BrowserRouter>
        <Header/>
        <Routes>
          <Route path="/" exact 
            element={ <Home/>}>
          </Route>
           <Route path="/" exact 
            element={
              <div>                
                <Home/>
              </div>}/> 
            <Route path="/project" exact 
            element={
              <div>                
                <Project></Project>
              </div>}/>
          <Route path="/profile" exact 
            element={
              <div>
                <Profile/>
              </div>}/>
          <Route path="/testResult" exact 
            element={
              <div>                
                <TestResult/>
              </div>}/>
          <Route path="/inputData" exact 
            element={
              <div>                
                <InputData/>
              </div>}/> 
          <Route path="/testReport" exact 
            element={
              <div>                
                <TestReport/>
              </div>}/> 
        </Routes>
      </BrowserRouter>

    </Container>
  );
};


const container = document.getElementById('root');
const root = ReactDOM.createRoot(container);
root.render(<App/>);
