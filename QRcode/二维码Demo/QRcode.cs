            //需要引用二维码的dll文件
            string str = Server.UrlDecode(Request.QueryString["id"]);
            QRCodeEncoder encoder = new QRCodeEncoder();
            encoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;//编码方式(注意：BYTE能支持中文，ALPHA_NUMERIC扫描出来的都是数字)
            encoder.QRCodeScale = 4;//大小(值越大生成的二维码图片像素越高)
            encoder.QRCodeVersion = 0;//版本(注意：设置为0主要是防止编码的字符串太长时发生错误)
            encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;//错误效验、错误更正(有4个等级)
            System.Drawing.Bitmap bp = encoder.Encode(str, Encoding.GetEncoding("GB2312"));
            MemoryStream ms = new MemoryStream();
            bp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            Response.ContentType = "image/bmp";
            Response.BinaryWrite(ms.ToArray());