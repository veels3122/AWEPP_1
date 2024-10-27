import React from 'react';
import { useNavigate } from 'react-router-dom';
import './RegistroExitoso.css'; // Puedes crear un archivo CSS para este componente

const RegistroExitoso = () => {
  const navigate = useNavigate();

  return (
    <div className="registro-exitoso-container">
      <h2>Registro Exitoso</h2>
      <p>¡Tu registro se ha completado con éxito!</p>
      <button onClick={() => navigate('/Login')}>Ir al Login</button>
    </div>
  );
};

export default RegistroExitoso;
