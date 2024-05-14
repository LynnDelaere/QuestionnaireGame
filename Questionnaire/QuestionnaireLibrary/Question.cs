using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireLibrary
{
    public class Question
    {
        // Attributes
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; }

        }
        public List<Answer> PossibleAnswers = new List<Answer>();
        private string imageURL;
        public string ImageURL
        {
            get { return imageURL; }
            set { imageURL = value; }
        }
        // Constructor
        public Question(string text)
        {
            this.text = text;
        }
        // Methods
        public void Add(Answer answer)
        {
            PossibleAnswers.Add(answer);
        }
        public Answer GetAnswer(int index)
        {
            return PossibleAnswers[index];
        }
        public string CorrectAnswer()
        {
            foreach (Answer answer in PossibleAnswers)
            {
                if (answer.IsCorrect)
                {
                    return answer.Text;
                }
            }
            return null;
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
