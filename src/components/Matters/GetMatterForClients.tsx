import React, { useState, useMemo, useEffect } from 'react';
import {
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Box,
  Container,
  Typography
} from '@mui/material';
import axios from 'axios';
import './Matter.css'

const GetMatterForClients = () => {
  const [matter, setMatter] = useState<any>([]);
  const [clientId, setClientId] = useState<any>()

  const getClients = async() => {
    const c = await axios.get('/api/Client');
    setClientId(c.data);
  }

  const getMatters = async(matter: any) => {

    try{
      const c = await axios.get(`api/Matters/client/${matter}`);
      console.log(c);
      setMatter(c.data);
    }catch(error){
      console.error(error);
    }
  };

  useEffect(() => {
    getClients()
  }, [])

  const handleChange = (event: any) => {
    getMatters(event.target.value);
    console.log("Clicked");
    console.log('event.target.value======', event.target.value)
  };

  console.log(clientId)
  
  return (
    <Box sx={{ display: "flex", justifyContent: "center", mt: 4, flexDirection: "column" }}>
      <Container maxWidth="sm">

        <Typography variant="h4" align="center" mb={4}>
          Get Matters For Client
        </Typography>

        <Box component="form">
          <select
            defaultValue="Select-Matter"
            onChange={handleChange}
          >
            {
              clientId?.map((menuItem: any, idx: any) => {
                return (<option value={menuItem.id}>{menuItem.firstName}{menuItem.lastName}</option>)
              })
            }
          </select>
        </Box>

        <br></br><br></br>

      </Container>

      <TableContainer component={Paper}>

        <Table aria-label="simple table">
        <TableHead>
            <TableRow>
              <TableCell><b>Sr.No</b></TableCell>
              <TableCell><b>Title</b></TableCell>
              <TableCell><b>Description</b></TableCell>
              <TableCell><b>Client Name</b></TableCell>
              <TableCell><b>Jurisdiction Area</b></TableCell>
              <TableCell><b>Attorney Name</b></TableCell>
            </TableRow>
          </TableHead>

          <TableBody>
            {
              matter.map((value: any, idx: any) => {
                return (<TableRow>
                  <TableCell component="th" scope="row">
                    {idx + 1}
                  </TableCell>
                  <TableCell>{value.title}</TableCell>
                  <TableCell>{value.description}</TableCell>
                  <TableCell>{value.clientFirstName}&nbsp;{value.clientLastName}</TableCell>
                  <TableCell>{value.jurisdictionArea}</TableCell>
                  <TableCell>{value.responsibleAttorneyName}</TableCell>
                </TableRow>)
              })
            }
          </TableBody> 
        </Table>
      </TableContainer>
    </Box>
  );
};

export default GetMatterForClients;

























































































































// // import { useState } from "react";
// // import { useNavigate, useParams } from "react-router-dom";
// // import axios from "axios";
// // import {
// //   TextField,
// //   Button,
// //   Typography,
// //   Box,
// //   Container,
// // } from "@mui/material";
// // import Select from "@mui/material/Select";
// // import MenuItem from '@mui/material/MenuItem';
// import React, { useState, useMemo, useEffect } from 'react';
// import {
//   FormControl,
//   InputLabel,
//   MenuItem,
//   Select,
//   Table,
//   TableBody,
//   TableCell,
//   TableContainer,
//   TableHead,
//   TableRow,
//   Paper,
//   Box,
//   Container,
//   Typography
// } from '@mui/material';
// import axios from 'axios';
// import './Matter.css'

// const GetMatterForClients = () => {
//   const [selectedOption, setSelectedOption] = useState<any>('');
//   const [clientData, setClientData] = useState([]);
//   const [matter, setMatter] = useState([]);

//   const getAllClients = async() => {
//     const c = await axios.get('/api/Client');
//     setClientData(c.data);
//   }

//   const getAllMatters = async() => {
//     const c = await axios.get('/api/Matters');
//     setMatter(c.data);
//   }

