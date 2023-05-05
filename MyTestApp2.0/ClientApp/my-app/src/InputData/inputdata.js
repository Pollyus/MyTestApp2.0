import React, { Component } from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import theme from '../Style/theme'
import { Typography, Button, Container } from '@mui/material';
import SendIcon from '@mui/icons-material/Send';
import './inputData.css'
import AddTest from "./addTest";

export class InputData extends Component {
    static displayName = InputData.name;

    render() {
        return (
            <Container>
                <div className='BackImage'>
                    <Container>
                        <AddTest />
                    </Container>
                </div>
            </Container>
        );
    }
}