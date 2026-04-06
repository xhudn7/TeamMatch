const passwordInput = document.querySelector(".pass");
const eyeHide = document.querySelector(".eye-hide");
const eyeShow = document.querySelector(".eye-show");

eyeHide.addEventListener("click", function () {
    passwordInput.type = "text";
    eyeHide.style.display = "none";
    eyeShow.style.display = "block";
    eyeShow.style.color = "#4070f4";
});

eyeShow.addEventListener("click", function () {
    passwordInput.type = "password";
    eyeHide.style.display = "block";
    eyeShow.style.display = "none";
    
});