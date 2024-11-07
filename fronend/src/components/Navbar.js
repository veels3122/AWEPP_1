import React from 'react';
import { NavLink } from 'react-router-dom';
import './Navbar.css';

const Navbar = () => {
  return (
    <nav className="navbar">
      <NavLink to="/cuentas" className={({ isActive }) => isActive ? "nav-link active" : "nav-link"}>CUENTAS</NavLink>
      <NavLink to="/ahorros" className={({ isActive }) => isActive ? "nav-link active" : "nav-link"}>AHORROS</NavLink>
      <NavLink to="/gastos" className={({ isActive }) => isActive ? "nav-link active" : "nav-link"}>GASTOS</NavLink>
      <NavLink to="/finanzas" className={({ isActive }) => isActive ? "nav-link active" : "nav-link"}>FINANZAS</NavLink>
      <NavLink to="/estadisticas" className={({ isActive }) => isActive ? "nav-link active" : "nav-link"}>ESTADISTICAS</NavLink>
    </nav>
  );
};

export default Navbar;
