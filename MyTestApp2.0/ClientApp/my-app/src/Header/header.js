import { AppBar, Toolbar, IconButton, Typography } from '@mui/material';

import AccountBoxIcon from '@mui/icons-material/AccountBox';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import MenuIcon from '@mui/icons-material/Menu';
import { Link } from 'react-router-dom';

import theme from '../theme'

const Header = () => {

  return (
    <AppBar theme={theme} position="fixed" color='primary'>
      <Toolbar>
        <Link to="/">
          <IconButton
            size="large"
            edge="start"
            aria-label="menu"
            sx={{ mr: 2, color: "white" }}
          >
            <MenuIcon />
          </IconButton>
        </Link>

        <Typography variant="h5" component="div" sx={{ flexGrow: 1, color: "white" }}>
          MyTests
        </Typography>


        <Link to="/profile">
          <IconButton
            size="large"
            aria-label="account of current user"
            aria-controls="menu-appbar"
            aria-haspopup="true"
            sx={{ color: "white" }}
          >
            <AccountBoxIcon />
          </IconButton>
        </Link>
        <Link to="/cart">
          <IconButton
            size="large"
            aria-label="account of current user"
            aria-controls="menu-appbar"
            aria-haspopup="true"
            sx={{ color: "white" }}
          >
            <ShoppingCartIcon />
          </IconButton>
        </Link>
      </Toolbar>
    </AppBar>
  )
}

export default Header;