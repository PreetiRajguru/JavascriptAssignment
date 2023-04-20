import AddCustomer from './components/AddCustomer';
import Navigation from './components/Navigation';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Customers from './components/Customers';
import Dashboard from './components/Dashboard';
import EditCustomer from './components/EditCustomer';
import { useEffect } from 'react';
import axios from 'axios';

function App() {

  useEffect(() => {
    axios.defaults.baseURL = 'https://localhost:7041';
  });

  return (
    <div>
      <BrowserRouter>
        <Navigation />
        <Routes>
          <Route path="/customers" element={<Customers />} />
          <Route path="/add" element={<AddCustomer />} />
          <Route path="/" element={<Dashboard />} />
          <Route path="/edit/:id" element={<EditCustomer/>} />
          <Route path="*" element={<h1>404 Not Found</h1>} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
