using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automation.BDaq;

namespace GiaoDienDATN
{
    public partial class Form3 : Form
    {
        private string _message , _message1;
        private int _mode;
        //private string _message1;
        double[] m_dataScaled;
        public delegate void UpdateUIDelegate();
        public Form3()
        {
            InitializeComponent();
            m_dataScaled = new double[1024];
        }
        public string Message //D1
        {
            get { return _message; }
            set { _message = value; }
        }
        public string Message1  //D2
        {
            get { return _message1; }
            set { _message1 = value; }
        }
        public int mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        //public Form3(string Message1) : this()
        //{
        //    _message1 = Message1;
        //    textBox2.Text = _message1;
        //}
        private void updateUI()
        {
            for (int i = 0; i < 1024; i++)
            {
                listBox1.Items.Add("channel " + (i % 3).ToString() + " data is: " + m_dataScaled[i]);
                /*
                 * if ((i + 1) % 3 == 0)
                {
                    listBox1.Items.Add("");
                }
                */
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            //float k;
            //string[] tocdo;
            //tocdo = new string[50];
            bufferedAiCtrl1.Prepare();
            //bufferedAiCtrl1.RunOnce(true);
            bufferedAiCtrl1.RunOnce();
            
            //tocdo = 
            //textBox1.Text = 
            //textBox1.Text = Convert.ToInt32(m_dataScaled[1]);
            

        }

        private void bufferedAiCtrl1_DataReady(object sender, BfdAiEventArgs e)
        {
            //bufferedAiCtrl1.GetData(0, 1024, m_dataScaled);
            bufferedAiCtrl1.GetData(1024, m_dataScaled);
            Invoke(new UpdateUIDelegate(updateUI));
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int mode;
            textBox1.Text = _message;   //D1
            textBox2.Text = _message1;  //D2
            mode = _mode;
            textBox3.Text = mode.ToString();
            
        }
        

    }
}
