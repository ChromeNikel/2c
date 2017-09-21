using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parsing2ch
{
    public partial class Form1 : Form
    {
        string dir;
        RealParser rp;
        ParserSettings ps;
        public Form1()
        {
          
            InitializeComponent();            
            dir = string.Empty;
            ps = new ParserSettings();
            folderBrowserDialog1.SelectedPath = "D:/Картинки/";            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                dir = folderBrowserDialog1.SelectedPath;
                ps.stringDomen = "https://2ch.pm";
                ps.forSelector = ".image-link a";
                rp = new RealParser(textBox1.Text, ps.wcwithCookies2ch);
                rp.ParsingAndSelector(ps.forSelector);
                rp.SavingStream(dir);
            }
              
        }

    }
}
