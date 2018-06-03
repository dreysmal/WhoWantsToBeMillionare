using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Who_Wants_to_Become_a_Millionare
{
    public partial class Form_Question_Edit : Form, IquestionEdit
    {
        public Form_Question_Edit()
        {
            InitializeComponent();
        }

        public List<string> List_of_questions
        {
            set
            {
                comboBox1.DataSource = value;
            }
        }

        public string question_checked
        {
            get
            {
                return comboBox1.SelectedItem.ToString();
            }
        }

        public string question_new_text
        {
            set
            {
                textBox1.Text = value;
            }
            get
            {
                return textBox1.Text.Trim();
            }
        }

        public string answerA_new_text
        {
            set
            {
                textBox2.Text = value;
            }
            get
            {
                return textBox2.Text.Trim();
            }
        }

        public string answerB_new_text
        {
            set
            {
                textBox3.Text = value;
            }
            get
            {
                return textBox3.Text.Trim();
            }
        }

        public string answerC_new_text
        {
            set
            {
                textBox4.Text = value;
            }
            get
            {
                return textBox4.Text.Trim();

            }
        }

        public string answerD_new_text
        {
            set
            {
                textBox5.Text = value;
            }
            get
            {
                return textBox5.Text.Trim();
            }
        }

        public event EventHandler<EventArgs> Edit;
        public event EventHandler<EventArgs> Fill_answers;

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(question_new_text) || string.IsNullOrEmpty(answerA_new_text) || string.IsNullOrEmpty(answerB_new_text) || string.IsNullOrEmpty(answerC_new_text) || string.IsNullOrEmpty(answerD_new_text))
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                Edit?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Изменения внесены");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            question_new_text = comboBox1.Text;
            Fill_answers?.Invoke(this, EventArgs.Empty);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            question_new_text = comboBox1.Text;
            Fill_answers?.Invoke(this, EventArgs.Empty);
        }
    }
}
