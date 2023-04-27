import * as React from 'react';
import { useNavigate } from 'react-router-dom'
import { styled, useTheme } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Drawer from '@mui/material/Drawer';
import CssBaseline from '@mui/material/CssBaseline';
import MuiAppBar, { AppBarProps as MuiAppBarProps } from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import List from '@mui/material/List';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import ChevronRightIcon from '@mui/icons-material/ChevronRight';
import { Button, Menu, MenuItem } from '@mui/material';

const drawerWidth = 240;

const Main = styled('main', { shouldForwardProp: (prop) => prop !== 'open' })<{
  open?: boolean;
}>(({ theme, open }) => ({
  flexGrow: 1,
  padding: theme.spacing(3),
  transition: theme.transitions.create('margin', {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.leavingScreen,
  }),
  marginLeft: `-${drawerWidth}px`,
  ...(open && {
    transition: theme.transitions.create('margin', {
      easing: theme.transitions.easing.easeOut,
      duration: theme.transitions.duration.enteringScreen,
    }),
    marginLeft: 0,
  }),
}));

interface AppBarProps extends MuiAppBarProps {
  open?: boolean;
}

const AppBar = styled(MuiAppBar, {
  shouldForwardProp: (prop) => prop !== 'open',
})<AppBarProps>(({ theme, open }) => ({
  transition: theme.transitions.create(['margin', 'width'], {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.leavingScreen,
  }),
  ...(open && {
    width: `calc(100% - ${drawerWidth}px)`,
    marginLeft: `${drawerWidth}px`,
    transition: theme.transitions.create(['margin', 'width'], {
      easing: theme.transitions.easing.easeOut,
      duration: theme.transitions.duration.enteringScreen,
    }),
  }),
}));

const DrawerHeader = styled('div')(({ theme }) => ({
  display: 'flex',
  alignItems: 'center',
  padding: theme.spacing(0, 1),
  ...theme.mixins.toolbar,
  justifyContent: 'flex-end',
}));

export default function PersistentDrawerLeft() {
  const theme = useTheme();
  const [open, setOpen] = React.useState(true);
  const navigate = useNavigate();

  const handleDrawerOpen = () => {
    setOpen(true);
  };

  const handleDrawerClose = () => {
    setOpen(false);
  };

  const [matter, setMatter] = React.useState<null | HTMLElement>(null);
  const openedMatter = Boolean(matter);
  const handleClickedMatter = (event: React.MouseEvent<HTMLButtonElement>) => {
    setMatter(event.currentTarget);
  };
  const handleCloseMatter = () => {
    setMatter(null);
  };

  const GetMattersByClients = () => {
    handleDrawerClose();
    handleCloseMatter();
    navigate('/getmattersbyclients');
  }

  const GetMatterForClient = () => {
    handleDrawerClose();
    handleCloseMatter();
    navigate('/getmatterforclient');
  }

  const CreateMatter = () => {
    handleDrawerClose();
    handleCloseMatter();
    navigate('/creatematter');
  }

  const [invoice, setInvoice] = React.useState<null | HTMLElement>(null);
  const openedInvoice = Boolean(invoice);
  const handleClickedInvoice = (event: React.MouseEvent<HTMLButtonElement>) => {
    setInvoice(event.currentTarget);
  };
  const handleCloseInvoice = () => {
    setInvoice(null);
  };

  const GetInvoiceForMatter = () => {
    handleDrawerClose();
    handleCloseInvoice();
    navigate('/getinvoicesformatter');
  }

  const GetInvoicesByMatters = () => {
    handleDrawerClose();
    handleCloseInvoice();
    navigate('/getinvoicesbymatters');
  }

  const GetBillingByAttorneys = () => {
    handleDrawerClose();
    handleCloseBilling();
    navigate('/billingforattorney');
  }

  const [billing, setBilling] = React.useState<null | HTMLElement>(null);
  const openedBilling = Boolean(billing);
  const handleClickedBilling = (event: React.MouseEvent<HTMLButtonElement>) => {
    setBilling(event.currentTarget);
  };
  const handleCloseBilling = () => {
    setBilling(null);
  };

  return (
    <Box sx={{ display: 'flex' }}>
      <CssBaseline />
      <AppBar position="fixed" open={open}>
        <Toolbar>
          <IconButton
            color="inherit"
            aria-label="open drawer"
            onClick={handleDrawerOpen}
            edge="start"
            sx={{ mr: 2, ...(open && { display: 'none' }) }}
          >
            <MenuIcon />
          </IconButton>
          <Typography variant="h6" noWrap component="div">
            Court Matter
          </Typography>
        </Toolbar>
      </AppBar>
      <Drawer
        sx={{
          width: drawerWidth,
          flexShrink: 0,
          '& .MuiDrawer-paper': {
            width: drawerWidth,
            boxSizing: 'border-box',
          },
        }}
        variant="persistent"
        anchor="left"
        open={open}
      >

        <DrawerHeader>
          <IconButton onClick={handleDrawerClose}>
            {theme.direction === 'ltr' ? <ChevronLeftIcon /> : <ChevronRightIcon />}
          </IconButton>
        </DrawerHeader>

        <List>
          <div>
            <Button
              id="basic-button"
              aria-controls={open ? 'basic-menu' : undefined}
              aria-haspopup="true"
              aria-expanded={open ? 'true' : undefined}
              onClick={handleClickedMatter}
            >
              Matter
            </Button>

            <Menu
              id="basic-menu"
              anchorEl={matter}
              open={openedMatter}
              onClose={handleCloseMatter}
              MenuListProps={{
                'aria-labelledby': 'basic-button',
              }}
            >
              <MenuItem onClick={CreateMatter}>Create Matter</MenuItem>
              <MenuItem onClick={GetMatterForClient}>Matter For Client</MenuItem>
              <MenuItem onClick={GetMattersByClients}>Matters By Clients</MenuItem>
            </Menu>
          </div>

          <br></br><br></br>

          <div>
            <Button
              id="basic-button"
              aria-controls={open ? 'basic-menu' : undefined}
              aria-haspopup="true"
              aria-expanded={open ? 'true' : undefined}
              onClick={handleClickedInvoice}
            >
              Invoices
            </Button>

            <Menu
              id="basic-menu"
              anchorEl={invoice}
              open={openedInvoice}
              onClose={handleCloseInvoice}
              MenuListProps={{
                'aria-labelledby': 'basic-button'
              }}
            >
              <MenuItem onClick={GetInvoiceForMatter}>Invoices For Matter</MenuItem>
              <MenuItem onClick={GetInvoicesByMatters}>Invoices By Matters</MenuItem>
            </Menu>
          </div>


          <br></br><br></br>

          <div>
            <Button
              id="basic-button"
              aria-controls={open ? 'basic-menu' : undefined}
              aria-haspopup="true"
              aria-expanded={open ? 'true' : undefined}
              onClick={handleClickedBilling}
            >
              Billing
            </Button>

            <Menu
              id="basic-menu"
              anchorEl={billing}
              open={openedBilling}
              onClose={handleCloseBilling}
              MenuListProps={{
                'aria-labelledby': 'basic-button'
              }}
            >
              <MenuItem onClick={GetBillingByAttorneys}>Billing For Attorney</MenuItem>
            </Menu>
          </div>

        </List>
      </Drawer>

      <Main open={open}>
        <DrawerHeader />
        <Typography paragraph>
          Welcome To The Court !!!
        </Typography>
      </Main>

    </Box>
  );
}
