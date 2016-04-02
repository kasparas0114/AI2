using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeCombobox();
        }

        public void HideGame()
        {
            var Buttons = ButtonsList();
            foreach (var b in Buttons)
                b.Hide();
        }
        public void ShowGame()
        {
            var Buttons = ButtonsList();
            foreach (var b in Buttons)
                b.Show();
        }
        public List<Button> ButtonsList()
        {
            var GameButtons = new List<Button>();
            GameButtons.Add(button1);
            GameButtons.Add(button2);
            GameButtons.Add(button3);
            GameButtons.Add(button4);
            GameButtons.Add(button5);
            GameButtons.Add(button6);
            GameButtons.Add(button7);
            GameButtons.Add(button8);
            GameButtons.Add(button9);
            return GameButtons;

        }
        public void InitializeCombobox ()
        {
            comboBox1.Items.Add(new ComboBoxItem("X", 0));
            comboBox1.Items.Add(new ComboBoxItem("0", 1));
            comboBox2.Items.Add(new ComboBoxItem("Mini-Max", 0));
            comboBox2.Items.Add(new ComboBoxItem("Alpha-Beta", 1));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var team = comboBox1.SelectedItem.ToString();
            var alg = comboBox2.SelectedItem.ToString();
            if (team == "X" && alg != "MiniMax")
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = comboBox1.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = comboBox1.SelectedItem.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = comboBox1.SelectedItem.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = comboBox1.SelectedItem.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Text = comboBox1.SelectedItem.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Text = comboBox1.SelectedItem.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        { 
            button7.Text = comboBox1.SelectedItem.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Text = comboBox1.SelectedItem.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.Text = comboBox1.SelectedItem.ToString();
        }
    }
}
