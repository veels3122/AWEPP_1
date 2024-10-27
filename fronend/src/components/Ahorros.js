import React, { useState } from 'react';
import { Chart } from 'primereact/chart';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';
import { InputNumber } from 'primereact/inputnumber';
import { ProgressBar } from 'primereact/progressbar';
import './Ahorros.css';

const Ahorros = () => {
  const [ahorros, setAhorros] = useState([]);
  const [mostrarModal, setMostrarModal] = useState(false);
  const [nuevoAhorro, setNuevoAhorro] = useState({
    id: null,
    nombre: '',
    meta: 0,
    balanceActual: 0,
    descripcion: '',
  });

  // Abre el modal de agregar ahorro
  const abrirModal = () => {
    setNuevoAhorro({
      id: ahorros.length + 1,
      nombre: '',
      meta: 0,
      balanceActual: 0,
      descripcion: '',
    });
    setMostrarModal(true);
  };

  // Cierra el modal de agregar ahorro
  const cerrarModal = () => {
    setMostrarModal(false);
  };

  // Maneja los cambios en los inputs del formulario
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setNuevoAhorro((prevAhorro) => ({
      ...prevAhorro,
      [name]: value,
    }));
  };

  // Guarda el nuevo ahorro en el estado de ahorros
  const handleGuardarAhorro = () => {
    setAhorros((prevAhorros) => [...prevAhorros, nuevoAhorro]);
    cerrarModal();
  };

  const totalAhorros = ahorros.reduce((total, ahorro) => total + ahorro.balanceActual, 0);

  return (
    <div className="ahorros-container">
      <header className="ahorros-header">
        <h2>Ahorros</h2>
        <button className="btn-agregar" onClick={abrirModal}>
          + Crear Ahorro
        </button>
      </header>

      <div className="ahorros-overview">
        <div className="ahorros-total">
          <h3>Total Ahorros</h3>
          <h1>
            {totalAhorros.toLocaleString('es-CO', {
              style: 'currency',
              currency: 'COP',
            })}
          </h1>
        </div>
        <div className="ahorros-chart">
          <Chart
            type="doughnut"
            data={{
              labels: ahorros.map((ahorro) => ahorro.nombre),
              datasets: [
                {
                  data: ahorros.map((ahorro) => ahorro.balanceActual),
                  backgroundColor: ['#42A5F5', '#66BB6A', '#FFA726', '#AB47BC', '#26C6DA'],
                },
              ],
            }}
          />
        </div>
      </div>

      <div className="ahorros-lista">
        {ahorros.map((ahorro) => (
          <div key={ahorro.id} className="ahorro-item">
            <div className="ahorro-header">
              <h3>{ahorro.nombre}</h3>
              <p>{ahorro.descripcion}</p>
            </div>
            <ProgressBar value={(ahorro.balanceActual / ahorro.meta) * 100} />
            <div className="ahorro-metas">
              <p>
                Meta: {ahorro.meta.toLocaleString('es-CO', { style: 'currency', currency: 'COP' })}
              </p>
              <p>
                Actual: {ahorro.balanceActual.toLocaleString('es-CO', { style: 'currency', currency: 'COP' })}
              </p>
            </div>
          </div>
        ))}
      </div>

      {/* Modal para crear un nuevo ahorro */}
      <Dialog
        header="Crear Nuevo Ahorro"
        visible={mostrarModal}
        style={{ width: '50vw' }}
        onHide={cerrarModal}
      >
        <div className="crear-ahorro-form">
          <div className="form-field">
            <label>Nombre</label>
            <InputText
              name="nombre"
              value={nuevoAhorro.nombre}
              onChange={handleInputChange}
              placeholder="Nombre del objetivo de ahorro"
            />
          </div>
          <div className="form-field">
            <label>Meta de Ahorro</label>
            <InputNumber
              name="meta"
              value={nuevoAhorro.meta}
              onValueChange={(e) => setNuevoAhorro({ ...nuevoAhorro, meta: e.value })}
              mode="currency"
              currency="COP"
              min={0}
            />
          </div>
          <div className="form-field">
            <label>Balance Inicial</label>
            <InputNumber
              name="balanceActual"
              value={nuevoAhorro.balanceActual}
              onValueChange={(e) => setNuevoAhorro({ ...nuevoAhorro, balanceActual: e.value })}
              mode="currency"
              currency="COP"
              min={0}
            />
          </div>
          <div className="form-field">
            <label>Descripción</label>
            <InputText
              name="descripcion"
              value={nuevoAhorro.descripcion}
              onChange={handleInputChange}
              placeholder="Descripción del ahorro (opcional)"
            />
          </div>
          <div className="form-actions">
            <button className="btn-guardar" onClick={handleGuardarAhorro}>
              Guardar
            </button>
          </div>
        </div>
      </Dialog>
    </div>
  );
};

export default Ahorros;
