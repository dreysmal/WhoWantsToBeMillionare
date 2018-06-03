using System;

namespace Who_Wants_to_Become_a_Millionare
{
    class Presenter_Add_Question
    {
        Model_Add_Question model_Add_Question = new Model_Add_Question();
        private readonly IquestionAdd questionAdd;

        public Presenter_Add_Question(IquestionAdd _iquestionAdd)
        {
            questionAdd = _iquestionAdd;
            questionAdd.Add += new EventHandler<EventArgs>(Add_meth);
        }

        private void Add_meth(Object sender, EventArgs e)
        {
            try
            {
                model_Add_Question.Insert(Int32.Parse(questionAdd.Difficulty),
                                                      questionAdd.Question,
                                                      questionAdd.AnswerA,
                                                      questionAdd.AnswerB,
                                                      questionAdd.AnswerC,
                                                      questionAdd.AnswerD);
            }
            catch
            {
                throw;
            }
        }
    }
}
