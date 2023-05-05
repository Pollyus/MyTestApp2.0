import DialogTitle from '@mui/material/DialogTitle';
import Dialog from '@mui/material/Dialog';
import Card from '@mui/material/Card';
import React, { useEffect, useState } from 'react';
import axios from 'axios';
import theme from '../Style/theme'
import { Typography, Container, Grid, Box, Button, TextField } from '@mui/material';

import { DriveFileRenameOutline, Route } from '@mui/icons-material';


function AddProject() {
  
    const [projectName, setName] = React.useState("");
    const [projectPath, setPath] = React.useState("");
    const [errors, setErrors] = useState([]);


    const handleNameChange = (event) => {
        setName(event.target.value);
    }

    const handlePathChange = (event) => {
        setPath(event.target.value);
    }

    const AddData = (e) => {
        e.preventDefault();
        
        const value = { "ProjectName": projectName, "ProjectPath": projectPath};
        axios.post(
            'https://localhost:32768/api/Project/add', value, { withCredentials: true }
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
                             value={projectName}
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
                            value={projectPath}
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

export default AddProject;
/* // import React, { useState, useEffect } from 'react';

// function AddProject(props) { */
    
//     const [posts, setPosts] = useState([]);

//    useEffect(() => {
//       fetch('https://localhost:32768/api/Project/add', {
//         method: 'POST',
//         headers: {
//             Accept: 'application/json',
//             'Content-Type': 'application/json',
//           },
//           body: JSON.stringify({
//             projectName: this.projectName.value,
//             projectPath: this.projectPath.value,
//           }),
//    })
//          .then((res) => res.json())
//          .then((data) => {
//             console.log(data);
//             setPosts(data);
//          })
//          .catch((err) => {
//             console.log(err.message);
//          });
//    }, []);

//    return (
//       <>
//          <div className="add-post-container">
//             <form>
//                <input ref={(ref) => {this.projectName = ref}} placeholder="Name" type="text" className="form-control" name="projectName"/><br />
//                <input ref={(ref) => {this.projectPath = ref}} placeholder="Path" type="text" className="form-control" name="projectPath" /><br />
//                <button type="submit">Add project</button>
//             </form>
//          </div>
//          <div className="posts-container">
//             {posts.map((post) => {
//                return (
//                   <div className="post-card" key={post.id}>
//                      <h2 className="post-title">{post.title}</h2>
//                      <p className="post-body">{post.body}</p>
//                      <div className="button">
//                         <div className="delete-btn">Delete</div>
//                      </div>
//                   </div>
//                );
//             })}
//          </div>
//       </>
//    );
// }

// export default AddProject;



// //  {/* <Box sx={{ width: 450, height: 350, display: 'flex', flexDirection: 'column', justifyContent: 'space-between', m: 'auto' }}>
// //                 <Typography sx={{ width: "100%", textAlign: 'center', mt: 3, fontSize: 16 }}>Введите название проекта и путь к нему</Typography>
// //                 <Box sx={{ width: '100%', display: 'flex', flexDirection: 'column', alignItems: 'center', m: 'auto' }}>
// //                     <Box sx={{ padding: 1, display: 'flex', alignItems: 'center', flexDirection: 'row' }}>
// //                         <DriveFileRenameOutline theme={theme} color="button" sx={{ height: 30, width: 30, mt: 'auto', mb: 'auto' }} />
// //                         <TextField
// //                             sx={{ width: 200, ml: 1 }}
// //                             required
// //                             label="Имя проекта"
// //                             onChange={handleNameChange}
// //                         />
// //                     </Box>
// //                     <Box sx={{ padding: 1, display: 'flex', alignItems: 'center', flexDirection: 'row' }}>
// //                         <Route theme={theme} color="button" sx={{ height: 30, width: 30, mt: 'auto', mb: 'auto' }} />
// //                         <TextField
// //                             sx={{ width: 200, ml: 1 }}
                           
// //                             required
// //                             label="Путь к проекту"
// //                             autoComplete="path"
// //                             onChange={handlePathChange}
// //                         />
// //                     </Box>
// //                 </Box>

// //                 <Box sx={{ padding: 1, display: 'flex', alignItems: 'center', flexDirection: 'row' }}>
// //                     <Button theme={theme} sx={{ m: 'auto', mb: 3 }} color="button" variant="contained" onClick={addProject}> 
// //                         Добавить
// //                     </Button>
// //                 </Box>
// //             </Box> */}