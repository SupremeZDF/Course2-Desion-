using FtpServer.FTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FtpServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Redis
        private void button1_Click(object sender, EventArgs e)
        {
            OneRunModel.UploadFileInFTP(@"C:\Users\27339\Desktop\1.jpg");
            //OneRunModel.UploadFileInFTP();
        }
    }
}
