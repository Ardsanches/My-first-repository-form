document.getElementById("userForm").addEventListener("submit", function (event) {
    event.preventDefault(); // Impede o envio padrão do form
    console.log("Formulário enviado!"); // Exibe no console

    const nome = document.getElementById("name").value;
    const email = document.getElementById("email").value;

    const user = {
        name: nome,
        email: email
    };

    console.log(user); // Exibe os dados do formulário
})