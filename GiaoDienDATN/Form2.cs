using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Timers;

namespace GiaoDienDATN
{
    
    public partial class Form2 : Form
    {

        //int mode, D1, D2, kc_a, kc_b, kc_c;
        int mode; 
        double DD1;
            bool nloi1 , nloi2;
            int Dmax = 300;
           
        public Form2()
        {
            InitializeComponent();
            //int mode;
            //int dmax = 300;            
            //string[] baoloi;
            //baoloi = new string[30];
            //baoloi[1] = "số âm";
            //baoloi[2] = "vượt quá dmax";             
        }
                    
       private void button1_Click(object sender, EventArgs e)
        {       
                // đổi màu ô 1 tu trắng sang xanh
                button1.Visible = false; // ẩn
                button2.Visible = true; // hiển thị mau xanh
                // các ô còn lại giữ nguyên
        }

        private void button2_Click(object sender, EventArgs e)
        {
                //đổi màu ô 1 từ xanh sang trắng
                button1.Visible = true; 
                button2.Visible = false; 
                //các ô còn lại màu xanh
                button3.Visible = false;
                button4.Visible = true;

                button5.Visible = false;
                button6.Visible = true;

                button7.Visible = false;
                button8.Visible = true;

                button9.Visible = false;
                button10.Visible = true;

                button11.Visible = false;
                button12.Visible = true;

                button13.Visible = false;
                button14.Visible = true;

                button15.Visible = false;
                button16.Visible = true;

                button17.Visible = false;
                button18.Visible = true;
            // hien thi hinh 1
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
            //
                D1.Location = new Point(412, 185);
                D2.Location = new Point(539, 185);
                ToL1.Location = new Point(406, 318);
                Tol2.Location = new Point(517, 318);
                kc_a.Location = new Point(274, 389);
                kc_b.Location = new Point(465, 389);
                kc_c.Location = new Point(668, 389);

                // ẩn hiện
                D.Visible = false;
                D1.Visible = true;
                D2.Visible = true;
                Tol.Visible = false;
                ToL1.Visible = true;
                Tol2.Visible = true;
                kc_c.Visible = true;
                // cân bằng 2 mặt (B| |A)
                mode = 1;
        }
           
        private void button3_Click(object sender, EventArgs e)
        {
                //đổi màu ô 2
                button3.Visible = false; // ẩn
                button4.Visible = true; // hiển thị mau xanh
                // các ô còn lại giữ nguyên
                                 
        }

        private void button4_Click(object sender, EventArgs e)
        {
                //đổi màu ô 2
                button3.Visible = true; 
                button4.Visible = false; 
                //các ô còn lại màu xanh
                button1.Visible = false;
                button2.Visible = true;

                button5.Visible = false;
                button6.Visible = true;

                button7.Visible = false;
                button8.Visible = true;

                button9.Visible = false;
                button10.Visible = true;

                button11.Visible = false;
                button12.Visible = true;

                button13.Visible = false;
                button14.Visible = true;

                button15.Visible = false;
                button16.Visible = true;

                button17.Visible = false;
                button18.Visible = true;
                // hien thi hinh 2
                pictureBox2.Visible = true;
                pictureBox1.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
            //
                D1.Location = new Point(274, 185);
                D2.Location = new Point(668, 185);
                ToL1.Location = new Point(406, 318);
                Tol2.Location = new Point(517, 318);
                kc_a.Location = new Point(274, 389);
                kc_b.Location = new Point(465, 389);
                kc_c.Location = new Point(668, 389);
                // ẩn hiện
                D.Visible = false;
                D1.Visible = true;
                D2.Visible = true;
                Tol.Visible = false;
                ToL1.Visible = true;
                Tol2.Visible = true;
                kc_c.Visible = true;
            //   |B A|
                mode = 2;


                            
        }

