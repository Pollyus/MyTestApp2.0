import React, { Component } from 'react';

import './home.css';
import { Link } from 'react-router-dom';


export class Home extends Component {
  static displayName = Home.name;
  render() {
    return (
        <container>
        <body className="BackImageHome">
          {/* <div class ="LogoHorizontal"/> */}
          <a class="MainText">Система<br/>модульного<br/>тестирования</a>
          <Link to="/inputData">
            <button class="ButtonInMainScreen">Начать тест</button>
          </Link>
        </body>
      </container>
    );
  }
}


