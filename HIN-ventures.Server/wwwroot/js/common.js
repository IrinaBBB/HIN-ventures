window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Success");
    }

    if (type === "error") {
        toastr.error(message, "Operation Failed");
    }
}

window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            "Success Notification!",
            message,
            "success"
        );
    }

    if (type === "error") {
        Swal.fire(
            "Error Notification!",
            message,
            "error"
        );
    }
}

