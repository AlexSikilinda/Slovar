using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class Form1 : Form
    {
        Dict d;
        public Form1()
        {
            InitializeComponent();
            d = new Dict();
            listBox1.DataSource = d.EngList();
            listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged1);
            listBox2.DataSource = d.ToRussian(listBox1.SelectedItem as string);
            
        }

        void listBox1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            listBox2.DataSource = d.ToRussian(listBox1.SelectedItem as string);
        }

        void listBox1_SelectedIndexChanged2(object sender, EventArgs e)
        {
            listBox2.DataSource = d.ToEnglish(listBox1.SelectedItem as string);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (d.IsEnglish)
            {
                listBox1.DataSource = d.RusList();
                listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged2);
                listBox2.DataSource = d.ToRussian(listBox1.SelectedItem as string);
                d.IsEnglish = false;
            }
            else
            {
                listBox1.DataSource = d.EngList();
                listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged1);
                listBox2.DataSource = d.ToEnglish(listBox1.SelectedItem as string);
                d.IsEnglish = true;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var z = new OpenFileDialog();
            z.ShowDialog();
            d.filename = z.FileName;
            d.Load();
            //listBox1.DataSource = null;
            listBox1.DataSource = d.EngList();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.Save();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var z = new SaveFileDialog();
            z.ShowDialog();
            d.filename = z.FileName;
            d.Save();
        }

        
    }
}
