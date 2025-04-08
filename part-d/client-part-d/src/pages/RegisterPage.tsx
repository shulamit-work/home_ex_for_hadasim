import React, { useState , ReactElement} from 'react';
import { useNavigate, Link, Form, useActionData } from 'react-router-dom';
import { AddProd } from '../components/AddProd';
import axios from 'axios';
import { registerProvider } from '../apis/providerApi';


export const RegisterPage = () => {
    const [formData, setFormData] = useState({
        name: '',
        password: '',
        companyName: '',
        phone: '',
        prods : [{}]
    });
    const [error, setError] = useState<string | null>(null);
    const [fieldErrors, setFieldErrors] = useState({
        name: false,
        password: false,
        companyName: false,
        phone: false,
        prods: false
    });


    const navigate = useNavigate();

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value
        });
        setFieldErrors({
            ...fieldErrors,
            [name]: false
        });
    }

    
    const [prodNum, setProdNum] = useState(0);
    const addProdFunc = (e: React.FormEvent<HTMLFormElement>)=> {
        e.preventDefault();
        
        try{
            const newProdItem = {
                name: e.currentTarget.nameInput.value,
                pricePerOne: e.currentTarget.pricePerOneInput.value,
                minCount: e.currentTarget.minCountInput.value
            }
            console.log('new product item', newProdItem);
            if (newProdItem.name === '' || newProdItem.pricePerOne === '' || newProdItem.minCount === '') {
                setFieldErrors({
                    ...fieldErrors,
                    prods: true
                });
                setError('Please fill in all fields.');
                return;
            }
            if (prodNum === 0){
                setFormData({
                    ...formData,
                    prods:[newProdItem]
                })
            }
            else{
                setFormData({
                    ...formData,
                    prods: [...formData.prods, newProdItem]
                })
            }                
            setProdNum(prodNum + 1);
            setFieldErrors({
                ...fieldErrors,
                prods: false
            });
            setProdComponents([
                ...prodComponents,
                <AddProd key={prodNum} action={addProdFunc} num={prodNum} />
            ]);
        } catch (error) {
            console.error('Error adding product:', error);
            setError('Error adding product. Please try again.');
        }

    }
    const [prodComponents, setProdComponents] = useState<ReactElement<any, any>[]>([<AddProd action={addProdFunc} num={0} />]);

    
    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        const newFieldErrors = {
            name : !formData.name,
            password: !formData.password,
            companyName: !formData.companyName,
            phone: !formData.phone,
            prods: formData.prods.length === 0
        };

        if (Object.values(newFieldErrors).some((error) => error)) {
            setFieldErrors(newFieldErrors);
            setError('Please fill in all fields.');
            return;
        }
        
        setError(null);
        try {
            
            const formDataToSend = new FormData();
            Object.keys(formData).forEach(key =>{
                const value = formData[key as keyof typeof formData];
                if (value !== null && key !== 'prods'){
                    formDataToSend.append(key, value as string |Blob);    
                }
                else{
                    const prodsToSend = JSON.stringify(formData.prods)
                    console.log(prodsToSend)
                    formDataToSend.append(key,prodsToSend)
                }
                

            })
            

            const respoonse = await registerProvider(formDataToSend);
            setTimeout(() => {
                navigate('/');
            }, 2000);
            console.log(respoonse);
        } catch (error:any) {
            console.error('register failed', error);
            if (axios.isAxiosError(error)){
                setError(error.response?.data || 'register failed');
            }
            else {
                setError('register failed');
            }
        }
    };

    return (
       

<div>
            <form onSubmit={handleSubmit}>
                <h1>Register</h1>
                <div>
                    <label>Name:</label>
                    <input type="text" name="name" value={formData.name} onChange={handleChange} />
                    {fieldErrors.name && <span className="error">Name is required.</span>}
                </div>
                <div>
                    <label>Password:</label>
                    <input type="password" name="password" value={formData.password} onChange={handleChange} />
                    {fieldErrors.password && <span className="error">Password is required.</span>}
                </div>
                <div>
                    <label>Company Name:</label>
                    <input type="text" name="companyName" value={formData.companyName} onChange={handleChange} />
                    {fieldErrors.companyName && <span className="error">Company Name is required.</span>}
                </div>
                <div>
                    <label>Phone:</label>
                    <input type="text" name="phone" value={formData.phone} onChange={handleChange} />
                    {fieldErrors.phone && <span className="error">Phone is required.</span>}
                </div>
                
                {error && <p className="error">{error}</p>}
                <button type="submit">Register</button>
                <Link to="/">Back to Login</Link>
            </form>

            <div>
            <label>Add p=Products</label>
            {prodComponents.map((_, index) => (
                <AddProd key={index} action={addProdFunc} num={index} />
            ))}
            {fieldErrors.prods && <span className="error">Products are required.</span>}
            </div>
        </div>

    )
    



}