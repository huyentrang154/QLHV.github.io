using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aspose.Words;
using System.IO;

namespace Web_Girls.Controllers
{
     public class MemberController : Controller
     {
          public ActionResult Index()
          {
               return View();
          }
          public ActionResult Member_Add()
          {
               return View();
          }
          public ActionResult Member_Add_Detail()
          {
               return View();
          }
        public ActionResult Member_Detail()
        {
            string dataDir = System.Web.HttpContext.Current.Server.MapPath(@"~/Data/Templates/");
            Aspose.Words.Document newdoc = new Aspose.Words.Document(dataDir + "Member_Detail.doc");

            var link = dataDir + "render_Member_Detail.doc.html";
            if (System.IO.File.Exists(link))
            {
                StreamReader renderContentStream = new StreamReader(link);
                string renderContent = renderContentStream.ReadToEnd();
                ViewBag.DocumentContent = renderContent;
                renderContentStream.Close();
                return View();
            }
            else
            {
                //Nếu file html của template vẫn chưa được gen ra html thì thực hiện bước này
                DocumentBuilder builder = new DocumentBuilder(newdoc);

                // Save as .html file

                Aspose.Words.Saving.HtmlSaveOptions option = new Aspose.Words.Saving.HtmlSaveOptions();
                option.SaveFormat = SaveFormat.Html;
                option.ExportImagesAsBase64 = true;
                //Lưu lại dưới dạng html với tên là id của văn bản
                newdoc.Save(dataDir + "before_render_Member_Detail.doc.html", option);

                // Insert Attribute placeholder to input elements
                StreamReader reader = new StreamReader(dataDir + "before_render_Member_Detail.doc.html");
                string input2 = reader.ReadToEnd();
                reader.Close();

                ViewBag.DocumentContent = input2;
                //String filename = Guid.NewGuid().ToString();
                StreamWriter writer = new StreamWriter(dataDir + "render_Member_Detail.doc.html", false);
                writer.Write(input2);
                writer.Close();


                return View();
            }
        }
    }
}