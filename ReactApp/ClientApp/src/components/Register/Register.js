import React, { useState } from 'react'
import axios from 'axios';
import validator from 'validator';
//import { DOMEN_SERVER, DOMEN_SITE } from '../../config/const';

export default function Register () {
    const [register, setRegister] = useState(() => {
        return {
            username: "",
            email: "",
            password: "",
            password2: "",
        }
    })
     
    const changeInputRegister = event => {
        event.persist()
        setRegister(prev => {
            return {
                ...prev,
                [event.target.name]: event.target.value,
            }
        })
    }

    return (
        <div className="form">
            <h2>Register user:</h2>
            <form> 
                {/* </div>onSubmit={submitChackin}> */}
                <p>Name: 
                    <input 
                        type="username"
                        id="username"
                        name="username"
                        value={register.usernamr}
                        onChange={changeInputRegister}
                    />
                </p>
                <p>Email: 
                    <input 
                        type="email"
                        id="email"
                        name="email"
                        value={register.email}
                        onChange={changeInputRegister}
                        formnovalidate
                    />
                </p>
                <p>Password: 
                    <input 
                        type="password"
                        id="password"
                        name="password"
                        value={register.password}
                        onChange={changeInputRegister}
                    />
                </p>
                <p>Repeat password: 
                    <input 
                        type="password"
                        id="password2"
                        name="password2"
                        value={register.password2}
                        onChange={changeInputRegister}
                    />
                </p>
                <input type="submit"/>
            </form>
        </div>
    )
}