import React, { useEffect, useState } from 'react';
import axios from 'axios';

const UserList = () => {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    axios.get('/api/users').then(res => setUsers(res.data));
  }, []);

  return (
    <div className="user-list">
      <h3>Users</h3>
      <ul>
        {users.map(u => (
          <li key={u.id}>{u.fullName} ({u.role})</li>
        ))}
      </ul>
    </div>
  );
};

export default UserList;
