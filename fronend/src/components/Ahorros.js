import React, { useState } from 'react';
import { Chart } from 'primereact/chart';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';
import { InputNumber } from 'primereact/inputnumber';
import { ProgressBar } from 'primereact/progressbar';
import { FaTrashAlt } from 'react-icons/fa'; 
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

  const [ahorroSeleccionado, setAhorroSeleccionado] = useState(null);
  const [mostrarModalEdicion, setMostrarModalEdicion] = useState(false);
  const [mostrarModalAgregarDinero, setMostrarModalAgregarDinero] = useState(false);
  const [cantidadAgregar, setCantidadAgregar] = useState(0);

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

  // Maneja los cambios en los inputs del formulario de nuevo ahorro
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

  // Abre el modal de edición para un ahorro específico
  const abrirModalEdicion = (ahorro) => {
    setAhorroSeleccionado(ahorro);
    setMostrarModalEdicion(true);
  };

  // Cierra el modal de edición
  const cerrarModalEdicion = () => {
    setMostrarModalEdicion(false);
  };

  // Maneja los cambios en los inputs del formulario de edición
  const handleEdicionInputChange = (e) => {
    const { name, value } = e.target;
    setAhorroSeleccionado((prevAhorro) => ({
      ...prevAhorro,
      [name]: value,
    }));
  };

  // Guarda los cambios hechos al ahorro seleccionado
  const handleGuardarEdicion = () => {
    setAhorros((prevAhorros) =>
      prevAhorros.map((ahorro) =>
        ahorro.id === ahorroSeleccionado.id ? ahorroSeleccionado : ahorro
      )
    );
    cerrarModalEdicion();
  };

  // Eliminar ahorro específico
  const handleEliminarAhorro = (id) => {
    setAhorros((prevAhorros) => prevAhorros.filter((ahorro) => ahorro.id !== id));
  };

    // Abre el modal para agregar dinero al ahorro seleccionado
    const abrirModalAgregarDinero = (ahorro) => {
      setAhorroSeleccionado(ahorro);
      setCantidadAgregar(0); // Inicializa la cantidad a agregar en 0
      setMostrarModalAgregarDinero(true);
    };
  
    // Cierra el modal de agregar dinero
    const cerrarModalAgregarDinero = () => {
      setMostrarModalAgregarDinero(false);
    };

      // Maneja la acción de agregar dinero al ahorro seleccionado
  const handleAgregarDinero = () => {
    setAhorros((prevAhorros) =>
      prevAhorros.map((ahorro) =>
        ahorro.id === ahorroSeleccionado.id
          ? { ...ahorro, balanceActual: ahorro.balanceActual + cantidadAgregar }
          : ahorro
      )
    );
    cerrarModalAgregarDinero();
  };

  // Calcula el total de los ahorros actuales
  const totalAhorros = ahorros.reduce((total, ahorro) => total + ahorro.balanceActual, 0);

  // Calcula la meta total de ahorro sumando todas las metas de ahorro
  const metaTotalAhorro = ahorros.reduce((total, ahorro) => total + ahorro.meta, 0);

  // Calcula el progreso hacia la meta total de ahorro
  const progresoMetaTotal = metaTotalAhorro > 0 ? (totalAhorros / metaTotalAhorro) * 100 : 0;

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
          <h3>Meta Total de Ahorro</h3>
          <h1>
            {metaTotalAhorro.toLocaleString('es-CO', {
              style: 'currency',
              currency: 'COP',
            })}
          </h1>
          <ProgressBar value={progresoMetaTotal} />
          <p>{progresoMetaTotal.toFixed(2)}% alcanzado</p>
        </div>
        <div className="ahorros-total">
          <h3>Total Ahorros Actuales</h3>
          <h1>
            {totalAhorros.toLocaleString('es-CO', {
              style: 'currency',
              currency: 'COP',
            })}
          </h1>
        </div>
        <div className="ahorros-chart grafica-container">
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
            <div
              className="ahorro-progreso"
              onClick={() => abrirModalEdicion(ahorro)}
              style={{ cursor: 'pointer', position: 'relative' }}
            >
              <ProgressBar value={(ahorro.balanceActual / ahorro.meta) * 100} />
              <FaTrashAlt
                onClick={(e) => {
                  e.stopPropagation(); // Para evitar abrir el modal de edición
                  handleEliminarAhorro(ahorro.id);
                }}
                style={{
                  color: 'red',
                  position: 'absolute',
                  top: '50%',
                  right: '10px',
                  transform: 'translateY(-50%)',
                  cursor: 'pointer',
                }}
              />
              <div className="ahorro-metas">
                <p>
                  Meta: {ahorro.meta.toLocaleString('es-CO', { style: 'currency', currency: 'COP' })}
                </p>
                <p>
                  Actual:{' '}
                  {ahorro.balanceActual.toLocaleString('es-CO', {
                    style: 'currency',
                    currency: 'COP',
                  })}
                </p>
              </div>
            </div>
            <button className="btn-agregar-dinero" onClick={() => abrirModalAgregarDinero(ahorro)}>
              Agregar Dinero
            </button>
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
      
      {/* Modal para agregar dinero al ahorro */}
      {ahorroSeleccionado && (
        <Dialog
          header={`Agregar Dinero a ${ahorroSeleccionado.nombre}`}
          visible={mostrarModalAgregarDinero}
          style={{ width: '50vw' }}
          onHide={cerrarModalAgregarDinero}
        >
          <div className="agregar-dinero-form">
            <div className="form-field">
              <label>Cantidad a Agregar</label>
              <InputNumber
                value={cantidadAgregar}
                onValueChange={(e) => setCantidadAgregar(e.value)}
                mode="currency"
                currency="COP"
                min={0}
              />
            </div>
            <div className="form-actions">
              <button className="btn-guardar" onClick={handleAgregarDinero}>
                Agregar Dinero
              </button>
            </div>
          </div>
        </Dialog>
      )}

      {/* Modal para editar ahorro */}
      {ahorroSeleccionado && (
        <Dialog
          header="Editar Ahorro"
          visible={mostrarModalEdicion}
          style={{ width: '50vw' }}
          onHide={cerrarModalEdicion}
        >
          <div className="editar-ahorro-form">
            <div className="form-field">
              <label>Nombre</label>
              <InputText
                name="nombre"
                value={ahorroSeleccionado.nombre}
                onChange={handleEdicionInputChange}
                placeholder="Nombre del objetivo de ahorro"
              />
            </div>
            <div className="form-field">
              <label>Meta de Ahorro</label>
              <InputNumber
                name="meta"
                value={ahorroSeleccionado.meta}
                onValueChange={(e) =>
                  setAhorroSeleccionado({ ...ahorroSeleccionado, meta: e.value })
                }
                mode="currency"
                currency="COP"
                min={0}
              />
            </div>
            <div className="form-field">
              <label>Balance Actual</label>
              <InputNumber
                name="balanceActual"
                value={ahorroSeleccionado.balanceActual}
                onValueChange={(e) =>
                  setAhorroSeleccionado({ ...ahorroSeleccionado, balanceActual: e.value })
                }
                mode="currency"
                currency="COP"
                min={0}
              />
            </div>
            <div className="form-field">
              <label>Descripción</label>
              <InputText
                name="descripcion"
                value={ahorroSeleccionado.descripcion}
                onChange={handleEdicionInputChange}
                placeholder="Descripción del ahorro"
              />
            </div>
            <div className="form-actions">
              <button className="btn-guardar" onClick={handleGuardarEdicion}>
                Guardar Cambios
              </button>
            </div>
          </div>
        </Dialog>
      )}
    </div>
  );
};

export default Ahorros;