        private void button5_Click(object sender, EventArgs e)
        {
                //đổi màu ô 3
                button5.Visible = false; // ẩn
                button6.Visible = true; // hiển thị mau xanh
                // các ô còn lại giữ nguyên
                
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //đổi màu ô 3
            button5.Visible = true; 
            button6.Visible = false; 
            //các ô còn lại màu xanh
            button1.Visible = false;
            button2.Visible = true;

            button3.Visible = false;
            button4.Visible = true;

            button7.Visible = false;
            button8.Visible = true;

            button9.Visible = false;
            button10.Visible = true;

            button11.Visible = false;
            button12.Visible = true;

            button13.Visible = false;
            button14.Visible = true;

            button15.Visible = false;
            button16.Visible = true;

            button17.Visible = false;
            button18.Visible = true;

            // hien thi hinh 3
            pictureBox3.Visible = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            //
            D1.Location = new Point(274, 195);
            D2.Location = new Point(591, 195);
            ToL1.Location = new Point(257, 304);
            Tol2.Location = new Point(592, 304);
            kc_a.Location = new Point(274, 403);
            kc_b.Location = new Point(428, 403);
            kc_c.Location = new Point(614, 403);
            // ẩn hiện
            D.Visible = false;
            D1.Visible = true;
            D2.Visible = true;
            Tol.Visible = false;
            ToL1.Visible = true;
            Tol2.Visible = true;
            kc_c.Visible = true;
            //  |B |A
            mode = 3;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //đổi màu ô 4
            button7.Visible = false; // ẩn
            button8.Visible = true; // hiển thị mau xanh
            // các ô còn lại giữ nguyên
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //đổi màu ô 4
            button7.Visible = true; 
            button8.Visible = false; 
            //các ô còn lại màu xanh
            button1.Visible = false;
            button2.Visible = true;

            button3.Visible = false;
            button4.Visible = true;

            button5.Visible = false;
            button6.Visible = true;

            button9.Visible = false;
            button10.Visible = true;

            button11.Visible = false;
            button12.Visible = true;

            button13.Visible = false;
            button14.Visible = true;

            button15.Visible = false;
            button16.Visible = true;

            button17.Visible = false;
            button18.Visible = true;

            // hien thi hinh 4
            pictureBox4.Visible = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            //
            D1.Location = new Point(327, 195);
            D2.Location = new Point(680, 195);
            ToL1.Location = new Point(298, 304);
            Tol2.Location = new Point(658, 304);
            kc_a.Location = new Point(318, 403);
            kc_b.Location = new Point(489, 403);
            kc_c.Location = new Point(668, 403);
            // ẩn hiện
            D.Visible = false;
            D1.Visible = true;
            D2.Visible = true;
            Tol.Visible = false;
            ToL1.Visible = true;
            Tol2.Visible = true;
            kc_c.Visible = true;
            // B| A|
            mode = 4;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //đổi màu ô 5
            button9.Visible = false; // ẩn
            button10.Visible = true; // hiển thị mau xanh
            // các ô còn lại giữ nguyên
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //đổi màu ô 5
            button9.Visible = true; 
            button10.Visible = false; 
            //các ô còn lại màu xanh
            button1.Visible = false;
            button2.Visible = true;

            button3.Visible = false;
            button4.Visible = true;

            button5.Visible = false;
            button6.Visible = true;

            button7.Visible = false;
            button8.Visible = true;

            button11.Visible = false;
            button12.Visible = true;

            button13.Visible = false;
            button14.Visible = true;

            button15.Visible = false;
            button16.Visible = true;

            button17.Visible = false;
            button18.Visible = true;

            // hien thi hinh 5
            pictureBox5.Visible = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            //
            D1.Location = new Point(269, 195);
            D2.Location = new Point(428, 195);
            ToL1.Location = new Point(269, 304);
            Tol2.Location = new Point(520, 304);
            kc_a.Location = new Point(284, 403);
            kc_b.Location = new Point(402, 403);
            kc_c.Location = new Point(578, 403);
            // ẩn hiện
            D.Visible = false;
            D1.Visible = true;
            D2.Visible = true;
            Tol.Visible = false;
            ToL1.Visible = true;
            Tol2.Visible = true;
            kc_c.Visible = true;
            // || BA
            mode = 5;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //đổi màu ô 6
            button11.Visible = false; // ẩn
            button12.Visible = true; // hiển thị mau xanh
            // các ô còn lại giữ nguyên
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //đổi màu ô 6
            button11.Visible = true; 
            button12.Visible = false; 
            //các ô còn lại màu xanh
            button1.Visible = false;
            button2.Visible = true;

            button3.Visible = false;
            button4.Visible = true;

            button5.Visible = false;
            button6.Visible = true;

            button7.Visible = false;
            button8.Visible = true;

            button9.Visible = false;
            button10.Visible = true;

            button13.Visible = false;
            button14.Visible = true;

            button15.Visible = false;
            button16.Visible = true;

            button17.Visible = false;
            button18.Visible = true;

            // hien thi hinh 6
            pictureBox6.Visible = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            //
            D1.Location = new Point(502, 195);
            D2.Location = new Point(679, 195);
            ToL1.Location = new Point(406, 304);
            Tol2.Location = new Point(657, 304);
            kc_a.Location = new Point(383, 393);
            kc_b.Location = new Point(532, 393);
            kc_c.Location = new Point(657, 393);
            // ẩn hiện
            D.Visible = false;
            D1.Visible = true;
            D2.Visible = true;
            Tol.Visible = false;
            ToL1.Visible = true;
            Tol2.Visible = true;
            kc_c.Visible = true;
            //  BA ||
            mode = 6;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //đổi màu ô 7
            button13.Visible = false; // ẩn
            button14.Visible = true; // hiển thị mau xanh
            // các ô còn lại giữ nguyên
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //đổi màu ô 7
            button13.Visible = true; 
            button14.Visible = false; 
            //các ô còn lại màu xanh
            button1.Visible = false;
            button2.Visible = true;

            button3.Visible = false;
            button4.Visible = true;

            button5.Visible = false;
            button6.Visible = true;

            button7.Visible = false;
            button8.Visible = true;

            button9.Visible = false;
            button10.Visible = true;

            button11.Visible = false;
            button12.Visible = true;

            button15.Visible = false;
            button16.Visible = true;

            button17.Visible = false;
            button18.Visible = true;

            // hiển thi hinh 7
            pictureBox7.Visible = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            //
            D1.Location = new Point(275, 195);
            Tol.Location = new Point(327, 304);
            //D1.Location = new Point(505, 200);
            //D2.Location = new Point(666, 200);
            //ToL1.Location = new Point(754, 328);
            //Tol2.Location = new Point(866, 328);
            kc_a.Location = new Point(223, 443);
            kc_b.Location = new Point(452, 377);
            //khoang_cach_c.Location = new Point(824, 419);
            // ẩn hiện
            D.Visible = false;
            D1.Visible = true;
            D2.Visible = false;
            Tol.Visible = true;
            ToL1.Visible = false;
            Tol2.Visible = false;
            kc_c.Visible = false;
            //mode 7 D2 & khoảng cách c = 0
            D2.Text = "0";
            kc_c.Text = "0";
            //cân bằng 1 mặt  | BA
            mode = 7;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //đổi màu ô 8
            button15.Visible = false; // ẩn
            button16.Visible = true; // hiển thị mau xanh
            // các ô còn lại giữ nguyên
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //đổi màu ô 8
            button15.Visible = true; 
            button16.Visible = false; 
            //các ô còn lại màu xanh
            button1.Visible = false;
            button2.Visible = true;

            button3.Visible = false;
            button4.Visible = true;

            button5.Visible = false;
            button6.Visible = true;

            button7.Visible = false;
            button8.Visible = true;

            button9.Visible = false;
            button10.Visible = true;

            button11.Visible = false;
            button12.Visible = true;

            button13.Visible = false;
            button14.Visible = true;

            button17.Visible = false;
            button18.Visible = true;

            // hien thi hinh 8
            pictureBox8.Visible = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            //
            D1.Location = new Point(348, 187);
            Tol.Location = new Point(327, 294);
            kc_a.Location = new Point(335, 393);
            kc_b.Location = new Point(540, 393);

            // ẩn hiện
            D.Visible = false;
            D1.Visible = true;
            D2.Visible = false;
            Tol.Visible = true;
            ToL1.Visible = false;
            Tol2.Visible = false;
            kc_c.Visible = false;
            //mode 8 D2 & khoảng cách c = 0
            D2.Text = "0";
            kc_c.Text = "0";
            // B|A
            mode = 8;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //đổi màu ô 9
            button17.Visible = false; // ẩn
            button18.Visible = true; // hiển thị mau xanh
            // các ô còn lại giữ nguyên
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //đổi màu ô 9
            button17.Visible = true; 
            button18.Visible = false; 
            //các ô còn lại màu xanh
            button1.Visible = false;
            button2.Visible = true;

            button3.Visible = false;
            button4.Visible = true;

            button5.Visible = false;
            button6.Visible = true;

            button7.Visible = false;
            button8.Visible = true;

            button9.Visible = false;
            button10.Visible = true;

            button11.Visible = false;
            button12.Visible = true;

            button13.Visible = false;
            button14.Visible = true;

            button15.Visible = false;
            button16.Visible = true;

            // hien thi hinh 9
            pictureBox9.Visible = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox10.Visible = false;
            //
            D1.Location = new Point(695, 176);
            Tol.Location = new Point(565, 294);
            kc_a.Location = new Point(425, 384);
            kc_b.Location = new Point(695, 375);

            // ẩn hiện
            D.Visible = false;
            D1.Visible = true;
            D2.Visible = false;
            Tol.Visible = true;
            ToL1.Visible = false;
            Tol2.Visible = false;
            kc_c.Visible = false;
            //mode 9 D2 & khoảng cách c = 0
            D2.Text = "0";
            kc_c.Text = "0";
            // cân bằng 1 mặt  BA |
            mode = 9;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        
        int z;
        private void timer1_Tick(object sender, EventArgs e)
        {
            z++;
            label1.Text = z.ToString();
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //int mode;
            //kiểm tra mode a b c 
            //if((mode > 0) & (mode < 10))

            //đóng form 2
            //Form2 f2 = new Form2();
            //f2.ShowDialog();
            
            //mở form 3
            Form3 dlg3 = new Form3();
            dlg3.Message = D1.Text;
            dlg3.Message1 = D2.Text;
            dlg3.mode = mode;
            dlg3.ShowDialog();
            //
            
            //this.Close();
            
        }

   
        private void D1_TextChanged(object sender, EventArgs e)
        {
            string[] baoloi;
            baoloi = new string[30];
            baoloi[1] = "Số 0, Nhập lại";
            baoloi[2] = "Vượt quá Dmax";
            //DD1 = int.Parse(D1.Text);
            //DD1 = Convert.ToInt32(D1.Text);
            DD1 = double.Parse(D1.Text);
            if (DD1 == 0 ) 
            {
                truyen.Text = baoloi[1];
                nloi1 = true;
                //MessageBox.Show("Nhót", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (DD1 > Dmax)
            {
                truyen.Text = baoloi[2];
                nloi2 = true;
            }
            if((DD1 > 0) & (DD1 < Dmax))
            {
                DD1 = Convert.ToInt32(D1.Text);
            }
            //else
            //{
            //    truyen.Text = "Nhập lại";
            //}
        }


        int d11, d22, kc_aa, kc_bb, kc_cc;
        
        private void button20_Click(object sender, EventArgs e)
        {
            //lấy dữ liệu
            d11 = Convert.ToInt32(D1.Text);
            d22 = Convert.ToInt32(D2.Text);
            kc_aa = Convert.ToInt32(kc_a.Text);
            kc_bb = Convert.ToInt32(kc_b.Text);
            kc_cc = Convert.ToInt32(kc_c.Text);
            
         // mở form 1 và truyền dữ liệu
            Form1 dlg1 = new Form1();
            dlg1.mode = mode;
            dlg1.D1 = d11;
            dlg1.D2 = d22;
            dlg1.kc_a = kc_aa;
            dlg1.kc_b = kc_bb;
            dlg1.kc_c = kc_cc;      
            // show form 1                
            dlg1.ShowDialog();
            
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //lấy dữ liệu
            d11 = Convert.ToInt32(D1.Text);
            d22 = Convert.ToInt32(D2.Text);
            kc_aa = Convert.ToInt32(kc_a.Text);
            kc_bb = Convert.ToInt32(kc_b.Text);
            kc_cc = Convert.ToInt32(kc_c.Text);
            // mở form 4 và truyền dữ liệu
            Form4 dlg4 = new Form4();
            dlg4.modetam = mode;
            dlg4.D1 = d11;
            dlg4.D2 = d22;
            dlg4.kc_a = kc_aa;
            dlg4.kc_b = kc_bb;
            dlg4.kc_c = kc_cc;
            // show form 4
            dlg4.ShowDialog();
        }
                
    }
}
