$(document).ready(function () {
    $("#userForm").on("submit", function (event) {
        event.preventDefault();
        
        // Get the values from the form inputs
        const nome = $("#name").val();
        const email = $("#email").val();

        // Create a user object with the data from the form
        const user = {
            name: nome,
            email: email
        };

        console.log(user); // show form results on console

        // Confirmation message
        $("#confirmationMessage").fadeIn();
        setTimeout(function () {
            $("#confirmationMessage").fadeOut();
        }, 3000);
    });
})


