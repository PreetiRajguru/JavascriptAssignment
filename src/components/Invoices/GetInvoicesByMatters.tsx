import { useState, useEffect } from "react";
import axios from "axios";
import {
  Box,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";

export interface Invoice {
  matterId: number;
  invoices: {
    Id: number;
    hoursWorked: number;
    totalAmount: number;
    invoiceDate: Date;
    attorneyId: number;
    matterId: number;
  }[];
}

const GetInvoicesByMatters = () => {
  const [matter, setMatter] = useState<Invoice[]>([]);

  useEffect(() => {
    const fetchInvoicesForMatters = async () => {
      try {
        const response = await axios.get("/api/Invoice/matter");
        setMatter(response.data);
        console.log(matter[3].invoices[0].totalAmount)
      } catch (error) {
        console.error(error);
      }
    };
    fetchInvoicesForMatters();
  }, []);

  return (
    <Box sx={{ mt: 4 }}>
      <Typography variant="h4" align="center" mb={4}>
        Invoices by Matters
      </Typography>

      <br></br><br></br>

      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>InvoiceId</TableCell>
              <TableCell>HoursWorked</TableCell>
              <TableCell>TotalAmount</TableCell>
              <TableCell>AttorneyId</TableCell>
              <TableCell>MatterId</TableCell>
            </TableRow>
          </TableHead>

          <TableBody>
            {matter.map((mtr, index) => (
              mtr.invoices.map((value) => (
                <TableRow key={value.Id}>
                  <TableCell>{index + 1}</TableCell>
                  <TableCell>{value.hoursWorked}</TableCell>
                  <TableCell>{value.totalAmount}</TableCell>
                  <TableCell>{value.attorneyId}</TableCell>
                  <TableCell>{value.matterId}</TableCell>
                </TableRow>
              ))
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Box>
  );
};

export default GetInvoicesByMatters;