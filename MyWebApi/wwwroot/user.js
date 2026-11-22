const postdata = async () => {
    const name = document.querySelector("#name").value
    const lname = document.querySelector("#lname").value
    const email = document.querySelector("#email").value
    const password = document.querySelector("#pass").value

    const user = {
        name,
        lname,
        email,
        password
    };

    try {
        const respone = await fetch('api/Users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });

       
        const CurrentUser = await respone.json();
        if (respone.ok) {
            alert("נרשמת בהצלחה")
            sessionStorage.setItem("CurrentUser",JSON.stringify(CurrentUser))
        }
        else {
            throw Error("error")
        }
    }
    catch (e) {
        alert(e.message)
    }


}

const login=async()=>{
    email:document.querySelector("#logemail").value
    password:document.querySelector("#logpass").value

    const loguser={
        email,
        password
    }

    try {
       
        const respone = await fetch('api/Users/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(loguser)
        });

        
        const postRes = await respone.json();
        if (!postRes.ok)
            throw Error("error")
        else {
            window.location.href="UserDetails.html"
                // a = document.querySelector(".a");
                // a.style.display = "none";
                // succses = document.querySelector(".succses");
                // succses.textContent = succses.textContent + " " + (await response.json()).firstName;
                // succses.style.display = "block";
        }
                
    }
    catch (e) {
        alert(e.message)
    }
}


const newUser=()=>{
    const sign=document.querySelector(".sign")
    sign.style.display="block";
    sign.style.display="grid"; 

}