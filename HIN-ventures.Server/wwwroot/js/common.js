window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Success");
    }

    if (type === "error") {
        toastr.error(message, "Operation Failed");
    }
}


