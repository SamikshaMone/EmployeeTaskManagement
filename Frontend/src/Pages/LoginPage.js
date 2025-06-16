import React from 'react';
import Login from '../Components/Login';

const LoginPage = ({ onLogin }) => {
  return (
    <div className="container">
      <Login onLogin={onLogin} />
    </div>
  );
};

export default LoginPage;
