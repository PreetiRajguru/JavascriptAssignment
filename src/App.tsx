import Navigation from './components/Navigation';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { useEffect, useState} from 'react';
import axios from 'axios';
import { AppContext } from './config/https';
import CreateMatter from './components/Matters/CreateMatter';
import GetInvoiceForMatter from './components/Invoices/GetInvoiceForMatter';
import GetMattersByClient from './components/Matters/GetMattersByClient';
import GetMatterForClients from './components/Matters/GetMatterForClients';
import GetInvoicesByMatters from './components/Invoices/GetInvoicesByMatters';
import GetBillingForAttorney from './components/Billing/GetBillingForAttorney';

function App() {
  const [loading] = useState(true);

  useEffect(() => {
    axios.defaults.baseURL = 'https://localhost:7207';
    }
  );

  return (
    <AppContext.Provider value={{ loading }}>
    <div>
      <BrowserRouter>
      <Navigation />
        <Routes>
          <Route path="/creatematter" element={<CreateMatter />} />
          <Route path="/getmatterforclient" element={<GetMatterForClients />} />
          <Route path="/getmattersbyclients" element={<GetMattersByClient />} />
          <Route path="/getinvoicesformatter" element={<GetInvoiceForMatter />} />
          <Route path="/getinvoicesbymatters" element={<GetInvoicesByMatters />} />
          <Route path="/billingforattorney" element={<GetBillingForAttorney />} />
        </Routes>
      </BrowserRouter>
    </div>
    </AppContext.Provider>
  );
}

export default App;