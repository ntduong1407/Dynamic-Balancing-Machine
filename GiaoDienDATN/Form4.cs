using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Automation.BDaq;


namespace GiaoDienDATN
{
    public partial class Form4 : Form
    {
        double[] Z1;       //  tín hiệu ssA 
        double[] Z2;       // tín hiệu ssB
        double[] Z3;       // tín hiệu Pha
        //khai báo biến lực
        double[] Luc1;
        double[] Luc2;
        //double[] Luc3;

                   
        /////////////////////////////////////////////////
        private int _mode, _D1, _D2, _kc_a, _kc_b, _kc_c;
        
        /////////////////////////////////////////////////
        double[] AAy1a;
        double[] AAy2a;
        //khai báo tín hiệu từ cảm biến chung
        double[] bien_chuyen;
        ////khai báo tín hiệu từ cảm biến
        double[] Ay1;
        double[] Ay2;
        double[] Apha;
        //khai hàm update dữ liệu từ cảm biến
        public delegate void UpdateUIDelegate();
        ////khai báo biến chứa tín hiệu từ cảm biến
        double[] y111;
        double[] y222;
        int[] AphaMotor;
        //thu nghiem
        double[] Ayz;
       
        //
        string filePath = Directory.GetCurrentDirectory() + @"\data.txt";
        string filehc = Directory.GetCurrentDirectory() + @"\hieu_chinh.txt";
        string fileghi = Directory.GetCurrentDirectory() + @"\ghi.txt";
        //khai báo các thông số hiệu chỉnh
        double hc_bien_doA, hc_bien_doB;
        double hc_phaA, hc_phaB;
        int so_mode,n;
        int[] y = null;
        double[] hc = null;
        double a1 = 3;
        double a2 = 1.5;
        double delta = 1 / 10000;
        double omega = 2 * 3.14159 / 242;
        double phiPha = 3.14159 / 6;
        int nMau = 0;
        int nMauth = 3072;
        int detectPhaMotor = 0;
        int xungThu1 = 0;
        int xungThu2 = 0;
        int baNphamotor ;
        Point[] line1 = new Point[2];
        Point[] line2 = new Point[2];
        //
        

        private void Doc_hieu_chinh()
        {
            StreamReader streamReader1 = new StreamReader(filehc);
            string data1 = streamReader1.ReadLine();
            try
            {
                n = Convert.ToInt16(data1);
                so_mode = n / 5;
                hc = new double[n];
            }
             catch { }
             for (int i11 = 0; i11 < n; i11++)
             {
                 data1 = streamReader1.ReadLine();
                 try
                 {
                     hc[i11] = Convert.ToDouble(data1);
                    
                 }
                 catch { }
             }
             streamReader1.Close();

        }

        private void Ghi_Data_Txt()
        {
            StreamWriter streamWriter = new StreamWriter(fileghi);
            baNphamotor = 3 * N_Phamotorr;
            streamWriter.WriteLine(baNphamotor.ToString());

            for (int i = Xung_thu_1; i < (baNphamotor + Xung_thu_1); i++)
            {
                streamWriter.WriteLine(AAy1a[i].ToString());
            }



        }

        private void Doc_Data_Txt()

        {
            StreamReader streamReader = new StreamReader(filePath);
            string data = streamReader.ReadLine();
            try
            {
                nMau = Convert.ToInt16(data);
                y = new int[nMau];
            }
            catch { }
            for (int i = 0; i < nMau; i++)
            {
                data = streamReader.ReadLine();
                try
                {
                    y[i] = Convert.ToInt16(data) * 10;
                }
                catch { }
            }
            streamReader.Close();
        }
        //

        
        public Form4()
        {
            InitializeComponent();
            Doc_hieu_chinh();
            Doc_Data_Txt();
            //bien chuyeenr chung
            bien_chuyen = new double[nMauth];
            ////khai báo tín hiệu từ cảm biến
            Ay1 = new double[nMauth];
            Ay2 = new double[nMauth];
            Apha = new double[nMauth];
            ////khai báo biến chứa tín hiệu từ cảm biến
            y111 = new double[nMau];
            y222 = new double[nMau];
            AphaMotor = new int[nMau];

            //
            double[] y1 = new double[nMau];
            double[] y2 = new double[nMau];
            //
           
            //
            timer1.Enabled = false;
            timer2.Enabled = false;
        }
        /////////////////////////////////////////////////
        public int modetam
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
        /////////////////////////////////////////////////
        int bien_mo_phong = 0;
        int N_Phamotorr;
        //
         int detectPhamotorr = 0;
                    
                    int Xung_thu_1 = 0;
                    int Xung_thu_2 = 1;
                    int Xung_thu_3 = 1;
                    int Xung_thu_4 = 1;
        //
        double G = 1;     

