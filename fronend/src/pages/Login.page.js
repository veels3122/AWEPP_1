import React from "react";
import LoginForm from "../components/Login.form";
import "../components/LoginForm.css";
import imagenLogin from "../assets/imagenLogin.png";

const LoginPage = () => {
  return (    
  <div className="login-page-container">
    <div className="promo-section">
      <h1>Tus finanzas en un solo lugar</h1>
      <img src={imagenLogin} alt="Imagen de finanzas" />
      <p>Ingresa informes, crea presupuestos, sincroniza con tus bancos...</p>
    </div>
    <div className="login-section">
      <LoginForm />
    </div>
  </div>
  );
};

export default LoginPage;
