import axios from 'axios';
const API_BASE_URL = process.env.REACT_APP_API_BASE_URL;


export const fetchUserData = async () => {
    const token = localStorage.getItem('authToken');
  
    if (!token) {
      throw new Error('No token found');
    }
  
    try {
      const response = await axios.get(`${API_BASE_URL}/User/profile`, {
        headers: { Authorization: `Bearer ${token}`, },
      });
  
      const userData = response.data;
  
      // console.log('User data from API:', userData); // הדפסת הנתונים שהתקבלו
      return userData;
    } catch (error: any) {
      throw error.response ? error.response.data : error.message;
    }
};