        private void button1_Click(object sender, EventArgs e)
        {
            //bat dau button1
            //double phi0 = 4 * 3.1459 / 242 + 2.69;

            //N_Phamotorr = 300;
            ///////////////////////////////////


            //Xung_thu_1 = 0;
            //Xung_thu_2 = 1;
            ////////////////////////////////////
            //int N_Phamotorr;
            //N_Phamotorr = 1;
            //khai báo tín hiệu mô phỏng từ data.txt
            double[] y1 = new double[nMau];
            double[] y2 = new double[nMau];
            double[] y3 = new double[nMau];
            //khai báo furier
            double[] yy1 = new double[nMau];
            double[] yy2 = new double[nMau];
            //             
            int[] phaMotor = new int[nMau];
            if (bien_mo_phong == 1)
            {
                //bat dau mophong tin hieu dau vao                           
            }
            else
            {
                ////

                button2.PerformClick();
                // biến mô phỏng vẽ đồ thị bằng 0 => vẽ truc tiep
                int mo_phong_ve_do_thi;
                mo_phong_ve_do_thi = 0;

                if (mo_phong_ve_do_thi == 1)
                {
                    // mophong ve do thi
                }
                else
                // mo_phong_ve_do_thi = 0 khong ve do thi mophong ma ve do thi tin hieu thuc
                {
                    //vẽ tín hiệu thực
                    // lấy tín hiệu từ card
                    for (int j10 = 0; j10 < nMau; j10++)
                    {
                        bufferedAiCtrl1.Prepare();
                        bufferedAiCtrl1.RunOnce(true);   // chạy 1 lần
                    }
                    //hệ số giữa lực và điện áp ( lực = G * điện_áp)
                    double G = 1;
                    //
                    Luc1 = new double[nMauth];
                    Luc2 = new double[nMauth];
                    //
                    Z1 = new double[nMauth];
                    Z2 = new double[nMauth];
                    Z3 = new double[nMauth];
                    //
                    for (int j12 = 0; j12 < nMauth; j12++)
                    {

                        if (j12 % 3 == 0)
                        {
                            Z1[j12] = Ay1[j12];
                            chart1.Series[0].Points.AddXY(j12, Ay1[j12]);

                        }
                        if (j12 % 3 == 1)
                        {
                            Z2[j12] = Ay2[j12];
                            chart1.Series[1].Points.AddXY(j12, Ay2[j12]);
                        }
                        if (j12 % 3 == 2)
                        {
                            Z3[j12] = Apha[j12];

                            chart1.Series[2].Points.AddXY(j12, 0.4 * Apha[j12]);
                        }
                    }

                    //////////////////////////////

                    //fourier
                    double suma = 0;
                    double trungbinh = 0;
                    //Xac định chu kỳ của tín hiệu
                    //tính max cua Apha
                    double sum1 = 0;
                    double sum2 = 0;
                    double sum3 = 0;
                    double Amax = -10;
                    double Amin = 10;
                    sum1 = Amin;
                    sum2 = Amax;
                    double ksum1 = 0;
                    double ksum2 = 0;
                    // khai baos mang tín hiệu liên tục
                    double[] Apha1;
                    //double[] AAy1a;
                    //double[] AAy2a;
                    Apha1 = new double[nMau];

                    ///////////tinh trung binh tin hieu
                    for (int f = 1; f < nMau; f++)
                    {
                        suma = suma + Ay1[f];

                    }
                    trungbinh = suma / nMau;
                    ee.Text = trungbinh.ToString();
                    ////
                    for (int j14 = 0; j14 < nMau; j14++)
                    {
                        Apha1[j14] = Apha[(3 * j14 + 2)];

                    }
                    for (int j3 = 1; j3 < nMau; j3++)
                    {

                        // tìm Max tin hieu pha
                        if (Apha1[j3] > sum1)
                        {
                            sum1 = Apha1[j3];
                        }
                        //sum1 chứa Maximun tin hieu pha
                        //Tim Min tin hieu pha

                        if (Apha1[j3] < sum2)
                        {
                            sum2 = Apha1[j3];
                        }

                        //sum2 chứa Minnimun cua tin hieu pha
                    }
                    ksum1 = sum1;
                    ksum2 = sum2;
                    Amax = -10;
                    Amin = 10;
                    // Tìm giá trị trung bình cua tin hieu pha
                    sum3 = (sum1 + sum2) / 2;
                    label22.Text = sum1.ToString();
                    label23.Text = sum2.ToString();




                    //sường lên cua tin hieu pha vector suong_len[nMau] chua hoac 1- 'co suon len' hoac 0 - khong co suon len
                    int[] suong_len;
                    suong_len = new int[nMau];
                    suong_len[0] = 0;

                    for (int j4 = 1; j4 < nMau; j4++)
                    {
                        if ((Apha1[j4] > sum3) & (Apha1[j4 - 1] < sum3))
                        {
                            suong_len[j4] = 1;
                        }
                        else
                        {
                            suong_len[j4] = 0;
                        }

                    }
                    //sường lên tại các điểm bằng 1
                    //tính chu kỳ cho FT
                    //tìm xung thứ 1 và 2
                    //int detectPhamotorr;
                    detectPhamotorr = 0;
                    for (int j5 = 0; j5 < nMau; j5++)
                    {

                        ////////////////////////////////
                        if (detectPhamotorr == 0)
                        {
                            if (suong_len[j5] == 1)
                            {
                                Xung_thu_1 = j5 + 1;
                                detectPhamotorr = 1;
                            }
                        }
                        else if (detectPhamotorr == 1)
                        {
                            if (suong_len[j5] == 1)
                            {
                                Xung_thu_2 = j5 + 1;
                                detectPhamotorr = 2;
                            }
                        }
                        ////////////
                        else if (detectPhamotorr == 2)
                        {
                            if (suong_len[j5] == 1)
                            {
                                Xung_thu_3 = j5 + 1;
                                detectPhamotorr = 3;
                            }
                        }
                        //////////////////////
                        else if (detectPhamotorr == 3)
                        {
                            if (suong_len[j5] == 1)
                            {
                                Xung_thu_4 = j5 + 1;
                                detectPhamotorr = 4;
                            }
                        }
                    }
                    //// tính chu kỳ N_Phamotor la chu ky cua tin hieu do bang so chu ky lay mau
                    for (int i = 0; i < nMau; i++)
                    {
                        listBox6.Items.Add("Apha1" + " " + i + " là: " + suong_len[i] + "  " + Apha1[i]);

                    }
                    label19.Text = Xung_thu_1.ToString();
                    label20.Text = Xung_thu_2.ToString();
                    label21.Text = sum3.ToString();
                    N_Phamotorr = Xung_thu_2 - Xung_thu_1;
                    label16.Text = N_Phamotorr.ToString();

                    //in ra báo lỗi nếu 3*N_Phamotorr > 1024
                    if ((3 * N_Phamotorr) > nMau)
                    {
                        label16.Text = "lỗi chu kỳ quá lớn";

                    }
                    label16.Text = N_Phamotorr.ToString();
                    /////////////////////////////////////////
                }
                //// các bước vẽ furier tin1 hieu thuc
                //khai bao biến furier cho tín hiệu thực
                //double[] AAy1a;
                //double[] AAy2a;
                AAy1a = new double[nMau];
                AAy2a = new double[nMau];


                //double[] AAy1a = new double[nMau];
                //double[] AAy2a = new double[nMau];
                ////
                for (int j14 = 0; j14 < nMau; j14++)
                {

                    AAy1a[j14] = Ay1[3 * j14];
                    AAy2a[j14] = Ay2[3 * j14 + 1];
                }
                double[] AAy1 = new double[nMau];
                double[] AAy2 = new double[nMau];
                ////khai báo tổng  khi bien doi furier tin hieu thuc = 0
                double aaSum1 = 0;
                double aaSum2 = 0;
                double bbSum1 = 0;
                double bbSum2 = 0;
                //khai bao int N_PhaMotor = 0, r1 ban kinh dau A, r2 ban kinh dau B;
                int r1 = Convert.ToInt32(R1_textBox.Text),
                r2 = Convert.ToInt32(R2_textBox.Text);
                // r1 va r2 lay tu cua so hien thi so r1, r2
                double omegaNN = Convert.ToInt32(RPM_textBox.Text) * 2 * Math.PI / 60;
                // omegaNN lay tu van toc vong khai bao vong quay truoc khi cho may can bang quay
                // bienDo11, bienDo22 luc mat can bang ban dau cho bang zero
                double bienDo11 = 0;               // tính bằng lực (N), điện áp (V)vì //hệ số giữa lực và điện áp ( lực = G * điện_áp)
                double bienDo22 = 0;
                double pha11 = 0;                  // tính bằng độ / gradient
                double pha22 = 0;
                double luongMatCanBang11 = 0;      // tính bằng gam
                double luongMatCanBang22 = 0;
                ////tính tổng cho chuỗi Furier từ xung thứ 1 đến xung thứ 3
                // tìm omegaa
                //hệ số tỉ lệ W
                double W = 300;
                // omegaa van toc vong cua tin hieu tinh tu N_Phamotor van toc nay phai gan bang (==) omegaNN
                double omegaa;
                //omegaa = 6;
                omegaa = 2 * Math.PI / N_Phamotorr;
                //omegaa = 2 * 3.14159 / 300;
                //TICH PHAN trong 1 chu ky => thu tich phan trong 3 chu ky
                //N_max =3*N_Phamotorr
                //int N_max;
                //N_max= 3 * N_Phamotorr;
                // neu N_max >1024 thi bao loi
                //for (int j6 = 0; j6 <= N_Phamotorr; j6++)
                for (int j6 = Xung_thu_1; j6 <= (3 * N_Phamotorr + Xung_thu_1); j6++)
                {
                    aaSum1 = aaSum1 + AAy1a[j6] * Math.Cos(omegaa * (j6 - Xung_thu_1)) * W;
                    bbSum1 = bbSum1 + AAy1a[j6] * Math.Sin(omegaa * (j6 - Xung_thu_1)) * W;
                    aaSum2 = aaSum2 + AAy2a[j6] * Math.Cos(omegaa * (j6 - Xung_thu_1)) * W;
                    bbSum2 = bbSum2 + AAy2a[j6] * Math.Sin(omegaa * (j6 - Xung_thu_1)) * W;
                    //////////////

                }
                //hien thi tạm N_phamotorr
                //label10.Text = N_Phamotorr.ToString();

                //N_PhaMotor = xungThu2 - xungThu1; 
                //N_max =3* N_Phamotorr
                //tính tổng của chuỗi Furier
                aaSum1 = (2 * aaSum1) / (3 * N_Phamotorr * W);
                bbSum1 = (2 * bbSum1) / (3 * N_Phamotorr * W);
                aaSum2 = (2 * aaSum2) / (3 * N_Phamotorr * W);
                bbSum2 = (2 * bbSum2) / (3 * N_Phamotorr * W);
                label24.Text = aaSum1.ToString();
                label25.Text = bbSum1.ToString();

                ////////////////////////////////////////
                //Tinh he so anh huong
                //hesoabc11 (tác động của lực mất cân bằng đầu A lên gối tưạ đầu A)
                //hesoabc12 (tác động của lực mất cân bằng đầu A lên gối tưạ đầu B)
                //hesoabc21 (tác động của lực mất cân bằng đầu B lên gối tưạ đầu A)
                //hesoabc22 (tác động của lực mất cân bằng đầu A lên gối tưạ đầu A)

                //hesoabcnghichdao11 (tác động của lực trên gối tưạ đầu A lên lực mất cân bằng đầu A)
                //hesoabcnghichdao12 (tác động của lực trên gối tưạ đầu A lên lực mất cân bằng đầu B)
                //hesoabcnghichdao21 (tác động của lực trên gối tưạ đầu B lên lực mất cân bằng đầu A)
                //hesoabcnghichdao22 (tác động của lực trên gối tưạ đầu B lên lực mất cân bằng đầu B)
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                //double La = 1, Lb = 1, Lc = 1, L = La + Lb + Lc;
                // determiant = (La*Lc)/(L*L) - ((La+Lb)*(Lb+Lc)/(L*L))
                double determiant;
                double afA = aaSum1, afB = aaSum2, bfA = bbSum1, bfB = bbSum2;
                double aFa = 0, aFb = 0, bFa = 0, bFb = 0;
                double La = 1, Lb = 1, Lc = 1, L = La + Lb + Lc, Lmay = 15;
                double bdA, bdB;
                double phaAA, phaBB;
                //double bdhcA, bdhcB;

                ////////mode1 a b c = ?
                //Fa lực mất cân bằng ở đầu A
                //Fb lực mất cân bằng ở đầu B
                //fa lực đo ở gối tựa A
                //fb lực đo ở gối tựa B
                //hesoabc1_11 = (a+b+c)/(a+b)  ; Fa = fa*hesoabc1_11
                //hesoabc1_12 = (a+b+c)/(a)    ; Fb = fa*hesoabc1_12
                //hesoabc1_21 = (a+b+c)/(c)    ; Fa = fb*hesoabc1_21
                //hesoabc1_22 = (a+b+c)/(b+c)  ; Fb = fb*hesoabc1_22  

                // thông báo lỗi 1: "La < 0"
                // thông báo lỗi 2: "Lb < 1mm hoặc Lb > 0.8*Lmay"
                // thông báo lỗi 3: "Lc < 0"
                // thông báo lỗi 4: "L < 0 hoặc L > Lmay"
                string Loi1 = "La <= 0";
                string Loi2 = "Lb < 1mm hoặc Lb > 0.8*Lmay";
                string Loi3 = "Lc <= 0";
                string Loi4 = "L <= 0 hoặc L > Lmay";
                string Loi5 = "determiant = 0";
                string Loi6 = "Lmay < (Lb + Lc)";
                string Loi7 = "Lb < 1mm hoặc Lb > Lmay";
                string Loi8 = "L <= 0";
                string Loi9 = "Lb < 1mm";
                string Loi10 = "Lmay < (La + Lb) ";
                string Loi11 = "L <= 0 hoặc L > Lmay";
                string Loi12 = "Lmay < Lc";
                //string Loi13 = "L13";


                int mode = 1;
                if (mode == 1)
                {
                    //Lấy hiệu chỉnh biên độ và pha

                    La = kc_a; Lb = kc_b; Lc = kc_c;
                    L = La + Lb + Lc;
                    textBox1.Text = La.ToString();
                    textBox2.Text = Lb.ToString();
                    textBox3.Text = Lc.ToString();

                    //La = 10; Lb = 200; Lc = 10; L = La + Lb + Lc;
                    //kiem tra lai La > zero, Lb > 1mm & Lb < 0.8*chiều dài của máy ,Lc > Zero, L>0 & L<chiều dài của máy
                    //nếu không đạt yêu cầu in ra báo lỗi dữ liệu
                    if (La <= 0)
                    {
                        Hien_Thi_loi.Text = Loi1;
                    }
                    if (Lb < 0.001)
                    {
                        Hien_Thi_loi.Text = Loi2;
                    }
                    if (Lb > (0.8 * Lmay))
                    {
                        Hien_Thi_loi.Text = Loi2;
                    }
                    if (Lc <= 0)
                    {
                        Hien_Thi_loi.Text = Loi3;
                    }
                    if (L <= 0)
                    {
                        Hien_Thi_loi.Text = Loi4;
                    }
                    if (L > Lmay)
                    {
                        Hien_Thi_loi.Text = Loi4;
                    }
                    determiant = (-La * Lc) / (L * L) + ((La + Lb) * (Lb + Lc) / (L * L));
                    //determiant phải khác Zero
                    if (determiant == 0)
                    {
                        Hien_Thi_loi.Text = Loi5;
                    }
                    //
                    aFa = (-afA * (Lb + Lc) / L + afB * La / L) / determiant;             // = aaSum1
                    aFb = ((La + Lb) * (-afB) / L + Lc * afA / L) / determiant;           // = aaSum2
                    bFa = (-bfA * (Lb + Lc) / L + bfB * La / L) / determiant;             // = bbSum1
                    bFb = ((La + Lb) * (-bfB) / L + Lc * bfA / L) / determiant;           // = bbSum2
                    //aFa = afA;
                    //bFa = bfA;
                    //aFb = afB;
                    //bFb = bfB;
                    //lấy hiệu chỉnh biên độ và hiệu chỉnh pha từ file hieu_chinh
                    Doc_hieu_chinh();
                    for (int i13 = 0; i13 < n; i13++)
                    {
                        if ((i13 % 5 == 1) & (i13 - 1 == 0))
                        {
                            hc_bien_doA = hc[i13];
                            label12.Text = hc_bien_doA.ToString();
                        }
                        if ((i13 % 5 == 2) & (i13 - 2 == 0))
                        {
                            hc_phaA = hc[i13];
                            label13.Text = hc_phaA.ToString();
                        }
                        if ((i13 % 5 == 3) & (i13 - 3 == 0))
                        {
                            hc_bien_doB = hc[i13];
                            label18.Text = hc_bien_doB.ToString();
                        }
                        if ((i13 % 5 == 4) & (i13 - 4 == 0))
                        {
                            hc_phaB = hc[i13];
                            label17.Text = hc_phaB.ToString();
                        }
                    }
                }

                ///////////////////////////////
                //biên độ hiệu chỉnh = bdA*hc_bien_do
                //pha hieu chinh = phaAA * hc_pha
                //hc_bien_do , hc_pha lấy từ tệp tin
                // lấy module
                //lấy biên độ đầu A = bdA = sqrt(aFa*aFa + bFa*bFa)
                bdA = Math.Sqrt(aFa * aFa + bFa * bFa);
                //phaAA = Math.Atan2(aFa, bFa);
                phaAA = Math.Atan2(bFa, aFa);

                // tạm
                // double afA = aaSum1, afB = aaSum2, bfA = bbSum1, bfB = bbSum2;
                double bdAAA, bdBBB, phaAAA, phaBBB;
                bdAAA = Math.Sqrt(afA * afA + bfA * bfA);
                //phaAAA = Math.Atan2(afA, bfA);
                phaAAA = Math.Atan2(bfA, afA);
                label14.Text = bdAAA.ToString();
                label37.Text = phaAAA.ToString();

                //
                bdBBB = Math.Sqrt(afB * afB + bfB * bfB);
                //phaBBB = Math.Atan2(afB, bfB);
                phaBBB = Math.Atan2(bfB, afB);
                //
                label15.Text = bdBBB.ToString();
                label38.Text = phaBBB.ToString();
                //////////////////////////////
                label27.Text = aFa.ToString();
                label26.Text = bFa.ToString();
                //phaAA = Math.Atan2(bbSum1, aaSum1);
                //lấy biên độ đầu B = bdB = sqrt(aFb*aFb + bFb*bFb)
                bdB = Math.Sqrt(aFb * aFb + bFb * bFb);
                //phaBB = Math.Atan2(aFb, bFb);
                phaBB = Math.Atan2(bFb, aFb);

                //phaBB = Math.Atan2(bbSum2, aaSum2);
                int bien_hieu_chinh = 0;// Hiệu chỉnh từ tệp tin-calib
                if (bien_hieu_chinh == 1) // bienDo11 = bdA * hc_bien_do 
                {
                    //đầu A
                    bienDo11 = bdA * hc_bien_doA;
                    pha11 = phaAA * hc_phaA;
                    //dầu B
                    bienDo22 = bdB * hc_bien_doB;
                    pha22 = phaBB * hc_phaB;

                }
                else
                {
                    //đầu A
                    bienDo11 = bdA;
                    pha11 = phaAA;
                    //dầu B
                    bienDo22 = bdB;
                    pha22 = phaBB;
                }

                ///////////////////////////////
                ////tính biên độ đầu A
                //bienDo11 = Math.Sqrt(Math.Pow(aFa, 2) + Math.Pow(bFa, 2));
                bienDo1_textBox.Text = Math.Round(bienDo11, 2).ToString();
                ////tính biên độ đầu B
                //bienDo22 = Math.Sqrt(Math.Pow(aFb, 2) + Math.Pow(bFb, 2));
                bienDo2_textBox.Text = Math.Round(bienDo22, 2).ToString();
                ////Tính pha đầu A
                //pha11 = Math.Atan(bFa / aFa);
                pha1_textBox.Text = Math.Round((pha11 + 3.1459) * 360 / (2 * 3.14), 2).ToString();
                ////Tính pha đầu B
                //pha22 = Math.Atan(bFb / aFb);
                pha2_textBox.Text = Math.Round((pha22 + 3.1459) * 360 / (2 * 3.14), 2).ToString();
                //Vẽ đồ thị sau khi Furier
                // nhân với G để được lực
                for (int j7 = 0; j7 < (nMau); j7++)
                {
                    AAy1[j7] = -bienDo11 * Math.Cos(omegaa * j7 / (nMau / N_Phamotorr) - pha11);
                    AAy2[j7] = -bienDo22 * Math.Cos(omegaa * j7 / (nMau / N_Phamotorr) - pha22);
                    //Luc1[j7] = G * AAy1[j7]; //G = 1
                    //Luc2[j7] = G * AAy2[j7];


                }
                // bắt đầu vẽ chart 2

                for (int j8 = 0; j8 < nMau; j8++)
                {
                    chart2.Series[0].Points.AddXY(j8, AAy1[j8]);
                    chart2.Series[1].Points.AddXY(j8, AAy2[j8]);
                    //chart2.Series[0].Points.AddXY(j8, Luc1[j8]);
                    //chart2.Series[1].Points.AddXY(j8, Luc2[j8]);
                    //chart2.Series[1].Points.AddXY(j8, AAy1a[j8]);
                }
                ////////////////////////////////////////////////////////
                //CHART3
                //double[] yy1aa = new double[nMau];
                //yy1aa = new double[nMau];
                //double[] yy2aa = new double[nMau];
                //yy2aa = new double[nMau];
                //for (int i1 = 0; i1 < nMau; i1++)
                //{
                //    //yy1aa[i1] = bienDo1 * Math.Cos(omega * i1 - phi0 + 0.7);
                //    yy2aa[i1] = bienDo2 * Math.Cos(omegaa * i1 - phi0 - 0.4);

                //}


                //double[] yy1aa = new double[nMau];

                for (int j = 0; j < nMau; j++)
                {

                    chart3.Series[0].Points.AddXY(j, Ay1[j]);
                    chart3.Series[1].Points.AddXY(j, Z1[j]);
                    //chart3.Series[2].Points.AddXY(j, phaMotor[j]);

                }
                ////////////////////////////////////////////////////////
                aaSum1 = 0;
                aaSum2 = 0;
                bbSum1 = 0;
                bbSum2 = 0;
                ////Vẽ tạm đồ thị thực , so sánh với Fourier thì mở comment dưới ra
                //for (int j9 = 0; j9 < N_Phamotorr; j9++)
                //{
                //    int so_chu_ky = 0;
                //    so_chu_ky = j9 * nMau / N_Phamotorr;
                //    chart2.Series[0].Points.AddXY((so_chu_ky), AAy2a[(j9 + Xung_thu_1)]);
                //}
                //Tính lượng mất cân bằng
                //tỉ lệ để vẽ phóng đại lên 25 lần
                double Ti_Le_Ve = 200;
                double tltrongluong = 10000;
                double trongluong1 = 0;
                double trongluong2 = 0;

                luongMatCanBang11 = Ti_Le_Ve * bienDo11 / Math.Pow(omegaNN, 2) / r1;
                trongluong1 = tltrongluong * luongMatCanBang11;
                luongMatCanBang1_textBox.Text = Math.Round(trongluong1, 5).ToString();


                luongMatCanBang22 = Ti_Le_Ve * bienDo22 / Math.Pow(omegaNN, 2) / r2;
                trongluong2 = tltrongluong * luongMatCanBang22;
                luongMatCanBang2_textBox.Text = Math.Round(trongluong2, 5).ToString();

                ////ve luong mat can bang
                Graphics g = this.CreateGraphics();
                Pen blackPen = new Pen(Color.Black, 3);
                Point x = new Point(200, 200);
                Point y = new Point(Convert.ToInt32(Math.Cos(pha11 + 3.14159) * Ti_Le_Ve * 25 * bienDo11 / 20 + x.X), Convert.ToInt32(Math.Sin(pha11) * Ti_Le_Ve * bienDo11 / 20 + x.Y));
                g.DrawLine(blackPen, x, y);
                line1[0] = x;
                line1[1] = y;
                x = new Point(500, 200);
                y = new Point(Convert.ToInt32(Math.Cos(pha22 + 3.14159) * Ti_Le_Ve * 25 * bienDo22 / 20 + x.X), Convert.ToInt32(Math.Sin(pha22) * Ti_Le_Ve * bienDo22 / 20 + x.Y));
                g.DrawLine(blackPen, x, y);
                line2[0] = x;
                line2[1] = y;
                g.Dispose();
            }
            /*bắt đầu vòng lặp
            mỗi thoi_Gian_Cho giây button1 (Draw) sẽ được nhấn 1 lần
            vòng lặp chỉ kết thúc khi nhấn Het_Giao_Dong (Nhấn khi hết giao động)*/
            if (Lap_Draw.Enabled == false)
            {
                Lap_Draw.Start();
            }

        }

