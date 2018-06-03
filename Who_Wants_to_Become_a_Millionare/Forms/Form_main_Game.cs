using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Who_Wants_to_Become_a_Millionare
{
    public partial class Form_main_Game : Form, IGameView
    {
        Int32 timer_blink = 9;
        Boolean fifty_fifty = false;
        Boolean call = false;
        Boolean crowd = false;
        public Form_main_Game()
        {
            InitializeComponent();
            main_timer.Start();
        }
        //--///////////////////////////////////////
        public String Buffer_label_question_text
        {
            get { return buffer_label_question.Text; }
            set { buffer_label_question.Text = value; }
        }
        public String Buffer_label_AnswerA_text
        {
            get { return buffer_label_answerA.Text; }
            set { buffer_label_answerA.Text = value; }
        }
        public String Buffer_label_AnswerB_text
        {
            get { return buffer_label_answerB.Text; }
            set { buffer_label_answerB.Text = value; }
        }
        public String Buffer_label_AnswerC_text
        {
            get { return buffer_label_answerC.Text; }
            set { buffer_label_answerC.Text = value; }
        }
        public String Buffer_label_AnswerD_text
        {
            get { return buffer_label_answerD.Text; }
            set { buffer_label_answerD.Text = value; }
        }
        public String Jessie_thoughts
        {
            get { return Jessie_answer.Text; }
            set { Jessie_answer.Text = value; }
        }

        public Int32 Crowd_help_A { get; set; }
        public Int32 Crowd_help_B { get; set; }
        public Int32 Crowd_help_C { get; set; }
        public Int32 Crowd_help_D { get; set; }

        public event voidDelegate exit_new_leave;
        public event boolDelegate questions_answers;
        public event voidDelegatevoid next_question;
        public event voidDelegate clues;

        public void vin()
        {
            SoundPlayer vin_sound = new SoundPlayer("../../sound/winner.wav");
            vin_sound.Play();
            Jeremy.Visible = false;
            label_text_Correct.Visible = false;
            congrats.Visible = true;
            main_timer.Interval = 3600000;
        }

        #region обработчики события кнопок exit new_game leave

        private void Button_new_game_Click(object sender, EventArgs e)
        {
            exit_new_leave?.Invoke((sender as Button).Name);
            SoundPlayer Gong = new SoundPlayer("../../sound/gong.wav");
            Gong.Play();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_leave_Click(object sender, EventArgs e)
        {
            foreach (Control item in Controls)
            {
                if (item is Label && item.BackColor == Color.Olive)
                {
                    set_window_to_default();
                    pictureBox_Leave.Visible = true;
                    SoundPlayer Summa = new SoundPlayer("../../sound/Summa.wav");
                    Summa.Play();
                    timer_leave.Start();
                    break;
                }
            }
        }

        #endregion

        #region обработчики события кнопок подсказок
        private void button_50_50_Click(object sender, EventArgs e)
        {
            if (!fifty_fifty)
            {
                clues?.Invoke((sender as Button).Name);
                main_timer_Tick(this, EventArgs.Empty);
                (sender as Button).Image = Image.FromFile("../../Image/4.jpg");
                fifty_fifty = true;
            }
        }

        private void button_call_to_a_friend_Click(object sender, EventArgs e)
        {
            if (!call)
            {
                SoundPlayer call_sound = new SoundPlayer("../../sound/zvonok.wav");
                call_sound.Play();
                Jessie_timer.Start();
                (sender as Button).Image = Image.FromFile("../../Image/5.jpg");
                call = true;
            }
        }

        private void button_croud_help_Click(object sender, EventArgs e)
        {
            if (!crowd)
            {
                clues?.Invoke((sender as Button).Name);
                groupBox3.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Text = Crowd_help_A.ToString() + "%";
                label5.Visible = true;
                label6.Text = Crowd_help_B.ToString() + "%";
                label6.Visible = true;
                label7.Text = Crowd_help_C.ToString() + "%";
                label7.Visible = true;
                label8.Text = Crowd_help_D.ToString() + "%";
                label8.Visible = true;
                progressBar1.Visible = true;
                progressBar2.Visible = true;
                progressBar3.Visible = true;
                progressBar4.Visible = true;
                timer_progress1.Start();
                timer_progress2.Start();
                timer_progress3.Start();
                timer_progress4.Start();
                (sender as Button).Image = Image.FromFile("../../Image/6.jpg");
                crowd = true;
            }
        }
        #endregion

        #region обработчики события кнопок ответов
        private void button_answerA_Click(object sender, EventArgs e)
        {
            if (!main_timer.Enabled)
            {
                if (questions_answers != null)
                {
                    if (questions_answers.Invoke((sender as Button).Text))
                    {
                        label_draw();
                        Jeremy.Visible = true;
                        label_text_Correct.Visible = true;
                        SoundPlayer True = new SoundPlayer("../../sound/True.wav");
                        True.Play();
                        (sender as Button).BackColor = Color.Green;
                        timer_answerA.Start();
                        Buffer_label_AnswerA_text = "";
                        next_question?.Invoke();
                    }
                    else
                    {
                        Jeremy_wrong.Visible = true;
                        label_answer_wrong.Visible = true;
                        SoundPlayer False = new SoundPlayer("../../sound/False.wav");
                        False.Play();
                        (sender as Button).BackColor = Color.Red;
                        timer_answer_wrongA.Start();
                        main_timer.Interval = 3600000;
                    }
                }
            }
            if(call)
            {
                Jessie.Visible = false;
                Jessie_answer.Visible = false;
            }
            if(crowd)
            {
                groupBox3.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                progressBar1.Visible = false;
                progressBar2.Visible = false;
                progressBar3.Visible = false;
                progressBar4.Visible = false;
            }
            main_timer.Start();
        }
        ///////
        private void button_AnswerB_Click(object sender, EventArgs e)
        {
            if (!main_timer.Enabled)
            {
                if (questions_answers != null)
                {
                    if (questions_answers.Invoke((sender as Button).Text))
                    {
                        label_draw();
                        Jeremy.Visible = true;
                        label_text_Correct.Visible = true;
                        SoundPlayer True = new SoundPlayer("../../sound/True.wav");
                        True.Play();
                        (sender as Button).BackColor = Color.Green;
                        timer_answerB.Start();
                        Buffer_label_AnswerB_text = "";
                        next_question?.Invoke();
                    }
                    else
                    {
                        Jeremy_wrong.Visible = true;
                        label_answer_wrong.Visible = true;
                        SoundPlayer False = new SoundPlayer("../../sound/False.wav");
                        False.Play();
                        (sender as Button).BackColor = Color.Red;
                        timer_answer_wrongB.Start();
                        main_timer.Interval = 3600000;
                    }
                }
            }
            if (call)
            {
                Jessie.Visible = false;
                Jessie_answer.Visible = false;
            }
            if (crowd)
            {
                groupBox3.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                progressBar1.Visible = false;
                progressBar2.Visible = false;
                progressBar3.Visible = false;
                progressBar4.Visible = false;
            }
            main_timer.Start();
        }
        ///////
        private void button_AnswerC_Click(object sender, EventArgs e)
        {
            if (!main_timer.Enabled)
            {
                if (questions_answers != null)
                {
                    if (questions_answers.Invoke((sender as Button).Text))
                    {
                        label_draw();
                        Jeremy.Visible = true;
                        label_text_Correct.Visible = true;
                        SoundPlayer True = new SoundPlayer("../../sound/True.wav");
                        True.Play();
                        (sender as Button).BackColor = Color.Green;
                        timer_answerC.Start();
                        Buffer_label_AnswerC_text = "";
                        next_question?.Invoke();
                    }
                    else
                    {
                        Jeremy_wrong.Visible = true;
                        label_answer_wrong.Visible = true;
                        SoundPlayer False = new SoundPlayer("../../sound/False.wav");
                        False.Play();
                        (sender as Button).BackColor = Color.Red;
                        timer_Answer_wrongC.Start();
                        main_timer.Interval = 3600000;
                    }
                }
            }
            if (call)
            {
                Jessie.Visible = false;
                Jessie_answer.Visible = false;
            }
            if (crowd)
            {
                groupBox3.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                progressBar1.Visible = false;
                progressBar2.Visible = false;
                progressBar3.Visible = false;
                progressBar4.Visible = false;
            }
            main_timer.Start();
        }
        ///////
        private void button_AnswerD_Click(object sender, EventArgs e)
        {
            if (!main_timer.Enabled)
            {
                if (questions_answers != null)
                {
                    if (questions_answers.Invoke((sender as Button).Text))
                    {
                        label_draw();
                        Jeremy.Visible = true;
                        label_text_Correct.Visible = true;
                        SoundPlayer True = new SoundPlayer("../../sound/True.wav");
                        True.Play();
                        (sender as Button).BackColor = Color.Green;
                        timer_answerD.Start();
                        Buffer_label_AnswerD_text = "";
                        next_question?.Invoke();
                    }
                    else
                    {
                        Jeremy_wrong.Visible = true;
                        label_answer_wrong.Visible = true;
                        SoundPlayer False = new SoundPlayer("../../sound/False.wav");
                        False.Play();
                        (sender as Button).BackColor = Color.Red;
                        timer_answer_wrongD.Start();
                        main_timer.Interval = 3600000;
                    }
                }
            }
            if (call)
            {
                Jessie.Visible = false;
                Jessie_answer.Visible = false;
            }
            if (crowd)
            {
                groupBox3.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                progressBar1.Visible = false;
                progressBar2.Visible = false;
                progressBar3.Visible = false;
                progressBar4.Visible = false;
            }
            main_timer.Start();
        }
        #endregion


        private void timer_leave_Tick(object sender, EventArgs e)
        {
            timer_leave.Stop();
            Close();
        }

        #region таймеры мерцания кнопок ответов

        private void timer_answerD_Tick(object sender, EventArgs e)
        {
            if (timer_blink > 3)
            {
                if (button_AnswerD.BackColor == Color.Green)
                    button_AnswerD.BackColor = Color.Black;
                else
                {
                    if (button_AnswerD.BackColor == Color.Black)
                        button_AnswerD.BackColor = Color.Green;
                }
            }
            if (timer_blink <= 3)
            {
                button_AnswerD.BackColor = Color.Green;
                timer_blink--;
            }
            if (timer_blink == 0)
            {
                timer_blink = 9;
                timer_answerD.Stop();
            }
            timer_blink--;
        }

        private void timer_answer_wrongD_Tick(object sender, EventArgs e)
        {
            if (timer_blink > 3)
            {
                if (button_AnswerD.BackColor == Color.Red)
                    button_AnswerD.BackColor = Color.Black;
                else
                {
                    if (button_AnswerD.BackColor == Color.Black)
                        button_AnswerD.BackColor = Color.Red;
                }
            }
            if (timer_blink <= 3)
            {
                button_AnswerD.BackColor = Color.Red;
                timer_blink--;
            }
            if (timer_blink == 0)
            {
                timer_blink = 9;
                timer_answer_wrongD.Stop();
            }
            timer_blink--;
        }
        //////////////
        private void timer_answerA_Tick(object sender, EventArgs e)
        {
            if (timer_blink > 3)
            {
                if (button_answerA.BackColor == Color.Green)
                    button_answerA.BackColor = Color.Black;
                else
                {
                    if (button_answerA.BackColor == Color.Black)
                        button_answerA.BackColor = Color.Green;
                }
            }
            if (timer_blink <= 3)
            {
                button_answerA.BackColor = Color.Green;
                timer_blink--;
            }
            if (timer_blink == 0)
            {
                timer_blink = 9;
                timer_answerA.Stop();
            }
            timer_blink--;
        }

        private void timer_answer_wrongA_Tick(object sender, EventArgs e)
        {
            if (timer_blink > 3)
            {
                if (button_answerA.BackColor == Color.Red)
                    button_answerA.BackColor = Color.Black;
                else
                {
                    if (button_answerA.BackColor == Color.Black)
                        button_answerA.BackColor = Color.Red;
                }
            }
            if (timer_blink <= 3)
            {
                button_answerA.BackColor = Color.Red;
                timer_blink--;
            }
            if (timer_blink == 0)
            {
                timer_blink = 9;
                timer_answer_wrongA.Stop();
            }
            timer_blink--;
        }
        //////////////
        private void timer_answerB_Tick(object sender, EventArgs e)
        {
            if (timer_blink > 3)
            {
                if (button_AnswerB.BackColor == Color.Green)
                    button_AnswerB.BackColor = Color.Black;
                else
                {
                    if (button_AnswerB.BackColor == Color.Black)
                        button_AnswerB.BackColor = Color.Green;
                }
            }
            if (timer_blink <= 3)
            {
                button_AnswerB.BackColor = Color.Green;
                timer_blink--;
            }
            if (timer_blink == 0)
            {
                timer_blink = 9;
                timer_answerB.Stop();
            }
            timer_blink--;
        }

        private void timer_answer_wrongB_Tick(object sender, EventArgs e)
        {
            if (timer_blink > 3)
            {
                if (button_AnswerB.BackColor == Color.Red)
                    button_AnswerB.BackColor = Color.Black;
                else
                {
                    if (button_AnswerB.BackColor == Color.Black)
                        button_AnswerB.BackColor = Color.Red;
                }
            }
            if (timer_blink <= 3)
            {
                button_AnswerB.BackColor = Color.Red;
                timer_blink--;
            }
            if (timer_blink == 0)
            {
                timer_blink = 9;
                timer_answer_wrongB.Stop();
            }
            timer_blink--;
        }
        //////////////
        private void timer_answerC_Tick(object sender, EventArgs e)
        {
            if (timer_blink > 3)
            {
                if (button_AnswerC.BackColor == Color.Green)
                    button_AnswerC.BackColor = Color.Black;
                else
                {
                    if (button_AnswerC.BackColor == Color.Black)
                        button_AnswerC.BackColor = Color.Green;
                }
            }
            if (timer_blink <= 3)
            {
                button_AnswerC.BackColor = Color.Green;
                timer_blink--;
            }
            if (timer_blink == 0)
            {
                timer_blink = 9;
                timer_answerC.Stop();
            }
            timer_blink--;
        }

        private void timer_Answer_wrongC_Tick(object sender, EventArgs e)
        {
            if (timer_blink > 3)
            {
                if (button_AnswerC.BackColor == Color.Red)
                    button_AnswerC.BackColor = Color.Black;
                else
                {
                    if (button_AnswerC.BackColor == Color.Black)
                        button_AnswerC.BackColor = Color.Red;
                }
            }
            if (timer_blink <= 3)
            {
                button_AnswerC.BackColor = Color.Red;
                timer_blink--;
            }
            if (timer_blink == 0)
            {
                timer_blink = 9;
                timer_Answer_wrongC.Stop();
            }
            timer_blink--;
        }
        #endregion

        private void main_timer_Tick(object sender, EventArgs e)
        {
            Jeremy.Visible = false;
            label_text_Correct.Visible = false;
            Jeremy_wrong.Visible = false;
            label_answer_wrong.Visible = false;
            label_Question.Text = Buffer_label_question_text;
            button_answerA.Text = "A: " + Buffer_label_AnswerA_text;
            button_AnswerB.Text = "B: " + Buffer_label_AnswerB_text;
            button_AnswerC.Text = "C: " + Buffer_label_AnswerC_text;
            button_AnswerD.Text = "D: " + Buffer_label_AnswerD_text;
            button_answerA.BackColor = Color.Black;
            button_AnswerB.BackColor = Color.Black;
            button_AnswerC.BackColor = Color.Black;
            button_AnswerD.BackColor = Color.Black;
            main_timer.Stop();
        }


        /// 
        public void set_window_to_default()
        {
            Jeremy.Visible = false;
            label_text_Correct.Visible = false;
            Jeremy_wrong.Visible = false;
            label_answer_wrong.Visible = false;
            label_Question.Text = "";
            button_answerA.Text = "A: ";
            button_AnswerB.Text = "B: ";
            button_AnswerC.Text = "C: ";
            button_AnswerD.Text = "D: ";
            button_answerA.BackColor = Color.Black;
            button_AnswerB.BackColor = Color.Black;
            button_AnswerC.BackColor = Color.Black;
            button_AnswerD.BackColor = Color.Black;
            label_1.BackColor = Color.Black;
            label_2.BackColor = Color.Black;
            label_3.BackColor = Color.Black;
            label_4.BackColor = Color.Black;
            label_5.BackColor = Color.Black;
            label_6.BackColor = Color.Black;
            label_7.BackColor = Color.Black;
            label_8.BackColor = Color.Black;
            label_9.BackColor = Color.Black;
            label_10.BackColor = Color.Black;
            label_11.BackColor = Color.Black;
            label_12.BackColor = Color.Black;
            label_13.BackColor = Color.Black;
            label_14.BackColor = Color.Black;
            label_15.BackColor = Color.Black;
            button_50_50.Image = Image.FromFile("../../Image/1.jpg");
            button_call_to_a_friend.Image = Image.FromFile("../../Image/2.jpg");
            button_croud_help.Image = Image.FromFile("../../Image/3.jpg");
            fifty_fifty = false;
            call = false;
            crowd = false;
            Jessie.Visible = false;
            Jessie_answer.Visible = false;
            congrats.Visible = false;
            groupBox3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar4.Value = 0;
            progressBar1.Visible = false;
            progressBar2.Visible = false;
            progressBar3.Visible = false;
            progressBar4.Visible = false;
            main_timer.Interval = 2000;
            main_timer.Start();
        }

        private void label_draw()
        {
            String label_name;
            Boolean _break = false;
            for (Int32 i = 15; i >= 0; i--)
            {
                if (i == 0)
                {
                    label_name = "label_1";
                    foreach (Control item in Controls)
                    {
                        if (item.Name.Equals(label_name))
                        {
                            item.BackColor = Color.Olive;
                            break;
                        }
                    }
                    break;
                }
                label_name = "label_" + i.ToString();
                foreach (Control item in Controls)
                {
                    if (item.Name.Equals(label_name))
                    {
                        if (item.BackColor == Color.Olive)
                        {
                            item.BackColor = Color.Black;
                            i++;
                            label_name = "label_" + i.ToString();
                            foreach (Control item1 in Controls)
                            {
                                if (item1.Name.Equals(label_name))
                                {
                                    item1.BackColor = Color.Olive;
                                    _break = true;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                if (_break)
                    break;
            }
        }

        private void Jessie_timer_Tick(object sender, EventArgs e)
        {
            Jessie.Visible = true;
            Jessie_answer.Visible = true;
            clues?.Invoke("button_call_to_a_friend");
            Jessie_timer.Stop();
        }

        private void timer_progress4_Tick(object sender, EventArgs e)
        {
            if (progressBar4.Value < Crowd_help_D)
                progressBar4.Increment(5);
            else
                timer_progress4.Stop();
        }

        private void timer_progress2_Tick(object sender, EventArgs e)
        {
            if (progressBar2.Value < Crowd_help_B)
                progressBar2.Increment(5);
            else
                timer_progress2.Stop();
        }

        private void timer_progress3_Tick(object sender, EventArgs e)
        {
            if (progressBar3.Value < Crowd_help_C)
                progressBar3.Increment(5);
            else
                timer_progress3.Stop();
        }

        private void timer_progress1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < Crowd_help_A)
                progressBar1.Increment(5);
            else
                timer_progress1.Stop();
        }


        #region Меню
        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit_new_leave?.Invoke(Button_new_game.Name);
            SoundPlayer Gong = new SoundPlayer("../../sound/gong.wav");
            Gong.Play();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void добавлениеВопросаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Question_Add form_Question_Add = new Form_Question_Add();
            Presenter_Add_Question presenter_Add_Question = new Presenter_Add_Question(form_Question_Add);
            Close();
            form_Question_Add.ShowDialog();
        }

        private void удаToolStripMenuItem_Click(object sender, EventArgs e)     //редактирование
        {
            Form_Question_Edit form_Question_Edit = new Form_Question_Edit();
            Presenter_Edit_Question presenter_Edit_Question = new Presenter_Edit_Question(form_Question_Edit);
            Close();
            form_Question_Edit.ShowDialog();
        }
        private void удалитьВопросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_question delete_Question = new Delete_question();
            Presenter_Delete presenter_Delete = new Presenter_Delete(delete_Question);
            Close();
            delete_Question.ShowDialog();
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Who Wants to Be a Milloinare\nV.1.0\nDrey Smal");
        }
        #endregion

    }
}
