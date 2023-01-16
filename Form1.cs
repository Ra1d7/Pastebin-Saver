using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace DirtyApp
{
    public partial class Form1 : Form
    {
        public static int i = 0;
        string raw;
        public static Random _rand = new Random();
        WebClient wc = new WebClient(); //create a webclient
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(string line in textBox1.Lines)
                {
                    if (line.Contains("pastebin") == true)
                    {
                        if (line.Contains("https://") == false)
                        {
                            raw = "https://" + line;
                        }
                        else
                        {
                            raw = line;
                        }
                        wc.DownloadData(raw);

                        string _raw = raw.Replace("https://", "");
                        _raw = _raw.Replace("/", "/raw/");
                        _raw = "https://" + _raw;
                        string namez = line.Replace("https://pastebin.com/", "");
                        saveFileDialog1.FileName = namez;
                        saveFileDialog1.Filter = "Text Files (.txt) | *.txt";
                        saveFileDialog1.ShowDialog();
                        File.WriteAllText(saveFileDialog1.FileName, wc.DownloadString(_raw));
                        if (File.Exists(saveFileDialog1.FileName))
                        {
                            MessageBox.Show("Saved File at:\n" + saveFileDialog1.FileName, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Could Not save file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }
                    else
                    {
                        MessageBox.Show("Are you sure this is a Pastebin Url?", "invalid site", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                
            }
            catch
            {
                MessageBox.Show("INVALID URL","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
    
}
