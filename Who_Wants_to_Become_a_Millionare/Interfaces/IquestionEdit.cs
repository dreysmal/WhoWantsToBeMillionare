using System;
using System.Collections.Generic;

namespace Who_Wants_to_Become_a_Millionare
{
    interface IquestionEdit
    {
        List<string> List_of_questions { set; }

        string question_checked { get; }
        string question_new_text { get; set; }
        string answerA_new_text { get; set; }
        string answerB_new_text { get; set; }
        string answerC_new_text { get; set; }
        string answerD_new_text { get; set; }

        event EventHandler<EventArgs> Edit;
        event EventHandler<EventArgs> Fill_answers;
    }
}
