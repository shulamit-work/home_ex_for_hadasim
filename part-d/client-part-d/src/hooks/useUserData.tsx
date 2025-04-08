import { useEffect, useState } from 'react';
import { fetchUserData } from '../apis/userApi'; 

const useUserData = () => {
    const [user, setUser] = useState<any>(null);
    const [errorMessage, setErrorMessage] = useState<string | null>(null);
  
    const fetchUser = async () => {
      try {
        const data = await fetchUserData();
        // console.log('User data from API:', data); 
        if (JSON.stringify(data) !== JSON.stringify(user)) {  
          setUser(data); 
        }
        setErrorMessage(null); 
      } catch (error) {
        console.error('Error fetching user data:', error);
        setErrorMessage('Error fetching user data');
      }
    };
}
export default useUserData;
