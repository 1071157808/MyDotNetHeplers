
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
usingSystem.Net;
using FileOperationAboutSharePoint.SPCopyService;
//这个没有测试过
namespace FileOperationAboutSharePoint.FileOperation
{
    public class SPServiceOperation : IFileOperation
    {
        public bool UploadFileToSPSite(string domain, string userAccount, string pwd, string documentLibraryUrl, string localFilePath, ref string statusInfo)
        {
            bool isSuccess = false;
            try
            {
                string fileName = Path.GetFileName(localFilePath);
                string tempFilePath = string.Format("{0}{1}", Path.GetTempPath(), fileName);
                File.Copy(localFilePath, tempFilePath, true);
                FileStream fs = new FileStream(tempFilePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] fileContent = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                Copy service = CreateCopy(domain, userAccount, pwd);
                service.Timeout = System.Threading.Timeout.Infinite;
                FieldInformation fieldInfo = new FieldInformation();
                FieldInformation[] fieldInfoArr = { fieldInfo };
                CopyResult[] resultArr;
                service.CopyIntoItems(
                    tempFilePath,
                    new string[] { string.Format("{0}{1}", documentLibraryUrl, fileName) },
                    fieldInfoArr,
                    fileContent,
                    out resultArr);
                isSuccess = resultArr[0].ErrorCode == CopyErrorCode.Success;
                if (!isSuccess)
                {
                    statusInfo = string.Format("Failed Info: {0}", resultArr[0].ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                statusInfo = string.Format("Failed Info: {0}", ex.Message);
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool DownloadFileFromSPSite(string domain, string userAccount, string pwd, string documentUrl, string localFilePath, ref string statusInfo)
        {
            bool isSuccess = false;
            try
            {
                Copy service = CreateCopy(domain, userAccount, pwd);
                service.Timeout = System.Threading.Timeout.Infinite;
                FieldInformation[] fieldInfoArr;
                byte[] fileContent;
                service.GetItem(documentUrl, out fieldInfoArr, out fileContent);
                if (fileContent != null)
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
                    fs.Write(fileContent, 0, fileContent.Length);
                    fs.Close();
                    isSuccess = true;
                }
                else
                {
                    statusInfo = string.Format("Failed Info: {0}不存在", documentUrl);
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                statusInfo = string.Format("Failed Info: {0}", ex.Message);
                isSuccess = false;
            }
            return isSuccess;
        }
        private Copy CreateCopy(string domain, string userAccount, string pwd)
        {
            Copy service = new Copy();
            if (String.IsNullOrEmpty(userAccount))
            {
                service.UseDefaultCredentials = true;
            }
            else
            {
                service.Credentials = new NetworkCredential(userAccount, pwd, domain);
            }
            return service;
        }
    }
}
