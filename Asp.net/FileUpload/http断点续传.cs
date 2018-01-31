public ActionResult GetFile () {
    // 创建一比特数组
    byte[] buffer = new Byte[10240];
    // 指定要下载文件的路径.
    string filePath = @"E:\Windows10.2017.03.18.iso";
    // 或取文件名包括扩展名
    string fileName = Path.GetFileName (filePath);
    Stream fileStream = null;
    try {
        // 打开文件
        fileStream = new FileStream (filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        Response.Clear ();
        // 获取文件的大小
        long fileSize = fileStream.Length;
        long sum = 0;
        if (Request.Headers["Range"] != null) {
            Response.StatusCode = 206; // 表示返回到客户端的 HTTP 输出状态的整数。默认值为 200。
            sum = long.Parse (Request.Headers["Range"].Replace ("bytes=", "").Replace ("-", ""));
        }
        if (sum != 0) {
            Response.AddHeader ("Content-Range", "bytes " + sum.ToString () + "-" + ((long) (fileSize)).ToString () + "/" + fileSize.ToString ());
        }
        // 获取部分http头信息
        Response.AddHeader ("Content-Length", ((long) (fileSize - sum)).ToString ());
        Response.ContentType = "application/octet-stream";
        //获取文件来源
        Response.AddHeader ("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode (Request.ContentEncoding.GetBytes (fileName)));
        // Response.Flush();
        fileStream.Position = sum; //设置当前流位置
        fileSize = fileSize - sum;
        // 当文件大小大于0是进入循环
        while (fileSize > 0) {
            // 判断客户端是否仍连接在服务器
            if (Response.IsClientConnected) {
                // 获取缓冲区中的总字节数.
                int length = fileStream.Read (buffer, 0, 10240);
                // 写入数据
                Response.OutputStream.Write (buffer, 0, length);
                // 将缓冲区的输出发送到客户端
                Response.Flush ();
                buffer = new Byte[10240];
                fileSize = fileSize - length;
            } else {
                //当用户断开后退出循环
                fileSize = -1;
            }
        }
    } catch (Exception ex) {
        Response.Write ("Error : " + ex.Message);
    } finally {
        if (fileStream != null) {
            //关闭文件
            fileStream.Close ();
        }
        Response.End ();
    }
    return Content ("");
}