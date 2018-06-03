using System;
using System.Collections.Generic;
using System.Linq;

namespace Who_Wants_to_Become_a_Millionare
{
    class Game_Presenter
    {
        Model_Main_Game model_main_game;
        private readonly IGameView gameView;

        public Game_Presenter(IGameView _gameView)
        {
            model_main_game = new Model_Main_Game();
            gameView = _gameView;
            try
            {
                model_main_game.Game();
            }
            catch { throw; }
            var question = model_main_game.questionsList.Where(x => x.Id == model_main_game.Id_of_question).ToList().First();
            gameView.Buffer_label_question_text = question.Question.ToString();
            Fill_answers_buffer_labels();

            gameView.exit_new_leave += exit_new_leave_meth;
            gameView.questions_answers += questions_Answers_meth;
            gameView.next_question += next_question;
            gameView.clues += clues_meth;
        }

        public void exit_new_leave_meth(String button_Name)
        {
            if (button_Name.Equals("Button_new_game"))
            {
                gameView.set_window_to_default();
                model_main_game = new Model_Main_Game();
                model_main_game.number_of_current_question = 0;
                try
                {
                    model_main_game.Game();
                }
                catch { throw; }
                var question = model_main_game.questionsList.Where(x => x.Id == model_main_game.Id_of_question).ToList().First();
                gameView.Buffer_label_question_text = question.Question.ToString();
                Fill_answers_buffer_labels();
            }
        }

        public bool questions_Answers_meth(String button_Name)
        {
            Boolean win = false;
            win = model_main_game.Is_Answer_Correct(button_Name);
            if (win && model_main_game.number_of_current_question == 15)
                gameView.vin();
            return win;
        }

        public void next_question()
        {
            try
            {
                model_main_game.Game();
            }
            catch { throw; }
            var question = model_main_game.questionsList.Where(x => x.Id == model_main_game.Id_of_question).ToList().First();
            gameView.Buffer_label_question_text = question.Question.ToString();
            Fill_answers_buffer_labels();
        }

        public void clues_meth(String button_Name)
        {
            switch (button_Name)
            {
                case "button_50_50":
                    Take_50_away();
                    break;
                case "button_call_to_a_friend":
                    call_friend();
                    break;
                case "button_croud_help":
                    crowd();
                    break;
                default:
                    break;
            }
        }
        
        public void Fill_answers_buffer_labels()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            var answer = model_main_game.answersList.Where(x => x.Questions_FK == model_main_game.Id_of_question).ToList().First();
            string[] ansFrom_A_to_D = new string[]
            {
                answer.Answer_A,
                answer.Answer_B,
                answer.Answer_C,
                answer.Answer_D,
            };
            gameView.Buffer_label_AnswerA_text = ansFrom_A_to_D[rnd.Next(0, 4)];

            do
            {
                gameView.Buffer_label_AnswerB_text = ansFrom_A_to_D[rnd.Next(0, 4)];
            }
            while (gameView.Buffer_label_AnswerB_text.Equals(gameView.Buffer_label_AnswerA_text));

            do
            {
                gameView.Buffer_label_AnswerC_text = ansFrom_A_to_D[rnd.Next(0, 4)];
            }
            while (gameView.Buffer_label_AnswerC_text.Equals(gameView.Buffer_label_AnswerA_text) || gameView.Buffer_label_AnswerC_text.Equals(gameView.Buffer_label_AnswerB_text));

            do
            {
                gameView.Buffer_label_AnswerD_text = ansFrom_A_to_D[rnd.Next(0, 4)];
            }
            while (gameView.Buffer_label_AnswerD_text.Equals(gameView.Buffer_label_AnswerA_text) || gameView.Buffer_label_AnswerD_text.Equals(gameView.Buffer_label_AnswerB_text) || gameView.Buffer_label_AnswerD_text.Equals(gameView.Buffer_label_AnswerC_text));
        }

