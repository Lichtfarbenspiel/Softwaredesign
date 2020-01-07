using System;
using static System.Console;

namespace Softwaredesign.Quiz
{
    class QuizSingleChoice : QuizElement
    {

        Answer[] answers;
        new string instructions = "'Single Choice' Please enter the number of the answer you believe to be correct. When finished press the 'enter' key.";

        public QuizSingleChoice(string question, Answer[] answers) : base(question)
        {
            this.answers = answers;
        }

        public override void Display()
        {
            int count = 1;
            WriteLine(instructions);
            WriteLine(question);
            
            for(int i = 0; i < answers.Length; i++){
                WriteLine(count + ": " + answers[i].text);
                count ++;
            }
        }

        public override bool CheckAnswer(string userInput)
        {
            bool selection = false;
            int number = int.Parse(userInput);

            for(int i = 0; i < answers.Length; i++){
                
                if(number == i && answers[i].isTrue)
                    selection = true;
                else if(number == i && !answers[i].isTrue)
                    selection = false;
                else 
                    WriteLine(MsgWrongInput);
                    selection = false;
            }
            return selection;
        }
    }
}