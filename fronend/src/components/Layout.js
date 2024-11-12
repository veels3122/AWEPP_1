import React, { useRef, useEffect, useState } from 'react';
import Navbar from './Navbar';
import { Avatar } from 'primereact/avatar';
import { Menu } from 'primereact/menu';
import { useNavigate } from 'react-router-dom';
import './Layout.css';

const Layout = ({ children }) => {
  const navigate = useNavigate();
  const menu = useRef(null);

  // Estado para almacenar el nombre del usuario
  const [userName, setUserName] = useState('New User');

  useEffect(() => {
    // Recuperar los datos del usuario desde localStorage
    const storedUser = localStorage.getItem('user');
    if (storedUser) {
      const user = JSON.parse(storedUser);
      setUserName(user.name); // Actualiza el nombre del usuario
    }
  }, []);

  const menuItems = [
    {
      label: 'Cerrar Sesión',
      icon: 'pi pi-sign-out',
      command: () => {
        // Limpiar el localStorage al cerrar sesión
        localStorage.removeItem('user');
        localStorage.removeItem('token');
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
              image="data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIzNCIgaGVpZ2h0PSIzNCIgdmlld0JveD0iMCAwIDM0IDM0Ij4KICAgIDxnIGZpbGw9Im5vbmUiIGZpbGwtcnVsZT0iZXZlbm9kZCI+CiAgICAgICAgPGNpcmNsZSBjeD0iMTciIGN5PSIxNyIgcj0iMTciIGZpbGw9IiNCMkIyQjciLz4KICAgICAgICA8cGF0aCBmaWxsPSIjRkZGIiBmaWxsLXJ1bGU9Im5vbnplcm8iIGQ9Ik0xNy4wNTYgOC41Yy0yLjQ5IDAtNC41MSAxLjk4NS00LjUxIDQuNDM1di43MzljMCAyLjQ1IDIuMDIgNC40MzUgNC41MSA0LjQzNSAyLjQ5MSAwIDQuNTEtMS45ODYgNC41MS00LjQzNXYtLjc0YzAtMi40NDktMi4wMTktNC40MzQtNC41MS00LjQzNHptLS4wMDEgMTEuODI2Yy0zLjAxMSAwLTYuODc1IDEuNjAyLTcuOTg2IDMuMDIzLS42ODcuODc5LS4wMzMgMi4xNTEgMS4wOTMgMi4xNTFIMjMuOTVjMS4xMjcgMCAxLjc4LTEuMjcyIDEuMDk0LTIuMTUxLTEuMTEyLTEuNDItNC45NzctMy4wMjMtNy45ODgtMy4wMjN6Ii8+CiAgICA8L2c+Cjwvc3ZnPgo="
              shape="circle"
              onClick={(e) => menu.current.toggle(e)}
              style={{ cursor: 'pointer' }}
            />
            <span 
              className="user-name" 
              onClick={toggleMenu} 
              style={{ cursor: 'pointer' }}
            >
              {userName} 
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
