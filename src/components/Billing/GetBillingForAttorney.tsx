import { useState, useEffect } from "react";
import axios from "axios";
import {
  Box,
  FormControl,
  InputLabel,
  MenuItem,
  Paper,
  Select,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";

const GetBillingForAttorney = () => {
  const [billingForAttorney, setBillingForAttorney] = useState<any>();
  const [attorneys, setAttorneys] = useState<any>();
  const [attorneyName, setAttorneyName] = useState<any>();

  const fetchBillingForAttorney = async (attorneyId: any) => {
    try {
      const response = await axios.get(`/api/Invoice/billing/${attorneyId}`);
      setBillingForAttorney(response.data);
    } catch (error) {
      console.error(error);
    }
  };

  const getAttorneys = async () => {

    try {
      const response = await axios.get('/api/Attorney')
      console.log(response)
      setAttorneys(response.data);
    } catch (error) {
      console.error(error);
    }
  }

  useEffect(() => {
    getAttorneys();
  }, []);

  const handleInputChange = (event: any) => {
    const { value } = event.target;
    attorneys.forEach((a: any) => {
      if (a.id == value) {
        setAttorneyName(a.name);
      }
      fetchBillingForAttorney(value);
    });
  }

  return (

    <Box sx={{ mt: 4 }}>
      <Typography variant="h4" align="center" mb={4}>
        Billing For Attorney
      </Typography>

      <FormControl style={{ width: '300px' }}>
        <InputLabel id="demo-simple-select-label">Attorneys</InputLabel>
        <Select
          name="Attorney"
          label="Attorney"
          id="demo-simple-select"
          fullWidth
          onChange={handleInputChange}
        >
          {attorneys?.map((option: any) => (
            <MenuItem value={option.id}>
              {option.name}
            </MenuItem>
          ))}
        </Select>
      </FormControl>

      <br></br><br></br>

      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell><b>Attorney Name</b></TableCell>
              <TableCell><b>Billing</b></TableCell>
            </TableRow>
          </TableHead>

          <TableBody>
            <TableRow>
              <TableCell>{attorneyName}</TableCell>
              <TableCell>{billingForAttorney?.billing}</TableCell>
            </TableRow>
          </TableBody>
        </Table>
      </TableContainer>
    </Box>
  );
};

export default GetBillingForAttorney;