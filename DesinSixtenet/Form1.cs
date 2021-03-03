using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesinSixtenet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var c = AA.bb;
            c.Age = 12;
            c.Name = "hah1";
            var dd = AA.bb;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class AA
    {
        public static AA bb = new AA() { Name = "123", Age = 123 };

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
