//import React, {useState, useRef} from 'react';
import ReactDOM from 'react-dom/client';

import Header from './Header/header';
//import axios from 'axios';
import theme from './theme';
import { BrowserRouter, Route, Routes } from 'react-router-dom';

import { Button, Container } from "@mui/material";

import Profile from './Profile/Profile';
import Project from './Project/project';

const App = () => {
  
  // const [catalog, setCatalog] = useState([]);
  // const [cart, setCart] = useState([]);

  // const [attributes, setAttributes] = useState({sort: 0, name:"", selectedCategory:"", selectedBrand:0});
  // const childRef = useRef()
  
  // const updateCatalog = (attributes) => childRef.current.updateCatalog(attributes);
 
  return (
    <Container>
      <BrowserRouter>
        <Header/>
        <Routes>
          <Route path="/" exact 
            element={
              // <div>
              //   <FilterBar
              //     attributes={attributes}
              //     setAttributes={setAttributes}
              //     updateCatalog={updateCatalog}/>
              //   <CatalogList 
              //     catalog={catalog} 
              //     setCatalog={setCatalog}
              //     attributes={attributes}
              //     ref={childRef}
              //   />
              // </div>}/>
              <Project></Project>}></Route>
          {/* <Route path="/cart" exact 
            element={
              <div>                
                <CartList 
                  cart={cart} 
                  setCart={setCart}               
                />
              </div>}/> */}
            <Route path="/project" exact 
            element={
              <div>                
                <Project></Project>
              </div>}/>
          <Route path="/Profile" exact 
            element={
              <div>
                <Profile/>
              </div>}/>
        </Routes>
      </BrowserRouter>
    </Container>
  );
};

const container = document.getElementById('root');
const root = ReactDOM.createRoot(container);
root.render(<App/>);
