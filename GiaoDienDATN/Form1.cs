using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienDATN
{
    public partial class Form1 : Form
    {
        private int _mode, _D1, _D2, _kc_a, _kc_b, _kc_c ;
        public Form1()
        {
            InitializeComponent();
        }
        public int mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        public int D1
        {
            get { return _D1; }
            set { _D1 = value; }
        }
        public int D2
        {
            get { return _D2; }
            set { _D2 = value; }
        }

        public int kc_a
        {
            get { return _kc_a; }
            set { _kc_a = value; }
        }
        public int kc_b
        {
            get { return _kc_b; }
            set { _kc_b = value; }
        }
        public int kc_c
        {
            get { return _kc_c; }
            set { _kc_c = value; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int mode, D1, D2, kc_a, kc_b, kc_c;
            mode = _mode;
            D1 = _D1;
            D2 = _D2;           
            kc_a = _kc_a;
            kc_b = _kc_b;
            kc_c = _kc_c;
            
            // truyền dữ liệu
            modef1.Text = mode.ToString();
            D1f1.Text = D1.ToString();
            D2f1.Text = D2.ToString();
            kc_af1.Text = kc_a.ToString();
            kc_bf1.Text = kc_b.ToString();
            kc_cf1.Text = kc_c.ToString();

            progressBar1.PerformStep();

        }
    }
}
