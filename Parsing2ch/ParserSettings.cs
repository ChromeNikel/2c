using System;
using System.Collections.Generic;
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
                return SetCookies();
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
        private WebClientEx SetCookies()
        {
            webcl = new WebClientEx();
            CookieContainer cc = new CookieContainer();
            cc.Add(new Uri("https://2ch.pm"), new Cookie("__cfduid", "dfeee45d014d0900aeae1d785ea6502491475017092"));
            cc.Add(new Uri("https://2ch.pm"), new Cookie("__utma", "219771354.1056146642.1475017130.1475185802.1475187970.3"));
            cc.Add(new Uri("https://2ch.pm"), new Cookie("_ga", "GA1.2.1056146642.1475017130"));
            cc.Add(new Uri("https://2ch.pm"), new Cookie("_gid", "GA1.2.1472264686.1505145033"));
            cc.Add(new Uri("https://2ch.pm"), new Cookie("_gid", "GA1.2.1044948328.1505336535"));
            cc.Add(new Uri("https://2ch.pm"), new Cookie("ageallow", "1"));
            cc.Add(new Uri("https://2ch.pm"), new Cookie("usercode_auth", "e70dd235a95f50b2c9ea987ca10b0e6c"));
            webcl.Cookies = cc;
            return webcl;
        }
    }
}
