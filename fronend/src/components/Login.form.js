import React, { useEffect, useCallback } from "react";
import { useNavigate } from "react-router-dom";
import { InputText } from "primereact/inputtext";
import { Button } from "primereact/button";
import { InputSwitch } from "primereact/inputswitch";
import { useForm } from "react-hook-form";


const LoginForm = () => {
  const navigate = useNavigate();
  const { register, handleSubmit, setValue, reset, formState: { errors, isDirty, isValid } } = useForm({ mode: "onChange" });

  const loginSubmit = (formData) => {
    const { email, isChecked } = formData;  // Eliminé `password` porque no se usa

    // Aquí puedes añadir lógica de autenticación con una API

    if (!!isChecked) {
      localStorage.setItem("email", email);
      localStorage.setItem("isChecked", isChecked);
    } else {
      localStorage.clear();
    }
    navigate("/principal");
    reset();
  };

  const checkRememberMe = useCallback(() => {
    const isCheckedStorage = localStorage.getItem("isChecked");
    const emailStorage = localStorage.getItem("email");
    if (!!isCheckedStorage) {
      setValue("email", emailStorage, { shouldDirty: true, shouldValidate: true });
      setValue("isChecked", isCheckedStorage === "true", { shouldDirty: true });
    }
  }, [setValue]);

  useEffect(() => {
    if (localStorage.getItem("isChecked")) checkRememberMe();
  }, [checkRememberMe]);

  return (
    <div className="register-container"> {/* Usar el mismo estilo del registro */}
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
            {...register("isChecked")}
            onChange={(e) => setValue("isChecked", e.value)}
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
      </form>
    </div>
  );
};

export default LoginForm;
