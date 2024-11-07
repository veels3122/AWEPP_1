// src/api.js
import axios from 'axios';

const api = axios.create({
  baseURL: 'https://awepp.somee.com/api'
});

export default api;
