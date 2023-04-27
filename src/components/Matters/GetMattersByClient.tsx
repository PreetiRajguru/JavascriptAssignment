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

export interface Matter {
  clientId: number;
  matters: {
    title: string;
    description: string;
    clientId: number;
    billingAttorneyId: number;
    responsibleAttorneyId: number;
    jurisdictionId: number;
  }[];
}

const GetMattersByClient = () => {
  const [matter, setMatter] = useState<Matter[]>();

  useEffect(() => {
    const fetchMattersForClients = async () => {
      try {
        const response = await axios.get("/api/Matters/client");
        setMatter(response.data);
        console.log(matter)
      } catch (error) {
        console.error(error);
      }
    };
    fetchMattersForClients();
  }, []);

  return (

    <Box sx={{ display: "flex", justifyContent: "center", mt: 4, flexDirection: "column" }}>

      <Typography variant="h4" align="center" mb={4}>
        Matter by Clients
      </Typography>

      <br></br><br></br>

      <TableContainer component={Paper}>

        <Table>
          <TableHead>
            <TableRow>
              <TableCell>ClientId</TableCell>
              <TableCell>Title</TableCell>
              <TableCell>Description</TableCell>
              <TableCell>BillingAttorneyId</TableCell>
              <TableCell>ResponsibleAttorneyId</TableCell>
              <TableCell>JurisdictionId</TableCell>
            </TableRow>
          </TableHead>

          <TableBody>
            {matter?.map((mtr, index) => (
              mtr.matters.map((value) => (
                <TableRow key={value.clientId}>
                  <TableCell>{index + 1}</TableCell>
                  <TableCell>{value.title}</TableCell>
                  <TableCell>{value.description}</TableCell>
                  <TableCell>{value.billingAttorneyId}</TableCell>
                  <TableCell>{value.responsibleAttorneyId}</TableCell>
                  <TableCell>{value.jurisdictionId}</TableCell>
                  <TableCell>
                  </TableCell>
                </TableRow>
              ))
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Box>
  );
};

export default GetMattersByClient;