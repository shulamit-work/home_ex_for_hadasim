import axios from 'axios';
const API_BASE_URL = process.env.REACT_APP_API_BASE_URL;

export const registerProvider = async (providerData : FormData) => {
    console.log('arrived at producerApi. ');
    console.log('providerData', providerData)
    
    try {
        const response = await axios.post(`${API_BASE_URL}/User`, providerData, {
            headers: {
              'Content-Type': 'multipart/form-data'
            }
          });
        console.log('response from server', response.data);
        return response.data;
    } catch( error){
        console.error('Error registering producer:', error);
        if (axios.isAxiosError(error)){
            throw error.response?.data || error.message;
        }
        else{
            throw 'Error registering producer';
        }

        
    }
    
    

    
}