import { Grid, Container, Typography, Card, Tooltip, Snackbar, Button, IconButton } from '@mui/material';
import React, { useEffect } from 'react';
import axios from 'axios';
import theme from '../Style/theme';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';

import LoginBox from './LoginBox';
import RegisterBox from './RegisterBox';
import User from './User';
import Admin from './Admin';

const Profile = (props) => {    
    const [isAuthenticated, setIsAuthenticated] = React.useState(false);
    const [name, setName] = React.useState("");
    const [openLogin, setOpenLogin] = React.useState(false);
    const [isAdmin, setAdmin] = React.useState(false);
    const [openRegister, setOpenRegister] = React.useState(false);

    useEffect(() =>{
        checkProfile();
    }, [])

    const logIn = () => {
        setOpenLogin(true);
    }    
    const registerOn = () => {
        setOpenRegister(true);
    }    

    const handleClose = (value) => {
        setOpenLogin(false);
        setOpenRegister(false);
    };

    const checkProfile = () => {   
        axios.get(`https://localhost:32770/api/Account/isAuthenticated`, { withCredentials: true })
            .then((response) => {
                setName(response.data.message);
                console.log(response.data.message);
                setAdmin(false);
                if (response.data.message === "Вы Гость. Пожалуйста, выполните вход.")
                {
                    setIsAuthenticated(false);}
                else
                {
                    setIsAuthenticated(true)
                }
            })
            .catch(console.error);
    }

    const logOut = () => {
        setAdmin(false);
        axios.post(`https://localhost:32770/api/Account/LogOff`, "", { withCredentials: true })
        .then((response) => {
            console.log(response.data.message);
            checkProfile();
            setIsAuthenticated(false);
        })
        .catch(console.error);
    }

    return (
        <Container sx={{mt: '5em'}}>
            <Card sx={{padding: 2}}>
                <Typography sx={{ fontSize: 16, textAlign: 'center'}}>
                    Мой профиль
                </Typography>
            </Card>
            
            <Card sx={{padding: 2, mt: '1em', color: 'white', backgroundColor: "#594d46", display: 'flex', justifyContent: 'flex-center'}}>
                <Typography sx={{ fontSize: 16, textAlign: 'center', m: 'auto', width: 350}}>
                    {name}  
                </Typography>
            </Card>

            {isAuthenticated === false ? 
                <Card sx={{padding: 2, mt: '1em'}}>
                    <Box sx={{ display: 'flex', flexDirection: 'row', justifyContent: 'center'}}>
                        <Button theme={theme} sx={{mr: 1}} color="button" variant="contained" onClick={logIn}>
                            Войти
                        </Button>

                        <Button theme={theme} color="button" variant="contained" onClick={registerOn}>
                            Регистрация
                        </Button>
                    </Box>
                </Card> 
                : isAdmin === true ?
                <Admin logOut={logOut}/>
                : 
                <User logOut={logOut} setAdmin={setAdmin}/>}
                { openLogin === true ? <LoginBox openLogin={openLogin} onClose={handleClose} checkProfile={checkProfile}/> : null }
                { openRegister === true ? <RegisterBox openReg={openRegister} onClose={handleClose} />: null}
                
        </Container>
    )
}

export default Profile;



