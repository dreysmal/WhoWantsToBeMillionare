using System;

namespace Who_Wants_to_Become_a_Millionare
{
    interface IquestionAdd
    {
        String Difficulty { get; set; }
        String Question { get; set; }
        String AnswerA { get; set; }
        String AnswerB { get; set; }
        String AnswerC { get; set; }
        String AnswerD { get; set; }

        event EventHandler<EventArgs> Add;
    }
}
