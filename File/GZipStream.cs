using (MemoryStream ms = new MemoryStream())
{
   IFormatter iFormatter = new BinaryFormatter();
   iFormatter.Serialize(ms, concurrentQueueItems);
   //使用二进制存储造成文件过大100G磁盘的数据大概32M
   buff = ms.GetBuffer();
   using (FileStream compressedFileStream = File.Create(compressionFileName))
   {
       using (GZipStream compressionStream = new GZipStream(compressedFileStream,
          CompressionLevel.Optimal))
       {
           compressionStream.Write(buff, 0, buff.Length);
       }
   }
}