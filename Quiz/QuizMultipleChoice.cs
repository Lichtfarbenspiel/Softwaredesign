using System;
using static System.Console;

namespace Softwaredesign.Quiz
{
    class QuizMultipleChoice : QuizElement
    {

        Answer[] answers;
        new string instructions = "'Multiple Choice' Please enter all the numbers separated only by a ',' (komma) of those answers you believe are correct. Example: '1,3,4,5' When finished press the 'enter' key.";

        public QuizMultipleChoice(string question, Answer[] answers) : base(question)
        {
            this.answers = answers;
        }

        public override void Display()
        {   
            int count = 1;

            WriteLine(instructions);
            WriteLine(question);
           
            for(int i = 0; i < answers.Length; i++){
                WriteLine(count + ": " + answers[i]);
                count ++;
            }

        }

        public override bool CheckAnswer(string userInput)
        {
            bool selection = false;

            int[] number = Array.ConvertAll(userInput.Split(','), int.Parse);
;

            for(int i = 1; i < answers.Length; i++){
                
                if(number[i-1] == i && answers[i].isTrue)
                    selection = true;
                else if(number[i-1] == i && !answers[i].isTrue)
                    selection = false;
                else 
                    WriteLine(MsgWrongInput);
                    selection = false;
            }
            return selection;
        }

        // public override bool CheckAnswer(string[] userInput)
        // {
        //     bool selection = false;
        //     int[] number = int.Parse(userInput);

        //     for(int i = 0; i < answers.Length; i++){
                
        //         if(number[i] == i && answers[i].isTrue)
        //             selection = true;
        //         else if(number[i] == i && !answers[i].isTrue)
        //             selection = false;
        //         else 
        //             WriteLine(MsgWrongInput);
        //             selection = false;
        //     }
        //     return selection;
        // }
    }
}