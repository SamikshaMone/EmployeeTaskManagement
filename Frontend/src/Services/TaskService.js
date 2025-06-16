import axios from 'axios';

const API_URL = '/api/tasks';

const getTasksForUser = async (email) => {
  const response = await axios.get(`${API_URL}/${email}`);
  return response.data;
};

const createTask = async (taskData) => {
  const response = await axios.post(API_URL, taskData);
  return response.data;
};

const updateTask = async (taskId, taskData) => {
  const response = await axios.put(`${API_URL}/${taskId}`, taskData);
  return response.data;
};

const deleteTask = async (taskId) => {
  const response = await axios.delete(`${API_URL}/${taskId}`);
  return response.data;
};

export default {
  getTasksForUser,
  createTask,
  updateTask,
  deleteTask,
};
