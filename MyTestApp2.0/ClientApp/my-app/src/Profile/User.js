import { Grid, IconButton, Typography, Card, Tooltip, Alert, Snackbar, Button, Accordion, Badge } from '@mui/material';
import React, { useEffect, useState} from 'react';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import axios from 'axios';
import theme from '../Style/theme';
import { alpha } from '@mui/material';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import LoginBox from './LoginBox';
import LogoutIcon from '@mui/icons-material/Logout';

const User = ({logOut, setAdmin}) => {    
    
    const [orders, setOrders] = useState([]);
    const [status, setStatus] = useState([]);

    const getOrders = () => {
        axios.get(`https://localhost:32770/api/Profile/GetAllOrders`, { withCredentials: true })
            .then((response) => {
                setOrders(response.data);
                setAdmin(false);
            })
            .catch(() => {
                setAdmin(true);
            });
    }

    const getStatus = () => {
        axios.get(`https://localhost:32770/api/Profile/GetStatusInfo`, { withCredentials: true })
            .then((response) => {
                setStatus(response.data);
            })
            .catch(console.error);
    }

    const handleClick = () => {
        logOut();
    }

    useEffect(() =>{
        getOrders();
        getStatus();
    }, [])

    return (
        <Box sx={{mt: '3px',}}>
            <Card sx={{padding: 2}}>
                {
                    {
                        1:
                        <Box>
                            <Typography textAlign='center' sx={{mb: 2}}>
                                Ваш уровень: {status.statusName}
                            </Typography>

                            <Card sx={{backgroundColor: alpha("#d1b280", '1'), padding: "7px", color: 'white', mb: 1, display: 'flex'}}>
                                <Typography sx={{width: '50%'}}>
                                    Скидка: 8%
                                </Typography> 
                                <Typography sx={{width: '50%'}} textAlign='right'>
                                    Золотой
                                </Typography>
                            </Card>
                            <Card sx={{backgroundColor: alpha("#c0c0c0", '0.3'), padding: "7px", color: 'white', mb: 1, display: 'flex'}}>
                                <Typography sx={{width: '50%'}}>
                                    Скидка: 5%
                                </Typography>
                                <Typography sx={{width: '50%'}} textAlign='right'>
                                    Серебрянный
                                </Typography>
                            </Card>
                            <Card sx={{backgroundColor: alpha("#CD7F32", '0.3'), padding: "7px", color: 'white', mb: 1, display: 'flex'}}>
                                <Typography sx={{width: '50%'}}>
                                    Скидка: 3%
                                </Typography>
                                <Typography sx={{width: '50%'}} textAlign='right'>
                                    Бронзовый
                                </Typography>
                            </Card>
                            <Card sx={{backgroundColor: alpha("#ABCDEF", '0.3'), padding: "7px", color: 'white', mb: 1, display: 'flex'}}>
                                <Typography sx={{width: '50%'}}>
                                    Скидка: 0%
                                </Typography>
                                <Typography sx={{width: '50%'}} textAlign='right'>
                                    Платиновый
                                </Typography>
                            </Card>
                        </Box>,
                        2:
                        <Box>
                            <Typography textAlign='center' sx={{mb: 2}}>
                                Ваш уровень: {status.statusName}
                            </Typography>
                            <Card sx={{backgroundColor: alpha("#d1b280", '1'), padding: "7px", color: 'white', mb: 1, display: 'flex'}}>
                                <Typography sx={{width: '50%'}}>
                                    Скидка: 8%
                                </Typography> 
                                <Typography sx={{width: '50%'}} textAlign='right'>
                                    Золотой
                                </Typography>
                            </Card>
                            <Card sx={{backgroundColor: alpha("#c0c0c0", '0.3'), padding: "7px", color: 'white', mb: 1, display: 'flex'}}>
                                <Typography sx={{width: '50%'}}>
                                    Скидка: 5%
                                </Typography>
                                <Typography sx={{width: '50%'}} textAlign='right'>
                                    Серебрянный
                                </Typography>
                            </Card>
                            <Card sx={{backgroundColor: alpha("#CD7F32", '0.3'), padding: "7px", color: 'white', mb: 1, display: 'flex'}}>
                                <Typography sx={{width: '50%'}}>
                                    Скидка: 3%
                                </Typography>
                                <Typography sx={{width: '50%'}} textAlign='right'>
                                    Бронзовый
                                </Typography>
                            </Card>
                            <Card sx={{backgroundColor: alpha("#ABCDEF", '0.3'), padding: "7px", color: 'white', mb: 1, display: 'flex'}}>
                                <Typography sx={{width: '50%'}}>
                                    Скидка: 0%
                                </Typography>
                                <Typography sx={{width: '50%'}} textAlign='right'>
                                    Платиновый
                                </Typography>
                            </Card>
                            <Typography textAlign='center' sx={{mb: 2}}>
                                Осталось {status.toNext} руб. до следущего уровня
                            </Typography>
                        </Box>
                        ,
                        3:
                        <Box>
                            <Typography textAlign='center' sx={{mb: 2}}>
                                Ваш уровень: {status.statusName}
                            </Typography>
                            <Card sx={{backgroundColor: alpha("#d1b280", '1'), padding: "7px", color: 'white', mb: 1, display: 'flex'}}>
                                <Typography sx={{width: '50%'}}>
                                    Скидка: 8%
                                </Typography> 
                                <Typography sx={{width: '50%'}} textAlign='right'>
                                    Золотой
                                </Typography>
                            </Card>
                            <Card sx={{backgroundColor: alpha("#c0c0c0", '0.3'), padding: "7px", color: 'white', mb: 1, display: 'flex'}}>
                                <Typography sx={{width: '50%'}}>
                                    Скидка: 5%
                                </Typography>
                                <Typography sx={{width: '50%'}} textAlign='right'>
                                    Серебрянный
                                </Typography>
                            </Card>
                            <Card sx={{backgroundColor: alpha("#CD7F32", '0.3'), padding: "7px", color: 'white', mb: 1, display: 'flex'}}>
                                <Typography sx={{width: '50%'}}>
                                    Скидка: 3%
                                </Typography>
                                <Typography sx={{width: '50%'}} textAlign='right'>
                                    Бронзовый
                                </Typography>
                            </Card>
                            <Card sx={{backgroundColor: alpha("#ABCDEF", '0.3'), padding: "7px", color: 'white', mb: 1, display: 'flex'}}>
                                <Typography sx={{width: '50%'}}>
                                    Скидка: 0%
                                </Typography>
                                <Typography sx={{width: '50%'}} textAlign='right'>
                                    Платиновый
                                </Typography>
                            </Card>
                            <Typography textAlign='center' sx={{mb: 2}}>
                                Осталось {status.toNext} руб. до следущего уровня
                            </Typography>
                        </Box>,
                        4:
                        <Box>
                            <Typography textAlign='center' sx={{mb: 2}}>
                                Ваш уровень: {status.statusName}
                            </Typography>
                            <Card sx={{backgroundColor: alpha("#d1b280", '1'), padding: "7px", color: 'white', mb: 1, display: 'flex'}}>
                                <Typography sx={{width: '50%'}}>
                                    Скидка: 8%
                                </Typography> 
                                <Typography sx={{width: '50%'}} textAlign='right'>
                                    Золотой
                                </Typography>
                            </Card>
                            <Card sx={{backgroundColor: alpha("#c0c0c0", '0.3'), padding: "7px", color: 'white', mb: 1, display: 'flex'}}>
                                <Typography sx={{width: '50%'}}>
                                    Скидка: 5%
                                </Typography>
                                <Typography sx={{width: '50%'}} textAlign='right'>
                                    Серебрянный
                                </Typography>
                            </Card>
                            <Card sx={{backgroundColor: alpha("#CD7F32", '0.3'), padding: "7px", color: 'white', mb: 1, display: 'flex'}}>
                                <Typography sx={{width: '50%'}}>
                                    Скидка: 3%
                                </Typography>
                                <Typography sx={{width: '50%'}} textAlign='right'>
                                    Бронзовый
                                </Typography>
                            </Card>
                            <Card sx={{backgroundColor: alpha("#ABCDEF", '0.3'), padding: "7px", color: 'white', mb: 1, display: 'flex'}}>
                                <Typography sx={{width: '50%'}}>
                                    Скидка: 0%
                                </Typography>
                                <Typography sx={{width: '50%'}} textAlign='right'>
                                    Платиновый
                                </Typography>
                            </Card>
                            <Typography textAlign='center' sx={{mb: 2}}>
                                Осталось {status.toNext} руб. до следущего уровня
                            </Typography>
                        </Box>,
                    }
                    [status.id]
                }
            </Card>
            <Card sx={{padding: 2, mt: '1em'}}>
                <Typography sx={{ fontSize: 16, textAlign: 'center', m: 'auto'}}>
                    Мои заказы
                </Typography>
            </Card>
            {orders.map((order) => (
                <Card sx={{mt: '7px', color: 'white', backgroundColor: '#594d46'}} key={order.id} >
                    <Grid container columns={5} spacing={1} sx={{overflow: 'auto', width: '100%', padding: 5, maxWidth: '100%', m: 'auto', backgroundColor: "#efefef", maxHeight: 255, height: 255}}>
                        {order.orderLines.map((item) => (
                            <Grid item md={1} key={item.name}>
                                <Tooltip title={item.name + " " + item.amount + " шт."} arrow>
                                    <Card sx={{height: "100%", maxWidth: '100%', padding: 1}}>
                                        <Box key={item.id} sx={{maxheight:150, m: 'auto', height: 150, maxWidth: "100%", display: 'flex', alignItems: 'flex-center', flexDirection: 'row'}}>
                                            <Box
                                                component="img"
                                                sx={{
                                                    maxWidth: '100%',
                                                    objectFit:'contain',
                                                    height: '100%', 
                                                    alignContent: 'center',
                                                    m: 'auto'
                                                }}
                                                alt="Изображение"
                                                src={item.photo}
                                            />
                                        </Box>                          
                                    </Card>
                                </Tooltip>
                            </Grid>
                        ))}
                    </Grid>
                    <Box sx={{display: 'flex', alignItems: 'flex-center', flexDirection: 'row'}}>
                        <Typography sx={{ fontSize: 16, textAlign: 'left', width: "50%", padding: 2}}>
                            {"Пункт выдачи: " + order.pickPoint}<br/>
                            {"Статус заказа: " + order.orderStatus}
                        </Typography>
                        <Typography sx={{ fontSize: 16, textAlign: 'right', width: "50%", padding: 2}}>
                            {"Итого: " + order.sum + " руб."}<br/>
                            {"Дата: " + order.date.slice(0, 10)}
                        </Typography>
                    </Box>
                </Card>
            ))}
            <Card sx={{padding: 2, display: 'flex', mt: '1em'}}>
                <Button theme={theme} color="button" variant="contained" sx={{m: 'auto'}} onClick={() => logOut()}>
                    Выйти
                </Button>
            </Card>
        </Box>
    )
}

export default User;



