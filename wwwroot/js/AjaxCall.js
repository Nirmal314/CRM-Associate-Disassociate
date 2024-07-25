const AjaxCall = (url, type, data = null, dataType = null, success = null, error = null) => {
    $.ajax({
        url: url,
        type: type,
        data: data,
        dataType: dataType,
        success: success,
        error: error
    });
}