import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import axios from "axios";
import {
  Box,
  Button,
  Dialog,
  DialogContent,
  DialogTitle,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
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

const Customers = () => {
  const [customers, setCustomers] = useState<Customer[]>([]);
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

  const handleDelete = async (e:any,id: number) => {
    // e.stopImmediatePropogation();
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

  console.log(customers.length && customers[selectedCustomerIndex]);

  return (

    <Box sx={{ mt: 4 }}>
      <Typography variant="h4" align="center" mb={4}>
        Customers
      </Typography>
      <Button
        variant="contained"
        color="primary"
        component={Link}
        to={`/add`}
        sx={{ marginLeft: 'auto', marginRight: 1 }}
        style={{marginLeft:'15px'}}
      >
        Add Customer
      </Button>
      <br></br><br></br>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>ID</TableCell>
              <TableCell>First Name</TableCell>
              <TableCell>Last Name</TableCell>
              <TableCell>Date of Birth</TableCell>
              <TableCell>Phone Number</TableCell>
              <TableCell>Email</TableCell>
              <TableCell>Address</TableCell>
              <TableCell>Action</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {customers.map((customer, index) => (
              <TableRow key={customer.id} onClick={() => setSelectedCustomerIndex(index)}>
                <TableCell>{customer.id}</TableCell>
                <TableCell>{customer.firstName}</TableCell>
                <TableCell>{customer.lastName}</TableCell>
                <TableCell>{customer.dateOfBirth}</TableCell>
                <TableCell>{customer.phoneNumber}</TableCell>
                <TableCell>{customer.email}</TableCell>
                <TableCell>{customer.address}</TableCell>
                <TableCell>
                  <Button
                    variant="contained"
                    color="primary"
                    component={Link}
                    to={`/edit/${customer.id}`}
                    sx={{ mr: 1 }}
                  >
                    Edit
                  </Button>
                  <Button
                    variant="contained"
                    color="secondary"
                    onClick={(e) => handleDelete(e,customer.id)}
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
        <Dialog open onClose={() => setSelectedCustomerIndex(-1)}>
          <DialogTitle>Customer data</DialogTitle>
          <DialogContent>
            {customers[selectedCustomerIndex].address}
            {customers[selectedCustomerIndex].email}
          </DialogContent>
        </Dialog>
      )}
    </Box>
  );
};

export default Customers;



