// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $(".ver-detalle").click(function () {
        var id = $(this).data("id");

        $.ajax({
            url: urlDetailsPartial,
            data: { id: id },
            type: "GET",
            success: function (result) {
                $("#detalleModalBody").html(result);
                $("#detalleModal").modal("show");
            },
            error: function () {
                alert("Error al cargar los detalles.");
            }
        });

    });
});