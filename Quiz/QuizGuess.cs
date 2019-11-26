using System;
using static System.Console;

namespace Softwaredesign.Quiz
{
    class QuizGuess : QuizElement
    {

        float tolerance;
        float correctAnswer;

        public QuizGuess(string question, float tolerance, float correctAnswer) : base(question)
        {
            this.tolerance = tolerance;
            this.correctAnswer = correctAnswer;
        }

        public override void Display()
        {
            WriteLine(instructions);
            WriteLine(question);
        }

        public override bool CheckAnswer(string userInput)
        {
            int guess = int.Parse(userInput);
            float range = correctAnswer*tolerance;

            if(guess <= correctAnswer + range || guess >= correctAnswer - range)
                return true;
            else return false;
        }
    }
}