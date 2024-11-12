import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { InputText } from "primereact/inputtext";
import { Button } from "primereact/button";
import { InputSwitch } from "primereact/inputswitch";
import api from '../api';
import { useForm } from "react-hook-form";
import 'primereact/resources/themes/lara-light-indigo/theme.css';
import 'primereact/resources/primereact.min.css';
import 'primeicons/primeicons.css';

const LoginForm = () => {
  const navigate = useNavigate();
  const { register, handleSubmit, setValue, reset, formState: { errors, isDirty, isValid } } = useForm({ mode: "onChange" });
  
  const [rememberMe, setRememberMe] = useState(false);
  const [errorMessage, setErrorMessage] = useState('');

  useEffect(() => {
    const isCheckedStorage = localStorage.getItem("isChecked");
    const emailStorage = localStorage.getItem("email");
    
    if (isCheckedStorage === "true") {
      setRememberMe(true);
      setValue("email", emailStorage, { shouldDirty: true, shouldValidate: true });
      setValue("isChecked", true);
    }
  }, [setValue]);

  const loginSubmit = async (formData) => {
    const { email, password } = formData;

    if (rememberMe) {
      localStorage.setItem("email", email);
      localStorage.setItem("isChecked", "true");
    } else {
      localStorage.removeItem("email");
      localStorage.removeItem("isChecked");
    }

    try {
      // Enviar las credenciales a la API de autenticación
      const response = await api.post('/User/Login', { email, password });

      if (response.status === 200) {
        const loginData = response.data;

        // Realizar una solicitud adicional para obtener los detalles del usuario
        const userResponse = await api.get(`/User/${loginData.userId}`);
        if (userResponse.status === 200) {
          const userData = userResponse.data;

          // Guardar los detalles completos del usuario en localStorage
          localStorage.setItem('user', JSON.stringify(userData));
          console.log('Detalles del usuario guardados:', userData);

          navigate("/principal");
          reset();
        } else {
          setErrorMessage('No se pudieron obtener los detalles del usuario.');
        }
      } else {
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
