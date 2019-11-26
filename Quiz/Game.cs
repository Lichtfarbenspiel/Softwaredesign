using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Diagnostics;

namespace Softwaredesign.Quiz
{
    class Game
    {
        public List<QuizElement> quizzes = new List<QuizElement>();
        int score = 0;
        int quizCount = 0;
        string MsgWrongAnswer = "Sorry the selected answer is wrong.";
        string MsgCorrectAnswer = "Congratulations! The selected answer ist correct.";

        public static void Main()
        {
            Game game = new Game();
            game.Menu();
        }

        void Menu(){

            int selection = 0;
            string input;

            WriteLine("QUIZ_____________________________________");
            WriteLine("Score: " + score);
            WriteLine("Questions already answered: " + quizCount);
            WriteLine("_________________________________________");
            WriteLine("Please Select:");
            WriteLine("• Enter '1' to play the quiz");
            WriteLine("• Enter '2' to add a new quiz element");
            WriteLine("• Enter '0' to quit the application");
            Write(">");
            input = ReadLine();
            // WriteLine(input);
            selection = Int32.Parse(input);

            switch(selection){
                case 0:
                    Debugger.Break();
                    break;
                case 1: 
                    PlayQuiz();
                    break;
                case 2:
                    AddUserQuiz();
                    break;
            }
        }

        void PlayQuiz()
        {
            var rnd = new Random();
            var rndList = quizzes.OrderBy(item => rnd.Next());

            var currentQuiz = rndList.ElementAt(0);
            currentQuiz.Display();

            Write(">");
            string userInput = ReadLine();

            bool check = currentQuiz.CheckAnswer(userInput);
            if(check == true){
                WriteLine(MsgCorrectAnswer);
                score += 2;
            }
            else{
                WriteLine(MsgWrongAnswer);
            }
            quizCount +=1;
            Menu();
        }

        void AddUserQuiz(){
            AddQuiz quiz = new AddQuiz();
            WriteLine("Please select a quiz type to add:");
            WriteLine("1: Quess Quiz");
            WriteLine("2: Text Quiz");
            WriteLine("3: True or False Quiz");
            WriteLine("4: Single Choice Quiz");
            WriteLine("5: Multiple Choice Quiz");
            WriteLine("6: Return to Menu");
            Write(">");

            int selection = Read();

            switch(selection){
                case 1:
                    quiz.AddQuizGuess();
                    Menu();
                    break;
                case 2:
                    quiz.AddQuizText();
                    Menu();
                    break;
                case 3:
                    quiz.AddQuizTrueFalse();
                    Menu();
                    break;
                case 4:
                    quiz.AddQuizSingleChoice();
                    Menu();
                    break;
                case 5:
                    quiz.AddQuizMultipleChoice();
                    Menu();
                break;
                case 6:
                    Menu();
                    break;
                
            }

        }

        void DefaultQuizzes(){
            QuizText quizText = new QuizText("What answeres in all languages? Talks without a mouth? Listens without ears?", new Answer("Echo", true));
            quizzes.Add(quizText);
            QuizGuess quizGuess = new QuizGuess("How many Letters has the Hawaiian alphabet?", 0.3f, 12f);
            quizzes.Add(quizGuess);
            QuizTrueFalse quizTrueFalse = new QuizTrueFalse("The Vatican State is not a democracy but the only dictatorship in Europe.", true);
            quizzes.Add(quizTrueFalse);
        }

    }
}