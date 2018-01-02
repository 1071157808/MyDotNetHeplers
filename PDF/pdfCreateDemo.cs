using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfTestDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = DateTime.Now.ToString("yyyy-MM-dd")+".pdf";
            Document document = new Document();
            //Document document = new Document(pageSize, 36f, 72f, 108f, 180f);
            var writer = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
            //设置页面大小
            iTextSharp.text.Rectangle pageSize = new iTextSharp.text.Rectangle(216f, 716f);
            pageSize.BackgroundColor = new iTextSharp.text.BaseColor(0xFF, 0xFF, 0xDE);
            //设置边界
            
            // 添加文档信息
            document.AddTitle("PDFInfo");
            document.AddSubject("Demo of PDFInfo");
            document.AddKeywords("Info, PDF, Demo");
            document.AddCreator("SetPdfInfoDemo");
            document.AddAuthor("焦涛");

            document.Open();

            #region 添加文档内容
            // 添加文档内容
            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph("Hello World");
            //设置段落位置
            paragraph.Alignment = Element.ALIGN_CENTER;
            document.Add(paragraph);
            #endregion

            #region 添加页面
            // 第一页
            document.Add(new iTextSharp.text.Paragraph("PDF1, PDF1, PDF1, PDF1, PDF1"));
            document.Add(new iTextSharp.text.Paragraph("PDF1, PDF1, PDF1, PDF1, PDF1"));
            document.Add(new iTextSharp.text.Paragraph("PDF1, PDF1, PDF1, PDF1, PDF1"));
            document.Add(new iTextSharp.text.Paragraph("PDF1, PDF1, PDF1, PDF1, PDF1"));
            // 添加新页面
            document.NewPage();
            // 第二页
            // 添加第二页内容
            document.Add(new iTextSharp.text.Paragraph("PDF2, PDF2, PDF2, PDF2, PDF2"));
            document.Add(new iTextSharp.text.Paragraph("PDF2, PDF2, PDF2, PDF2, PDF2"));
            document.Add(new iTextSharp.text.Paragraph("PDF2, PDF2, PDF2, PDF2, PDF2"));
            document.Add(new iTextSharp.text.Paragraph("PDF2, PDF2, PDF2, PDF2, PDF2"));
            document.Add(new iTextSharp.text.Paragraph("PDF2, PDF2, PDF2, PDF2, PDF2"));
            document.Add(new iTextSharp.text.Paragraph("PDF2, PDF2, PDF2, PDF2, PDF2"));
            // 添加新页面
            document.NewPage();
            // 第三页
            // 添加新内容
            document.Add(new iTextSharp.text.Paragraph("PDF3, PDF3, PDF3, PDF3, PDF3"));
            document.Add(new iTextSharp.text.Paragraph("PDF3, PDF3, PDF3, PDF3, PDF3"));
            document.Add(new iTextSharp.text.Paragraph("PDF3, PDF3, PDF3, PDF3, PDF3"));
            document.Add(new iTextSharp.text.Paragraph("PDF3, PDF3, PDF3, PDF3, PDF3"));
            // 重新开始页面计数
            document.ResetPageCount();
            // 新建一页
            document.NewPage();
            // 第四页
            // 添加第四页内容
            document.Add(new iTextSharp.text.Paragraph("PDF4, PDF4, PDF4, PDF4, PDF4"));
            document.Add(new iTextSharp.text.Paragraph("PDF4, PDF4, PDF4, PDF4, PDF4"));
            document.Add(new iTextSharp.text.Paragraph("PDF4, PDF4, PDF4, PDF4, PDF4"));
            document.Add(new iTextSharp.text.Paragraph("PDF4, PDF4, PDF4, PDF4, PDF4"));
            #endregion

            #region pdf中插入图片
            var imagePath = @"C:\Users\spike\Desktop\我猜你想死.jpg";
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagePath);
            img.SetAbsolutePosition((PageSize.POSTCARD.Width - img.ScaledWidth) / 2, (PageSize.POSTCARD.Height - img.ScaledHeight) / 2);
            writer.DirectContent.AddImage(img);
            #endregion

            document.Close();
        }
    }
}
