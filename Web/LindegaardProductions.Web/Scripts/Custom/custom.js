// ------------------
// Sweetalert2 init.
// ------------------
function ShowSuccessMessage(message) {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        allowEscapeKey: true,
        showCloseButton: true,
        timer: 1500,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer)
            toast.addEventListener('mouseleave', Swal.resumeTimer)
        }
    })

    Toast.fire({
        icon: 'success',
        title: message
    })
}
function ShowErrorMessage(message) {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        allowEscapeKey: true,
        showCloseButton: true,
        timer: 4000,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer)
            toast.addEventListener('mouseleave', Swal.resumeTimer)
        }
    })

    Toast.fire({
        icon: 'error',
        title: message
    })
}

// ------------------
// Loading icon
// ------------------
function ShowSpinner() {
    $(".spinner").show();
}
function HideSpinner() {
    $(".spinner").hide();
}