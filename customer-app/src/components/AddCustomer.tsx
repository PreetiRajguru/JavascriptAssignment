// import { useState } from "react";
// import { useNavigate } from "react-router-dom";
// import axios from "axios";
// import {
//   TextField,
//   Button,
//   Typography,
//   Box,
//   Container,
// } from "@mui/material";

// interface Customer {
//   // id: number;
//   firstName: string;
//   lastName: string;
//   dateOfBirth: string;
//   phoneNumber: string;
//   email: string;
//   address: string;
// }

// const AddCustomer = () => {
//   const [customer, setCustomer] = useState<Customer>({
//     // id: 0,
//     firstName: "",
//     lastName: "",
//     dateOfBirth: "",
//     phoneNumber: "",
//     email: "",
//     address: "",
//   });

//   const history = useNavigate();

//   const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
//     event.preventDefault();
//     try {
//       await axios.post("/api/Customer", customer);
//       history("/customers");
//     } catch (error) {
//       console.error(error);
//     }
//   };

//   const handleInputChange = (
//     event: React.ChangeEvent<HTMLInputElement>
//   ) => {
//     const { name, value } = event.target;
//     setCustomer((prevState) => ({
//       ...prevState,
//       [name]: value,
//     }));
//   };

//   return (
//     <Box sx={{ display: "flex", justifyContent: "center", mt: 4 }}>
//       <Container maxWidth="sm">
//         <Typography variant="h4" align="center" mb={4}>
//           Add Customer
//         </Typography>
//         <Box component="form" onSubmit={handleSubmit}>
//           <TextField
//             name="firstName"
//             label="First Name"
//             fullWidth
//             required
//             value={customer.firstName}
//             onChange={handleInputChange}
//             sx={{ mb: 2 }}
//           />
//           <TextField
//             name="lastName"
//             label="Last Name"
//             fullWidth
//             required
//             value={customer.lastName}
//             onChange={handleInputChange}
//             sx={{ mb: 2 }}
//           />
//           <TextField
//             name="dateOfBirth"
//             // label="Date of Birth"
//             type="date"
//             fullWidth
//             required
//             value={customer.dateOfBirth}
//             onChange={handleInputChange}
//             sx={{ mb: 2 }}
//           />
//           <TextField
//             name="phoneNumber"
//             label="Phone Number"
//             type="tel"
//             fullWidth
//             required
//             value={customer.phoneNumber}
//             onChange={handleInputChange}
//             sx={{ mb: 2 }}
//           />
//           <TextField
//             name="email"
//             label="Email"
//             type="email"
//             fullWidth
//             required
//             value={customer.email}
//             onChange={handleInputChange}
//             sx={{ mb: 2 }}
//           />
//           <TextField
//             name="address"
//             label="Address"
//             fullWidth
            
//             value={customer.address}
//             onChange={handleInputChange}
//             sx={{ mb: 2 }}
//           />
//           <Button
//             type="submit"
//             variant="contained"
//             color="primary"
//             sx={{ mt: 2 }}
//           >
//             Save
//           </Button>
//         </Box>
//       </Container>
//     </Box>
//   );
// };

// export default AddCustomer;import { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import {
  TextField,
  Button,
  Typography,
  Box,
  Container,
} from "@mui/material";
import { useState } from "react";

interface Customer {
  firstName: string;
  lastName: string;
  dateOfBirth: string;
  phoneNumber: string;
  email: string;
  address: string;
}

const AddCustomer = () => {
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
    try {
      await axios.post("/api/Customer", customer);
      navigate("/customers");
    } catch (error) {
      console.error(error);
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

  return (
    <Box sx={{ display: "flex", justifyContent: "center", mt: 4 }}>
      <Container maxWidth="sm">
        <Typography variant="h4" align="center" mb={4}>
          Add Customer
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



