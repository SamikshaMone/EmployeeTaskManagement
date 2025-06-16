import React, { useState, useEffect } from 'react';
import { Routes, Route, Navigate } from 'react-router-dom';

import HomePage from './pages/HomePage';
import LoginPage from './pages/LoginPage';
import RegisterPage from './pages/RegisterPage';
import DashboardPage from './pages/DashboardPage';
import NotFoundPage from './pages/NotFoundPage';

import AuthService from './Services/AuthService';

const App = () => {
  const [user, setUser] = useState(AuthService.getCurrentUser());

  const handleLogin = (userData) => {
    setUser(userData);
  };

  const handleLogout = () => {
    AuthService.logout();
    setUser(null);
  };

  return (
    <Routes>
      <Route path="/" element={<HomePage />} />
      <Route
        path="/login"
        element={user ? <Navigate to="/dashboard" /> : <LoginPage onLogin={handleLogin} />}
      />
      <Route
        path="/register"
        element={user ? <Navigate to="/dashboard" /> : <RegisterPage />}
      />
      <Route
        path="/dashboard"
        element={user ? <DashboardPage user={user} onLogout={handleLogout} /> : <Navigate to="/login" />}
      />
      <Route path="*" element={<NotFoundPage />} />
    </Routes>
  );
};

export default App;
