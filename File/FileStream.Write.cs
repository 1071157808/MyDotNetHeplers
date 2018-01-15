
string filePath = Directory.GetCurrentDirectory() + "\\" + Process.GetCurrentProcess().ProcessName + ".txt";
if (File.Exists(filePath))
　　File.Delete(filePath);
FileStream fs = new FileStream(filePath, FileMode.Create);
//获得字节数组
string xyPointer = string.Format("X: {0}, Y: {1}", this.Location.X.ToString(), this.Location.Y.ToString());
string highWidth = string.Format("\nW: {0}, H: {1}", this.Width.ToString(), this.Height.ToString());
byte[] data = System.Text.Encoding.Default.GetBytes(xyPointer + highWidth);
//开始写入
fs.Write(data, 0, data.Length);
//清空缓冲区、关闭流
fs.Flush();
fs.Close();
