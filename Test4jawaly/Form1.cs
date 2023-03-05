using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test4jawaly
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string app_key = "";
            string app_secrt = "";
            var sendesr = (new SMSControl4Jawaly.SMS()).GetSenders4jawaly(app_key, app_secrt);
            var send = (new SMSControl4Jawaly.SMS()).Send4jawaly(app_key, app_secrt, sendesr[0],
                new List<Models.message>()
            {
                    new Models.message()
                    {
                        numbers = new List<string>() {txtMobile.Text}
                        ,text =txtMsg.Text}
                });

        }
    }
}
