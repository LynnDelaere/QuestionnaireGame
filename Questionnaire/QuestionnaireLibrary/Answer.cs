using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireLibrary
{
    public class Answer
    {
        // Attributes
        public string Text;
        public bool IsCorrect;

        // Constructor
        public Answer(string text, bool isCorrect)
        {
            Text = text;
            IsCorrect = isCorrect;
        }
        // ToString override method
        public override string ToString()
        {
            return Text;
        }
    }
}
