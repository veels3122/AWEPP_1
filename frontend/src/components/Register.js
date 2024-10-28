import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './Register.css';
import imagenLogin from '../assets/imagenLogin.png';

const Register = () => {
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    password: '',
    confirmPassword: '',
  });

  const [errorMessage, setErrorMessage] = useState('');
  const navigate = useNavigate(); // Hook para navegar entre rutas

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({ ...prevData, [name]: value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const { name, email, password, confirmPassword } = formData;

    if (!name || !email || !password || !confirmPassword) {
      setErrorMessage('Por favor, completa todos los campos.');
      return;
    }

    if (password !== confirmPassword) {
      setErrorMessage('Las contraseñas no coinciden.');
      return;
    }

    console.log('Formulario enviado:', formData);
    setErrorMessage('');
    navigate('/registro-exitoso');
  };

  return (
    <div className="register-page-container">
      <div className="register-section">
        <div className="register-container">
          <h2>Registro</h2>
          {errorMessage && <p className="error-message">{errorMessage}</p>}
          <form onSubmit={handleSubmit}>
            <div className="form-group">
              <label htmlFor="name">Nombre:</label>
              <input
                type="text"
                name="name"
                value={formData.name}
                onChange={handleChange}
                required
              />
            </div>
            <div className="form-group">
              <label htmlFor="email">Correo Electrónico:</label>
              <input
                type="email"
                name="email"
                value={formData.email}
                onChange={handleChange}
                required
              />
            </div>
            <div className="form-group">
              <label htmlFor="password">Contraseña:</label>
              <input
                type="password"
                name="password"
                value={formData.password}
                onChange={handleChange}
                required
              />
            </div>
            <div className="form-group">
              <label htmlFor="confirmPassword">Confirmar Contraseña:</label>
              <input
                type="password"
                name="confirmPassword"
                value={formData.confirmPassword}
                onChange={handleChange}
                required
              />
            </div>
            <button type="submit" className="btn-register">Registrarse</button>
          </form>
        </div>
      </div>
      <div className="background-section">
        <h1>Tus finanzas en un solo lugar</h1>
        <img src={imagenLogin} alt="Imagen de finanzas" />
        <p>Ingresa informes, crea presupuestos, sincroniza con tus bancos...</p>
      </div>
    </div>
  );
};

export default Register;
