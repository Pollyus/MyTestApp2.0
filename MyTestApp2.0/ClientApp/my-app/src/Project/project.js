import { Container, Typography, Box, List, ListItem } from "@mui/material";
import React, { useEffect } from 'react';
import { useState } from 'react';
import axios from 'axios';
import './project.css'
import theme from '../theme';

function GetProjects() {
    const [projects, setProjects] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        fetch(`https://localhost:32768/api/project/get/all`)
            .then((response) => response.json())
            .then((data) => setProjects(data));
        setLoading(false);
    }, []);

    if (loading) {
        return <h1>Loading...</h1>
    }

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
            <h2>Test</h2>

        </Box>
    )
}

export default GetProjects;