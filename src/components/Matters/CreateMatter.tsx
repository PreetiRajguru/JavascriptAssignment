import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import {
  TextField,
  Button,
  Typography,
  Box,
  Container,
  Select,
  MenuItem,
  InputLabel,
  FormControl
} from "@mui/material";

interface Matter {
  title: string;
  description: string;
  clientId: number;
  billingAttorneyId: number;
  responsibleAttorneyId: number;
  jurisdictionId: number;
}

const CreateMatter = () => {
  const navigate = useNavigate()
  const [jurisdictions, setJurisdictions] = useState([]);
  const [attorneys, setAttorneys] = useState([]);
  const [clients, setClients] = useState([]);
  const [matter, setMatter] = useState<Matter>({
    title: "",
    description: "",
    clientId: 0,
    billingAttorneyId: 0,
    responsibleAttorneyId: 0,
    jurisdictionId: 0,
  });
  const [initialData, setInitialData] = useState([])

  const getClients = () => {
    axios.get('/api/Client').then((response) => {
      setClients(response.data);
    });
  }

  const getJurisdictions = () => {
    axios.get('/api/JurisdictionMaster').then((response) => {
      console.log(response)
      setJurisdictions(response.data);
    })
      .catch(error => console.log(error.data.message));
  }

  const getAttorneys = () => {
    axios.get('/api/Attorney').then((response) => {
      console.log(response)
      setAttorneys(response.data);
    })
      .catch(error => console.log(error.data.message));
  }

  const getMatters = () => {
    axios.get('/api/Matters').then((response) => {
      console.log(response)
      setInitialData(response.data);
    })
      .catch(error => console.log(error.data.message));
  }

  useEffect(() => {
    getClients();
    getJurisdictions();
    getMatters();
    getAttorneys();
  }, [])

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const newMatter: Matter = {
      title: matter.title,
      description: matter.description,
      clientId: matter.clientId,
      billingAttorneyId: matter.billingAttorneyId,
      responsibleAttorneyId: matter.responsibleAttorneyId,
      jurisdictionId: matter.jurisdictionId
    }

    try {
      axios.post('/api/Matters', newMatter)
        .then((response) => {
          console.log(response.data);
        });
    }
    catch (error: any) {
      alert(error.response.data.message);
    }
    alert("Record Created");
  };

  const handleInputChange = (
    event: any
  ) => {
    const { name, value } = event.target;
    setMatter((prevState: any) => ({
      ...prevState,
      [name]: value,
    }));
  };

  const handleBackButton = () => {
    navigate("/");
  };

  return (
    <Box sx={{ display: "flex", justifyContent: "center", mt: -4 }}>
      <Container maxWidth="sm">
        <Typography variant="h4" align="center" mb={4}>
          Add Matter
        </Typography>

        <Box component="form" onSubmit={handleSubmit}>

          <TextField
            name="title"
            label="Title"
            fullWidth
            required
            autoComplete="off"
            value={matter.title}
            onChange={handleInputChange}
            sx={{ mb: 2 }}
          />

          <TextField
            name="description"
            label="Description"
            fullWidth
            required
            autoComplete="off"
            value={matter.description}
            onChange={handleInputChange}
            sx={{ mb: 2 }}
          />

          <FormControl fullWidth>
            <InputLabel id="demo-simple-select-label">ClientId</InputLabel>
            <Select
              name="clientId"
              label="ClientId"
              id="demo-simple-select"
              fullWidth
              value={matter.clientId}
              onChange={handleInputChange}
            >
              {
                clients.map((val: any) => (
                  <MenuItem key={val.id} value={val.id}>
                    {val.firstName} {val.lastName}
                  </MenuItem>
                ))
              }
            </Select>
          </FormControl>

          <br></br><br></br>

          <FormControl fullWidth>
            <InputLabel id="demo-simple-select-label">Billing Attorney</InputLabel>
            <Select
              name="billingAttorneyId"
              label="Billing Attorney Id"
              id="demo-simple-select"
              fullWidth
              onChange={handleInputChange}
            >
              {attorneys.map((option: any) => (
                <MenuItem value={option.id}>
                  {option.name}
                </MenuItem>
              ))}
            </Select>
          </FormControl>

          <br></br><br></br>

          <FormControl fullWidth>
            <InputLabel id="demo-simple-select-label">Responsible Attorney</InputLabel>
            <Select
              name="responsibleAttorneyId"
              label="Billing Attorney Id"
              id="demo-simple-select"
              fullWidth
              onChange={handleInputChange}
            >
              {attorneys.map((option: any) => (
                <MenuItem value={option.id}>
                  {option.name}
                </MenuItem>
              ))}
            </Select>
          </FormControl>

          <br></br><br></br>

          <FormControl fullWidth>
            <InputLabel id="demo-simple-select-label">Jurisdiction</InputLabel>
            <Select
              name="jurisdictionId"
              label="JurisdictionId"
              id="demo-simple-select"
              fullWidth
              value={matter.jurisdictionId}
              onChange={handleInputChange}
            >
              {
                jurisdictions.map((val: any) => (
                  <MenuItem key={val.id} value={val.id}>
                    {val.jurisdictionName}
                  </MenuItem>
                ))
              }
            </Select>
          </FormControl>

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

export default CreateMatter;