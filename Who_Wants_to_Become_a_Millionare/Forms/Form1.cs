using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Who_Wants_to_Become_a_Millionare
{
    public partial class Form1 : Form
    {
        SoundPlayer main_theme = new SoundPlayer("../../sound/begin.wav");

        public Form1()
        {
            InitializeComponent();
            main_theme.Play();
        }
        #region смена цвета кнопок новая игра и выход
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.Aquamarine;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.Aquamarine;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.LightBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.LightBlue;
        }
        private void button1_MouseEnter_1(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.Aquamarine;
        }
        private void button1_MouseLeave_1(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.LightBlue;
        }
        #endregion

        private void new_game_Click(object sender, EventArgs e)
        {
            Form_main_Game form_Main_Game = new Form_main_Game();
            try
            {
                Game_Presenter game_Presenter = new Game_Presenter(form_Main_Game);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            Visible = false;
            main_theme.Stop();
            SoundPlayer Gong = new SoundPlayer("../../sound/gong.wav");
            
            Gong.Play();
            form_Main_Game.ShowDialog();
            Visible = true;
            main_theme.Play();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