        /// <summary>
        // ket thuc button1

        /// </summary>
        int giatridemvong = 4;
        int giatridem = 0;
        int giatrihienthi = 0;
        private void button2_Click(object sender, EventArgs e) // clear, xóa và vẽ lại đồ thị
        {
           giatridem++;
           giatrihienthi = giatridem % giatridemvong;
           
            bienDo1_textBox.Text = giatrihienthi.ToString() ;                // hiện 0 1 2 3
            bienDo2_textBox.Text = "0";
            pha1_textBox.Text = "0";
            pha2_textBox.Text = "0";
            luongMatCanBang1_textBox.Text = "0";
            luongMatCanBang2_textBox.Text = "0";
            Graphics i = this.CreateGraphics();
            Pen whitePen = new Pen(Form4.DefaultBackColor, 3);
            i.DrawLine(whitePen, line1[0], line1[1]);
            i.DrawLine(whitePen, line2[0], line2[1]);
            i.Dispose();                     //Xóa các đường đã vẽ trước đó
            drawObjects();      // vẽ lại
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();                  //Xóa dữ liệu trong biểu đồ
            }
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            /////////////
            giatrihienthi = giatridem % giatridemvong;//thực hiện tính toán phép chia dư để đảm bảo giatrihienthi được cập nhật đúng với giá trị hiện tại của giatridem.

