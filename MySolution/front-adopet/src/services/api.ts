import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:5286/adopet',
});

export default api;
