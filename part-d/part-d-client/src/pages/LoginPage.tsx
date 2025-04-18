import React, { useState } from 'react';
import { useNavigate, Link, Form } from 'react-router-dom';
import { login } from '../apis/loginApi';


const loginPage = () => {
    const [formData, setFormData] = useState({
        name: '',
        password: ''
    });
    const [error, setError] = useState<string | null>(null);
    const [fieldErrors, setFieldErrors] = useState({
        name: false,
        password: false
    });
    const navigate = useNavigate();

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value,
        })
        setFieldErrors({
            ...fieldErrors,
            [name]: false,
        })
    };
    
    const handleSubmit = async (e :React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        setError(null);
        try{
            const response = await login(formData.name, formData.password);
            console.log('Response form server:', response); 
            if (response) {
                console.log('saving token', response);
                localStorage.setItem('authToken', response); 
                if (response.role === "owner"){
                    navigate('/owner'); 
                }
                else {
                    navigate('/provider'); 
                }
            } else {
                console.error('No token received from server');
                setError('No token received from server');
            }
        } catch (error: any){
            console.error('Error during login:', error);
            setError(error.message || 'login failed')
        }      
    }

    return 
    <Form onSubmit={handleSubmit} className="login-form">
        <h2>Login</h2>
        {error && <p className="error">{error}</p>}
        <div className="form-group">
            <label htmlFor="name">Name</label>
            <input type="text" id="name" name="name" value={formData.name} onChange={handleChange} required />
            {fieldErrors.name && <p className="error">Please enter a valid name</p>}
        </div>
        <div className="form-group">
            <label htmlFor="password">Password</label>
            <input type="password" id="password" name="password" value={formData.password} onChange={handleChange} required />
            {fieldErrors.password && <p className="error">Please enter a valid password</p>}
        </div>
        <button type="submit">Login</button>
        <p>Don't have an account? <Link to="/register">Register</Link></p>
    </Form>
}