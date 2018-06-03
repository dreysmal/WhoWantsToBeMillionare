using System;
using System.Linq;
using System.Collections.Generic;

namespace Who_Wants_to_Become_a_Millionare
{
    class Presenter_Delete
    {
        Model_delete_question model_Delete_Question = new Model_delete_question();
        private readonly IquestionDelete iquestionDelete;

        public Presenter_Delete(IquestionDelete iquestionDelete)
        {
            this.iquestionDelete = iquestionDelete;
            iquestionDelete.delete += new EventHandler<EventArgs>(Delete);
            UpdateView();
        }

        public void Delete(Object sender, EventArgs e)
        {
            model_Delete_Question.delete(iquestionDelete.Selected_question);
            UpdateView();
        }
        public void UpdateView()
        {
            iquestionDelete.List_of_questions = model_Delete_Question.questions;
        }
    }
}
