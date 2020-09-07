using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DNA_Compare_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = ("GUI for DNA Compare tool by Ahmed Nematallah\r\nahmed_nematallah@hotmail.com\r\nhttps://github.com/Ahmed-Nematallah/DNA-Alignment-Tools\r\nIcon from \"https://www.flaticon.com/authors/freepik\"");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = "Please wait...";

            if (!File.Exists(textBox3.Text)) {
                textBox4.Text = "Executable file doesn't exist, please select it.";
                return;
            }

            System.IO.File.WriteAllText("tmp1.txt", textBox1.Text);
            System.IO.File.WriteAllText("tmp2.txt", textBox2.Text);

            string arguments = "-S1 tmp1.txt -S2 tmp2.txt -o out.txt";

            if (comboBox1.SelectedIndex == 0) {
                arguments += " -An";
            } else if (comboBox1.SelectedIndex == 1) {
                arguments += " -As";
            }

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = textBox3.Text;
            startInfo.Arguments = arguments;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            textBox4.Text = System.IO.File.ReadAllText("out.txt");

            System.IO.File.Delete("tmp1.txt");
            System.IO.File.Delete("tmp2.txt");
            System.IO.File.Delete("out.txt");
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox3.Text = openFileDialog1.FileName;
        }
    }
}
