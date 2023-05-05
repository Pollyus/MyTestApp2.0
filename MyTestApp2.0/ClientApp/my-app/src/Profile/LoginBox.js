import DialogTitle from '@mui/material/DialogTitle';
import Dialog from '@mui/material/Dialog';
import Card from '@mui/material/Card';
import React, { useEffect, useState } from 'react';
import axios from 'axios';
import theme from '../Style/theme'
import { Typography, Container, Grid, Box, Button, TextField } from '@mui/material';

import MailIcon from '@mui/icons-material/Mail';
import KeyIcon from '@mui/icons-material/Key';

function LoginBox(props) {
    const { onClose, openLogin, checkProfile } = props;
    
    const [login, setLogin] = React.useState("");
    const [password, setPassword] = React.useState("");
    const [errors, setErrors] = useState([]);

    const handleClose = () => {
      onClose();
    };
    
    const handleLoginChange = (event) => {
        setLogin(event.target.value);
    }

    const handlePasswordChange = (event) => {
        setPassword(event.target.value);
    }
  
    const logIn = (e) => {
        e.preventDefault();
        const value = { "email": login, "password": password, "rememberMe" : true };
        axios.post(
            'https://localhost:32770/api/Account/Login', value, { withCredentials: true }
        )
            .then((response) => { 
                console.log(response.data.message);
                typeof response.data.error !== "undefined" && setErrors(response.data.error)
                checkProfile();
                onClose();
            })
            .catch(console.error);
    }


    return (
        <Dialog onClose={handleClose} open={openLogin} sx={{m: 'auto'}}>
            <Box sx={{width: 450, height: 350,display: 'flex', flexDirection: 'column', justifyContent: 'space-between', m: 'auto' }}>
                <Typography sx={{width: "100%", textAlign: 'center', mt: 3, fontSize: 16}}>Вход в аккаунт</Typography>
                <Box sx={{width: '100%', display: 'flex', flexDirection: 'column', alignItems: 'center', m: 'auto'}}>
                    <Box sx={{padding: 1,display: 'flex', alignItems: 'center', flexDirection: 'row'}}>
                        <MailIcon theme={theme} color="button" sx={{height: 30, width: 30, mt: 'auto', mb: 'auto'}}/>
                        <TextField
                            sx={{width: 200, ml: 1}}
                            required
                            id="outlined-required"
                            label="Почта"
                            value={login} onChange={handleLoginChange}
                        />
                    </Box>
                    <Box sx={{padding: 1, display: 'flex', alignItems: 'center', flexDirection: 'row'}}> 
                        <KeyIcon theme={theme} color="button" sx={{height: 30, width: 30, mt: 'auto', mb: 'auto'}}/>
                        <TextField
                            sx={{width: 200, ml: 1}}
                            id="outlined-password-input"
                            required
                            label="Пароль"
                            type="password"
                            autoComplete="current-password"
                            value={password} onChange={handlePasswordChange}
                        />
                    </Box>
                </Box>
                
                <Box sx={{padding: 1, display: 'flex', alignItems: 'center', flexDirection: 'row'}}> 
                    <Button theme={theme} sx={{m: 'auto', mb: 3}} color="button" variant="contained" onClick={logIn}>
                        Войти
                    </Button>
                </Box>
            </Box>
        </Dialog>
    );
  }

export default LoginBox;