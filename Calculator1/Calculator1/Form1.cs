﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        bool isTypingNumber = false;

        enum PhepToan { None, Cong, Tru, Nhan, Chia };
        PhepToan pheptoan;

        double nho;

        private void Nhapso(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Nhapso(btn.Text);
        }

        private void Nhapso(string so)
        {
            if (isTypingNumber)
                lblDisplay.Text = lblDisplay.Text + so;
            else
            {
                lblDisplay.Text = so;
                isTypingNumber = true;
            }
        }

        private void NhapPhepToan(object sender, EventArgs e)
        {
            if (nho != 0)
                Tinhketqua();

            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "+": pheptoan = PhepToan.Cong; break;
                case "-": pheptoan = PhepToan.Tru; break;
                case "*": pheptoan = PhepToan.Nhan; break;
                case "/": pheptoan = PhepToan.Chia; break;
            }

            nho = double.Parse(lblDisplay.Text);

            isTypingNumber = false;
        }

        private void btnBang_Click(object sender, EventArgs e)
        {
            Tinhketqua();
            isTypingNumber = false;
            nho = 0;
            pheptoan = PhepToan.None;
        }

        private void Tinhketqua()
        {
            // tinh toan dua tren: nho, pheptoan, lblDisplay.Tex
            double tam = double.Parse(lblDisplay.Text);
            double ketqua = 0.0;
            switch (pheptoan)
            {
                case PhepToan.Cong: ketqua = nho + tam; break;
                case PhepToan.Tru: ketqua = nho + tam; break;
                case PhepToan.Nhan: ketqua = nho * tam; break;
                case PhepToan.Chia: ketqua = nho / tam; break;
            }
            // gan ket qua tinh duoc len lblDisplay
            lblDisplay.Text = ketqua.ToString();
        }

        private void btnbang_Click(object sender, EventArgs e)
        {
            Tinhketqua();
            isTypingNumber = false;
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    Nhapso("" + e.KeyChar);
                    break;

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }

        private void btnnho_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            nho = 0;
            lblDisplay.Text = "";
        }
    }
}
