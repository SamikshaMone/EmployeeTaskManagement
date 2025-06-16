import React, { useState } from 'react';
import axios from 'axios';

const TaskForm = ({ user }) => {
  const [task, setTask] = useState({ title: '', description: '', assignedTo: '' });

  const handleChange = e => setTask({ ...task, [e.target.name]: e.target.value });

  const handleSubmit = async e => {
    e.preventDefault();
    try {
      await axios.post('/api/tasks', task);
      alert('Task created');
    } catch {
      alert('Error creating task');
    }
  };

  if (user.role !== 'Manager') return null;

  return (
    <form onSubmit={handleSubmit} className="form">
      <h3>Create Task</h3>
      <input name="title" placeholder="Title" onChange={handleChange} required />
      <input name="description" placeholder="Description" onChange={handleChange} required />
      <input name="assignedTo" placeholder="Assign To (email)" onChange={handleChange} required />
      <button type="submit">Create</button>
    </form>
  );
};

export default TaskForm;
