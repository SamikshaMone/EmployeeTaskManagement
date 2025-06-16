import axios from 'axios';

const API_URL = '/api/users';

const getAllUsers = async () => {
  const response = await axios.get(API_URL);
  return response.data;
};

const getUserById = async (id) => {
  const response = await axios.get(`${API_URL}/${id}`);
  return response.data;
};

export default {
  getAllUsers,
  getUserById,
};
