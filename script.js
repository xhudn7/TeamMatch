const male = document.getElementById("dot-1");
const female = document.getElementById("dot-2");
const title = document.getElementById("mainTitle");

male.addEventListener("change", function () {
    if (male.checked) {
        title.classList.remove("female-active");
        title.classList.add("male-active");
    }
});

female.addEventListener("change", function () {
    if (female.checked) {
        title.classList.remove("male-active");
        title.classList.add("female-active");
    }
});



function validateForm(event) {
    event.preventDefault();

    let firstName = document.getElementById("firstName").value;
    let lastName = document.getElementById("lastName").value;
    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;
    let male = document.getElementById("dot-1").checked;
    let female = document.getElementById("dot-2").checked;
    let major = document.getElementById("major").value;
    let message = document.getElementById("message");

    if (firstName === "") {
        message.innerHTML = "Please enter your first name.";
        message.style.color = "red";
    } 
    else if (lastName === "") {
        message.innerHTML = "Please enter your last name.";
        message.style.color = "red";
    } 
    else if (email === "") {
        message.innerHTML = "Please enter your email.";
        message.style.color = "red";
    } 
    else if (!email.includes("@stu.kau.edu.sa")) {
        message.innerHTML = "Please enter a valid email with @stu.kau.edu.sa";
        message.style.color = "red";
    } 
    else if (password === "") {
        message.innerHTML = "Please enter your password.";
        message.style.color = "red";
    } 
    else if (password.length < 8) {
        message.innerHTML = "Password must be at least 8 characters.";
        message.style.color = "red";
    } 
    else if (male === false && female === false) {
        message.innerHTML = "Please select your gender.";
        message.style.color = "red";
    } 
    else if (major === "") {
        message.innerHTML = "Please select your major.";
        message.style.color = "red";
    } 
    else {
        message.innerHTML = "Registration completed successfully!";
        message.style.color = "green";
        message.style.fontWeight = "bold";

        document.getElementById("mainTitle").innerHTML = "Registration Completed";
        document.getElementById("mainTitle").style.color = "green";

        document.getElementById("registerForm").reset();
    }
}

document.getElementById("registerForm").addEventListener("submit", validateForm);