import { AppBar, Toolbar, IconButton, Typography } from '@mui/material';
import React, { useEffect } from 'react';
import AccountBoxIcon from '@mui/icons-material/AccountBox';
import GradingIcon from '@mui/icons-material/Grading';
import MenuIcon from '@mui/icons-material/Menu';
import { Link } from 'react-router-dom';

import theme from '../Style/theme'
import Menu from './Menu/menu';
import { Container } from '@mui/system';

import HomeIcon from '@mui/icons-material/Home';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import LaptopChromebookIcon from '@mui/icons-material/LaptopChromebook';
import ChecklistIcon from '@mui/icons-material/Checklist';
import RocketLaunchIcon from '@mui/icons-material/RocketLaunch';
import { useState } from 'react';
import LogoutIcon from '@mui/icons-material/Logout';
import LogoutBox from '../Profile/LogoutBox';

const Header = () => {
  const [menuActive, setMenuActive] = useState(false);
  const [openLogout, setOpenLogout] = React.useState(false);

  const logOut = () => {
    setOpenLogout(true);
  }

  const handleClose = (value) => {
    setOpenLogout(false);
  };

  const items = [{ value: "Главная", href: '/', icon: <HomeIcon /> },
  { value: "Профиль", href: '/profile', icon: <AccountCircleIcon /> },
  { value: "Проекты", href: '/project', icon: <LaptopChromebookIcon /> },
  { value: "Результаты", href: '/testResult', icon: <ChecklistIcon /> },
  { value: "Запустить тест", href: '/inputData', icon: <RocketLaunchIcon /> }]
  
  return (
    <Container>
      <AppBar theme={theme} position="fixed" color='primary'>
        <Toolbar>
          
            <IconButton
              size="large"
              edge="start"
              aria-label="menu"
              sx={{ mr: 2, color: "white" }}
              onClick={() => setMenuActive(!menuActive)}
            >
              <MenuIcon />
              <span />
            </IconButton>
           
           <Typography variant="h5" component="div" sx={{ flexGrow: 1, color: "white" }}> </Typography>

          {/* <Link to="/"> */}
                {/* {items.map(item => 
                <Typography variant="h5" component="div" sx={{ flexGrow: 1, color: "white" }}>
                  {item.value}
                </Typography>
                )}  */}
          {/* </Link> */}


          <div className='icons-right' >
            <Link to="/profile">
              <IconButton
                className='IconButton'
                size="large"
                aria-label="account of current user"
                aria-controls="menu-appbar"
                aria-haspopup="true"
                sx={{ color: "white" }}
              >
                <AccountBoxIcon />
                <span />
              </IconButton>
            </Link>
            
            <Link to="#">
              <IconButton
                size="large"
                aria-label="account of current user"
                aria-controls="menu-appbar"
                aria-haspopup="true"
                sx={{ color: "white" }}
                onClick={logOut}
              >
                <LogoutIcon />
                { openLogout === true ? 
                <LogoutBox openLogout={openLogout} onClose={handleClose} /> : null }
              </IconButton>
            </Link>
          </div>
        </Toolbar>
        <Menu active={menuActive} setActive={setMenuActive} header={'MyTests'}  items={items}>
      </Menu>
      </AppBar>
    </Container>
  )
}

export default Header;