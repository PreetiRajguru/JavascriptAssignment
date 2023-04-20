import { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";
import {
  Box,
  Button,
  Container,
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
        setCustomer(response.data.result);
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
    <Box sx={{ display: "flex", justifyContent: "center", mt: 4 }}>
      <Container maxWidth="sm">
        <Typography variant="h4" align="center" mb={4}>
          Edit Customer
        </Typography>
        <Box component="form" onSubmit={handleSubmit}>
          <TextField
            name="firstName"
            label="First Name"
            fullWidth
            required
            value={customer.firstName}
            onChange={handleInputChange}
            sx={{ mb: 2 }}
          />
          <TextField
            name="lastName"
            label="Last Name"
            fullWidth
            required
            value={customer.lastName}
            onChange={handleInputChange}
            sx={{ mb: 2 }}
          />
          <TextField
            name="dateOfBirth"
            // label="Date of Birth"
            type="date"
            fullWidth
            required
            value={customer.dateOfBirth}
            onChange={handleInputChange}
            sx={{ mb: 2 }}
          />
          <TextField
            name="phoneNumber"
            label="Phone Number"
            type="tel"
            fullWidth
            required
            value={customer.phoneNumber}
            onChange={handleInputChange}
            sx={{ mb: 2 }}
          />
          <TextField
            name="email"
            label="Email"
            type="email"
            fullWidth
            required
            value={customer.email}
            onChange={handleInputChange}
            sx={{ mb: 2 }}
          />
          <TextField
            name="address"
            label="Address"
            fullWidth
            value={customer.address}
            onChange={handleInputChange}
            sx={{ mb: 2 }}
          />
          <Button
            type="submit"
            variant="contained"
            color="primary"
            sx={{ mt: 2 }}
          >
            Save
          </Button>
        </Box>
      </Container>
    </Box>
  );
};

export default EditCustomer;

