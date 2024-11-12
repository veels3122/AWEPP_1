import React, { useState, useRef } from 'react';
import { useNavigate } from 'react-router-dom';
import api from '../api';
import imagenLogin from '../assets/imagenLogin.png';
import PoliticaTratamiento from './PoliticaTratamiento';
import { Toast } from "primereact/toast";
import './Register.css';

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
  const [passwordError, setPasswordError] = useState('');
  const navigate = useNavigate();
  
  const toast = useRef(null);

    // Función para validar la contraseña
    const validatePassword = (password) => {
      const minLength = 8;
      const hasUpperCase = /[A-Z]/.test(password);
      const hasLowerCase = /[a-z]/.test(password);
      const hasNumber = /[0-9]/.test(password);
      const hasSpecialChar = /[!@#$%^&*(),.?":{}|<>]/.test(password);
  
      if (
        password.length >= minLength &&
        hasUpperCase &&
        hasLowerCase &&
        hasNumber &&
        hasSpecialChar
      ) {
        return true;
      } else {
        setPasswordError(
          'La contraseña debe tener al menos ocho caracteres, una mayúscula, una minúscula, un número y un carácter especial.'
        );
        return false;
      }
    };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({ ...prevData, [name]: value }));

    if (name === "confirmPassword") {
      setPasswordError('');
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

    if (!name || !email || !password || !confirmPassword) {
      toast.current.show({
        severity: 'warn',
        summary: 'Campos incompletos',
        detail: 'Por favor, completa todos los campos.',
        life: 3000
      });
      return;
    }

    if (password !== confirmPassword) {
      setPasswordError('Las contraseñas no coinciden.');
      return;
    }

    if (!validatePassword(password)) {
      return;
    }

    if (!politicaAceptada) {
      setMostrarTooltip(true);
      return;
    }

    try {
      const response = await api.post('/User', {
        "id": 0,
        "name": name,
        "email": email,
        "password": password,
        "phoneNumber": '',
        "userName": name,
        "date": new Date().toISOString(),
        "modified": new Date().toISOString(),
        "modifiedBy": name,
        "usertype": {
          "id": 0,
          "name": "Cliente",
          "isDeleted": false
        },
        "typeAcces": {
          "id": 0,
          "typeacces": "Cliente",
          "isDeleted": false
        },
        "typeAccesUser": {
          "id": 0,
          "typeAccesUserss": 'Acceso estándar',
          "isDeleted": false
        },
        "isDeleted": false
      });

      console.log('Respuesta de la API:', response.data);
      navigate('/registro-exitoso');
    } catch (error) {
      console.error("Error al registrar el usuario:", error);
      toast.current.show({
        severity: 'error',
        summary: 'Error en el registro',
        detail: 'Hubo un problema al registrar el usuario. Inténtalo de nuevo.',
        life: 3000
      });
    }
  };

  return (
    <div className="register-page-container">
      <Toast ref={toast} /> 
      <div className="register-section">
        <div className="register-container">
          <h2>Registro</h2>
          <form onSubmit={handleSubmit}>
            <div className="form-group">
              <label htmlFor="name">Nombre y Apellido:</label>
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
              <label htmlFor="confirmPassword">Vuelve a escribir la contraseña:</label>
              <input
                type="password"
                name="confirmPassword"
                value={formData.confirmPassword}
                onChange={handleChange}
                required
              />
              {passwordError && <small className="password-error">{passwordError}</small>}
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
