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
        MiniMaxGame MiniMaxGame = new MiniMaxGame();
        List<Button> GameButtons = new List<Button>();
        public Form1()
        {
            InitializeComponent();
            InitializeCombobox();
            HideGame();
            
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
            for (int i = 0; i < 9; i++)
            {
                MiniMaxGame.gameBoard[i] = " ";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = comboBox1.SelectedItem.ToString();
            windows[0, 0] = comboBox1.SelectedItem.ToString();
            MakeMove(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = comboBox1.SelectedItem.ToString();
            windows[1, 0] = comboBox1.SelectedItem.ToString();
            MakeMove(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = comboBox1.SelectedItem.ToString();
            windows[2, 0] = comboBox1.SelectedItem.ToString();
            MakeMove(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = comboBox1.SelectedItem.ToString();
            windows[0, 1] = comboBox1.SelectedItem.ToString();
            MakeMove(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Text = comboBox1.SelectedItem.ToString();
            windows[1, 1] = comboBox1.SelectedItem.ToString();
            MakeMove(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Text = comboBox1.SelectedItem.ToString();
            windows[2, 1] = comboBox1.SelectedItem.ToString();
            MakeMove(5);
        }

        private void button7_Click(object sender, EventArgs e)
        { 
            button7.Text = comboBox1.SelectedItem.ToString();
            windows[0, 2] = comboBox1.SelectedItem.ToString();
            MakeMove(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Text = comboBox1.SelectedItem.ToString();
            windows[1, 2] = comboBox1.SelectedItem.ToString();
            MakeMove(7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.Text = comboBox1.SelectedItem.ToString();
            windows[2, 2] = comboBox1.SelectedItem.ToString();
            MakeMove(8);
        }
        private void MakeMove(int index)
        {
            MiniMaxGame.gameBoard[index] = "x";
            ResultMinMax res = MiniMaxGame.MinMax(MiniMaxGame.gameBoard, "MAX", 0,0);          
            for (int i = 0; i < 9; i++)
            {    
                    if (res.matrix[i] != MiniMaxGame.gameBoard[i])
                    {
                        MiniMaxGame.gameBoard[i] = "o";
                        GameButtons[i].Text = "O";
                        return;
                    }                
           }
            
            return;
        }
    }
}
