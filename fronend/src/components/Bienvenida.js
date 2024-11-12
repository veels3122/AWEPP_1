import React from 'react';
import { useNavigate } from 'react-router-dom';
import logo from '../assets/billetera.png';
import './Bienvenida.css';

function Bienvenida() {
  const navigate = useNavigate();

  return (
    <div style={{
      display: 'flex',
      flexDirection: 'column',
      alignItems: 'center',
      justifyContent: 'space-between',
      height: '100vh',
      backgroundColor: '#e0f7fa',
      color: '#00796b',
      textAlign: 'center',
      padding: '20px',
      overflow: 'hidden',
    }}>
      <button
        onClick={() => navigate('/Login')}
        style={{
          position: 'absolute',
          top: '20px',
          right: '20px',
          padding: '10px 20px',
          fontSize: '14px',
          color: '#ffffff',
          backgroundColor: '#00796b',
          border: 'none',
          borderRadius: '5px',
          cursor: 'pointer',
          boxShadow: '0 4px 6px rgba(0, 0, 0, 0.1)',
          transition: 'background-color 0.3s',
        }}
        onMouseOver={(e) => e.target.style.backgroundColor = '#004d40'}
        onMouseOut={(e) => e.target.style.backgroundColor = '#00796b'}
      >
        Inicia sesión
      </button>

      <div style={{ textAlign: 'center' }}>
        <img
          src={logo}
          alt="Logo de la plataforma"
          style={{
            width: '150px',
            marginBottom: '20px',
            animation: 'bounce 2s infinite',
          }}
        />
        <h1 style={{ fontSize: '2.5rem', fontWeight: 'bold', margin: '0' }}>
          ¡Bienvenido a la plataforma de finanzas!
        </h1>
        <p style={{ fontSize: '1.2rem', marginTop: '10px', color: '#004d40' }}>
          Administra tus finanzas de manera eficiente, segura y moderna.
        </p>
      </div>

      <div style={{
        display: 'grid',
        gridTemplateColumns: '1fr 1fr 1fr',
        gap: '20px',
        marginTop: '30px',
        width: '80%',
      }}>
        <div style={featureCardStyle}>
          <h3>Seguridad</h3>
          <p>Protege tu información con la mejor tecnología en seguridad.</p>
        </div>
        <div style={featureCardStyle}>
          <h3>Facilidad</h3>
          <p>Una interfaz diseñada para que cualquier persona pueda usarla.</p>
        </div>
        <div style={featureCardStyle}>
          <h3>Control Total</h3>
          <p>Organiza tus finanzas con herramientas avanzadas y personalizables.</p>
        </div>
      </div>

      <div style={{
        backgroundColor: '#004d40',
        color: '#ffffff',
        padding: '15px 20px',
        borderRadius: '10px',
        marginTop: '40px',
        cursor: 'pointer',
        fontWeight: 'bold',
        fontSize: '1.2rem',
        boxShadow: '0 4px 6px rgba(0, 0, 0, 0.2)',
        transition: 'transform 0.3s',
      }}
        onClick={() => navigate('/Register')}
        onMouseOver={(e) => e.target.style.transform = 'scale(1.05)'}
        onMouseOut={(e) => e.target.style.transform = 'scale(1)'}
      >
        ¡Regístrate ahora y empieza a controlar tu futuro financiero!
      </div>
    </div>
  );
}

const featureCardStyle = {
  backgroundColor: '#ffffff',
  padding: '15px',
  borderRadius: '10px',
  boxShadow: '0 4px 6px rgba(0, 0, 0, 0.1)',
  textAlign: 'center',
  color: '#00796b',
  fontSize: '1rem',
};

export default Bienvenida;
