import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import './Register.css';
import imagenLogin from '../assets/imagenLogin.png';
import PoliticaTratamiento from './PoliticaTratamiento';

const Register = () => {
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    password: '',
    confirmPassword: '',
  });
  const [politicaAceptada, setPoliticaAceptada] = useState(false);
  const [mostrarTooltip, setMostrarTooltip] = useState(false);
  const [mostrarModal, setMostrarModal] = useState(false);
  const [errorMessage, setErrorMessage] = useState(""); // Nuevo estado para el mensaje de error
  const navigate = useNavigate();

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({ ...prevData, [name]: value }));

    // Limpiar el mensaje de error al cambiar el campo de confirmación de contraseña
    if (name === 'confirmPassword' && formData.password === value) {
      setErrorMessage("");
    }
  };

  const handleCheckboxChange = (e) => {
    setPoliticaAceptada(e.target.checked);
    if (e.target.checked) {
      setMostrarTooltip(false);
    }
  };

  const handlePoliticaClick = (e) => {
    e.preventDefault();
    setMostrarModal(true);
  };

  const handleCloseModal = () => {
    setMostrarModal(false);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const { name, email, password, confirmPassword } = formData;

    // Verificar si hay campos vacíos
    if (!name || !email || !password || !confirmPassword) {
      setErrorMessage("Por favor, completa todos los campos."); // Cambiar alert por mensaje en línea
      return;
    }

    // Verificar si las contraseñas coinciden
    if (password !== confirmPassword) {
      setErrorMessage("Las contraseñas no coinciden."); // Cambiar alert por mensaje en línea
      return;
    }

    // Verificar si la política ha sido aceptada
    if (!politicaAceptada) {
      setMostrarTooltip(true);
      return;
    }

    try {
      // Solicitud POST a la API
      const response = await axios.post('https://awepp.somee.com/api/User', {
        id: null,
        name: name,
        email: email,
        passaword: password, // Asegúrate de que el nombre del campo coincida con el esperado en la API
        phoneNumber: '',
        userName: name, // O utiliza otro campo si tienes un nombre de usuario diferente
        date: new Date().toISOString(),
        modified: new Date().toISOString(),
        modifiedBy: name,
        usertype: {
          id: 1, // Ajusta esto según el tipo de usuario necesario
          name: 'usuario', // Asigna el tipo de usuario
          isDeleted: false
        },
        typeAcces: {
          id: 1, // Ajusta esto según el nivel de acceso necesario
          typeacces: 'general', // Nivel de acceso
          isDeleted: false
        },
        typeAccesUser: {
          id: 1,
          typeAcces: {
            id: 1,
            typeacces: 'general',
            isDeleted: false
          },
          isDeleted: false
        },
        isDeleted: false
      });

      console.log('Respuesta de la API:', response.data);
      alert("Registro exitoso");
      navigate('/registro-exitoso');
    } catch (error) {
      console.error("Error al registrar el usuario:", error);
      alert("Hubo un problema al registrar el usuario. Inténtalo de nuevo.");
    }
  };

  return (
    <div className="register-page-container">
      <div className="register-section">
        <div className="register-container">
          <h2>Registro</h2>
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
              {errorMessage && <p style={{ color: "red" }}>{errorMessage}</p>} {/* Mostrar mensaje de error */}
            </div>
            <div className="form-group-checkbox" style={{ position: 'relative' }}>
              <input
                type="checkbox"
                id="politica"
                checked={politicaAceptada}
                onChange={handleCheckboxChange}
              />
              <label htmlFor="politica">
                Acepto la <a href="#!" onClick={handlePoliticaClick}>política de tratamiento de datos</a>
              </label>
              {mostrarTooltip && (
                <span className="tooltip">
                  Debes aceptar la política de tratamiento de datos
                </span>
              )}
            </div>
            <button type="submit" className="btn-register">
              Registrarse
            </button>
          </form>
        </div>
      </div>
      <div className="background-section">
        <h1>Tus finanzas en un solo lugar</h1>
        <img src={imagenLogin} alt="Imagen de finanzas" />
        <p>Ingresa informes, crea presupuestos, sincroniza con tus bancos...</p>
      </div>

      {mostrarModal && (
        <div className="modal-overlay">
          <div className="modal-content">
            <h2>Política de Tratamiento de Datos</h2>
            <PoliticaTratamiento />
            <button onClick={handleCloseModal} className="btn-close">Aceptar</button>
          </div>
        </div>
      )}
    </div>
  );
};

export default Register;
