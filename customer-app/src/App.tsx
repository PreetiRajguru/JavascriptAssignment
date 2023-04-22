import AddCustomer from './components/AddCustomer';
import Navigation from './components/Navigation';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Customers from './components/Customers';
import Dashboard from './components/Dashboard';
import EditCustomer from './components/EditCustomer';
import { useEffect, useState } from 'react';
import axios from 'axios';
import React from 'react';

export const AppContext = React.createContext<any>({});

function App() {

  useEffect(() => {
    axios.defaults.baseURL = 'https://localhost:7041';
  });

  const [loading, setLoading] = useState(true);

  useEffect(() => {
    axios.interceptors.request.use(
      function (config) {
        console.log("Before Request..");
        setLoading(true);
        return config;
      },
      function (error) {
        console.log("Error Before Request");
        setLoading(false);
        return Promise.reject(error);
      }
    );

    axios.interceptors.response.use(
      function (response) {
        console.log("After Request..");
        setLoading(false);
        return response;
      },
      function (error) {
        console.log("Error After Request");
        setLoading(false);
        return Promise.reject(error);
      }
    );
  }, []);


  return (
    <AppContext.Provider value={{ loading }}>
    <div>

    {loading && (
          <div className="loader">
            <div className="spinner"></div>
            <div>Loading...</div>
          </div>
        )}

      <BrowserRouter>
        <Navigation />
        <Routes>
          <Route path="/dashboard" element={<Dashboard />} />
          <Route path="/customers" element={<Customers />} />
          <Route path="/add" element={<AddCustomer />} />
          <Route path="/" element={<Dashboard />} />
          <Route path="/edit/:id" element={<EditCustomer />} />
          <Route path="*" element={<h1>404 Not Found</h1>} />
        </Routes>
      </BrowserRouter>
    </div>
    </AppContext.Provider>
  );
}

export default App;