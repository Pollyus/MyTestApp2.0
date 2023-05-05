import DialogTitle from '@mui/material/DialogTitle';
import Dialog from '@mui/material/Dialog';
import Card from '@mui/material/Card';
import React, { useEffect, useState } from 'react';
import axios from 'axios';
import theme from '../Style/theme'
import { Typography, Container, Grid, Box, Button, TextField } from '@mui/material';
import CloseIcon from '@mui/icons-material/Close';
import '../Profile/LogoutBox.css'

function LogoutBox(props) {
    const { onClose, openLogout } = props;

    const handleClose = () => {
      onClose();
    };

    return (
        <Dialog onClose={handleClose} open={openLogout} sx={{m: 'auto'}}>
            <Box  sx={{width: 450, height: 200,display: 'flex', flexDirection: 'column', justifyContent: 'space-between', m: 'auto' }}>
                <CloseIcon sx={{ width: 850, marginTop: '20px'}} onClose={handleClose}/>
                <Typography sx={{width: "100%", textAlign: 'center', mt: 3, fontSize: 16}}>Вы уверены, что хотите выйти?</Typography>
                
                <Box sx={{padding: 1, display: 'flex', alignItems: 'center', flexDirection: 'row'}}> 
                    <Button theme={theme} sx={{m: 'auto', mb: 3}} color="button" variant="contained">
                        Выйти
                    </Button>
                </Box>
            </Box>
        </Dialog>
    );
  }

export default LogoutBox;