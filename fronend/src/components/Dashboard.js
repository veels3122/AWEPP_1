import React, { useEffect, useState } from "react";
import api from '../api'; // Usamos la instancia de Axios que ya configuraste en `api.js`

const Dashboard = () => {
  // Estado para almacenar los datos del usuario
  const [userData, setUserData] = useState(null);

  // Función para obtener los datos del usuario cuando carga el dashboard
  useEffect(() => {
    const fetchUserData = async () => {
      const userId = localStorage.getItem('userId'); // Obtenemos el ID del usuario
      const token = localStorage.getItem('token');   // Obtenemos el token de autenticación

      try {
        // Hacemos una solicitud a la API para obtener los datos del usuario
        const response = await api.get(`/User/${userId}`, {
          headers: { 
            Authorization: `Bearer ${token}` // Enviamos el token en los headers para autenticación
          }
        });
        // Guardamos los datos del usuario en el estado
        setUserData(response.data); 
      } catch (error) {
        console.error("Error al cargar los datos del usuario:", error);
      }
    };

    fetchUserData(); // Ejecuta la función para obtener los datos del usuario
  }, []);

  // Mostramos un mensaje de carga mientras esperamos los datos
  if (!userData) return <p>Cargando...</p>;

  // Renderizamos el contenido personalizado del dashboard con los datos del usuario
  return (
    <div>
      <h1>Bienvenido, {userData.name}</h1>
      <p>Email: {userData.email}</p>
      <p>Rol: {userData.role}</p>
      {/* Puedes añadir más datos o secciones personalizadas aquí */}
    </div>
  );
};

export default Dashboard;
