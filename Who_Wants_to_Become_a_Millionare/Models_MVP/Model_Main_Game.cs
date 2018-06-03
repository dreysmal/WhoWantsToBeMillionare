using System;
using System.Collections.Generic;
using System.Linq;

namespace Who_Wants_to_Become_a_Millionare
{
    class Model_Main_Game
    {
        public int number_of_current_question = 0;
        public int Id_of_question;
        List<int> used_questions_id = new List<int>();
        public List<EntityDM.Questions> questionsList;
        public List<EntityDM.Answers> answersList;

        public Model_Main_Game()
        {
            try
            {
                using (var db = new EntityDM.MillionareDBEntities3())
                {
                    questionsList = db.Questions.ToList();
                    answersList = db.Answers.ToList();
                }
            }
            catch { throw; }
        }
        public void Game()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            //простые вопросы. Первая пятерка

            if (number_of_current_question >= 0 && number_of_current_question < 5)
            {
                var first_level_questions = questionsList.Where(x => x.Difficulty == 1).ToList();
                if (first_level_questions.Count >= 5)
                {
                    Id_of_question = first_level_questions[rnd.Next(0, first_level_questions.Count)].Id;
                    while (used_questions_id.Contains(Id_of_question))
                    {
                        Id_of_question = first_level_questions[rnd.Next(0, first_level_questions.Count)].Id;
                    }
                }
                else throw (new Exception("В базе данных не хватает вопросов первого уровня для корректной работы приложения"));
                used_questions_id.Add(Id_of_question);
            }

            //средние вопросы. Вторая пятерка
            if (number_of_current_question >= 5 && number_of_current_question < 10)
            {
                var second_level_questions = questionsList.Where(x => x.Difficulty == 2).ToList();
                if (second_level_questions.Count >= 5)
                {
                    Id_of_question = second_level_questions[rnd.Next(0, second_level_questions.Count)].Id;
                    while (used_questions_id.Contains(Id_of_question))
                    {
                        Id_of_question = second_level_questions[rnd.Next(0, second_level_questions.Count)].Id;
                    }
                }
                else throw (new Exception("В базе данных не хватает вопросов второго уровня для корректной работы приложения"));
                used_questions_id.Add(Id_of_question);
            }

            //тяжелые вопросы. Третья пятерка
            if (number_of_current_question >= 10 && number_of_current_question < 15)
            {
                var third_level_questions = questionsList.Where(x => x.Difficulty == 3).ToList();
                if (third_level_questions.Count >= 5)
                {
                    Id_of_question = third_level_questions[rnd.Next(0, third_level_questions.Count)].Id;
                    while (used_questions_id.Contains(Id_of_question))
                    {
                        Id_of_question = third_level_questions[rnd.Next(0, third_level_questions.Count)].Id;
                    }
                }
                else throw (new Exception("В базе данных не хватает вопросов третьего уровня для корректной работы приложения"));
                used_questions_id.Add(Id_of_question);
            }
            number_of_current_question++;
        }

        public Boolean Is_Answer_Correct(String text)
        {
            var answers = answersList.ToList();
            foreach (var answer in answers)
            {
                if(answer.Answer_A.Equals(text.Remove(0, 3)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
