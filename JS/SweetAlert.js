document.addEventListener("DOMContentLoaded", function () {
    var errorMessage = document.getElementById("errorMessage");

    if (errorMessage && errorMessage.value.trim() !== "") {
        Swal.fire({
            icon: 'error',
            title: 'Error!',
            text: errorMessage.value,
            confirmButtonText: 'Aceptar'
        });
    }
});
