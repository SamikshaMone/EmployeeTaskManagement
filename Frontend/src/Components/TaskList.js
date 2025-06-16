import React, { useEffect, useState } from 'react';
import axios from 'axios';
import * as signalR from '@microsoft/signalr';

const TaskList = ({ user }) => {
  const [tasks, setTasks] = useState([]);

  const loadTasks = async () => {
    const res = await axios.get(`/api/tasks/${user.email}`);
    setTasks(res.data);
  };

  useEffect(() => {
    loadTasks();

    const connection = new signalR.HubConnectionBuilder()
      .withUrl('/notificationHub')
      .withAutomaticReconnect()
      .build();

    connection.on('TaskUpdated', () => loadTasks());

    connection.start();

    return () => connection.stop();
  }, []);

  return (
    <div className="task-list">
      <h3>My Tasks</h3>
      <ul>
        {tasks.map(t => (
          <li key={t.id}>
            <strong>{t.title}</strong>: {t.description} - <em>{t.status}</em>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default TaskList;
