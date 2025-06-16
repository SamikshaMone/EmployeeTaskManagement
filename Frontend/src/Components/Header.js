import React from 'react';

const Header = ({ onLogout }) => (
  <header className="app-header">
    <h1>Employee Task Management System</h1>
    <button onClick={onLogout}>Logout</button>
  </header>
);

export default Header;
