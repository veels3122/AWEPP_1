import React, { useState } from 'react';
import Navbar from './Navbar';
import './Cuentas.css'; 
import { Dialog } from 'primereact/dialog';

const Cuentas = () => {
  const [cuentas] = useState([
    { nombre: 'Efectivo', tipo: 'Efectivo', balance: 10000 },
  ]);

  const [mostrarModal, setMostrarModal] = useState(false);

  const abrirModal = () => {
    setMostrarModal(true);
  };

  const cerrarModal = () => {
    setMostrarModal(false);
  };

  return (
    <div className="cuentas-container">
      <header className="cuentas-header">
        <h2>Cuentas</h2>
        <button className="btn-agregar" onClick={abrirModal}>+ Agregar</button>
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
        {cuentas.map((cuenta, index) => (
          <div key={index} className="cuenta-item">
            <div className="cuenta-icono">💰</div>
            <div className="cuenta-info">
              <h3>{cuenta.nombre}</h3>
              <p>{cuenta.tipo}</p>
              <h4>{cuenta.balance.toLocaleString('es-CO', { style: 'currency', currency: 'COP' })}</h4>
            </div>
          </div>
        ))}
      </div>

      {/* Modal para añadir una nueva cuenta */}
      <Dialog
        header="Añadir Cuenta"
        visible={mostrarModal}
        style={{ width: '50vw' }}
        onHide={cerrarModal}
      >
        <div className="opciones-agregar">
          <div className="opcion">
            <div className="opcion-icono">🏦</div>
            <h3>Sincronización Bancaria</h3>
            <p>Conéctese a su cuenta bancaria. Sincronice sus transacciones automáticamente.</p>
          </div>
          <div className="opcion">
            <div className="opcion-icono">✏️</div>
            <h3>Ingreso Manual</h3>
            <p>Actualiza tu cuenta manualmente. Puedes conectar tu banco o importar más tarde.</p>
          </div>
          <div className="opcion">
            <div className="opcion-icono">📄</div>
            <h3>Importaciones</h3>
            <p>Sube tu historial de transacciones importando CSV, Excel, OFX u otros archivos.</p>
          </div>
        </div>
      </Dialog>
    </div>
  );
};

export default Cuentas;
