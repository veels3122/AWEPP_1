import React from 'react';
import "./App.css";
import Register from "./components/Register.js";
import LoginPage from "./pages/Login.page";
import InicioForm from "./components/Inicio.form";
import RegistroExitoso from "./components/RegistroExitoso";
import Cuentas from "./components/Cuentas";
import Ahorros from "./components/Ahorros";
import Gastos from "./components/Gastos";
import Aportes from "./components/Aportes";
import Estadisticas from "./components/Estadisticas";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import 'primereact/resources/themes/lara-light-indigo/theme.css';
import 'primereact/resources/primereact.min.css';
import 'primeicons/primeicons.css';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<LoginPage />} />
        <Route path="/principal" element={<InicioForm />} />
        <Route path="/register" element={<Register />} />
        <Route path="/registro-exitoso" element={<RegistroExitoso />} /> 
        <Route path="/cuentas" element={<Cuentas />} />
        <Route path="/ahorros" element={<Ahorros />} />
        <Route path="/gastos" element={<Gastos />} />
        <Route path="/aportes" element={<Aportes />} />
        <Route path="/estadisticas" element={<Estadisticas />} />
      </Routes>
    </Router>
  );
}

export default App;
