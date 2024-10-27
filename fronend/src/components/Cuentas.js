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
  const [mostrarModalOpciones, setMostrarModalOpciones] = useState(false);
  const [mostrarModalSincronizacion, setMostrarModalSincronizacion] = useState(false); // Nuevo estado para el modal de sincronización bancaria
  const [nuevaCuenta, setNuevaCuenta] = useState({
    id: null,
    nombre: '',
    tipo: 'General',
    balance: 0,
    color: '#ffffff',
    excluirEstadisticas: false,
  });


  
  const [selectedCountry, setSelectedCountry] = useState(null);
  const [selectedBank, setSelectedBank] = useState(null);

  const countries = [
    { label: 'Argentina', value: 'Argentina' },
    { label: 'Colombia', value: 'Colombia' },
    { label: 'México', value: 'México' },
    { label: 'Estados Unidos', value: 'Estados Unidos' },
    { label: 'España', value: 'España' },
    { label: 'Brasil', value: 'Brasil' },
    { label: 'Francia', value: 'Francia' },
    { label: 'Alemania', value: 'Alemania' },
    { label: 'Reino Unido', value: 'Reino Unido' },
    { label: 'Italia', value: 'Italia' },
    { label: 'China', value: 'China' },
    { label: 'Japón', value: 'Japón' },
    { label: 'India', value: 'India' },
    { label: 'Rusia', value: 'Rusia' },
    { label: 'Canadá', value: 'Canadá' },
    { label: 'Australia', value: 'Australia' },
    { label: 'Sudáfrica', value: 'Sudáfrica' },
    { label: 'Corea del Sur', value: 'Corea del Sur' },
    { label: 'Portugal', value: 'Portugal' },
    { label: 'Países Bajos', value: 'Países Bajos' },
];

const bankOptions = {
  Argentina: [
    { label: 'BUXFER', value: 'BUXFER' },
    { label: 'BBVA Argentina', value: 'BBVA Argentina' },
    { label: 'Banco de la Nación Argentina', value: 'Banco de la Nación Argentina' },
  ],
  Colombia: [
    { label: 'Banco de Bogotá', value: 'Banco de Bogotá' },
    { label: 'BBVA Colombia', value: 'BBVA Colombia' },
    { label: 'Bancolombia', value: 'Bancolombia' },
  ],
  México: [
    { label: 'BBVA México', value: 'BBVA México' },
    { label: 'Banorte', value: 'Banorte' },
    { label: 'Santander México', value: 'Santander México' },
  ],
  'Estados Unidos': [
    { label: 'Bank of America', value: 'Bank of America' },
    { label: 'Chase', value: 'Chase' },
    { label: 'Wells Fargo', value: 'Wells Fargo' },
  ],
  España: [
    { label: 'BBVA España', value: 'BBVA España' },
    { label: 'Banco Santander', value: 'Banco Santander' },
    { label: 'CaixaBank', value: 'CaixaBank' },
  ],
  Brasil: [
    { label: 'Banco do Brasil', value: 'Banco do Brasil' },
    { label: 'Bradesco', value: 'Bradesco' },
    { label: 'Itaú', value: 'Itaú' },
  ],
  Francia: [
    { label: 'BNP Paribas', value: 'BNP Paribas' },
    { label: 'Crédit Agricole', value: 'Crédit Agricole' },
    { label: 'Société Générale', value: 'Société Générale' },
  ],
  Alemania: [
    { label: 'Deutsche Bank', value: 'Deutsche Bank' },
    { label: 'Commerzbank', value: 'Commerzbank' },
    { label: 'Sparkasse', value: 'Sparkasse' }, 
  ],
  ReinoUnido: [
    { label: 'HSBC', value: 'HSBC' },
    { label: 'Barclays', value: 'Barclays' },
    { label: 'Lloyds Bank', value: 'Lloyds Bank' },
  ],
  Italia: [
    { label: 'Intesa Sanpaolo', value: 'Intesa Sanpaolo' },
    { label: 'Unicredit', value: 'Unicredit' },
    { label: 'Monte dei Paschi di Siena', value: 'Monte dei Paschi di Siena' },
  ]};


};

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
    setMostrarModalOpciones(true);
  };

  // Cierra el modal de agregar cuenta
  const cerrarModal = () => {
    setMostrarModal(false);
  };

  // Cierra el modal de opciones avanzadas
  const cerrarModalOpciones = () => {
    setMostrarModalOpciones(false);
  };

