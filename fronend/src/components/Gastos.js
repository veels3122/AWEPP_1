import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';
import { Dropdown } from 'primereact/dropdown';
import { InputNumber } from 'primereact/inputnumber';
import { ToggleButton } from 'primereact/togglebutton';
import './Gastos.css';

const Gastos = () => {
  const navigate = useNavigate();
  const [Gastos, setGastos] = useState([
  ]);

  const [mostrarModal, setMostrarModal] = useState(false);
  const [nuevaGasto, setNuevaGasto] = useState({
    id: null,
    nombre: '',
    tipo: 'General',
    balance: 0,
    color: '#ffffff',
    excluirEstadisticas: false,
  });

  // Abre el modal de agregar Gasto
  const abrirModal = () => {
    setNuevaGasto({
      id: Gastos.length + 1,
      nombre: '',
      tipo: 'General',
      balance: 0,
      color: '#ffffff',
      excluirEstadisticas: false,
    });
    setMostrarModal(true);
  };

  // Cierra el modal de agregar Gasto
  const cerrarModal = () => {
    setMostrarModal(false);
  };

  // Maneja los cambios en los inputs del formulario
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setNuevaGasto((prevGasto) => ({
      ...prevGasto,
      [name]: value,
    }));
  };

  // Guarda la nueva Gasto en el estado de Gastos
  const handleGuardarGasto = () => {
    setGastos((prevGastos) => [...prevGastos, nuevaGasto]);
    cerrarModal();
  };

  const tiposDeGasto = [
    { label: 'General', value: 'General' },
    { label: 'Efectivo', value: 'Efectivo' },
    { label: 'Gasto Actual', value: 'Gasto Actual' },
    { label: 'Tarjeta de Crédito', value: 'Tarjeta de Crédito' },
    { label: 'Gasto con sobregiro', value: 'Gasto con sobregiro' },
    { label: 'Gasto de Ahorros', value: 'Gasto de Ahorros' },
  ];

  return (
    <div className="Gastos-container">
      <header className="Gastos-header">
        <div className="Gastos-titulo-boton">
          <h2>Gastos</h2>
          <button className="btn-agregar" onClick={abrirModal}>
            + Agregar
          </button>
        </div>
      </header>

      <div className="Gastos-sidebar">
        <input type="text" placeholder="Buscar" className="buscar-Gastos" />
        <select className="ordenar-Gastos">
          <option value="default">Ordenar por</option>
          <option value="nombre">Nombre</option>
          <option value="balance">Balance</option>
        </select>
      </div>

      <div className="Gastos-lista">
        {Gastos.map((Gasto) => (
          <div
            key={Gasto.id}
            className="Gasto-item"
            onClick={() => navigate(`/Gastos/${Gasto.id}`)}
            style={{ cursor: 'pointer' }}
          >
            <div className="Gasto-icono">
              <i className="pi pi-wallet" style={{ color: '#004aad', fontSize: '2rem' }}></i>
            </div>
            <div className="Gasto-info" style={{ backgroundColor: Gasto.color }}>
              <h3>{Gasto.nombre}</h3>
              <p>{Gasto.tipo}</p>
              <h4>
                {Gasto.balance.toLocaleString('es-CO', {
                  style: 'currency',
                  currency: 'COP',
                })}
              </h4>
            </div>
          </div>
        ))}
      </div>

      <Dialog
        header="Añadir Gasto Manual"
        visible={mostrarModal}
        style={{ width: '50vw' }}
        onHide={cerrarModal}
      >
        <div className="editar-Gasto-form">
          <div className="form-field">
            <label>Nombre</label>
            <InputText
              name="nombre"
              value={nuevaGasto.nombre}
              onChange={handleInputChange}
              placeholder="Nombre de la Gasto"
            />
          </div>
          <div className="form-field">
            <label>Color</label>
            <input
              type="color"
              name="color"
              value={nuevaGasto.color}
              onChange={handleInputChange}
            />
          </div>
          <div className="form-field">
            <label>Tipo de Gasto</label>
            <Dropdown
              name="tipo"
              value={nuevaGasto.tipo}
              options={tiposDeGasto}
              onChange={(e) => setNuevaGasto({ ...nuevaGasto, tipo: e.value })}
              placeholder="Seleccione un tipo"
            />
          </div>
          <div className="form-field">
            <label>Monto inicial</label>
            <InputNumber
              name="balance"
              value={nuevaGasto.balance}
              onValueChange={(e) =>
                setNuevaGasto({ ...nuevaGasto, balance: e.value })
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
              checked={nuevaGasto.excluirEstadisticas}
              onChange={(e) =>
                setNuevaGasto({ ...nuevaGasto, excluirEstadisticas: e.value })
              }
            />
          </div>
          <div className="form-actions">
            <button className="btn-guardar" onClick={handleGuardarGasto}>
              Guardar
            </button>
          </div>
        </div>
      </Dialog>
    </div>
  );
};

export default Gastos;
