using AVtomirTestDB;
using AVtomirTestDB.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AVtomirTestLibrary
{
    public class Cbr
    {
        DateTime date;
        CbrDbContext context = new CbrDbContext();
        string TempDirectory = ConfigurationManager.AppSettings["TempDirectory"];

        public Cbr()
        {

        }

        public Cbr(DateTime date)
        {
            this.date = date;
        }

        public void Start()
        {

            if (!Directory.Exists(TempDirectory))
            {
                Directory.CreateDirectory(TempDirectory);
            }
            else Delete();


            string fileName = Download();

            Unpack(fileName);

            var file = Directory.GetFiles(TempDirectory).FirstOrDefault();

            if (file != null)
            {
                var result = Parse(file);
                Save(result);
            }

            Delete();

        }

        private void Save(BikData result)
        {
            context.Save(result);
        }

        string Download()
        {


            WebClient client = new WebClient();
            string fileName = Guid.NewGuid().ToString() + ".zip";
            string link = "";
            if (date.Year == 1)
                link = "http://cbr.ru/s/newbik";
            else
            {
                var siteContent = client.DownloadString(@"http://cbr.ru/PSystem/payment_system/?UniDbQuery.Posted=True&UniDbQuery.To=" + date.ToString("dd.MM.yyyy") + "#BikFormData");
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(siteContent);
                var result = doc.DocumentNode.Descendants("p").Where(a => a.HasClass("file")).ToList();
                if (result.Count > 0)
                {
                    link = "http://cbr.ru" + result[0].FirstChild.Attributes?[0].Value;
                }
                else
                    throw new Exception("Невозможно запарсить файл с сайта");
            }


            client.DownloadFile(link, TempDirectory + "\\" + fileName);

            return fileName;


        }

        void Unpack(string fileName)
        {
            ZipFile.ExtractToDirectory(TempDirectory + "\\" + fileName, TempDirectory);
        }

        BikData Parse(string path)
        {
            var xml = File.ReadAllText(path, Encoding.GetEncoding("windows-1251"));
            XmlSerializer serializer = new XmlSerializer(typeof(BikData));
            BikData result = null;
            using (var reader = new StringReader(xml))
            {
                result = (BikData)serializer.Deserialize(reader);
            }

            return result;
        }

        void Delete()
        {
            foreach (var item in Directory.GetFiles(TempDirectory))
            {
                File.Delete(item);
            }

        }
    }
}
