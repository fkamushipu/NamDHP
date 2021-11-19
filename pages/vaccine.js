import React, { useState, useEffect } from 'react'  
import Axios from 'axios';  

 function Vaccine() {  
    const [data, setData] = useState([]); 
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null); 
  
    useEffect(() => {   
        Axios  
            .get("http://localhost:6503/api/Vaccines")  
            .then((result) => {
                setData(result.data);
                setLoading(false);
                },  
                (error) => {
                    console.error("Error fetching data: ", error);
                    setError(error);
                    }
            );
    }, []); 

    if(loading) return "Loading ...";
    if(error) return "Error!"

    return (  
       <div>
           <pre>{JSON.stringify(data, null, 2)}</pre>
       </div> 
    )  
}  
(React.Component);
ReactDOM.render(document.getElementById("vaccine_card")); 