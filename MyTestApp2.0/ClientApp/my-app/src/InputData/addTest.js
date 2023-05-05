import DialogTitle from '@mui/material/DialogTitle';
import Dialog from '@mui/material/Dialog';
import Card from '@mui/material/Card';
import React, { useEffect, useState } from 'react';
import axios from 'axios';
import theme from '../Style/theme'
import { Typography, Container, Grid, Box, Button, TextField } from '@mui/material';

import { DriveFileRenameOutline, Route } from '@mui/icons-material';


function AddTest() {
  
    const [testName, setName] = React.useState("");
    const [testPath, setPath] = React.useState("");
    const [errors, setErrors] = useState([]);


    const handleNameChange = (event) => {
        setName(event.target.value);
    }

    const handlePathChange = (event) => {
        setPath(event.target.value);
    }

    const AddData = (e) => {
        e.preventDefault();
        
        const value = { "TestName": testName, "TestPath": testPath};
        axios.post(
            'https://localhost:32768/api/Test/add', value, { withCredentials: true }
        )
        
            .then((response) => { 
                console.log(response.data.message);
                typeof response.data.error !== "undefined" && setErrors(response.data.error)
            })
            .catch(console.error);
            
    }


    return (
        <Box sx={{ width: 450, height: 350, display: 'flex', flexDirection: 'column', justifyContent: 'space-between', m: 'auto' }}>
                <Typography sx={{ width: "100%", textAlign: 'center', mt: 3, fontSize: 16 }}>Введите название проекта и путь к нему</Typography>
                 <Box sx={{ width: '100%', display: 'flex', flexDirection: 'column', alignItems: 'center', m: 'auto' }}>
                     <Box sx={{ padding: 1, display: 'flex', alignItems: 'center', flexDirection: 'row' }}>
                         <DriveFileRenameOutline theme={theme} color="button" sx={{ height: 30, width: 30, mt: 'auto', mb: 'auto' }} />
                        <TextField
                           required
                             label="Имя проекта"
                             value={testName}
                            onChange={handleNameChange}
                         />
                     </Box>
                     <Box sx={{ padding: 1, display: 'flex', alignItems: 'center', flexDirection: 'row' }}>
                         <Route theme={theme} color="button" sx={{ height: 30, width: 30, mt: 'auto', mb: 'auto' }} />
                         <TextField
                             sx={{ width: 200, ml: 1 }}
                           
                            required
                            label="Путь к проекту"
                            autoComplete="path"
                            value={testPath}
                            onChange={handlePathChange}
                        />
                     </Box>
                </Box>

                <Box sx={{ padding: 1, display: 'flex', alignItems: 'center', flexDirection: 'row' }}>
                    <Button theme={theme} sx={{ m: 'auto', mb: 3 }} color="button" variant="contained" onClick={AddData}> 
                        Добавить
                    </Button>
                </Box>
            </Box>
            
    )
  }

export default AddTest;
