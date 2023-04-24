import React, {useState } from 'react';
import { Route, Routes} from 'react-router-dom';
import { Layout } from '../Layout';
import './custom.css';
import Dashboard from '../Dashboard/Dashboard';
import Preferences from '../Preferences/Preferences';
import { Home } from '../Home';
import Login from '../Login/Login';
//import useToken from './useToken';
import Registr from '../Register/Register';

  function App() {
    // const { token, setToken } = useToken();
    // if(!token) {
    //   return <Login setToken={setToken} />
    // }
    return (
      <Layout>
        <Routes>
          <Route exact path='/' element={<Home/>} />
          <Route path='/dashboard' element={<Dashboard/>}></Route>
          <Route path='/preferences' element={<Preferences/>}></Route>
          <Route path='/login' element={<Login/>}></Route>
          <Route path='/register' element={<Registr/>}></Route>
        </Routes>
      </Layout>
    );
  }
export default App;