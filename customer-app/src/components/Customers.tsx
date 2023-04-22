import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import axios from "axios";
import {
  Box,
  Button,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";
import Modal from "./Modal";

export interface Customer {
  id: number;
  firstName: string;
  lastName: string;
  dateOfBirth: string;
  phoneNumber: string;
  email: string;
  address: string;
}

const Customers = () => {
  const [customers, setCustomers] = useState<Customer[]>([
      {
        id: 0,
        firstName: "aa",
        lastName: "ss",
        dateOfBirth: "ss",
        phoneNumber: "ss",
        email: "ss",
        address: "ss",
      }
  ]);
  const [selectedCustomerIndex, setSelectedCustomerIndex] = useState<number>(-1);

  useEffect(() => {
    const fetchCustomers = async () => {
      try {
        const response = await axios.get("/api/Customer");
        setCustomers(response.data.result);
      } catch (error) {
        console.error(error);
      }
    };
    fetchCustomers();
  }, []);

  const handleDelete = async (e: any, id: number) => {
    setSelectedCustomerIndex(-1);
    try {
      await axios.delete(`/api/Customer/${id}`);
      setCustomers((prevState) =>
        prevState.filter((customer) => customer.id !== id)
      );
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <Box sx={{ mt: 4 }}>
      <Typography variant="h4" align="center" mb={4}>
        Customers
      </Typography>
      <Button
        variant="contained"
        color="primary"
        component={Link}
        to={`/customers/add`}
        sx={{ marginLeft: 'auto', marginRight: 1 }}
        style={{ marginLeft: '15px' }}
      >
        Add Customer
      </Button>
      <br></br><br></br>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Id</TableCell>
              <TableCell>First Name</TableCell>
              <TableCell>Last Name</TableCell>
              <TableCell>Email</TableCell>
              <TableCell>Action</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {customers.map((customer, index) => (
              <TableRow key={customer.id} onClick={() => setSelectedCustomerIndex(index)}>
                <TableCell>{customer.id}</TableCell>
                <TableCell>{customer.firstName}</TableCell>
                <TableCell>{customer.lastName}</TableCell>
                <TableCell>{customer.email}</TableCell>
                <TableCell>
                  <Button
                    variant="contained"
                    color="primary"
                    component={Link}
                    to={`/customers/edit/${customer.id}`}
                    sx={{ mr: 1 }}
                  >
                    Edit
                  </Button>
                  <Button
                    variant="contained"
                    color="secondary"
                    onClick={(e) => handleDelete(e, customer.id)}
                    disabled={customer.address !== ''}
                  >
                    Delete
                  </Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      {selectedCustomerIndex !== -1 && customers[selectedCustomerIndex]?.email && (
        <Modal onClose={() => setSelectedCustomerIndex(-1)} customer={customers[selectedCustomerIndex]}/> 
      )}
    </Box>
  );
};

export default Customers;