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