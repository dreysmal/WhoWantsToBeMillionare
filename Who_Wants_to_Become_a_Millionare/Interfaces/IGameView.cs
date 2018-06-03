using System;

namespace Who_Wants_to_Become_a_Millionare
{
    public delegate void voidDelegate (String Button_Name);
    public delegate bool boolDelegate (String Button_Name);
    public delegate void voidDelegatevoid();
    public interface IGameView
    {
        String Buffer_label_question_text { get; set; }
        String Buffer_label_AnswerA_text { get; set; }
        String Buffer_label_AnswerB_text { get; set; }
        String Buffer_label_AnswerC_text { get; set; }
        String Buffer_label_AnswerD_text { get; set; }
        String Jessie_thoughts { get; set; }
        Int32 Crowd_help_A { get; set; }
        Int32 Crowd_help_B { get; set; }
        Int32 Crowd_help_C { get; set; }
        Int32 Crowd_help_D { get; set; }

        void set_window_to_default();
        void vin();

        event voidDelegate exit_new_leave;
        event boolDelegate questions_answers;
        event voidDelegatevoid next_question;
        event voidDelegate clues;
    }
}
