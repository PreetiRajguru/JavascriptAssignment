import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import Tooltip from '@mui/material/Tooltip';
import {
  Drawer,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  IconButton,
  Toolbar,
  Typography,
  Menu,
  MenuItem,
} from '@mui/material';
import {
  Menu as MenuIcon,
  Dashboard as DashboardIcon,
  Add as AddIcon,
  PeopleOutlined as PeopleIcon,
} from '@mui/icons-material';
import Avatar from '@mui/material/Avatar';

const Navigation = () => {
  const [sidebarOpen, setSidebarOpen] = useState(false);
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
  const Open = Boolean(anchorEl);
  const handleClick = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };

  const toggleDrawer = () => {
    setSidebarOpen(!sidebarOpen);
  };

  return (
    <>
      <Toolbar style={{backgroundColor:'#4447916e'}}>
        <IconButton
          edge="start"
          color="default"
          aria-label="menu"
          onClick={toggleDrawer}
        >
        <Typography variant="h6">Customer CRUD</Typography>&nbsp;&nbsp;
          <MenuIcon />
        </IconButton>
        <Tooltip title="Account settings">
          <IconButton
          style={{marginLeft:'1100px'}}
            onClick={handleClick}
            size="small"
            sx={{ ml: 2 }}
            aria-controls={Open ? 'account-menu' : undefined}
            aria-haspopup="true"
            aria-expanded={Open ? 'true' : undefined}
          >
            <Avatar sx={{ width: 32, height: 32 }}>P</Avatar>
          </IconButton>
        </Tooltip>
      </Toolbar>
      <Menu
        id="customers-menu"
        anchorEl={anchorEl}
        open={Open}
        onClose={handleClose}
      >
        <MenuItem component={Link} to="/add" onClick={handleClose}>
          <ListItemIcon>
            <AddIcon />
          </ListItemIcon>
          <ListItemText primary="Add Customer" />
        </MenuItem>
        <MenuItem component={Link} to="/customers" onClick={handleClose}>
          <ListItemIcon>
            <PeopleIcon />
          </ListItemIcon>
          <ListItemText primary="View Customers" />
        </MenuItem>
      </Menu>
      <Drawer anchor="left" open={sidebarOpen} onClose={toggleDrawer}>
        <List>
          <ListItem button component={Link} to="/" onClick={toggleDrawer}>
            <ListItemIcon><DashboardIcon /></ListItemIcon>
            <ListItemText primary="Dashboard" />
          </ListItem>
          <ListItem button onClick={handleClick}>
            <ListItemIcon><PeopleIcon /></ListItemIcon>
            <ListItemText primary="Customers" />
          </ListItem>
        </List>
      </Drawer>
    </>
  );
};

export default Navigation;
