$(function () {
    if ($("div.alert.notification").length) {
        setTimeout(() => {
            $("div.alert.notification").fadeOut();
        }, 2000);
    }
});


function readURL(input) {
    if (input.files && input.files[0]) {
        let reader = new FileReader();
        reader.onload = function (e) {
            $("#imagePreview").attr("src", e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}

$("#ImageUpload").change(function () {
    debugger
    readURL(this);
});