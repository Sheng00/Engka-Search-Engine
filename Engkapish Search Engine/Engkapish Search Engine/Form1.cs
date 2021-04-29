using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engkapish_Search_Engine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    public static string content { get; set; }

        public static string title2 { get; set; }
        public static string title { get; set; }
        


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                WebClient wc = new WebClient();
                //Foreach line in each link, if the link contains the selected item, use the file to navgiate
                var item = listBox1.SelectedItem.ToString();
                item = item.Replace(".site", "");
                foreach(string line in File.ReadAllLines(Directory.GetCurrentDirectory() + @"\cached.dat"))
                {
                    File.WriteAllText(Directory.GetCurrentDirectory() + @"\cachedSites.dat", wc.DownloadString(line));
                    foreach(string lin in File.ReadAllLines(Directory.GetCurrentDirectory() + @"\cachedSites.dat"))
                    {
                        if(lin.Contains(item))
                        {
                            textBox1.Text = listBox1.SelectedItem.ToString();
                            webBrowser1.DocumentText = File.ReadAllText(Directory.GetCurrentDirectory () + @"\cachedSites.dat");
                            continue;

                        }

                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            create create = new create();
            create.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            WebClient wc = new WebClient();
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.DocumentText = wc.DownloadString("https://pastebin.com/raw/VP5cga9X");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 0;
            listBox1.Items.Clear();
            try
            {
                WebClient wc = new WebClient();
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\cached.dat", wc.DownloadString("https://pastebin.com/raw/Ui8mFBZ7"));

                foreach (string line in File.ReadAllLines(Directory.GetCurrentDirectory() + @"\cached.dat"))
                {
                    i++;
                    content = wc.DownloadString(line);
                    File.WriteAllText(Directory.GetCurrentDirectory() + @"\cachedN" + i + ".dat", content);
                    foreach (string lin in File.ReadAllLines(Directory.GetCurrentDirectory() + @"\cachedN" + i + ".dat"))
                    {
                        
                        if (lin.Contains("<title>"))
                        {
                            var newLine = lin.Replace("<title>", "").Replace("</title>", "").Replace(" ", "");
                            title = newLine;
                            continue;
                        }

                    }
                    listBox1.Items.Add(title + ".site");

                }

            }
            catch (Exception ex)
            {
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            dateLbl.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            listBox1.Items.Clear();
            /*listBox1.Items.Clear();
          string text = textBox1.Text;
          foreach(var file in Directory.GetFiles(Directory.GetCurrentDirectory()))
          {
              string fil = Path.GetFileName(file);
              if (fil.Contains(text))
              {
                  listBox1.Items.Add(fil);
              }
          }*/
            /*WebClient wc = new WebClient();
            string content = wc.DownloadString("https://pastebin.com/raw/7dmzS4xj");
            File.WriteAllText(Directory.GetCurrentDirectory() + @"\cached.dat", content);

            foreach(string line in File.ReadAllLines(Directory.GetCurrentDirectory() + @"\cached.dat"))
            {
                if(line.Contains("<title>"))
                {
                    var newLine = line.Replace("<title>", "").Replace("</title>", "").Replace(" ", "");
                    title = newLine;
                    continue;
                }
                continue;
            }
            //MessageBox.Show(content, title);*/

            //Database = https://pastebin.com/raw/Ui8mFBZ7
            Uri url = new Uri("https://pastebin.com/raw/Ui8mFBZ7");
            WebClient wc = new WebClient();
            File.WriteAllText(Directory.GetCurrentDirectory() + @"\cached.dat", wc.DownloadString(url));
            int i = 0;
            foreach (string line in File.ReadAllLines(Directory.GetCurrentDirectory() + @"\cached.dat"))
            {
                i++;
                content = wc.DownloadString(line);
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\cachedN" + i + ".dat", content);
                foreach (string lin in File.ReadAllLines(Directory.GetCurrentDirectory() + @"\cachedN" + i + ".dat"))
                {
                    if (lin.Contains("<title>"))
                    {
                        var newLine = lin.Replace("<title>", "").Replace("</title>", "").Replace(" ", "");
                        title = newLine;
                        continue;
                    }
                }
                if (textBox1.Text.ToLower() == title.ToLower() + ".site")
                {
                    webBrowser1.DocumentText = wc.DownloadString(line);
                }
                if (title.ToLower().Contains(textBox1.Text.ToLower()))
                {
                    listBox1.Items.Add(title + ".site");
                }
            }
            //Make it so you can search

            //ebBrowser1.DocumentText = content;
            if (listBox1.Items.Count <= 0)
            {
                listBox1.Items.Add("No Results!");
            }

        }
    }
}
