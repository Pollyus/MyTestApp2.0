import { createTheme } from '@mui/material/styles';

const theme = createTheme({
    palette: {
      primary: {
        main: "#080706",
      },
      secondary: {
        main: '#efefef',  
      },
      button: {
        main: '#d1b280',
        contrastText: '#ffffff'
      },
      background: {
        main: '#594d46',
      },
    },
  });

  export default theme;