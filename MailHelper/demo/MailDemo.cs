using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Email
{
    class Program
    {
        static void Main(string[] args)
        {
            //服务器邮件服务器地址
            string smtpServer = "smtp.exmail.qq.com";
            //服务器账户
            string userName = "zbadmin@sitrc.com";
            //帐号密码
            string userPassword = "P@ssw0rd123";
            //邮件标题
            string mailSubject = "审核已经通过";
            //邮件主体
            string mailBody = "您申请的工作包的已经审核通过，请及时上传资料\n您的帐号是您的密码是" ;
            //邮件接收方
            string userMail = "906990711@qq.com";
            List<string> mailList = new List<string>();
            mailList.Add(userMail);
            bool result = MailHelper.sendMail(mailSubject, mailBody, userName, mailList, smtpServer, userName, userPassword);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
