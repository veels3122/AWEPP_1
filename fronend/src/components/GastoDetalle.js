import React, { useState } from 'react';
import { useParams } from 'react-router-dom';
import { Chart } from 'primereact/chart';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';
import { Dropdown } from 'primereact/dropdown';
import { InputNumber } from 'primereact/inputnumber';
import { ToggleButton } from 'primereact/togglebutton';
import { useNavigate } from 'react-router-dom';
import './GastoDetalle.css';

const GastoDetalle = () => {
  const navigate = useNavigate();
  const { GastoId } = useParams(); // Obtener ID de la Gasto desde la URL

  const [Gasto, setGasto] = useState({
    nombre: 'Efectivo',
    tipo: 'Efectivo',
    balance: 10000,
    color: '#8b5cf6',
  });

  const [mostrarModalEdicion, setMostrarModalEdicion] = useState(false);
  const [activeTab, setActiveTab] = useState('saldo'); // Controla la pestaña activa

  const saldoData = {
    labels: ['27/09', '30/09', '04/10', '08/10', '12/10'],
    datasets: [
      {
        label: 'Saldo',
        backgroundColor: Gasto.color,
        borderColor: Gasto.color,
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
    setGasto((prevGasto) => ({ ...prevGasto, [name]: value }));
  };

  const handleEliminar = () => {
    // Aquí puedes agregar la lógica para eliminar la Gasto.
    // Por ejemplo, podrías hacer una llamada a la API o navegar a una página específica.
    console.log('Gasto eliminada:', GastoId);
    navigate('/Gastos'); // Redirigir a la lista de Gastos tras eliminar.
  };

  return (
    <div className="Gasto-detalle-container">
      <header className="Gasto-detalle-header">
        <button className="btn-volver" onClick={() => window.history.back()}>←</button>
        <h2>Detalles de Gasto</h2>
        <div className="btn-actions">
          <button className="btn-editar" onClick={abrirModalEdicion}>Editar</button>
          <button className="btn-eliminar" onClick={handleEliminar}>Eliminar</button>
        </div>
      </header>

      <div className="Gasto-detalle-info">
      <div className="Gasto-icono">
              <i className="pi pi-wallet" style={{ color: '#004aad', fontSize: '2rem' }}></i>
            </div>
        <div className="Gasto-info">
          <h3>{Gasto.nombre}</h3>
          <p>Tipo: {Gasto.tipo}</p>
          <h4>{Gasto.balance.toLocaleString('es-CO', { style: 'currency', currency: 'COP' })}</h4>
        </div>
      </div>

      <div className="tabs">
        <button 
          className={`tab-button ${activeTab === 'saldo' ? 'active' : ''}`} 
          onClick={() => setActiveTab('saldo')}
        >
          Saldo
        </button>
        <button 
          className={`tab-button ${activeTab === 'registros' ? 'active' : ''}`} 
          onClick={() => setActiveTab('registros')}
        >
          Registros
        </button>
      </div>

      {activeTab === 'saldo' && (
        <div>
          <div className="Gasto-saldo">
            <h2>Hoy</h2>
            <h1>{Gasto.balance.toLocaleString('es-CO', { style: 'currency', currency: 'COP' })}</h1>
            <p>VS PERIODO ANTERIOR: 0%</p>
          </div>
          <div className="saldo-chart">
            <Chart type="line" data={saldoData} />
          </div>
        </div>
      )}

      {activeTab === 'registros' && (
        <div className="Gasto-registros">
          <h2>Registros</h2>
          <div className="no-registros">
            <p>Añadir transacciones al contacto</p>
            <p>Añadir nuevas transacciones y mantener esta Gasto actualizada.</p>
            <p>Comienza con (+ Agregar) para crear el primero.</p>
            <button className="btn-agregar-registro">+ Agregar</button>
          </div>
        </div>
      )}

      {/* Modal de edición */}
      <Dialog header="Editar Gasto" visible={mostrarModalEdicion} style={{ width: '50vw' }} onHide={cerrarModalEdicion}>
        <div className="editar-Gasto-form">
          <div className="form-field">
            <label>Nombre</label>
            <InputText name="nombre" value={Gasto.nombre} onChange={handleInputChange} />
          </div>
          <div className="form-field">
            <label>Color</label>
            <input type="color" name="color" value={Gasto.color} onChange={handleInputChange} />
          </div>
          <div className="form-field">
            <label>Tipo de Gasto</label>
            <Dropdown
              name="tipo"
              value={Gasto.tipo}
              options={[{ label: 'Efectivo', value: 'Efectivo' }, { label: 'Bancaria', value: 'Bancaria' }]}
              onChange={(e) => setGasto({ ...Gasto, tipo: e.value })}
              placeholder="Seleccione un tipo"
            />
          </div>
          <div className="form-field">
            <label>Monto inicial</label>
            <InputNumber name="balance" value={Gasto.balance} onValueChange={(e) => setGasto({ ...Gasto, balance: e.value })} mode="currency" currency="COP" />
          </div>
          <div className="form-field">
            <label>Excluir de las estadísticas</label>
            <ToggleButton onLabel="Sí" offLabel="No" checked={Gasto.excluir || false} onChange={(e) => setGasto({ ...Gasto, excluir: e.value })} />
          </div>
          <div className="form-field">
            <label>Archivar</label>
            <ToggleButton onLabel="Sí" offLabel="No" checked={Gasto.archivar || false} onChange={(e) => setGasto({ ...Gasto, archivar: e.value })} />
          </div>
          <div className="form-actions">
            <button className="btn-guardar" onClick={cerrarModalEdicion}>Guardar</button>
          </div>
        </div>
      </Dialog>
    </div>
  );
};

export default GastoDetalle;
