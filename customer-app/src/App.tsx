import AddCustomer from './components/AddCustomer';
import Navigation from './components/Navigation';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Customers from './components/Customers';
import Dashboard from './components/Dashboard';
import EditCustomer from './components/EditCustomer';
import { useEffect, useState} from 'react';
import axios from 'axios';
import { AppContext } from './config/https';

function App() {
  useEffect(() => {
    axios.defaults.baseURL = 'https://localhost:7041';
  });
  const [loading] = useState(true);


  return (
    <AppContext.Provider value={{ loading }}>
    <div>
      <BrowserRouter>
        <Navigation />
        <Routes>
          <Route path="/dashboard" element={<Dashboard />} />
          <Route path="customers">
            <Route index element={<Customers />} />
            <Route path="add" element={<AddCustomer />} />
            <Route path="edit/:id" element={<EditCustomer />} />
          </Route>            
          <Route path="/" element={<Dashboard />} />
          <Route path="*" element={<h1>404 Not Found</h1>} />
        </Routes>
      </BrowserRouter>
    </div>
    </AppContext.Provider>
  );
}

export default App;