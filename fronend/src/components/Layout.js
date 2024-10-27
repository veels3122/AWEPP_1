import React, { useRef } from 'react';
import Navbar from './Navbar';
import { Avatar } from 'primereact/avatar';
import { Menu } from 'primereact/menu';
import { useNavigate } from 'react-router-dom';
import './Layout.css';

const Layout = ({ children }) => {
  const navigate = useNavigate();
  const menu = useRef(null);

  const menuItems = [
    {
      label: 'Cerrar Sesión',
      icon: 'pi pi-sign-out',
      command: () => {
        navigate('/'); 
      },
    },
  ];

  const toggleMenu = (e) => {
    menu.current.toggle(e); // Mostrar el menú al hacer clic en el avatar o el nombre del usuario
  };

  return (
    <div>
      {/* Header principal que contiene al nombre de la página y al usuario */}
      <header className="layout-header">
        <div className="header-left">
          <h1 className="page-title">Manager By Awepp</h1>
        </div>
        <div className="header-right">
          <div className="user-menu">
            <Avatar
              image="https://lh3.googleusercontent.com/a/ACg8ocLu2ugpsX6qStVIF0kUbm9fO9oUeS17xJVLuMABNxWh_vehElio=s100"
              shape="circle"
              onClick={(e) => menu.current.toggle(e)}
              style={{ cursor: 'pointer' }}
            />
            <span 
              className="user-name" 
              onClick={toggleMenu} // Mostrar el menú al hacer clic en el nombre del usuario
              style={{ cursor: 'pointer' }}
            >
              Andres Rodriguez
            </span>
          </div>
        </div>
      </header>

      <Navbar />

      <div className="content">{children}</div>

      <Menu model={menuItems} popup ref={menu} />
    </div>
  );
};

export default Layout;