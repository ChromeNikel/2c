using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Parsing2ch
{
    class RealParser
    {
    /// <summary>
    /// сюда сохраняем код страницы
    /// </summary>
        private string Source = string.Empty;
        /// <summary>
        /// в список собираем ссылки на пикчи
        /// </summary>
        private List<string> l1 = new List<string>();
        /// <summary>
        /// сюда пишем URL страницы
        /// </summary>
        private string URL = string.Empty;
        /// <summary>
        /// измененный WebClient (можно работать с cookies)
        /// </summary>
        public WebClientEx wecCL = new WebClientEx();
       /// <summary>
       /// для обращения к коду страницы
       /// </summary>
        public string htmlstring
        {
            get
            {
                return Source;
            }
            set
            {
                Source = value;
            }
        }
        /// <summary>
        /// Скачивает страницу в Source
        /// </summary>
        /// <param name="URL">адресс треда</param>
        /// <param name="wc">измененный WebClient</param>
        public RealParser(string URL, WebClientEx wc)
        {
            if (URL != null && URL !=string.Empty)
            {
                this.URL = URL;
                //SetCookies();
                wecCL = wc;
                Source = wecCL.DownloadString(URL);
            }           
        }
        /// <summary>
        /// непосредственно парсинг и настройка селектора, собирает ссылки на пикчи в l1
        /// </summary>
        /// <param name="selector">строка-селектор</param>
        public void ParsingAndSelector(string selector)
        {
            if (Source != null && URL != null && URL != string.Empty)
            {
                var parser = new HtmlParser();
                IHtmlDocument doc = parser.Parse(Source);

                var div = doc.QuerySelectorAll(selector);
                string domen = URL.Substring(0, 14);
                foreach (var item in div)
                {
                    string a = domen + item.GetAttribute("href");
                    if (!a.Contains(".webm") && !a.Contains(".mp4"))
                    {
                        l1.Add(a);
                    }
                }
            }           
        }
        /// <summary>
        /// загружает и сохраняет пикчи
        /// </summary>
        /// <param name="dir">папка сохранения</param>
        public void SavingStream(string dir)
        {
            if (l1 != null && dir != null)
            {
                Stream stream;
                Bitmap bitmap;                
                foreach (var item in l1)
                {
                    stream = wecCL.OpenRead(item);
                    bitmap = new Bitmap(stream);

                    var fileName = Path.GetFileName(item);
                    if (bitmap != null)
                    {
                        bitmap.Save(dir + "\\" + fileName + ".jpg");
                    }
                }
            }           
        }
    }
}
