using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES_PROJECT
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void 주문관리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Order_mng od = new Order_mng();
            od.MdiParent = this;
            od.Show();
            od.WindowState = FormWindowState.Maximized;
        }

        private void 발주등록ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Material_mng mt = new Material_mng();
            mt.MdiParent = this;
            mt.Show();
            mt.WindowState = FormWindowState.Maximized;
        }

        private void 작업지시등록ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkOrder_mng wo = new WorkOrder_mng();
            wo.MdiParent = this;
            wo.Show();
            wo.WindowState = FormWindowState.Maximized;
        }
    }
}
