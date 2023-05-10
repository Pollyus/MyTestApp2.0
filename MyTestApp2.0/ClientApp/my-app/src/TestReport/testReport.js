import { Typography, Container, Grid, Box, Button, TextField, ListItem } from "@mui/material";
import React, { useEffect, useState } from "react";
import './testReport.css'

function TestReport(){

    const [projects, setProjects] = useState([]);
    const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch(`https://localhost:32768/api/TestsGroup/get/all`)
        .then((response) => response.json())
        .then((data) => setProjects(data));
    setLoading(false);
}, []);

if (loading) {
    return <h1>Loading...</h1>
}


    return (
    <container className='TestReportStyle'>
        <h1> Xml файл</h1>
        <Box>
        {projects?.map((project) => (
                    <ListItem key={project.id}>
                        {project.xmlReport}
                    </ListItem>
                ))}
        </Box>
    </container>
    );
  }

  export default TestReport;
