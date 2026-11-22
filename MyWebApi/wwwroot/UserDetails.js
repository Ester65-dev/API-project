const title = document.querySelector(".title")
const User = sessionStorage.getItem("CurrentUser")
const NameUser = JSON.parse(User).name
const IdUser = JSON.parse(User).IdUser

title.textContent = NameUser
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




const put = () => {
    const sign = document.querySelector(".sign")
    sign.style.display = "block";
    sign.style.display = "grid";

}


    const update = () => {
        try {

            const respone = await fetch('api/Users', {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(loguser)
            });

        }
        catch (e) {
            alert(e.message)
        }
    }
}
