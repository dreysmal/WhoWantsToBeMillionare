using System.Collections.Generic;
using System.Linq;

namespace Who_Wants_to_Become_a_Millionare
{
    class Model_delete_question
    {
        public List<string> questions;
        public List<EntityDM.Answers> answersList;

        public Model_delete_question()
        {
            Update();
        }

        public void Update()
        {
            questions = new List<string>();
            try
            {
                using (var db = new EntityDM.MillionareDBEntities3())
                {
                    answersList = db.Answers.ToList();
                    List<EntityDM.Questions> questionsList = db.Questions.ToList();
                    foreach (var item in questionsList)
                    {
                        questions.Add(item.Question);
                    }
                }
            }
            catch { throw; }
        }
        public void delete(string qeuestion_)
        {
            try
            {
                using (var db = new EntityDM.MillionareDBEntities3())
                {
                    IQueryable<EntityDM.Questions> question = db.Questions;
                    IQueryable<EntityDM.Answers> answer = db.Answers;
                    var q = question.Where(x => x.Question.Equals(qeuestion_)).ToList().First();
                    var a =answer.Where(x => x.Questions_FK == q.Id).ToList().First();
                    db.Answers.Remove(a);
                    db.Questions.Remove(q);
                    db.SaveChanges();
                    Update();
                }
            }
            catch
            { throw; }
        }
    }
}
