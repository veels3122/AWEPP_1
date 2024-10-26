import React, { useState } from 'react';
import { useParams } from 'react-router-dom';
import { Chart } from 'primereact/chart';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';
import { Dropdown } from 'primereact/dropdown';
import { InputNumber } from 'primereact/inputnumber';
import { ToggleButton } from 'primereact/togglebutton';
import { useNavigate } from 'react-router-dom';
import './CuentaDetalle.css';

const CuentaDetalle = () => {
  const { cuentaId } = useParams(); // Obtener ID de la cuenta desde la URL
  const [cuenta, setCuenta] = useState({
    nombre: 'Efectivo',
    tipo: 'Efectivo',
    balance: 10000,
    color: '#8b5cf6',
  });

  const [mostrarModalEdicion, setMostrarModalEdicion] = useState(false);

  const saldoData = {
    labels: ['27/09', '30/09', '04/10', '08/10', '12/10'],
    datasets: [
      {
        label: 'Saldo',
        backgroundColor: cuenta.color,
        borderColor: cuenta.color,
        data: [10000, 10000, 10000, 10000, 10000], // Datos ficticios para mostrar en el gráfico
      },
    ],
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

  return (
    <div className="cuenta-detalle-container">
      <header className="cuenta-detalle-header">
        <button className="btn-volver" onClick={() => window.history.back()}>←</button>
        <h2>Detalles de Cuenta</h2>
        <div className="btn-actions">
          <button className="btn-editar" onClick={abrirModalEdicion}>Editar</button>
          <button className="btn-eliminar">Eliminar</button>
        </div>
      </header>

      <div className="cuenta-detalle-info">
        <div className="cuenta-icono">💰</div>
        <div className="cuenta-info">
          <h3>{cuenta.nombre}</h3>
          <p>Tipo: {cuenta.tipo}</p>
          <h4>{cuenta.balance.toLocaleString('es-CO', { style: 'currency', currency: 'COP' })}</h4>
        </div>
      </div>

      <div className="tabs">
        <button className="tab-button active">Saldo</button>
        <button className="tab-button">Registros</button>
      </div>

      <div className="cuenta-saldo">
        <h2>Hoy</h2>
        <h1>{cuenta.balance.toLocaleString('es-CO', { style: 'currency', currency: 'COP' })}</h1>
        <p>VS PERIODO ANTERIOR: 0%</p>
      </div>

      <div className="saldo-chart">
        <Chart type="line" data={saldoData} />
      </div>

      {/* Modal de edición */}
      <Dialog header="Editar Cuenta" visible={mostrarModalEdicion} style={{ width: '50vw' }} onHide={cerrarModalEdicion}>
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
            <InputNumber name="balance" value={cuenta.balance} onValueChange={(e) => setCuenta({ ...cuenta, balance: e.value })} mode="currency" currency="COP" />
          </div>
          <div className="form-field">
            <label>Excluir de las estadísticas</label>
            <ToggleButton onLabel="Sí" offLabel="No" checked={cuenta.excluir || false} onChange={(e) => setCuenta({ ...cuenta, excluir: e.value })} />
          </div>
          <div className="form-field">
            <label>Archivar</label>
            <ToggleButton onLabel="Sí" offLabel="No" checked={cuenta.archivar || false} onChange={(e) => setCuenta({ ...cuenta, archivar: e.value })} />
          </div>
          <div className="form-actions">
            <button className="btn-guardar" onClick={cerrarModalEdicion}>Guardar</button>
          </div>
        </div>
      </Dialog>
    </div>
  );
};

export default CuentaDetalle;
