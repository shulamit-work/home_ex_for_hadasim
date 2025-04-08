import axios from 'axios';
const API_BASE_URL = process.env.REACT_APP_API_BASE_URL;


export const login = async (name: string, pwd: string) => {
  try {
      console.log('Logging in with:', { name, pwd }); 
      console.log('address:', `${API_BASE_URL}/Login`);
      
      const response = await axios.post(`${API_BASE_URL}/Login`, null, {
        params: { name, pwd }
      });
  
      console.log('Server response:', response.data);
  
      if (response.data) {
        localStorage.setItem('authToken', response.data); 
      } else {
        throw new Error('No token received from server'); 
      }
  
      return response.data;
    } catch (error: unknown) {
      if (axios.isAxiosError(error)) {
        throw error.response ? error.response.data : error.message;
      } else {
        throw 'An unexpected error occurred';
      }
    }
};


export const getRole = async()=>{
    try{
      const token = localStorage.getItem("authToken");
      const response = await axios.get('https://localhost:7160/getRole', {
          headers: {
              Authorization: `Bearer ${token}`
              // "Access-Control-Allow-Origin": "*",

          }
      })
      return response.data
    } catch (error: unknown) {
      if (axios.isAxiosError(error)) {
        throw error.response ? error.response.data : error.message;
      } else {
        throw 'An unexpected error occurred';
      }
    }
}