using System;
using System.Collections.Generic;
namespace Who_Wants_to_Become_a_Millionare
{
    interface IquestionDelete
    {
        List<string> List_of_questions { set; }
        string Selected_question { get; }
        event EventHandler<EventArgs> delete;
    }
}
