using CLRCore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLRCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 4、什么时候 执行垃圾回收 GC
        // a) new() 对象时-临界点（） （内存不够 垃圾回收 new 创建对象）
        // b) GC.Collect() 强制执行 内存溢出
        // c) 程序退出时会 GC
        private void button1_Click(object sender, EventArgs e)
        {
            //垃圾回收时 会优先回收 0 代 提升效率 最多也容易释放
            //TwoModel twoModel = new TwoModel();
            //twoModel = null;
            //GC.Collect();
            TwoModel.IOneRun();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TwoModel.ITwoRun();
        }
    }
}
