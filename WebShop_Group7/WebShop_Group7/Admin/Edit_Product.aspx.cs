using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7.Admin
{
    public partial class Edit_Product : System.Web.UI.Page
    {
        Product product = new Product();
        ProductObject proObc;
        Image img = new Image();
        string attributes = "";
        int ProductID;
        protected void Page_Load(object sender, EventArgs e)
        {
            // fs = new FileStream();   
            int ProductID = int.Parse(Request.QueryString["id"]);

            proObc = product.GetProduct(ProductID);

            LoadValues();
                //QueryString["id"].ToString();
        }

        private void LoadValues()
        {
            Label_ProductNameHeader.Text = proObc.name;
            Label_ArticleNumber.Text = proObc.artNr;
            Label_ProductName.Text = proObc.name;
            Label_ProduktID.Text = proObc.productID.ToString();
            Label_Quantity.Text = proObc.quantity.ToString();
            Label_Brand.Text = proObc.brandName;
            Label_Category.Text = proObc.category;       
            TextBox_Description.Text = proObc.description;
            attributes = product.GetAttributes(ProductID);
            var attributeArray = attributes.Split('\t');
            try { Label_Attribute1.Text = attributeArray[0]; } catch { }
            try { Label_Attribute2.Text = attributeArray[1]; } catch { }
            try { Label_Attribute3.Text = attributeArray[2]; } catch { }
           
           
       
        }

        protected void Button_Save_Click(object sender, EventArgs e)
        {

        }

        protected void Button_NewProductIMG_Click(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile)
            {
                Label_ImgUpload.ForeColor = System.Drawing.Color.Red;
                Label_ImgUpload.Text = "Please Select Image File";
            }

            else
            {
                Label_ImgUpload.ForeColor = System.Drawing.Color.Green;
                Label_ImgUpload.Text = "Image Uploaded Sucessfully";
                UploadProfileImage("", @"/cerwus.se / public_html / Grupp7", "");
            }
        }
        private void UploadProfileImage(string TargetFileName, string TargetDestinationPath, string FiletoUpload)
        {
            //Get the Image Destination path
            string imageName = TargetFileName; //you can comment this
            string imgPath = TargetDestinationPath;
            //ftp.cerwus.se
            string ftpurl = "ftp://downloads.abc.com/downloads.abc.com/MobileApps/SystemImages/ProfileImages/" + imgPath;
            string ftpusername = ConfigurationManager.AppSettings["207706_master"];//krayknot_DAL.clsGlobal.FTPUsername;
            string ftppassword = ConfigurationManager.AppSettings["Cerwus123456"];//krayknot_DAL.clsGlobal.FTPPassword;
            string fileurl = FiletoUpload;

            FtpWebRequest ftpClient = (FtpWebRequest)FtpWebRequest.Create(ftpurl);
            ftpClient.Credentials = new System.Net.NetworkCredential(ftpusername, ftppassword);
            ftpClient.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
            ftpClient.UseBinary = true;
            ftpClient.KeepAlive = true;
            System.IO.FileInfo fi = new System.IO.FileInfo(fileurl);
            ftpClient.ContentLength = fi.Length;
            byte[] buffer = new byte[4097];
            int bytes = 0;
            int total_bytes = (int)fi.Length;
            System.IO.FileStream fs = fi.OpenRead();
            System.IO.Stream rs = ftpClient.GetRequestStream();
            while (total_bytes > 0)
            {
                bytes = fs.Read(buffer, 0, buffer.Length);
                rs.Write(buffer, 0, bytes);
                total_bytes = total_bytes - bytes;
            }
            //fs.Flush();
            fs.Close();
            rs.Close();
            FtpWebResponse uploadResponse = (FtpWebResponse)ftpClient.GetResponse();
            string value = uploadResponse.StatusDescription;
            uploadResponse.Close();
        }
        private void up(string sourceFile, string targetFile)
        {
            // Adress: ftp.cerwus.se
            // Katalog: / cerwus.se / public_html / Grupp7
            // Användare: 207706_master
            // Pass: Cerwus123456

            try
            {
                string ftpServerIP = ConfigurationManager.AppSettings["ftp.cerwus.se"];
                string ftpUserID = ConfigurationManager.AppSettings["207706_master"];
                string ftpPassword = ConfigurationManager.AppSettings["Cerwus123456"];
                ////string ftpURI = "";
                string filename = "ftp://" + ftpServerIP + "//" + targetFile;
                FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(filename);
                ftpReq.UseBinary = true;
                ftpReq.Method = WebRequestMethods.Ftp.UploadFile;
                ftpReq.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftpReq.Proxy = null;

                byte[] b = File.ReadAllBytes(sourceFile);

                ftpReq.ContentLength = b.Length;
                using (Stream s = ftpReq.GetRequestStream())
                {
                    s.Write(b, 0, b.Length);
                }

                FtpWebResponse ftpResp = (FtpWebResponse)ftpReq.GetResponse();

                if (ftpResp != null)
                {
                    Label_ImgUpload.Text = ftpResp.StatusDescription.ToString();
                }
            }
            catch (Exception ex)
            {
                Label_ImgUpload.Text = ex.ToString();
            }
        }
    }
}