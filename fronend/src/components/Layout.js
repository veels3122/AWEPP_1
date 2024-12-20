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
        navigate('/Login'); 
      },
    },
  ];

  const toggleMenu = (e) => {
    menu.current.toggle(e); 
  };

  return (
    <div>
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
              onClick={toggleMenu} 
              style={{ cursor: 'pointer' }}
            >
              New User
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