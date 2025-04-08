type addType = {
    action: (e: React.FormEvent<HTMLFormElement>) => void
    num: number
}

export const AddProd = (props:addType)=>{
    let idn = "nameInput" 
    let idp = "pricePerOneInput" 
    let idm = "minCountInput" 
    return (
        <div className="add-prod-form">
            <form className="add-prod-form" onSubmit={props.action}>
                <h2>add product</h2>
                <label htmlFor={idn}>name of product</label>
                <input type="text" placeholder="name" id={idn}/>
                <label htmlFor={idp}>price per one</label>
                <input type="Double" id={idp} />
                <label htmlFor={idm}>minimum count</label>
                <input type="number" id={idm} />
                <button type="submit" >add product</button>
            </form>
        </div>
    )
}