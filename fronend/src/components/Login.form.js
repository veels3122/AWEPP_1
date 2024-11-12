import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { InputText } from "primereact/inputtext";
import { Button } from "primereact/button";
import { InputSwitch } from "primereact/inputswitch";
import api from '../api';
import { useForm } from "react-hook-form";
// Importa los estilos de PrimeReact
import 'primereact/resources/themes/lara-light-indigo/theme.css';
import 'primereact/resources/primereact.min.css';
import 'primeicons/primeicons.css';

const LoginForm = () => {
  const navigate = useNavigate();
  const { register, handleSubmit, setValue, reset, formState: { errors, isDirty, isValid } } = useForm({ mode: "onChange" });
  
  // Añadir estado para manejar el valor del InputSwitch y el mensaje de error
  const [rememberMe, setRememberMe] = useState(false);
  const [errorMessage, setErrorMessage] = useState('');

  useEffect(() => {
    // Al cargar el componente, verifica si hay información guardada en localStorage
    const isCheckedStorage = localStorage.getItem("isChecked");
    const emailStorage = localStorage.getItem("email");
    
    if (isCheckedStorage === "true") {
      setRememberMe(true); // Cambiar el estado del toggle
      setValue("email", emailStorage, { shouldDirty: true, shouldValidate: true });
      setValue("isChecked", true);
    }
  }, [setValue]);

  const loginSubmit = async (formData) => {
    const { email, password } = formData;

    // Almacenar email si el usuario ha activado el toggle "Recuérdame"
    if (rememberMe) {
      localStorage.setItem("email", email);
      localStorage.setItem("isChecked", "true");
    } else {
      localStorage.removeItem("email");
      localStorage.removeItem("isChecked");
    }

    // Enviar las credenciales a la API de autenticación
    try {
      const response = await api.post('/User/Login', 
      {
        email, 
        password 
      }
    );
  
      // Verificar respuesta y redirigir en caso de éxito
      if (response.status === 200) {
        const data = response.data;;
        
        // Opcional: guarda el token en localStorage si es necesario
        localStorage.setItem('token', data.token);

        // Redirige a la página principal
        navigate("/principal");
        reset();
      } else {
        // Maneja el error si el inicio de sesión falla
        const errorData = await response.json();
        setErrorMessage(errorData.message || 'Error de inicio de sesión. Verifica tus credenciales.');
      }
    } catch (error) {
      console.error('Error en la solicitud:', error);
      setErrorMessage('Error de inicio de sesión. Verifica tus credenciales.');
    }
  };

  const handleRememberMeChange = (e) => {
    setRememberMe(e.value);
    setValue("isChecked", e.value);
  };

  return (
    <div className="register-container"> 
      <h2>Iniciar Sesión</h2>
      <form autoComplete="off" onSubmit={handleSubmit(loginSubmit)}>
        <div className="form-group">
          <label htmlFor="email">Email:</label>
          <InputText
            id="new-email"
            type="text"
            placeholder="introduzca su Email"
            autoComplete="new-email"
            className={errors?.email ? "p-invalid" : ""}
            {...register("email", {
              required: "El campo email es obligatorio",
              pattern: {
                value: /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i,
                message: "El formato del email es incorrecto"
              }
            })}
          />
          {errors?.email && <small className="p-error">{errors.email.message}</small>}
        </div>
        <div className="form-group">
          <label htmlFor="password">Contraseña:</label>
          <InputText
            type="password"
            placeholder="introduzca su contraseña"
            autoComplete="new-password"
            className={errors?.password ? "p-invalid" : ""}
            {...register("password", {
              required: "El campo contraseña es obligatorio",
              minLength: { value: 6, message: "La contraseña debe tener al menos 6 caracteres" }
            })}
          />
          {errors?.password && <small className="p-error">{errors.password.message}</small>}
        </div>
        <div className="form-group remember-me">
          <label htmlFor="rememberMe" style={{ marginRight: "10px" }}>Recuérdame</label>
          <InputSwitch
            id="rememberMe"
            checked={rememberMe}
            onChange={handleRememberMeChange}
          />
        </div>
        <div className="buttons">
          <Button
            type="submit"
            label="Ingresar"
            className="btn-register"
            disabled={!isValid || !isDirty}
          />
          <Button
            type="button"
            label="Registrarse"
            className="btn-register"
            onClick={() => navigate("/register")}
          />
        </div>
        {errorMessage && <p style={{ color: 'red' }}>{errorMessage}</p>}
      </form>
    </div>
  );
};

export default LoginForm;
