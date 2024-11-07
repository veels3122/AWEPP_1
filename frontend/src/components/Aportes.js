import React, { useState } from 'react';

const Aportes = () => {
  const [aportes, setAportes] = useState([
    { fecha: '2023-11-01', concepto: 'Sueldo', monto: 1000, estado: 'Procesado' },
    // ... más aportes
  ]);

  return (
    <div>
      <h2>Página de Aportes</h2>
      <p>Aquí puedes ver y administrar todas tus Aportes.</p>

      <table>
        <thead>
          <tr>
            <th>Fecha</th>
            <th>Concepto</th>
            <th>Monto</th>
            <th>Estado</th>
          </tr>
        </thead>
        <tbody>
          {aportes.map(aporte => (
            <tr key={aporte.fecha}>
              <td>{aporte.fecha}</td>
              <td>{aporte.concepto}</td>
              <td>${aporte.monto.toFixed(2)}</td>
              <td>{aporte.estado}</td>
              
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Aportes;