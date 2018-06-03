using System;
using System.Windows.Forms;

namespace Who_Wants_to_Become_a_Millionare
{
    public partial class Form_Question_Add : Form, IquestionAdd
    {
        public String Difficulty
        {
            get { return comboBox1.Text; }
            set { comboBox1.Text = value; }
        }
        public String Question
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public String AnswerA
        {
            get { return textBox2.Text.Trim(); }
            set { textBox2.Text = value; }
        }
        public String AnswerB
        {
            get { return textBox3.Text.Trim(); }
            set { textBox3.Text = value; }
        }
        public String AnswerC
        {
            get { return textBox4.Text.Trim(); }
            set { textBox4.Text = value; }
        }
        public String AnswerD
        {
            get { return textBox5.Text.Trim(); }
            set { textBox5.Text = value; }
        }

        public event EventHandler<EventArgs> Add;

        public Form_Question_Add()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Enabling_Add_Button();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Enabling_Add_Button();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Enabling_Add_Button();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Enabling_Add_Button();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enabling_Add_Button();
        }

        private void Enabling_Add_Button()
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrEmpty(comboBox1.Text))
            {
                button1.Enabled = true;
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "")
            {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Add?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Вопрос добавлен в базу вопросов");
                comboBox1.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
