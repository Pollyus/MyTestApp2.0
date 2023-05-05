import { createTheme } from '@mui/material/styles';
import {green, purpule, yellow, pink, white} from "./color";

const theme = createTheme({
    palette: {
      primary: {
        main: purpule[300],
      },
      secondary: {
        main: green[300],  
      },
      button: {
        main: purpule[400],
        contrastText: white[0],
      },
      background: {
        main: white[0],
      },
      
      
    },
  });

  export default theme;