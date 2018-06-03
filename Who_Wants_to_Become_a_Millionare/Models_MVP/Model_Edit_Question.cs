using System;
using System.Collections.Generic;
using System.Linq;

namespace Who_Wants_to_Become_a_Millionare
{
    class Model_Edit_Question
    {
        public List<string> questions;
        public List<EntityDM.Answers> answersList;

        public Model_Edit_Question()
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
        public QuestionAnswersStruct GetAnswers(String question)
        {
            using (var db = new EntityDM.MillionareDBEntities3())
            {
                IQueryable<EntityDM.Answers> answers = db.Answers;
                var answer = answers.Where(x => x.Questions.Question == question).ToList().First();
                QuestionAnswersStruct qa = new QuestionAnswersStruct();
                qa.answerA = answer.Answer_A;
                qa.answerB = answer.Answer_B;
                qa.answerC = answer.Answer_C;
                qa.answerD = answer.Answer_D;
                return qa; 
            }      
        }
        public void Edit(QuestionAnswersStruct qa)
        {
            try
            {
                using (var db = new EntityDM.MillionareDBEntities3())
                {
                    IQueryable<EntityDM.Questions> q = db.Questions;
                    IQueryable<EntityDM.Answers> a = db.Answers;
                    var question = q.Where(x => x.Question.Equals(qa.question_old)).ToList().First();
                    var answer = a.Where(x => x.Questions_FK == question.Id).ToList().First();
                    answer.Answer_A = qa.answerA;
                    answer.Answer_B = qa.answerB;
                    answer.Answer_C = qa.answerC;
                    answer.Answer_D = qa.answerD;
                    question.Question = qa.question_new;
                    db.SaveChanges();
                    Update();
                }
            }
            catch
            { throw; }
        }
    }
}
