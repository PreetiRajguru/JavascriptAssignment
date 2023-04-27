import { useEffect, useState } from "react";
import axios from "axios";
import {
  Typography,
  Box,
  Container,
  Table,
  TableContainer,
  TableHead,
  TableCell,
  TableRow,
  TableBody,
  Paper
} from "@mui/material";
import './Invoice.css'

const GetInvoiceForMatter = () => {
  const [invoice, setInvoice] = useState<any>([]);
  const [matterId, setMatterId] = useState<any>()

  const getMatters = async () => {
    const d = await axios.get('/api/Matters');
    setMatterId(d.data);
  }

  const getInvoices = async (invoice: any) => {
    try {
      const x = await axios.get(`/api/Invoice/bymatterid/${invoice}`)
      console.log(x)
      setInvoice(x.data)
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    getMatters()
  }, [])

  const handleChange = (event: any) => {
    getInvoices(event.target.value);
    console.log('Clicked')
    console.log('event.target.value======', event.target.value)
  };

  console.log(matterId)

  return (
    <Box sx={{ display: "flex", justifyContent: "center", mt: 4, flexDirection: "column" }}>
      <Container maxWidth="sm">
        <Typography variant="h4" align="center" mb={4}>
          Get Invoice For Matter
        </Typography>
        <Box component="form">
          <select
            defaultValue="Select-Matter"
            onChange={handleChange}
          >
            {
              matterId?.map((menuItem: any, idx: any) => {
                return (<option value={menuItem.id}>{menuItem.title}</option>)
              })
            }
          </select>
        </Box>
      </Container>
      <TableContainer component={Paper}>
        <Table aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell><b>Sr.No</b></TableCell>
              <TableCell><b>Attorney Name</b></TableCell>
              <TableCell><b>Invoice Date</b></TableCell>
              <TableCell><b>Hours Worked</b></TableCell>
              <TableCell><b>Total Amount</b></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {
              invoice.map((value: any, idx: any) => {
                return (<TableRow>
                  <TableCell component="th" scope="row">
                    {idx + 1}
                  </TableCell>
                  <TableCell>{value.attorneyName}</TableCell>
                  <TableCell>{new Date(value.invoiceDate).toLocaleDateString()}</TableCell>
                  <TableCell>{value.hoursWorked}</TableCell>
                  <TableCell>{value.totalAmount}</TableCell>
                </TableRow>)
              })
            }
          </TableBody>
        </Table>
      </TableContainer>
    </Box>
  );
};

export default GetInvoiceForMatter;