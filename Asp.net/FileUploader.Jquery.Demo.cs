//  Ajax file upload只需要引用jquyer就行了,这个是比较简单的传输方式，但是对IE10以下版本的浏览器兼容不好       
public ActionResult Upload()
{
    HttpPostedFileBase ss = Request.Files["avatarFile"];
    var inputStream = ss.InputStream;
    byte[] bData = new byte[inputStream.Length];
    inputStream.Read(bData, 0, bData.Length);
    inputStream.Dispose();
    return Content("成功");
}


//----------------------------------------------------------------------------------
<form id = "avatarForm" name="avatarForm" enctype="multipart/form-data" >
    <label for="file">文件名：</label>
    <input type = "file" name="avatarFile" id="avatarFile" required><br>
    <button name = "avatarButton" class="k-button k-primary" value="上传头像">上传头像</button>
</form>
<script>
    $('#avatarForm').submit(function(e) {
    var avatarData = new FormData();
    avatarData.append("avatarFile", $('#avatarFile')[0].files[0]);
    //avatarData.append("avatarFile", $('#avatarFile'));
    avatarData.append("userName", $('#userName').val());
        //var fileInputElement = $("#avatarFile");
        //avatarData.append(fileInputElement);
        //avatarData.append("avatarFile", fileInputElement.files[0]);
        //var data = new FormData($('input[name^="media"]'));
        //avatarData.append($('avatarFile'));
        $.ajax({
        url: "/Home/Upload",
            data: avatarData,
            cache: false,
            contentType: false,
            processData: false,
            type: 'POST',
            success: function(data) {
            alert(data);
        }
    });
    e.preventDefault();
});
</script>
