import React from 'react';
import Navbar from './Navbar';

const Layout = ({ children }) => {
  return (
    <div>
      <Navbar /> {/* Navbar siempre visible */}
      <div className="content">{children}</div> {/* Contenido de la página */}
    </div>
  );
};

export default Layout;