const abrirModalSincronizacion = () => {
    setMostrarModalSincronizacion(true);
    setErrorMessage(""); // Resetea el mensaje de error al abrir el modal
  };

  const cerrarModalSincronizacion = () => {
    setMostrarModalSincronizacion(false);
    setSelectedCountry(null);
    setSelectedBank(null);
    setErrorMessage("");
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


  // Actualiza la selección de bancos según el país
  const handleCountryChange = (e) => {
    setSelectedCountry(e.value);
    setSelectedBank(null); // Resetea el banco seleccionado cuando cambia el país
  };

  // Función para continuar la sincronización bancaria con validación
  const handleSyncContinue = () => {
    if (!selectedCountry || !selectedBank) {
      setErrorMessage("Por favor, seleccione su país y banco antes de continuar.");
    } else {
      alert(`Sincronizando con el banco ${selectedBank} en ${selectedCountry}`);
      cerrarModalSincronizacion();
    }
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
    <div>
      {/* Botón para abrir el modal de sincronización bancaria */}
      <button onClick={abrirModalSincronizacion}>Sincronización Bancaria</button>

      {/* Modal de Sincronización Bancaria */}
      <Dialog
        header="Sincronización Bancaria"
        visible={mostrarModalSincronizacion}
        style={{ width: '40vw' }}
        onHide={cerrarModalSincronizacion}
      >
        <div className="sincronizacion-form">
          <div className="form-field">
            <label>Seleccione su País:</label>
            <Dropdown
              value={selectedCountry}
              options={countries}
              onChange={handleCountryChange}
              placeholder="Seleccione un país"
            />
          </div>
          <div className="form-field">
            <label>Seleccione su Banco:</label>
            <Dropdown
              value={selectedBank}
              options={selectedCountry ? bankOptions[selectedCountry] : []} // Opciones de bancos dinámicas
              onChange={(e) => setSelectedBank(e.value)}
              placeholder="Seleccione un banco"
              disabled={!selectedCountry} // Deshabilitado hasta que se seleccione un país
            />
          </div>

          {/* Mensaje de error si no se han seleccionado ambos campos */}
          {errorMessage && <p style={{ color: 'red' }}>{errorMessage}</p>}

          {/* Botón "Continuar" deshabilitado hasta que ambos campos sean seleccionados */}
          <button
            className="action-btn"
            onClick={handleSyncContinue}
            disabled={!selectedCountry || !selectedBank}
          >
            Continuar
          </button>
        </div>
      </Dialog>
    </div>,
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

      {/* Modal para seleccionar opciones de cuenta */}
      <Dialog
        header="AÑADIR CUENTA"
        visible={mostrarModalOpciones}
        style={{ width: '60vw' }}
        onHide={cerrarModalOpciones}
      >
        <div className="opciones-agregar">
          <div className="opcion" onClick={abrirModalSincronizacion}>
            <i className="pi pi-sync opcion-icono" style={{ color: '#004aad' }}></i>
            <h3>Sincronización Bancaria</h3>
            <p>Conéctese a su cuenta bancaria. Sincronice sus transacciones a Wallet automáticamente.</p>
          </div>
          <div className="opcion" onClick={() => { setMostrarModal(true); setMostrarModalOpciones(false); }}>
            <i className="pi pi-upload opcion-icono" style={{ color: '#004aad' }}></i>
            <h3>Importaciones</h3>
            <p>Sube tu historial de transacciones importando CSV, Excel, OFX u otros archivos.</p>
          </div>
          <div className="opcion" onClick={() => { setMostrarModal(true); setMostrarModalOpciones(false); }}>
            <i className="pi pi-pencil opcion-icono" style={{ color: '#004aad' }}></i>
            <h3>Ingreso Manual</h3>
            <p>Actualiza tu cuenta manualmente. Puedes conectar tu banco o importar más tarde.</p>
          </div>
          <div className="opcion">
            <i className="pi pi-chart-bar opcion-icono" style={{ color: '#004aad' }}></i>
            <h3>Inversiones</h3>
            <p>Cree una cuenta de inversión con el valor de su cartera actualizado automáticamente en su aplicación móvil Wallet.</p>
          </div>
        </div>
      </Dialog>

      {/* Modal de Sincronización Bancaria */}
      <Dialog
        header="Sincronización Bancaria"
        visible={mostrarModalSincronizacion}
        style={{ width: '40vw' }}
        onHide={cerrarModalSincronizacion}
      >
        <div className="sincronizacion-form">
          <div className="form-field">
            <label>Seleccione su País:</label>
            <Dropdown
              value={selectedCountry}
              options={countries}
              onChange={(e) => setSelectedCountry(e.value)}
              placeholder="Seleccione un país"
            />
          </div>
          <div className="form-field">
            <label>Seleccione su Banco:</label>
            <Dropdown
              value={selectedBank}
              options={banks}
              onChange={(e) => setSelectedBank(e.value)}
              placeholder="Seleccione un banco"
            />
          </div>
          <button className="action-btn" onClick={handleSyncContinue}>
            Continuar
          </button>
        </div>
      </Dialog>

      {/* Modal para crear una nueva cuenta */}
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
