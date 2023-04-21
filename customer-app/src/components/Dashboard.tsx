import { Breadcrumbs, Link, Typography } from '@mui/material';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import lp from '../../src/assets/landscape.png'



const Dashboard = () => {
  return (
    <div>

      <br></br>
      <Breadcrumbs aria-label="breadcrumb" style={{marginLeft:'10px'}}>
        <Link underline="hover" color="inherit" href="/add">
          Add Customer
        </Link>
        <Link underline="hover" color="inherit" href="/customers">
          View Customer
        </Link>
      </Breadcrumbs>
      <br></br>

      <Typography variant="h6" style={{ marginLeft: '510px' }}>Welcome to Customer CRUD Dashboard</Typography>
      <br></br>
      <Card sx={{ maxWidth: 500, marginLeft: '455px' }}>
        <CardMedia
          sx={{ height: 190 }}
          image={lp}
          title="aesthetic"
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="div">
            Card One
          </Typography>
          <Typography variant="body2" color="text.secondary">
            Card One Data
          </Typography>
        </CardContent>
        <CardActions>
          <Button size="small">Share</Button>
          <Button size="small">Learn More</Button>
        </CardActions>
      </Card>


    </div>
  );
};

export default Dashboard;