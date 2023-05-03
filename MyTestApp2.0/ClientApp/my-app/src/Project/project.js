import { Typography, Container, Grid, Box, Button, TextField, ListItem } from "@mui/material";
import React, { useEffect } from 'react';
import { useState } from 'react';
import './project.css';
import theme from '../theme';
import axios from 'axios';
import AddProject from "./addProject";

//import MailIcon from '@mui/icons-material/Mail';
import KeyIcon from '@mui/icons-material/Key';
import { DriveFileRenameOutline } from "@mui/icons-material";
import { Route } from "@mui/icons-material";

function GetProjects() {
    
    const [projects, setProjects] = useState([]);
    const [loading, setLoading] = useState(true);
    const [name, setName] = React.useState("");
    const [path, setPath] = React.useState("");
    const [errors, setErrors] = useState([]);

    const handleNameChange = (event) => {
        setName(event.target.value);
    }

    const handlePathChange = (event) => {
        setPath(event.target.value);
    }

    useEffect(() => {
        fetch(`https://localhost:32768/api/project/get/all`)
            .then((response) => response.json())
            .then((data) => setProjects(data));
        setLoading(false);
    }, []);

    if (loading) {
        return <h1>Loading...</h1>
    }

    // const addProject = (e) => {
    //     e.preventDefault();
    //     const value = { "name": name, "path": path};
    //     axios.post(
    //         'https://localhost:32768/api/Project/add', value, { withCredentials: true }
    //     )
    //         .then((response) => {
    //             console.log(response.data.message);
    //             typeof response.data.error !== "undefined" && setErrors(response.data.error)
                
    //         })
    //         .catch(console.error);
    // }
 

    return (
        <Box>
            <h1 className="text">Посмотреть все проекты</h1>
            <Box>
                {projects?.map((project) => (
                    <ListItem key={project.id}>
                        {project.name}
                        {project.path}
                    </ListItem>
                ))}
            </Box>
            <h2>Добавить проект</h2>
            <Container>
                <AddProject></AddProject>
            </Container>
           
        </Box>
    )
}

export default GetProjects;