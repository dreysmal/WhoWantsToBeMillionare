using System;

namespace Who_Wants_to_Become_a_Millionare
{
    class Presenter_Edit_Question
    {
        Model_Edit_Question model_edit_question = new Model_Edit_Question();
        private readonly IquestionEdit iquestionEdit;

        public Presenter_Edit_Question(IquestionEdit iquestionEdit)
        {
            this.iquestionEdit = iquestionEdit;
            iquestionEdit.Edit += new EventHandler<EventArgs>(Edit);
            iquestionEdit.Fill_answers += new EventHandler<EventArgs>(FillAnswers);
            UpdateView();
            FillAnswers(this, EventArgs.Empty);
        }

        public void FillAnswers(Object sender, EventArgs e)
        {
            QuestionAnswersStruct question_answer = model_edit_question.GetAnswers(iquestionEdit.question_checked);
            iquestionEdit.answerA_new_text = question_answer.answerA;
            iquestionEdit.answerB_new_text = question_answer.answerB;
            iquestionEdit.answerC_new_text = question_answer.answerC;
            iquestionEdit.answerD_new_text = question_answer.answerD;
        }

        public void Edit(Object sender, EventArgs e)
        {
            QuestionAnswersStruct question_answer = new QuestionAnswersStruct();
            question_answer.question_old = iquestionEdit.question_checked;
            question_answer.question_new = iquestionEdit.question_new_text;
            question_answer.answerA = iquestionEdit.answerA_new_text;
            question_answer.answerB = iquestionEdit.answerB_new_text;
            question_answer.answerC = iquestionEdit.answerC_new_text;
            question_answer.answerD = iquestionEdit.answerD_new_text;
            model_edit_question.Edit(question_answer);
            UpdateView();
        }
        public void UpdateView()
        {
            iquestionEdit.List_of_questions = model_edit_question.questions;
        }
    }
}
