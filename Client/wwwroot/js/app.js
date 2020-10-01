function showConfirmDialog(message, callbackName, dotnetHelper) {
    bootbox.confirm(message, function (result) {
        if (result)
            dotnetHelper.invokeMethodAsync(callbackName)
    })

}