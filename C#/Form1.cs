﻿using API_Example.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            var data = _4jawaly.GetSenders4jawaly(txtAPIkey.Text, txtAPISecret.Text);

            if (data != null && data.items != null && data.items.data != null)
            {
                var activeSender = data.items.data.Where(s => s.status == 1).ToList(); ;
                cmbSenderNames.DataSource = activeSender;
                cmbSenderNames2.DataSource = activeSender;
                MessageBox.Show("تم الاتصال بنجاح | Connected");
            }
            else
            {
                MessageBox.Show("لم ينم الاتصال | Can not connect");
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            string[] mobiles = txtMobiles.Text.Split(',');

            List<message> messages = new List<message>();

            foreach (var mobile in mobiles)
            {
                messages.Add(new message()
                {
                    text = txtMessage.Text,
                    numbers = new List<string>() { mobile }
                });
            }

            var result = _4jawaly.Send4jawaly(txtAPIkey.Text, txtAPISecret.Text, cmbSenderNames2.Text, messages);
            if (result.Sent)
            {
                MessageBox.Show("Message sent تم الارسال");
            }
            else
            {
                MessageBox.Show("Message not sent لم يتم الارسال" + Environment.NewLine + result.Message);
            }
        }
    }
}
