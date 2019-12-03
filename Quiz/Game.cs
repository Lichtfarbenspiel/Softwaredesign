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

        // public static void Main()
        // {
        //     Game game = new Game();
        //     game.Menu();
        // }

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
            DefaultQuiz();
            Random rnd = new Random();
            // var rndList = quizzes.OrderBy(item => rnd.Next());

            int number  = rnd.Next(0, quizzes.Count);

            var currentQuiz = quizzes.ElementAt(number);
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
            quizzes.Remove(currentQuiz);
            quizCount +=1;
            Menu();
        }

        void AddUserQuiz(){
        
            WriteLine("Please select a quiz type to add:");
            WriteLine("1: Guess Quiz");
            WriteLine("2: Text Quiz");
            WriteLine("3: True or False Quiz");
            WriteLine("4: Single Choice Quiz");
            WriteLine("5: Multiple Choice Quiz");
            WriteLine("6: Return to Menu");
            Write(">");

            int selection = Read();

            // if(selection == 1)
            //     AddQuizGuess();
            // else if(selection == 2)
            //     AddQuizText();
            // else if(selection == 3)
            //     AddQuizText();
            // else if(selection == 4)
            //     AddQuizSingleChoice();
            // else if(selection == 5)
            //     AddQuizMultipleChoice();
            // else if(selection == 6)
            //     Menu();

            switch(selection){
                case 1:
                    AddQuizGuess();
                    break;
                case 2:
                    AddQuizText();                    
                    break;
                case 3:
                    AddQuizTrueFalse();                    
                    break;
                case 4:
                    AddQuizSingleChoice();                    
                    break;
                case 5:
                    AddQuizMultipleChoice();                    
                    break;
                case 6:
                    Menu();
                break;
            }

        }

        void DefaultQuiz(){
            // quizzes.Add(
            //     new QuizText("What answeres in all languages? Talks without a mouth? Listens without ears?", new Answer("Echo", true))
            // );
            // quizzes.Add(
            //     new QuizGuess("How many Letters has the Hawaiian alphabet?", 0.3f, 12f)
            // );
            // quizzes.Add(
            //     new QuizTrueFalse("The Vatican State is not a democracy but the only dictatorship in Europe.", true)
            // );
            quizzes.Add(new QuizMultipleChoice("Who is a Professor at Hogwarts?", new Answer[6]{
                new Answer("Prof. Dumbledore", true), new Answer("Prof. McDonalds", false), new Answer("Prof. MacGonagall", true), new Answer("Prof. Hagrid", false), new Answer("Prof. Umbridge", true), new Answer("Prof. Sniper", false)
            }));
            
        }


        string instructionsQuestion = "Please enter the question.";
        void AddQuizText()
        {
            WriteLine(instructionsQuestion);
            Write(">");
            string question = ReadLine();
            WriteLine("Please enter the answer.");
            Write(">");
            string userAnswer = ReadLine();

            Answer answer = new Answer(userAnswer, true);
            quizzes.Add(new QuizText(question, answer));
            
            Menu();
        }

        void AddQuizTrueFalse()
        {
            bool isTrue = false;
            WriteLine(instructionsQuestion);
            Write(">");
            string question = ReadLine();
            WriteLine("Please enter 'T' if the question is correct. Enter 'F' if it is incorrect.");
            Write(">");
            string input = ReadLine();

            if(input == "T" || input == "t")
                isTrue = true;
            else if(input == "F" || input == "f")
                isTrue = false;

            quizzes.Add(new QuizTrueFalse(question, isTrue));
            Menu();
        }

        void AddQuizGuess()
        {
            WriteLine(instructionsQuestion);
            WriteLine(">");
            string question = ReadLine();

            WriteLine("Please enter the correct answer as a number. It may be a float number seperated by a dot.");
            Write(">");
            float answer = float.Parse(ReadLine());

            WriteLine("Please enter the 'percentage' of the valid tolarance from 0 to 1. E.g. 0.2 for a tolerance of 20%.");
            Write(">");
            float tolerance = float.Parse(ReadLine());

            new QuizGuess(question, tolerance, answer);
            Menu();
        }

        void AddQuizMultipleChoice()
        {
            Answer[] answers = new Answer[6];
            string correctAnswer = "";
            string wrongAnswer = "";
            int count = 0;

            WriteLine(instructionsQuestion);
            WriteLine(">");
            string question = ReadLine();

            WriteLine("Please enter the correct answer");
            Write(">");
            correctAnswer = ReadLine();
            while(correctAnswer != ""){
                for(int i = 0; i <= answers.Length - 1; i++){
                    answers[i].text = correctAnswer;
                    answers[i].isTrue = true;
                    Write(">");
                    correctAnswer = ReadLine();
                    count ++;
                }
            }
           
            WriteLine("Please enter up to 5 more answers which aren't correct.");
            Write(">");
            wrongAnswer = ReadLine();

            while(wrongAnswer != ""){
                for(int i = count + 1; i <= answers.Length - count; i++){
                    answers[i].text = wrongAnswer;
                    answers[i].isTrue = false;
                    Write(">");
                    wrongAnswer = ReadLine();
                }
            }

            quizzes.Add(new QuizMultipleChoice(question, answers));
            Menu();

        }
        void AddQuizSingleChoice()
        {
            Answer[] answers = new Answer[6];
            string answer = "";

            WriteLine(instructionsQuestion);
            WriteLine(">");
            string question = ReadLine();

            WriteLine("Please enter the correct answer");
            Write(">");
            string correctAnswer = ReadLine();
            answers[0].text = correctAnswer;
            answers[0].isTrue = true;

            WriteLine("Please enter up to 5 more answers which aren't correct.");
            Write(">");
            answer = ReadLine();

            while(answer != ""){
                for(int i = 1; i <= answers.Length -1; i++){
                    answers[i].text = answer;
                    answers[i].isTrue = false;
                    Write(">");
                    answer = ReadLine();
                }
            }

            quizzes.Add(new QuizSingleChoice(question, answers));
            Menu();
        }

    }
}