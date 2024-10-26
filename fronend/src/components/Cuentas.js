import React, { useState } from 'react';
import './Cuentas.css'; // Añadir CSS para el estilo específico de esta página

const Cuentas = () => {
  const [cuentas, setCuentas] = useState([
    { nombre: 'Efectivo', tipo: 'Efectivo', balance: 10000 },
  ]);

  return (
    <div className="cuentas-container">
      <header className="cuentas-header">
        <h2>Cuentas</h2>
        <button className="btn-agregar">+ Agregar</button>
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
    </div>
  );
};

export default Cuentas;
