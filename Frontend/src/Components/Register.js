import React, { useState } from 'react';
import axios from 'axios';

const Register = () => {
  const [form, setForm] = useState({ fullName: '', email: '', password: '', role: 'Employee' });

  const handleChange = e => setForm({ ...form, [e.target.name]: e.target.value });

  const handleSubmit = async e => {
    e.preventDefault();
    try {
      await axios.post('/api/auth/register', form);
      alert('Registered successfully');
    } catch {
      alert('Error during registration');
    }
  };

  return (
    <form onSubmit={handleSubmit} className="form">
      <h2>Register</h2>
      <input name="fullName" placeholder="Full Name" onChange={handleChange} required />
      <input name="email" placeholder="Email" onChange={handleChange} required />
      <input name="password" type="password" placeholder="Password" onChange={handleChange} required />
      <select name="role" onChange={handleChange}>
        <option value="Employee">Employee</option>
        <option value="Manager">Manager</option>
      </select>
      <button type="submit">Register</button>
    </form>
  );
};

export default Register;
