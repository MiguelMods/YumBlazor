window.showToastr = function (type, messge)
{
    if (typeof toastr === 'undefined')
    {
        alert('Toastr is not defined. Please ensure toastr.js is included in your project.');
        return;
    } else if (typeof toastr[type] !== 'function') {
        alert(`Toastr type "${type}" is not valid. Valid types are: info, success, warning, error.`);
        return;
    }
        
    switch (type) {
        case 'info':
            toastr.info(messge);
            break;
        case 'success':
            toastr.success(messge);
            break;
        case 'warning':
            toastr.warning(messge);
            break;
        case 'error':
            toastr.error(messge);
            break;
        default:
            toastr.info(messge);
    }
}