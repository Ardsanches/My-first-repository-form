document.addEventListener("DOMContentLoaded", function (event) {
    document.getElementById("userForm").addEventListener("submit", function (event) {
        event.preventDefault();
        

        const nome = document.getElementById("name").value;
        const email = document.getElementById("email").value;

        const user = {
            name: nome,
            email: email
        };

        console.log(user); // show form results on console
    }
    );
})
