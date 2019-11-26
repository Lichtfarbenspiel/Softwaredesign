using System;
using System.Collections.Generic;
using static System.Console;

namespace Softwaredesign.Quiz
{
    class AddQuiz
    {
        string instructionsQuestion = "Please enter the question.";
        

        public QuizText AddQuizText()
        {
            WriteLine(instructionsQuestion);
            Write(">");
            string question = ReadLine();
            WriteLine("Please enter the answer.");
            Write(">");
            string userAnswer = ReadLine();

            Answer answer = new Answer(userAnswer, true);
            QuizText quizText = new QuizText(question, answer);
            
            return quizText;
        }

        public QuizTrueFalse AddQuizTrueFalse()
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

            QuizTrueFalse quizTrueFalse = new QuizTrueFalse(question, isTrue);
          return quizTrueFalse;
        }

        public QuizGuess AddQuizGuess()
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

            QuizGuess quizGuess = new QuizGuess(question, tolerance, answer);
            return quizGuess;
        }

        public QuizMultipleChoice AddQuizMultipleChoice()
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

            QuizMultipleChoice quizMultipleChoice = new QuizMultipleChoice(question, answers);
            return quizMultipleChoice;

        }
        public QuizSingleChoice AddQuizSingleChoice()
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

            QuizSingleChoice quizSingleChoice = new QuizSingleChoice(question, answers);
            return quizSingleChoice;
        }
    }
}