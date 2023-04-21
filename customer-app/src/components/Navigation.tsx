// import React, { useState } from 'react';
// import { Link } from 'react-router-dom';
// import Tooltip from '@mui/material/Tooltip';
// import {
//   Drawer,
//   List,
//   ListItem,
//   ListItemIcon,
//   ListItemText,
//   IconButton,
//   Divider,
//   Toolbar,
//   Typography,
// } from '@mui/material';
// import {
//   Menu as MenuIcon,
//   Dashboard as DashboardIcon,
//   Add as AddIcon,
//   PeopleOutlined as PeopleIcon,
// } from '@mui/icons-material';
// import Avatar from '@mui/material/Avatar';
// import Menu from '@mui/material/Menu';
// import MenuItem from '@mui/material/MenuItem';
// import Logout from '@mui/icons-material/Logout';

// const menuItems = [ 
//   {
//     text: "Dashboard",
//     icon: <DashboardIcon />,
//     link: "/",
//   },
//   {
//     text: "Customers",
//     icon: <PeopleIcon />,
//     children: [
//       {
//         text: "Add Customer",
//         icon: <AddIcon />,
//         link: "/add",
//       },
//       {

//         text: "View Customers",
//         icon: <PeopleIcon />,
//         link: "/customers",
//       }
//     ],
//   },
// ];

// const Navigation = () => {
//   const [sidebarOpen, setSidebarOpen] = useState(false);
//   const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
//   const [customersOpen, setCustomersOpen] = useState(false);
//   const Open = Boolean(anchorEl);
//   const handleClick = (event: React.MouseEvent<HTMLElement>) => {
//     setAnchorEl(event.currentTarget);
//   };
//   const handleClose = () => {
//     setAnchorEl(null);
//   };

//   const toggleDrawer = () => {
//     setSidebarOpen(!sidebarOpen);
//   };

//   const handleCustomersClick = () => {
//     setCustomersOpen(!customersOpen);
//   };

//   return (
//     <>
//       <Toolbar style={{backgroundColor:'#4447916e'}}>
//         <IconButton
//           edge="start"
//           color="default"
//           aria-label="menu"
//           onClick={toggleDrawer}
//         >
//         <Typography variant="h6">Customer CRUD</Typography>&nbsp;&nbsp;
//           <MenuIcon />
//         </IconButton>
//         <Tooltip title="Account settings">
//           <IconButton
//           style={{marginLeft:'1100px'}}
//             onClick={handleClick}
//             size="small"
//             sx={{ ml: 2 }}
//             aria-controls={Open ? 'account-menu' : undefined}
//             aria-haspopup="true"
//             aria-expanded={Open ? 'true' : undefined}
//           >
//             <Avatar sx={{ width: 32, height: 32 }}>P</Avatar>
//           </IconButton>
//         </Tooltip>
//       </Toolbar>
//       <Menu
//         anchorEl={anchorEl}
//         id="account-menu"
//         open={Open}
//         onClose={handleClose}
//         onClick={handleClose}
//         PaperProps={{
//           elevation: 0,
//           sx: {
//             overflow: 'visible',
//             filter: 'drop-shadow(0px 2px 8px rgba(0,0,0,0.32))',
//             mt: 1.5,
//             '& .MuiAvatar-root': {
//               width: 32,
//               height: 32,
//               ml: -0.5,
//               mr: 1,
//             },
//             '&:before': {
//               content: '""',
//               display: 'block',
//               position: 'absolute',
//               top: 0,
//               right: 14,
//               width: 10,
//               height: 10,
//               bgcolor: 'background.paper',
//               transform: 'translateY(-50%) rotate(45deg)',
//               zIndex: 0,
//             },
//           },
//         }}
//         transformOrigin={{ horizontal: 'right', vertical: 'top' }}
//         anchorOrigin={{ horizontal: 'right', vertical: 'bottom' }}
//       >
//         <MenuItem onClick={handleClose}>
//           <Avatar /> Username
//         </MenuItem>
//         <MenuItem onClick={handleClose}>
//           <ListItemIcon>
//             <Logout fontSize="small" />
//           </ListItemIcon>
//           Logout
//         </MenuItem>
//       </Menu>
//       <Drawer anchor="left" open={sidebarOpen} onClose={toggleDrawer}>
//         {menuItems.map((item: any, index: number) => {
//           return (
//             <div key={index}>
//               <ListItem button component={Link} to={item.link} onClick={toggleDrawer}>
//                 <ListItemIcon>{item.icon}</ListItemIcon>
//                 <ListItemText primary={item.text} />
//               </ListItem>
//               {item.children && (
//                 <List>
//                   {item.children.map((childItem: any, childIndex: number) => {
//                     return (
//                       <ListItem
//                         key={`${index}-${childIndex}`}
//                         button
//                         sx={{ pl: 4 }}
//                         component={Link}
//                         to={childItem.link}
//                         onClick={toggleDrawer}
//                       >
//                         <ListItemIcon>{childItem.icon}</ListItemIcon>
//                         <ListItemText primary={childItem.text} />
//                       </ListItem>
//                     );
//                   })}
//                 </List>
//               )}
//               {index < menuItems.length - 1 && <Divider />}
//             </div>
//           );
//         })}
//       </Drawer>
//     </>
//   );
// };

// export default Navigation;




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

  const [anchor, setAnchor] = React.useState<null | HTMLElement>(null);
  const Opened = Boolean(anchor);
  const handleClicked = (event: React.MouseEvent<HTMLElement>) => {
    setAnchor(event.currentTarget);
  };
  const handleClosed = () => {
    setAnchor(null);
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
            onClick={handleClicked}
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
