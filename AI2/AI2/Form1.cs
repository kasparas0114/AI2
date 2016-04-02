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
        string [,] windows = new string[3, 3];
        public Form1()
        {
            InitializeComponent();
            InitializeCombobox();
            HideGame();
            
        }
        public void MIniMax(string[,] windows, bool computerTurn)
        {

        }
        //public int evaluateLine(int row1, int col1, int row2, int col2, int row3, int col3)
        //{
        //    int score = 0;
        //    return sc
        //}
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
            comboBox1.Items.Add(new ComboBoxItem("X", 1));
            comboBox1.Items.Add(new ComboBoxItem("0", 2));
            comboBox2.Items.Add(new ComboBoxItem("Mini-Max", 1));
            comboBox2.Items.Add(new ComboBoxItem("Alpha-Beta", 2));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            ShowGame();
            foreach (var b in ButtonsList())
            {
                b.Enabled = true;
                b.Text = "";
            }
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    windows[i, j] = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = comboBox1.SelectedItem.ToString();
            windows[0, 0] = comboBox1.SelectedItem.ToString();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = comboBox1.SelectedItem.ToString();
            windows[1, 0] = comboBox1.SelectedItem.ToString();
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = comboBox1.SelectedItem.ToString();
            windows[2, 0] = comboBox1.SelectedItem.ToString();
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = comboBox1.SelectedItem.ToString();
            windows[0, 1] = comboBox1.SelectedItem.ToString();
            button4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Text = comboBox1.SelectedItem.ToString();
            windows[1, 1] = comboBox1.SelectedItem.ToString();
            button5.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Text = comboBox1.SelectedItem.ToString();
            windows[2, 1] = comboBox1.SelectedItem.ToString();
            button6.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        { 
            button7.Text = comboBox1.SelectedItem.ToString();
            windows[0, 2] = comboBox1.SelectedItem.ToString();
            button7.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Text = comboBox1.SelectedItem.ToString();
            windows[1, 2] = comboBox1.SelectedItem.ToString();
            button8.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.Text = comboBox1.SelectedItem.ToString();
            windows[2, 2] = comboBox1.SelectedItem.ToString();
            button9.Enabled = false;
        }
    }
}