        public void Take_50_away()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            List<Int32> list = new List<Int32>();
            Int32 count = 0;
            while (count < 2)
            {
                Int32 s = rnd.Next(1, 5);
                if (!list.Contains(s))
                {
                    switch (s)
                    {
                        case 1:
                            if (!model_main_game.Is_Answer_Correct("A: " + gameView.Buffer_label_AnswerA_text))
                            {
                                gameView.Buffer_label_AnswerA_text = "";
                                list.Add(s);
                                count++;
                            }
                            break;
                        case 2:
                            if (!model_main_game.Is_Answer_Correct("B: " + gameView.Buffer_label_AnswerB_text))
                            {
                                gameView.Buffer_label_AnswerB_text = "";
                                count++;
                                list.Add(s);
                            }
                            break;
                        case 3:
                            if (!model_main_game.Is_Answer_Correct("C: " + gameView.Buffer_label_AnswerC_text))
                            {
                                gameView.Buffer_label_AnswerC_text = "";
                                count++;
                                list.Add(s);
                            }
                            break;
                        case 4:
                            if (!model_main_game.Is_Answer_Correct("D: " + gameView.Buffer_label_AnswerD_text))
                            {
                                gameView.Buffer_label_AnswerD_text = "";
                                count++;
                                list.Add(s);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void call_friend()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            Boolean isanswer = false;
            while (!isanswer)
            {
                Int32 s = rnd.Next(1, 5);
                switch (s)
                {
                    case 1:
                        if (!String.IsNullOrEmpty(gameView.Buffer_label_AnswerA_text))
                        {
                            gameView.Jessie_thoughts = "Стопудово это " + gameView.Buffer_label_AnswerA_text;
                            isanswer = true;
                        }
                            break;
                    case 2:
                        if (!String.IsNullOrEmpty(gameView.Buffer_label_AnswerB_text))
                        {
                            gameView.Jessie_thoughts = "Стопудово это " + gameView.Buffer_label_AnswerB_text;
                            isanswer = true;
                        }
                        break;
                    case 3:
                        if (!String.IsNullOrEmpty(gameView.Buffer_label_AnswerC_text))
                        {
                            gameView.Jessie_thoughts = "Стопудово это " + gameView.Buffer_label_AnswerC_text;
                            isanswer = true;
                        }
                        break;
                    case 4:
                        if (!String.IsNullOrEmpty(gameView.Buffer_label_AnswerD_text))
                        {
                            gameView.Jessie_thoughts = "Стопудово это " + gameView.Buffer_label_AnswerD_text;
                            isanswer = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void crowd()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            List<Int32> list = new List<Int32>();
            Int32 count = 0;
            Int32 a = 0;
            Int32 b = 0;
            Int32 c = 0;
            Int32 d = 0;
            Int32 g = 0;
            while (count < 4)
            {
                Int32 s = rnd.Next(1, 5);
                if (!list.Contains(s))
                {
                    switch (s)
                    {
                        case 1:
                            if (count == 3)
                            {
                                gameView.Crowd_help_A = 101 - b - c - d;
                                count++;
                            }
                            else
                            {
                                g = 101 - a - b - c - d;
                                gameView.Crowd_help_A = a = rnd.Next(0, g);
                                count++;
                                list.Add(s);
                            }
                            break;
                        case 2:
                            if (count == 3)
                            {
                                gameView.Crowd_help_B = 101 - a - c - d;
                                count++;
                            }
                            else
                            {
                                g = 101 - a - b - c - d;
                                gameView.Crowd_help_B = b = rnd.Next(0, g);
                                count++;
                                list.Add(s);
                            }
                            break;
                        case 3:
                            if (count == 3)
                            {
                                gameView.Crowd_help_C = 101 - b - a - d;
                                count++;
                            }
                            else
                            {
                                g = 101 - a - b - c - d;
                                gameView.Crowd_help_C = c = rnd.Next(0, g);
                                count++;
                                list.Add(s);
                            }
                            break;
                        case 4:
                            if (count == 3)
                            {
                                gameView.Crowd_help_D = 101 - b - c - a;
                                count++;
                            }
                            else
                            {
                                g = 101 - a - b - c - d;
                                gameView.Crowd_help_D = d = rnd.Next(0, g);
                                count++;
                                list.Add(s);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
