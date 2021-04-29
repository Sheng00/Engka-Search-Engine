using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Engkapish_Search_Engine
{
    public partial class create : Form
    {
        public create()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            richTextBox1.Text = richTextBox1.Text.Replace(' ', '-');

            string siteName = richTextBox1.Text + textBox1.Text;
            string content = richTextBox2.Text;

            try
            {
                NetworkCredential credit = new NetworkCredential("contact.Koderz@gmail.com", "Koderzfor2019");
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage message = new MailMessage("contact.Koderz@gmail.com", "contact.Koderz@gmail.com", siteName, content);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = credit;
                client.Send(message);
                MessageBox.Show("Done! Will take 24-48 hours!");
            }
            catch(WebException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void create_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
        }
    }
}
