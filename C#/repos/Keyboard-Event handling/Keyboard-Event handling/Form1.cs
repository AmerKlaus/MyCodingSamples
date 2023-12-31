﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard_Event_handling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            charLabel.Text = $"Key pressed: {e.KeyChar}";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            keyInfoLabel.Text =
                $"Alt: {(e.Alt ? "Yes" : "No")}\n" +
                $"Shift: {(e.Shift ? "Yes" : "No")}\n" +
                $"Ctrl: {(e.Control ? "Yes" : "No")}\n" +
                $"KeyCode: {e.KeyCode}\n" +
                $"KeyData: {e.KeyData}\n" +
                $"KeyValue: {e.KeyValue}";
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            charLabel.Text = "";
            keyInfoLabel.Text = "";
        }
    }
}
