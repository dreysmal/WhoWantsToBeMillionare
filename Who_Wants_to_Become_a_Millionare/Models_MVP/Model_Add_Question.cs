using System;
using System.Data;
using System.Linq;

namespace Who_Wants_to_Become_a_Millionare
{
    class Model_Add_Question
    {
        public void Insert(Int32 diff, String qeuestion_, String answerA, String answerB, String answerC, String answerD)
        {
            try
            {
                using (var db = new EntityDM.MillionareDBEntities3())
                {
                    if(db.Questions.Where(x => x.Question.Equals(qeuestion_)).ToList().Count == 0)
                    {
                        var question = new EntityDM.Questions { Difficulty = diff, Question = qeuestion_ };
                        db.Questions.Add(question);
                        db.SaveChanges();
                        var answer = new EntityDM.Answers
                        {
                            Questions_FK = db.Questions.Where(x => x.Question.Equals(qeuestion_)).ToList().First().Id,
                            Answer_A = answerA,
                            Answer_B = answerB,
                            Answer_C = answerC,
                            Answer_D = answerD
                        };
                        db.Answers.Add(answer);
                        db.SaveChanges();
                    }
                    else
                    {
                        throw (new Exception("Такой вопрос уже есть в базе"));
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    } 
}
