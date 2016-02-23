using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace SerialStepperControl
{
    public partial class Form1 : Form
    {
        SerialPort port = new SerialPort("COM4");
        private string RxString;

        public Form1()
        {
            port.Handshake = Handshake.None;
            InitializeComponent();
            port.BaudRate = 9600;
            port.DtrEnable = true;
            if (port.IsOpen == false) //if not open, open the port
                port.Open();
            
            port.DataReceived += port_DataReceived;
        }

       


        private void port_DataReceived
     (object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            RxString = port.ReadExisting();
            this.Invoke(new EventHandler(DisplayText));
        }

        private void DisplayText(object sender, EventArgs e)
        {
            textBox5.AppendText(RxString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            port.Write(textBox1.Text + ";" + textBox6.Text + ":" + textBox2.Text + ";" + textBox7.Text + ":" + textBox3.Text + ";" + textBox8.Text);
            textBox5.AppendText(textBox1.Text + ";" + textBox6.Text + ":" + textBox2.Text + ";" + textBox7.Text + ":" + textBox3.Text + ";" + textBox8.Text + "\n");
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            if (port.IsOpen == false) //if not open, open the port
                port.Open();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (port.IsOpen == true) //if not open, open the port
                port.Close();
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
