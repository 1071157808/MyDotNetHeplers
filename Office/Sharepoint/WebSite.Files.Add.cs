using Microsoft.SharePoint;
if (htmlInputFile1.PostedFile != null) {
    SPWeb site = new SPSite (destinationURL).OpenWeb ();
    Stream stream = htmlInputFile1.PostedFile.InputStream;
    byte[] buffer = new bytes[stream.Length];
    stream.Read (buffer, 0, (int) stream.Length);
    stream.Close ();
    site.Files.Add (destinationURL, buffer);
}