import React from 'react';
import "./App.css";
import Register from "./components/Register.js";
import LoginPage from "./pages/Login.page";
import InicioForm from "./components/Inicio.form";
import RegistroExitoso from "./components/RegistroExitoso";
import Cuentas from "./components/Cuentas";
//import Ahorros from "./components/Ahorros";
//import Gastos from "./components/Gastos";
//import Aportes from "./components/Aportes";
import { BrowserRouter as Router, Route, Routes, Navigate  } from "react-router-dom";
import CuentaDetalle from "./components/CuentaDetalle";
import 'primereact/resources/themes/lara-light-indigo/theme.css';
import 'primereact/resources/primereact.min.css';
import 'primeicons/primeicons.css';
import Layout from "./components/Layout";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<LoginPage />} />
        <Route path="/register" element={<Register />} />
        <Route path="/registro-exitoso" element={<RegistroExitoso />} /> 
        
        <Route path="/principal" element={<Layout><InicioForm /></Layout>} />
        <Route path="/cuentas" element={<Layout><Cuentas /></Layout>} />
        <Route path="/ahorros" element={<Layout><div>Ahorros Page</div></Layout>} />
        <Route path="/gastos" element={<Layout><div>Gastos Page</div></Layout>} />
        <Route path="/aportes" element={<Layout><div>Aportes Page</div></Layout>} />
        <Route path="/estadisticas" element={<Navigate to="/principal" />} /> 
        <Route path="/cuentas/:cuentaId" element={<Layout><CuentaDetalle /></Layout>} />
      </Routes>
    </Router>
  );
}

export default App;