            ///////
            //zedGraphControl1.GraphPane.CurveList.Clear();
            //zedGraphControl1.GraphPane.GraphObjList.Clear();
            //zedGraphControl2.GraphPane.CurveList.Clear();
            //zedGraphControl2.GraphPane.GraphObjList.Clear();
        }
        private void drawObjects()                  // vẽ 2 đường tròn khi bắt đầu   
        {
            //chuky9.Text = "9 ve MAT dong ho";
            Graphics i = this.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 1);
            i.DrawEllipse(blackPen, 100, 100, 200, 200);
            i.DrawEllipse(blackPen, 400, 100, 200, 200);
            Pen blackDashedPen = new Pen(Color.Black, 1);
            blackDashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            Point x = new Point(200, 200);
            Point y = new Point();
            double temp = 0;
            for (int j = 0; j < 8; j++)
            {
                y = new Point(Convert.ToInt32(200 + 150 * Math.Cos(temp)), Convert.ToInt32(200 + 150 * Math.Sin(temp)));
                i.DrawLine(blackDashedPen, x, y);
                temp += Math.PI / 4;
            }
            x = new Point(500, 200);
            temp = 0;
            for (int j = 0; j < 8; j++)
            {
                y = new Point(Convert.ToInt32(500 + 150 * Math.Cos(temp)), Convert.ToInt32(200 + 150 * Math.Sin(temp)));
                i.DrawLine(blackDashedPen, x, y);
                temp += Math.PI / 4;
            }
            i.Dispose();
        }
        private void Form4_Paint(object sender, PaintEventArgs e)
        {
            drawObjects();
        }

        private void button3_Click(object sender, EventArgs e)    // nút Save
        {
            timer1.Interval = 20000;    // 20s
            timer2.Interval = 6000;     // 6s
            //timer1.Enabled = true;
            double[] y1 = new double[nMau];
            double[] y2 = new double[nMau];
            //khai báo
            double[] yy1 = new double[nMau];
            double[] yy2 = new double[nMau];
            int[] phaMotor = new int[nMau];
            
            //tính toán trước khi vẽ
            for (int i = 0; i < nMau; i++)             // 0 - 1023
            {
                if (Math.Sin(omega * i + phiPha) > 0 && Math.Sin(omega * (i - 1) + phiPha) < 0)
                {
                    phaMotor[i] = 1500;
                }
                else phaMotor[i] = -1500;
                if (phaMotor[i] > a1 * Math.Sin(omega * i))
                {
                    y1[i] = phaMotor[i];
                }
                else y1[i] = a1 * Math.Sin(omega * i);
                if (y1[i] == phaMotor[i])
                {
                    if (detectPhaMotor == 0)
                    {
                        detectPhaMotor = 1;
                        xungThu1 = i + 1;
                    }
                    else if (detectPhaMotor == 1)
                    {
                        detectPhaMotor = 2;
                        xungThu2 = i - 1;
                    }
                }
                y2[i] = a2 * Math.Cos(omega * i + 3.14 / 4);
            }
            //vẽ
            ///// tạo vòng lặp
            //timer1.Start();
            int j = 0;

            //timer1.Enabled = true;
            for (j = 0; j < nMau; j++)
            {
                //y1[j] = 0;
                //y2[j] = 0;
                chart1.Series[0].Points.AddXY(j, y1[j]);
                chart1.Series[1].Points.AddXY(j, y2[j]);

            }
            // thêm code 20s hiển thị 6s tắt
            //timer2.Start();
            //timer2.Enabled = true;
            //for (int j1 = 0; j1 < nMau; j1++)
            //{
            //    y1[j1] = 0;
            //    y2[j1] = 0;
            //    chart1.Series[0].Points.AddXY(j1, y1[j1]);
            //    chart1.Series[1].Points.AddXY(j1, y2[j1]);

            //}


            ////////////////////////////////////////////////////////////
            //chart1.Series[0].Points.DataBindY(y1);
            //chart1.Series[1].Points.DataBindY(y2);
            //fourier
            //khai báo tổng = 0
            double aSum1 = 0;
            double aSum2 = 0;
            double bSum1 = 0;
            double bSum2 = 0;
            int N_PhaMotor = 0;
            int r1 = Convert.ToInt32(R1_textBox.Text),
                r2 = Convert.ToInt32(R2_textBox.Text);
            double omegaN = Convert.ToInt32(RPM_textBox.Text) * 2 * 3.14 / 60;
            double bienDo1 = 0;
            double bienDo2 = 0;
            double pha1 = 0;
            double pha2 = 0;
            double luongMatCanBang1 = 0;
            double luongMatCanBang2 = 0;
            //tính tổng cho chuỗi Furier từ xung thứ 1 đến xung thứ 2
            for (int i = xungThu1; i <= xungThu2; i++)
            {
                aSum1 = aSum1 + y1[i] * Math.Sin(omega * i) * 100;
                bSum1 = bSum1 + y1[i] * Math.Cos(omega * i) * 100;
                aSum2 = aSum2 + y2[i] * Math.Sin(omega * i) * 100;
                bSum2 = bSum2 + y2[i] * Math.Cos(omega * i) * 100;
            }
            N_PhaMotor = xungThu2 - xungThu1;
            //tính tổng của chuỗi Furier
            aSum1 = 2 * aSum1 / N_PhaMotor / 100;
            bSum1 = 2 * bSum1 / N_PhaMotor / 100;
            aSum2 = 2 * aSum2 / N_PhaMotor / 100;
            bSum2 = 2 * bSum2 / N_PhaMotor / 100;
            // tính biên độ đầu A
            bienDo1 = Math.Sqrt(Math.Pow(aSum1, 2) + Math.Pow(bSum1, 2));
            bienDo1_textBox.Text = Math.Round(bienDo1, 2).ToString();
            //tính biên độ đầu B
            bienDo2 = Math.Sqrt(Math.Pow(aSum2, 2) + Math.Pow(bSum2, 2));
            bienDo2_textBox.Text = Math.Round(bienDo2, 2).ToString();
            //Tính pha đầu A
            pha1 = Math.Atan(bSum1 / aSum1);
            pha1_textBox.Text = Math.Round(pha1 * 360 / (2 * 3.14), 2).ToString();
            //Tính pha đầu B
            pha2 = Math.Atan(bSum2 / aSum2);
            pha2_textBox.Text = Math.Round(pha2 * 360 / (2 * 3.14), 2).ToString();
            //Vẽ đồ thị sau khi Furier
            for (int i1 = 0; i1 <= (nMau - 1); i1++)
            {
                yy1[i1] = bienDo1 * Math.Sin(omega * i1 / 4 + pha1);
                yy2[i1] = bienDo2 * Math.Sin(omega * i1 / 4 + pha2);

            }
            // bắt đầu vẽ chart 2
            for (int i2 = 0; i2 < nMau; i2++)
            {
                chart2.Series[0].Points.AddXY(i2, yy1[i2]);
                chart2.Series[1].Points.AddXY(i2, yy2[i2]);
            }


            /////////////////
            //Tính lượng mất cân bằng
            luongMatCanBang1 = bienDo1 / Math.Pow(omegaN, 2) / r1;
            luongMatCanBang1_textBox.Text = Math.Round(luongMatCanBang1, 2).ToString();
            luongMatCanBang2 = bienDo2 / Math.Pow(omegaN, 2) / r2;
            luongMatCanBang2_textBox.Text = Math.Round(luongMatCanBang2, 2).ToString();
            //////////////////////////////////////////////////////////////////////////////////
            ////ve luong mat can bang
            //Graphics g = this.CreateGraphics();
            //Pen blackPen = new Pen(Color.Black, 3);
            //Point x = new Point(200, 200);
            //Point y = new Point(Convert.ToInt32(Math.Sin(pha1) * bienDo1 / 20 + x.X), Convert.ToInt32(Math.Cos(pha1) * bienDo1 / 20 + x.Y));
            //g.DrawLine(blackPen, x, y);
            //line1[0] = x;
            //line1[1] = y;
            //x = new Point(500, 200);
            //y = new Point(Convert.ToInt32(Math.Sin(pha2) * bienDo2 / 20 + x.X), Convert.ToInt32(Math.Cos(pha2) * bienDo2 / 20 + x.Y));
            //g.DrawLine(blackPen, x, y);
            //line2[0] = x;
            //line2[1] = y;
            //g.Dispose();
            ////
        }

        // chưa dùng timer 1, chỉ dùng cho nút Save
        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer2.Stop();
            //timer2.Enabled = false;
           

        }

        // chưa dùng timer 2, chỉ dùng cho nút Save
        private void timer2_Tick(object sender, EventArgs e)
        {
            //timer1.Stop();
           // timer1.Enabled = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            int modetam, D1, D2, kc_a, kc_b, kc_c;
            modetam = _mode;
            D1 = _D1;
            D2 = _D2;
            kc_a = _kc_a;
            kc_b = _kc_b;
            kc_c = _kc_c;
            //hiển thị
            modef4.Text = modetam.ToString();
            D1f4.Text = D1.ToString();
            D2f4.Text = D2.ToString();
            kc_af4.Text = kc_a.ToString();
            kc_bf4.Text = kc_b.ToString();
            kc_cf4.Text = kc_c.ToString();
            int La, Lb, Lc, L;
            La = kc_a; Lb = kc_b; Lc = kc_c;
            L = La + Lb + Lc;
            textBox1.Text = La.ToString();
            textBox2.Text = Lb.ToString();
            textBox3.Text = Lc.ToString();
            /////////////////////////////////////////////////
            //tickStart1.Environment.TickCount;
            //button2.PerformClick();
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            ///////////////////////////////////////////////// 
            

        }

        private void Het_Giao_Dong_Click(object sender, EventArgs e)
        {
            /*Chấp nhận dữ liệu cuối cùng từ data.txt
            Đọc data.txt vào mảng
            Sử dụng các mảng này làm dữ liệu cuối*/
            Lap_Draw.Stop();
            Doc_Data_Txt();
        }

        int lap_Draw_arg = 1;
        int thoi_Gian_Cho = 1;
     
        // timer Lap_Draw dùng cho lặp vẽ, vẽ xong rồi mới lặp vẽ
        private void Lap_Draw_Tick(object sender, EventArgs e)
        {
            /*Đếm mỗi giây từ khi nhấn Draw lần đầu tiên
             mỗi thoi_Gian_Cho giây sẽ đọc data.txt và nhấn Draw lần nữa*/
            thoi_Gian_Cho = 1;
            lap_Draw_arg++;
            
            if (lap_Draw_arg % thoi_Gian_Cho == 0)
            {
                // Doc_Data_Txt();

                button1.PerformClick();
                                              
            }
        }

        private void bufferedAiCtrl1_DataReady(object sender, BfdAiEventArgs e)
        {
            //bufferedAiCtrl1.GetData(0, nMauth, bien_chuyen);
            bufferedAiCtrl1.GetData(nMauth, bien_chuyen);  // 3072  vd bien_chuyen[0] =1321  ...bien_chuyen[3071] = 1235 
            Invoke(new UpdateUIDelegate(updateUI));
        }
        private void updateUI()
        {
            for (int i = 0; i < nMauth; i++)      // 3072
            {
                listBox1.Items.Add("channel " + (i % 3).ToString() + " thứ " + i + " data is: " + bien_chuyen[i]);
                if (i % 3 == 0) // 3i
                {
                    Ay1[i] = bien_chuyen[i]; // Ay1[i], i = 0,3,6,9,...3i
                    listBox3.Items.Add("tin hieu a"  + " " + i + " là: " + Ay1[i]);
                }
                if (i % 3 == 1)  // 3i+1    // Ay2[i], i = 1 ,4 , 7, ... 3i+1
                {
                    Ay2[i] = bien_chuyen[i];
                    listBox4.Items.Add("tin hieu b"  + " " + i + " là: " + Ay2[i]);
                }
                if (i % 3 == 2)
                {
                    Apha[i] = bien_chuyen[i]; // Apha[i], i = 2, 5, 8, ...3i+2
                    listBox5.Items.Add("tin hieu pha" + " " + i + " là: " + Apha[i]);
                }
                //if ((i + 1) % 3 == 0)
                //{
                    
                //     listBox1.Items.Add("");
                //}
                
            }
            
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ee_TextChanged(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            bufferedAiCtrl1.Prepare();
            //bufferedAiCtrl1.RunOnce(true);
            bufferedAiCtrl1.RunOnce(true);
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            button5.Visible = true;
            button6.Visible = false;
            ////
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            ////
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            ////
            bienDo1_textBox.Visible = false;
            pha1_textBox.Visible = false;
            luongMatCanBang1_textBox.Visible = false;
            bienDo2_textBox.Visible = false;
            pha2_textBox.Visible = false;
            luongMatCanBang2_textBox.Visible = false;
            ////
            R1_textBox.Visible = false;
            R2_textBox.Visible = false;
            RPM_textBox.Visible = false;
            ////
            chart1.Visible = false;
            chart2.Visible = false;
            //listBox1.Visible = false;
            button4.Visible = false;
            Het_Giao_Dong.Visible = false;
            Bang_Ma_Loi.Visible = false;
            Hien_Thi_loi.Visible = false;
            ////
            listBox1.Visible = false;
            listBox2.Visible = false;
            listBox3.Visible = false;
            listBox4.Visible = false;
            listBox5.Visible = false;
            listBox6.Visible = false;




        }

        private void button5_Click(object sender, EventArgs e)
        {
            //drawObjects();
            button5.Visible = false;
            button6.Visible = true;
            ////
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            ////
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            ////
            bienDo1_textBox.Visible = true;
            pha1_textBox.Visible = true;
            luongMatCanBang1_textBox.Visible = true;
            bienDo2_textBox.Visible = true;
            pha2_textBox.Visible = true;
            luongMatCanBang2_textBox.Visible = true;
            ////
            R1_textBox.Visible = true;
            R2_textBox.Visible = true;
            RPM_textBox.Visible = true;
            ////
            chart1.Visible = true;
            chart2.Visible = true;
            listBox1.Visible = false;
            button4.Visible = true;
            Het_Giao_Dong.Visible = true;
            Bang_Ma_Loi.Visible = true;
            Hien_Thi_loi.Visible = true;
            ////


        }

        private void button7_Click(object sender, EventArgs e)
        {
            label10.Text = so_mode.ToString();
            label11.Text = n.ToString();
            
            for (int i12 = 0; i12 < n; i12++)
            {
                listBox2.Items.Add("dulieu " + i12.ToString() + " bằng: " + hc[i12]);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Ghi_Data_Txt();
        }
   
    }
}
