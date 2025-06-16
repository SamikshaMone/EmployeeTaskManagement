import React from 'react';
import Dashboard from '../Components/Dashboard';
import Header from '../Components/Header';

const DashboardPage = ({ user, onLogout }) => {
  if (!user) {
    return <p>You must be logged in to view this page.</p>;
  }

  return (
    <div>
      <Header onLogout={onLogout} />
      <Dashboard user={user} />
    </div>
  );
};

export default DashboardPage;
