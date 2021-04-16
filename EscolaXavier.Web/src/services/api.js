import axios from 'axios';

import { API_URL } from "../environment/env.json";

const api = axios.create({
  baseURL: API_URL,
  headers: {
    'Access-Control-Allow-Origin': '*',
  },
});

export default api;
