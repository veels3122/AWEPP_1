import { Chart } from 'primereact/chart';
import './InicioForm.css';
import React, { useState } from 'react';
import { NavLink } from 'react-router-dom';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';
import { Dropdown } from 'primereact/dropdown';
import { InputNumber } from 'primereact/inputnumber';
import { ToggleButton } from 'primereact/togglebutton';

const InicioForm = () => {
  const [mostrarModalEdicion, setMostrarModalEdicion] = useState(false);

  // Datos de la cuenta
  const [cuenta, setCuenta] = useState({
    nombre: 'Efectivo',
    tipo: 'Efectivo',
    balance: 10000,
    color: '#d4af37'
  });

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

  const abrirModalEdicion = () => {
    setMostrarModalEdicion(true);
  };

  const cerrarModalEdicion = () => {
    setMostrarModalEdicion(false);
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setCuenta((prevCuenta) => ({ ...prevCuenta, [name]: value }));
  };

  const handleGuardarCambios = () => {
    // Guardar los cambios y cerrar el modal
    setMostrarModalEdicion(false);
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
          <div
            className="balance-info"
            onClick={abrirModalEdicion}
            style={{ cursor: 'pointer', backgroundColor: cuenta.color }}
          >
            <p>{cuenta.nombre}</p>
            <h2>
              {cuenta.balance.toLocaleString('es-CO', {
                style: 'currency',
                currency: 'COP'
              })}
            </h2>
          </div>
        </div>
      </header>

      {/* Botones de navegación */}
      <nav className="nav-buttons">
        <NavLink to="/cuentas" className={({ isActive }) => (isActive ? 'nav-link active' : 'nav-link')}>
          CUENTAS
        </NavLink>
        <NavLink to="/ahorros" className={({ isActive }) => (isActive ? 'nav-link active' : 'nav-link')}>
          AHORROS
        </NavLink>
        <NavLink to="/gastos" className={({ isActive }) => (isActive ? 'nav-link active' : 'nav-link')}>
          GASTOS
        </NavLink>
        <NavLink to="/aportes" className={({ isActive }) => (isActive ? 'nav-link active' : 'nav-link')}>
          APORTES
        </NavLink>
        <NavLink to="/estadisticas" className={({ isActive }) => (isActive ? 'nav-link active' : 'nav-link')}>
          Estadísticas
        </NavLink>
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

      {/* Modal de edición */}
      <Dialog
        header="Editar Cuenta"
        visible={mostrarModalEdicion}
        style={{ width: '50vw' }}
        onHide={cerrarModalEdicion}
      >
        <div className="editar-cuenta-form">
          <div className="form-field">
            <label>Nombre</label>
            <InputText name="nombre" value={cuenta.nombre} onChange={handleInputChange} />
          </div>
          <div className="form-field">
            <label>Color</label>
            <input type="color" name="color" value={cuenta.color} onChange={handleInputChange} />
          </div>
          <div className="form-field">
            <label>Tipo de cuenta</label>
            <Dropdown
              name="tipo"
              value={cuenta.tipo}
              options={[{ label: 'Efectivo', value: 'Efectivo' }, { label: 'Bancaria', value: 'Bancaria' }]}
              onChange={(e) => setCuenta({ ...cuenta, tipo: e.value })}
              placeholder="Seleccione un tipo"
            />
          </div>
          <div className="form-field">
            <label>Monto inicial</label>
            <InputNumber
              name="balance"
              value={cuenta.balance}
              onValueChange={(e) => setCuenta({ ...cuenta, balance: e.value })}
              mode="currency"
              currency="COP"
            />
          </div>
          <div className="form-field">
            <label>Excluir de las estadísticas</label>
            <ToggleButton
              onLabel="Sí"
              offLabel="No"
              checked={cuenta.excluir || false}
              onChange={(e) => setCuenta({ ...cuenta, excluir: e.value })}
            />
          </div>
          <div className="form-field">
            <label>Archivar</label>
            <ToggleButton
              onLabel="Sí"
              offLabel="No"
              checked={cuenta.archivar || false}
              onChange={(e) => setCuenta({ ...cuenta, archivar: e.value })}
            />
          </div>
          <div className="form-actions">
            <button className="btn-guardar" onClick={handleGuardarCambios}>
              Guardar
            </button>
          </div>
        </div>
      </Dialog>
    </div>
  );
};

export default InicioForm;
