﻿using System;
using System.Windows.Forms;

namespace GiaoDienDATN
    {
    static class Program


    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new Form2());
            //Application.Run(new Form3());
            //Application.Run(new Form4());

        }
    }
}
