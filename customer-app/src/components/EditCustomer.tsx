import { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";
import {
  Box,
  Button,
  Grid,
  TextField,
  Typography,
} from "@mui/material";

interface Customer {
  id: number;
  firstName: string;
  lastName: string;
  dateOfBirth: string;
  phoneNumber: string;
  email: string;
  address: string;
}

const EditCustomer = () => {
  const { id } = useParams<{ id: string }>();
  const history = useNavigate();
  const [customer, setCustomer] = useState<Customer>({
    id: 0,
    firstName: "",
    lastName: "",
    dateOfBirth: "",
    phoneNumber: "",
    email: "",
    address: "",
  });

  useEffect(() => {
    const fetchCustomer = async () => {
      try {
        const response = await axios.get(`/api/Customer/${id}`);
        setCustomer(response.data);
      } catch (error) {
        console.error(error);
      }
    };
    fetchCustomer();
  }, [id]);

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setCustomer((prevState) => ({ ...prevState, [name]: value }));
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    try {
      await axios.put(`/api/Customer/${id}`, customer);
      history("/customers");
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <Box sx={{ mt: 4 }}>
      <Typography variant="h4" align="center" mb={4}>
        Edit Customer
      </Typography>
      <form onSubmit={handleSubmit}>
        <Grid container spacing={2}>
          <Grid item xs={12} sm={6}>
            <TextField
              required
              fullWidth
              label="First Name"
              name="firstName"
              value={customer.firstName}
              onChange={handleInputChange}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              required
              fullWidth
              label="Last Name"
              name="lastName"
              value={customer.lastName}
              onChange={handleInputChange}
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              required
              fullWidth
              type="date"
              label="Date of Birth"
              name="dateOfBirth"
              value={customer.dateOfBirth}
              onChange={handleInputChange}
              InputLabelProps={{ shrink: true }}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              required
              fullWidth
              label="Phone Number"
              name="phoneNumber"
              value={customer.phoneNumber}
              onChange={handleInputChange}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              required
              fullWidth
              label="Email"
              name="email"
              value={customer.email}
              onChange={handleInputChange}
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              required
              fullWidth
              label="Address"
              name="address"
              value={customer.address}
              onChange={handleInputChange}
              multiline
              rows={4}
            />
          </Grid>
          <Grid item xs={12}>
            <Box sx={{ display: "flex", justifyContent: "flex-end" }}>
              <Button type="submit" variant="contained" color="primary">
                Save
              </Button>
              <Button>
                Cancel
              </Button>
            </Box>
          </Grid>
        </Grid>
      </form>
    </Box>
  );
};

export default EditCustomer;

