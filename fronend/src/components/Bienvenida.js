// /components/Bienvenida.js
import React from 'react';
import { useNavigate } from 'react-router-dom';

function Bienvenida() {
  const navigate = useNavigate();

  return (
    <div style={{
      display: 'flex',
      flexDirection: 'column',
      alignItems: 'center',
      justifyContent: 'center',
      height: '100vh',
      backgroundColor: '#e0f7fa',
      color: '#00796b',
      textAlign: 'center',
      padding: '20px'
    }}>
      <h1>¡Bienvenido a la plataforma de finanzas!</h1>
      <p>Administra tus finanzas en un solo lugar, con facilidad y seguridad.</p>
      <button 
        onClick={() => navigate('/Login')}
        style={{
          padding: '10px 20px',
          fontSize: '16px',
          color: '#ffffff',
          backgroundColor: '#00796b',
          border: 'none',
          borderRadius: '5px',
          cursor: 'pointer',
          marginTop: '20px'
        }}
      >
        Ir al Login
      </button>
    </div>
  );
}

export default Bienvenida;
