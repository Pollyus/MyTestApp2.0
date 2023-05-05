import { Typography, Card, Button } from "@mui/material"
import theme from '../Style/theme';

const Admin = ({logOut}) => {
    return(
        <Card sx={{padding: 2}}>
            <Typography>
                Да, я админ:)
            </Typography>
            
            <Button theme={theme} color="button" variant="contained" sx={{m: 'auto'}} onClick={() => logOut()}>
                Выйти
            </Button>
        </Card>
    )
}

export default Admin;