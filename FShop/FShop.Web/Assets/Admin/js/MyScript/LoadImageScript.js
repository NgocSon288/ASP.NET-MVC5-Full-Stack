function ShowImage(ImageUpload, preImage) {
    if (ImageUpload.files && ImageUpload.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            preImage.src = e.target.result;
        }
        reader.readAsDataURL(ImageUpload.files[0]);
    }
}