//   useEffect(() => {
//     getAllClients();
//     getAllMatters();
//   },[])

//   const handleChange = (event: any) => {
//     console.log(event.target.value)
//     setSelectedOption(event.target.value);
//   };
//   // const {clientId} = useParams()
//   console.log(matter)

// // //   const navigate = useNavigate();

// //   const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
// //     event.preventDefault();

// //     const newMatter: Matter = {
// //       clientId: matter.clientId
// //     }

// //     try {
// //       axios.get(`/api/Matters/client/${matter.clientId}`).then(s => {
        
// //         console.log(s);
// //         // navigate("/matters");
// //       }, error => {
// //         alert(error.response.data.message);
// //       });
// //     } catch (error) {
// //       console.error(error);
// //     }

// //   };

// //   const handleInputChange = (
// //     event: React.ChangeEvent<HTMLInputElement>
// //   ) => {
// //     const { value } = event.target;
// //     setMatter({
// //       clientId: value as unknown as number,
// //     });
// //   };

// //   const handleBackButton = () => {
// //     // navigate("/matters");
// //   };

// //   const toggleDrawer = () => {
// //     setSidebarOpen(!sidebarOpen);
// //   };

// // const selectedOptionDetails = useMemo(()  => {
// //   return matter.find(m => m.id === selectedOption);
// // }, [selectedOption])

// console.log(clientData)

//   return (
//     <Box sx={{ display: "flex", justifyContent: "center", mt: 4 }}>
//       <Container maxWidth="sm">
//         <Typography variant="h4" align="center" mb={4}>
//         Get Matter For Client
//         </Typography>
//         <Box component="form">
//         <select
//           defaultValue={selectedOption}
//           onChange={handleChange}
//         >
//           {clientData?.map((option: any, idx: any) => (
//             <option key={idx}>
//               {option.firstName} {option.lastName}
//             </option>
//           ))}
//         </select>
//         </Box>
//       </Container>
//         {/* {selectedOptionDetails && (
//         <TableContainer component={Paper}>
//           <Table aria-label="simple table">
//             <TableHead>
//               <TableRow>
//                 <TableCell><b>Title</b></TableCell>
//                 <TableCell><b>Description</b></TableCell>
//               <TableCell><b>BillingAttorneyId</b></TableCell>
//               <TableCell><b>ResponsibleAttorneyId</b></TableCell>
//               <TableCell><b>JurisdictionId</b></TableCell>
//               </TableRow>
//             </TableHead>
//             <TableBody>
//                 <TableRow>
//                   <TableCell component="th" scope="row">
//                     {selectedOptionDetails.title}
//                   </TableCell>
//                   <TableCell>{selectedOptionDetails.description}</TableCell>
//                   <TableCell>{selectedOptionDetails.billingAttorneyId}</TableCell>
//                   <TableCell>{selectedOptionDetails.responsibleAttorneyId}</TableCell>
//                   <TableCell>{selectedOptionDetails.jurisdictionId}</TableCell>
//                 </TableRow>
//             </TableBody>
//           </Table>
//         </TableContainer>
//       )} */}
//     </Box>
//     // <div>
//     //   {/* <FormControl>
//     //     <InputLabel id="demo-simple-select-label">Select an option</InputLabel>
//     //     <Select
//     //       labelId="demo-simple-select-label"
//     //       id="demo-simple-select"
//     //       fullWidth
//     //       value={selectedOption}
//     //       onChange={handleChange}
//     //     >
//     //       {matter.map((option: any) => (
//     //         <MenuItem key={option.id} value={option.id}>
//     //           {option.id}
//     //         </MenuItem>
//     //       ))}
//     //     </Select>
//     //   </FormControl> */}
      
//     // </div>
//   );
// };

// export default GetMatterForClients;

// function register(arg0: string): JSX.IntrinsicAttributes & import("@mui/material").TextFieldProps {
//   throw new Error("Function not implemented.");
// }
