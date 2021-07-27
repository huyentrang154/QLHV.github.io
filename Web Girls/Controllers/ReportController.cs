using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aspose.Words;
using System.IO;

namespace Web_Girls.Controllers
{
    public class ReportController : Controller
    {
          // GET: Report
          
        public ActionResult Report()
        {
               
               string dataDir = System.Web.HttpContext.Current.Server.MapPath(@"~/Data/Templates/");
               Aspose.Words.Document newdoc = new Aspose.Words.Document(dataDir + "BaoCao.doc");

               var link = dataDir + "render_BaoCao.doc.html";
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
                    newdoc.Save(dataDir + "before_render_BaoCao.doc.html", option);

                    // Insert Attribute placeholder to input elements
                    StreamReader reader = new StreamReader(dataDir + "before_render_BaoCao.doc.html");
                    string input2 = reader.ReadToEnd();
                    reader.Close();

                    ViewBag.DocumentContent = input2;
                    //String filename = Guid.NewGuid().ToString();
                    StreamWriter writer = new StreamWriter(dataDir + "render_BaoCao.doc.html", false); 
                    writer.Write(input2);
                    writer.Close();


                    return View();
               }

        }
          [HttpPost]
          public void Gen(FormCollection ls)
          {
               string inputPath = "BaoCao.doc";
               string dataDir = System.Web.HttpContext.Current.Server.MapPath(@"~/Data/Templates/");

               Aspose.Words.Document doc = new Aspose.Words.Document(dataDir + "BaoCao.doc");

               doc.Save(dataDir + "html/Aspose_DocToHTML.html", SaveFormat.Html); //Save the document in HTML format.

               var list_fields = doc.MailMerge.GetFieldNames().ToArray();
               //String[] field_array = field_list.ToArray();
               //field_array[field_array.Length-1] = field_array[field_array.Length-1].Replace("\r\n", string.Empty);
               doc.MailMerge.UseNonMergeFields = true;


               // Fill the fields in the document with user data.  

               dataDir = dataDir + ".docx";
               // Send the document in Word format to the client browser with an option to save to disk or open inside the current browser.
               doc.Save(@dataDir);

               string time = DateTime.Now.ToString();


               System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
               response.ClearContent();
               response.Clear();
               response.ContentType = "Application/msword";
               response.AddHeader("Content-Disposition", "attachment; filename=" + time + "_" + @inputPath + ";");
               response.TransmitFile(dataDir);
               response.Flush();
               response.End();
          }

     }
}