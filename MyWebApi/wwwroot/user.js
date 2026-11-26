
const MIN_SCORE = 3;   // זהה ל-PasswordMinScore בשרת

const validPass = async () => {
    const password = document.querySelector("#password").value;
    try {
        if (password == '')
            throw ("enter password")
        const respone = await fetch("api/Pass", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(password)
        });
        if (!respone.ok) throw Error("שגיאה בבדיקת הסיסמה");
        const score = await respone.json();
        document.querySelector("#prog").value = score;
        if (score < MIN_SCORE)
        {
            alert("הסיסמה חלשה מדי"); return false;
        }
        return true;
    }
    catch (e) {
        alert(e.message);
        return false;
    }
};

const postdata = async () => {
    const user = {
        Email: document.querySelector("#email").value,
        Password: document.querySelector("#password").value,
        FirstName: document.querySelector("#firstName").value,
        LastName: document.querySelector("#lastName").value
    };
    if (!(await validPass())) return;
    try {
        const respone = await fetch("api/Users", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        });
        if (!respone.ok)
            throw Error("שגיאה בהרשמה");
        alert("נרשמת בהצלחה");
    }
    catch (e) {
        alert(e.message);
    }
};


const getUser = async () => {
   const email=document.querySelector("#logemail").value
    const password=document.querySelector("#logpassword").value

    const loguser={
        email,
        password
    }

    try {
       
        const respone = await fetch(`api/Users/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(loguser)
        });

        if (respone.status === 401)
            throw Error("אימייל או סיסמה שגויים");
        if (!respone.ok)
            throw Error("the user not connected")
        else {
            const CurrentUser = await respone.json();
            alert("your login was succsess")
            sessionStorage.setItem("CurrentUser",JSON.stringify(CurrentUser))
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

