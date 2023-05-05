import { Typography, Container, Grid, Box, Button, TextField, ListItem } from "@mui/material";
import React, { useEffect } from 'react';
import { useState } from 'react';
import './project.css';
import theme from '../Style/theme';
import axios from 'axios';
import AddProject from "./addProject";
import "../index";
import { styled } from '@mui/material/styles';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

const StyledTableCell = styled(TableCell)(({ theme }) => ({
    [`&.${tableCellClasses.head}`]: {
      backgroundColor: "#81B809",
      color: theme.palette.common.white,
      fontSize: 25,
    },
    [`&.${tableCellClasses.body}`]: {
      fontSize: 20,
    },
  }));
  
  const StyledTableRow = styled(TableRow)(({ theme }) => ({
    '&:nth-of-type(odd)': {
      backgroundColor: "#D5FC7F",
    },
    // hide last border
    '&:last-child td, &:last-child th': {
      border: 0,
    },
  }));

  function createData(name, calories, fat, carbs, protein) {
    return { name, calories, fat, carbs, protein };
  }
  
  

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
        <Container>
        <Box>
            <h1 className="text">Посмотреть все проекты</h1>
            {/* <Box>
                {projects?.map((project) => (
                    <ListItem key={project.id}>
                        {project.name}
                        {project.path}
                    </ListItem>
                ))}
            </Box> */}

        </Box>
        <TableContainer component={Paper}>
        <Table sx={{ minWidth: 700 }} aria-label="customized table">
          <TableHead>
            <TableRow>
              <StyledTableCell className="TableText">Имя проекта</StyledTableCell>
              <StyledTableCell align="right">Путь к проекту</StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {projects.map((row) => (
              <StyledTableRow key={row.name}>
                <StyledTableCell component="th" scope="row">
                  {row.name}
                </StyledTableCell>
                <StyledTableCell align="right">{row.path}</StyledTableCell>

              </StyledTableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      <h2>Добавить проект</h2>
            <Container>
                <AddProject></AddProject>
            </Container>
      </Container>
      
    )
}

export default GetProjects;