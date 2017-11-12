using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Parsing2ch
{
    class ParserSettings
    {
    /// <summary>
    /// основной URL двача
    /// </summary>
        private string domen;
        private string nameCookie;
        private string valueCookie;     
        /// <summary>
        /// селектор парсинга
        /// </summary>
        private string selector;
        /// <summary>
        /// обращение к domen
        /// </summary>
        public string stringDomen {
        get {
                return domen;
            }
            set
            {
                domen = value;
            }
        }
        /// <summary>
        /// обращение к selector
        /// </summary>      
        public string forSelector
        {
            get
            {
                return selector;
            }
            set
            {
                selector = value;
            }
        }
        /// <summary>
        /// измененный WebClient
        /// </summary>
        private WebClientEx webcl;
        /// <summary>
        /// обращение к измененному WebClient
        /// </summary>
        public WebClientEx wcwithCookies2ch
        {
            get
            {
                return SetCookies(domen, nameCookie, valueCookie);
            }
            set
            {
                wcwithCookies2ch = value;
            }
        }
        /// <summary>
        /// настраиваем cookies для скрытых досок 2ch
        /// </summary>
        /// <returns>изменнный WebClient c cookies</returns>
        private WebClientEx SetCookies(string mainUrl, string name, string value)
        {
            webcl = new WebClientEx();
            CookieContainer cc = new CookieContainer();
            using (StreamReader sr = new StreamReader("Cookies.txt"))
            {
                while (!sr.EndOfStream) {
                    var str = sr.ReadLine();
                    nameCookie = str.Substring(0, str.IndexOf(','));
                    str = str.Remove(0, str.IndexOf(',') + 1);
                    valueCookie = str;
                    cc.Add(new Uri(domen), new Cookie(nameCookie, valueCookie));
                }
            }           
            webcl.Cookies = cc;
            return webcl;
        }
    }
}
