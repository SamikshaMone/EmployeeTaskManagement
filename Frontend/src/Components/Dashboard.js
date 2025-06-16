import React from 'react';
import TaskList from './TaskList';
import TaskForm from './TaskForm';
import UserList from './UserList';

const Dashboard = ({ user }) => {
  return (
    <div className="dashboard">
      <h2>Welcome, {user.fullName}</h2>
      {user.role === 'Manager' && <UserList />}
      <TaskForm user={user} />
      <TaskList user={user} />
    </div>
  );
};

export default Dashboard;
