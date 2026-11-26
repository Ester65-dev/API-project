const title = document.querySelector(".title")
// const NameUser = JSON.parse(User).name
// const IdUser = JSON.parse(User).IdUser
const updateDetails=document.querySelector(".updateDetails")
const details=document.querySelector(".details")


const User = sessionStorage.getItem("CurrentUser")
const nameUser1 = JSON.parse(User).firstName;
const lastName1 = JSON.parse(User).lastName;
const email1 = JSON.parse(User).email;
const password1 = JSON.parse(User).password;
const id = JSON.parse(User).id;

title.textContent = title.textContent+ " "+ nameUser1

const writeTheUser =  () => {
    const fname2 = document.querySelector("#firstName")
    const lname2 = document.querySelector("#lastName")
    const email2 = document.querySelector("#email")
    const password2 = document.querySelector("#password")

    fname2.value=nameUser1
    lname2.value=lastName1
    email2.value=email1
    password2.value=password1

    details.style.display="block"
}

const put = async() => {
    const firstname = document.querySelector("#firstName").value
    const lastname = document.querySelector("#lastName").value
    const email = document.querySelector("#email").value
    const password = document.querySelector("#password").value
    
    const user = {  
        id:id,
        firstname,
        lastname,
        email,
        password

    };

    try {

        const respone = await fetch(`api/Users/${id}`, {
            method: 'PUT',
            headers: {
               'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        if (respone.ok)
            alert("succsess to update")
        else
            alert("try again")


    }
        catch (e) {
            alert(e.message)
        }
}

const ValidPass = async () => {
    const password = document.querySelector("#password").value;
    try {
        const respone = await fetch("api/Pass", {
            method: 'POST', headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(password)
        });
        const score = await respone.json();
        document.querySelector("#prog").value = score;
        if (score < 3) alert("הסיסמה חלשה מדי");
        return score >= 3;
    } catch (e) { alert(e.message); return false; }
};

