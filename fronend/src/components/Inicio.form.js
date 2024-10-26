import { Chart } from 'primereact/chart';
import './InicioForm.css';
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { NavLink } from 'react-router-dom';


const InicioForm = () => {
  const navigate = useNavigate();

  const saldoData = {
    labels: ['Mes 1', 'Mes 2', 'Mes 3', 'Mes 4', 'Mes 5'],
    datasets: [
      {
        label: 'Saldo',
        backgroundColor: ['#3b82f6', '#f97316', '#14b8a6', '#f43f5e', '#8b5cf6'],
        data: [150, 120, 130, 180, 140]
      }
    ]
  };

  const limiteCreditoData = {
    labels: ['Saldo Crédito', 'Límite de Crédito'],
    datasets: [
      {
        data: [950000, 2350000],
        backgroundColor: ['#4ade80', '#f87171'],
        hoverBackgroundColor: ['#34d399', '#f87171']
      }
    ]
  };

  return (
    <div className="container">
      <header className="header">
        <div className="logo">Finanzas Personales</div>
        <div className="search-bar">
          <input type="text" placeholder="Búsqueda" />
        </div>
        <div className="user-info">
          <span>User</span>
        </div>
        <div className="balance">
          <div className="balance-info">
            <p>Efectivo</p>
            <h2>$100.000</h2>
          </div>
        </div>
      </header>

      {/* Botones de navegación */}
      <nav className="nav-buttons">
        <NavLink to="/cuentas" className={({ isActive }) => isActive ? "nav-link active" : "nav-link"}>CUENTAS</NavLink>
        <NavLink to="/ahorros" className={({ isActive }) => isActive ? "nav-link active" : "nav-link"}>AHORROS</NavLink>
        <NavLink to="/gastos" className={({ isActive }) => isActive ? "nav-link active" : "nav-link"}>GASTOS</NavLink>
        <NavLink to="/aportes" className={({ isActive }) => isActive ? "nav-link active" : "nav-link"}>APORTES</NavLink>
        <NavLink to="/estadisticas" className={({ isActive }) => isActive ? "nav-link active" : "nav-link"}>Estadísticas</NavLink>
      </nav>


      {/* Gráficos y datos */}
      <div className="main-content">
        <div className="saldo-chart">
          <h2>Saldo</h2>
          <Chart type="bar" data={saldoData} />
        </div>

        <div className="credito-chart">
          <h2>Uso límite de Crédito</h2>
          <Chart type="pie" data={limiteCreditoData} />
          <p>Saldo crédito: $950.000</p>
          <p>Límite de crédito: $2.350.000</p>
        </div>

        <div className="ahorro-box">
          <h3>Ahorro</h3>
          <p>$620.000</p>
        </div>

        <div className="deudas-box">
          <h3>Deudas</h3>
          <p>$1.310.000</p>
        </div>

        <div className="gastos-categoria">
          <h3>Gastos por categoría</h3>
          <p>Vivienda: $500k</p>
          <p>Alimentación: $300k</p>
          <p>Ocio: $150k</p>
          <p>Otros: $150k</p>
        </div>
      </div>
    </div>
  );
};

export default InicioForm;
