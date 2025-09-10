// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



document.addEventListener("DOMContentLoaded", function () {
    //Se le asigna la clase toogle
    const toggleButton = document.getElementById("toggle-dark");

    //body del html
    const body = document.body;

    // Se guarda en locals
    if (localStorage.getItem("theme") === "dark") {
        body.classList.add("dark-mode");
    }

    toggleButton.addEventListener("click", function () {
        body.classList.toggle("dark-mode");

        if (body.classList.contains("dark-mode")) {
            toggleButton.textContent = "Modo claro";
            localStorage.setItem("theme", "dark");
            
        } else {
            toggleButton.textContent = "Modo oscuro";
            localStorage.setItem("theme", "light");
        }
    });
});
