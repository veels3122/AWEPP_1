import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';
import { Dropdown } from 'primereact/dropdown';
import { InputNumber } from 'primereact/inputnumber';
import { ToggleButton } from 'primereact/togglebutton';
import './Cuentas.css';

const Cuentas = () => {
  const navigate = useNavigate();
  const [cuentas, setCuentas] = useState([]);

  const [mostrarModal, setMostrarModal] = useState(false);
  const [nuevaCuenta, setNuevaCuenta] = useState({
    id: null,
    nombre: '',
    tipo: 'General',
    balance: 0,
    color: '#ffffff',
    excluirEstadisticas: false,
  });

  // Abre el modal de agregar cuenta
  const abrirModal = () => {
    setNuevaCuenta({
      id: cuentas.length + 1,
      nombre: '',
      tipo: 'General',
      balance: 0,
      color: '#ffffff',
      excluirEstadisticas: false,
    });
    setMostrarModal(true);
  };

  // Cierra el modal de agregar cuenta
  const cerrarModal = () => {
    setMostrarModal(false);
  };

  // Maneja los cambios en los inputs del formulario
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setNuevaCuenta((prevCuenta) => ({
      ...prevCuenta,
      [name]: value,
    }));
  };

  // Guarda la nueva cuenta en el estado de cuentas
  const handleGuardarCuenta = () => {
    setCuentas((prevCuentas) => [...prevCuentas, nuevaCuenta]);
    cerrarModal();
  };

  const tiposDeCuenta = [
    { label: 'General', value: 'General' },
    { label: 'Efectivo', value: 'Efectivo' },
    { label: 'Cuenta Actual', value: 'Cuenta Actual' },
    { label: 'Tarjeta de Crédito', value: 'Tarjeta de Crédito' },
    { label: 'Cuenta con sobregiro', value: 'Cuenta con sobregiro' },
    { label: 'Cuenta de Ahorros', value: 'Cuenta de Ahorros' },
  ];

  return (
    <div className="cuentas-container">
      <header className="cuentas-header">
        <div className="cuentas-titulo-boton">
          <h2>Cuentas</h2>
          <button className="btn-agregar" onClick={abrirModal}>
            + Agregar
          </button>
        </div>
      </header>
      
      <div className="cuentas-sidebar">
        <input type="text" placeholder="Buscar" className="buscar-cuentas" />
        <select className="ordenar-cuentas">
          <option value="default">Ordenar por</option>
          <option value="nombre">Nombre</option>
          <option value="balance">Balance</option>
        </select>
      </div>

      <div className="cuentas-lista">
        {cuentas.map((cuenta) => (
          <div
            key={cuenta.id}
            className="cuenta-item"
            onClick={() => navigate(`/cuentas/${cuenta.id}`)}
            style={{ cursor: 'pointer' }}
          >
            <div className="cuenta-icono">
              <i className="pi pi-wallet" style={{ color: '#004aad', fontSize: '2rem' }}></i>
            </div>
            <div className="cuenta-info" style={{ backgroundColor: cuenta.color }}>
              <h3>{cuenta.nombre}</h3>
              <p>{cuenta.tipo}</p>
              <h4>
                {cuenta.balance.toLocaleString('es-CO', {
                  style: 'currency',
                  currency: 'COP',
                })}
              </h4>
            </div>
          </div>
        ))}
      </div>

      <Dialog
        header="Añadir Cuenta Manual"
        visible={mostrarModal}
        style={{ width: '50vw' }}
        onHide={cerrarModal}
      >
        <div className="editar-cuenta-form">
          <div className="form-field">
            <label>Nombre</label>
            <InputText
              name="nombre"
              value={nuevaCuenta.nombre}
              onChange={handleInputChange}
              placeholder="Nombre de la cuenta"
            />
          </div>
          <div className="form-field">
            <label>Color</label>
            <input
              type="color"
              name="color"
              value={nuevaCuenta.color}
              onChange={handleInputChange}
            />
          </div>
          <div className="form-field">
            <label>Tipo de cuenta</label>
            <Dropdown
              name="tipo"
              value={nuevaCuenta.tipo}
              options={tiposDeCuenta}
              onChange={(e) => setNuevaCuenta({ ...nuevaCuenta, tipo: e.value })}
              placeholder="Seleccione un tipo"
            />
          </div>
          <div className="form-field">
            <label>Monto inicial</label>
            <InputNumber
              name="balance"
              value={nuevaCuenta.balance}
              onValueChange={(e) =>
                setNuevaCuenta({ ...nuevaCuenta, balance: e.value })
              }
              mode="currency"
              currency="COP"
              min={0}
            />
          </div>
          <div className="form-field">
            <label>Excluir de las estadísticas</label>
            <ToggleButton
              onLabel="Sí"
              offLabel="No"
              checked={nuevaCuenta.excluirEstadisticas}
              onChange={(e) =>
                setNuevaCuenta({ ...nuevaCuenta, excluirEstadisticas: e.value })
              }
            />
          </div>
          <div className="form-actions">
            <button className="btn-guardar" onClick={handleGuardarCuenta}>
              Guardar
            </button>
          </div>
        </div>
      </Dialog>
    </div>
  );
};

export default Cuentas;
