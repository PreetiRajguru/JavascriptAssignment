import { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import {
  TextField,
  Button,
  Typography,
  Box,
  Container,
} from "@mui/material";

interface Customer {
  firstName: string;
  lastName: string;
  dateOfBirth: string;
  phoneNumber: string;
  email: string;
  address: string;
}

const AddCustomer = () => {
  const [sidebarOpen, setSidebarOpen] = useState(false);
  const [customer, setCustomer] = useState<Customer>({
    firstName: "",
    lastName: "",
    dateOfBirth: "",
    phoneNumber: "",
    email: "",
    address: "",
  });

  const navigate = useNavigate();

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const newCustomer: Customer = {
      firstName: customer.firstName,
      lastName: customer.lastName,
      dateOfBirth: customer.dateOfBirth,
      phoneNumber: customer.phoneNumber,
      email: customer.email,
      address: customer.address
    }

    const validPhone = /^[0-9]{10}$/;
    const resultNumber = validPhone.test(newCustomer.phoneNumber);
    const pattern = /[a-zA-Z0-9]+[\.]?([a-zA-Z0-9]+)?[\@][a-z]{3,9}[\.][a-z]{2,5}/g;
    const result = pattern.test(newCustomer.email);

    if (resultNumber == false) {
      alert("Incorrect Phone Number");
    }
    else if (result === false) {
      alert("Incorrect Email Format");
    }
    else {
      try {
        axios.post("/api/Customer", customer).then(s => {
          console.log(s);
          navigate("/customers");
        }, error => {
          alert(error.response.data.message);
        });
      } catch (error) {
        console.error(error);
      }
    }

  };

  const handleInputChange = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    const { name, value } = event.target;
    setCustomer((prevState: any) => ({
      ...prevState,
      [name]: value,
    }));
  };

  const handleBackButton = () => {
    navigate("/customers");
  };

  const toggleDrawer = () => {
    setSidebarOpen(!sidebarOpen);
  };

  return (
    <Box sx={{ display: "flex", justifyContent: "center", mt: 4 }}>
      <Container maxWidth="sm">
        <Typography variant="h4" align="center" mb={4}>
          Add Customer
        </Typography>
        <Box component="form" onSubmit={handleSubmit} onClick={toggleDrawer}>
          <TextField
            name="firstName"
            label="First Name"
            fullWidth
            required
            autoComplete="off"
            value={customer.firstName}
            onChange={handleInputChange}
            sx={{ mb: 2 }}
          />
          <TextField
            name="lastName"
            label="Last Name"
            fullWidth
            required
            autoComplete="off"
            value={customer.lastName}
            onChange={handleInputChange}
            sx={{ mb: 2 }}
          />
          <TextField
            name="dateOfBirth"
            type="date"
            fullWidth
            required
            autoComplete="off"
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
            autoComplete="off"
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
            autoComplete="off"
            value={customer.email}
            onChange={handleInputChange}
            sx={{ mb: 2 }}
          />
          <TextField
            name="address"
            label="Address"
            fullWidth
            autoComplete="off"
            value={customer.address}
            onChange={handleInputChange}
            sx={{ mb: 2 }}
          />
          <Button
            type="submit"
            variant="contained"
            color="primary"
            sx={{ mt: 2, mr: 2 }}
          >
            Save
          </Button>
          <Button
            variant="contained"
            onClick={handleBackButton}
            sx={{ mt: 2 }}
          >
            Back
          </Button>
        </Box>
      </Container>
    </Box>
  );
};

export default AddCustomer;

function register(arg0: string): JSX.IntrinsicAttributes & import("@mui/material").TextFieldProps {
  throw new Error("Function not implemented.");
}
