function PostFormMethod(Url, data, callback) {
    var res;
    $.ajax({
        url: Url,
        type: 'POST',
        data: data,
        processData: false,
        contentType: false,
        success: function (response) {
            res = response;
            callback(response);

        },
       
    });
    return res;
}

function ShowToastr(){
    toastr.success("Data Saved Successfully");

}