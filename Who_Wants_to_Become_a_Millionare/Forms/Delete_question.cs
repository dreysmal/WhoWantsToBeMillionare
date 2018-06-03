using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Who_Wants_to_Become_a_Millionare
{
    public partial class Delete_question : Form, IquestionDelete
    {
        public Delete_question()
        {
            InitializeComponent();    
        }
        public List<string> List_of_questions
        {
            set
            {
                listBox1.DataSource = value;
            }
        }
        public string Selected_question
        {
            get
            {
                return listBox1.SelectedItem.ToString();
            }
        }
        public event EventHandler<EventArgs> delete;

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                delete?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Вопрос удален из базы вопросов");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
