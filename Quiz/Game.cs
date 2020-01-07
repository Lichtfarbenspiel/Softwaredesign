using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

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
            game.DefaultQuiz();
            game.Menu();
           
        }

        void Menu(){

            int selection = 0;
            string input;

            Console.Clear();
            WriteLine("QUIZ_____________________________________");
            WriteLine("Score: " + score);
            WriteLine("Questions already answered: " + quizCount);
            WriteLine("_________________________________________");
            WriteLine("Please Select:");
            WriteLine("• Enter '1' to play the quiz");
            WriteLine("• Enter '2' to add a new quiz element");
            WriteLine("• Enter '0' to quit the application");
            WriteLine("\n");
            Write(">");
            input = ReadLine();
            // WriteLine(input);
            selection = Int32.Parse(input);

            switch(selection){
                case 0:
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
            Console.Clear();
            Random rnd = new Random();
            // var rndList = quizzes.OrderBy(item => rnd.Next());

            int number  = rnd.Next(0, quizzes.Count);

            var currentQuiz = quizzes.ElementAt(number);
            currentQuiz.Display();

            Write(">");
            string userInput = ReadLine();

            bool check = currentQuiz.CheckAnswer(userInput);
            if(check == true){
                WriteLine("\n");
                WriteLine(MsgCorrectAnswer);
                WriteLine("\n");
                score += 2;
            }
            else{
                WriteLine(MsgWrongAnswer);
            }
            quizzes.Remove(currentQuiz);
            quizCount +=1;
            Menu();
        }

        void DefaultQuiz(){
            readQuizTextJsn();
            readQuizGuessJsn();
            readQuizTrueFalseJsn();
            readQuizSingleChoiceJsn();
        }

        string pathText = "Quiz/QuizTextJsn.json";

        void readQuizTextJsn(){
            List<QuizText> quizList = new List<QuizText>();

            using(StreamReader r = new StreamReader(pathText)){
                string json = r.ReadToEnd();
                quizList = JsonConvert.DeserializeObject<List<QuizText>>(json);
            }

            foreach(QuizText element in quizList){
                quizzes.Add(element);
            }
        }

        void readQuizGuessJsn(){
            string path = "C:/Repositories/HFU/Softwaredesign/Quiz/QuizGuessJsn.json";
            List<QuizGuess> quizList = new List<QuizGuess>();

            using(StreamReader r = new StreamReader(path)){
                string json = r.ReadToEnd();
                quizList = JsonConvert.DeserializeObject<List<QuizGuess>>(json);
            }

            foreach(QuizGuess element in quizList){
                quizzes.Add(element);
            }
        }

        void readQuizTrueFalseJsn(){
            string path = "C:/Repositories/HFU/Softwaredesign/Quiz/QuizTrueFalseJsn.json";
            List<QuizTrueFalse> quizList = new List<QuizTrueFalse>();

            using(StreamReader r = new StreamReader(path)){
                string json = r.ReadToEnd();
                quizList = JsonConvert.DeserializeObject<List<QuizTrueFalse>>(json);
            }

            foreach(QuizTrueFalse element in quizList){
                quizzes.Add(element);
            }
        }

        void readQuizSingleChoiceJsn(){
            string path = "C:/Repositories/HFU/Softwaredesign/Quiz/QuizSingleChoiceJsn.json";
            List<QuizSingleChoice> quizList = new List<QuizSingleChoice>();

            using(StreamReader r = new StreamReader(path)){
                string json = r.ReadToEnd();
                quizList = JsonConvert.DeserializeObject<List<QuizSingleChoice>>(json);
            }

            

            foreach(QuizSingleChoice element in quizList){
                quizzes.Add(element);
            }
        }

        void AddUserQuiz(){
            int selection = 0;
            string input;
        
            WriteLine("ADD QUIZ_________________________________");
            WriteLine("Please select a quiz type to add:");
            WriteLine("1: Guess Quiz");
            WriteLine("2: Text Quiz");
            WriteLine("3: True or False Quiz");
            WriteLine("4: Single Choice Quiz");
            WriteLine("5: Multiple Choice Quiz");
            WriteLine("6: Return to Menu");
            WriteLine("\n");
            WriteLine("Enter '0' to quit the application");
            WriteLine("\n");
            Write(">");

            input = ReadLine();
            selection = Int32.Parse(input);


            switch(selection){
                case 0:
                    break;
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

        public string AddObjectsToJson<QuizElement>(string jsonPath, QuizElement element)
        {

            List<QuizElement> quizList = new List<QuizElement>();
            using(StreamReader r = new StreamReader(jsonPath)){
                string json = r.ReadToEnd();
                quizList = JsonConvert.DeserializeObject<List<QuizElement>>(json);
            }
            quizList.Add(element);
            WriteLine(quizList);
            return JsonConvert.SerializeObject(quizList);
        
        }

        string instructionsQuestion = "Please enter the question.";

        void AddQuizGuess()
        {
            Console.Clear();
            WriteLine("ADD GUESS QUIZ___________________________");
            WriteLine("\n");
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

        void AddQuizText()
        {
            Console.Clear();
            WriteLine("ADD TEXT QUIZ____________________________");
            WriteLine("\n");
            WriteLine(instructionsQuestion);
            Write(">");
            string question = ReadLine();
            WriteLine("\n");
            WriteLine("Please enter the answer.");
            Write(">");
            
            string userAnswer = ReadLine();

            Answer answer = new Answer(userAnswer, true);
            QuizText element = new QuizText(question, answer);

            string updatedJson = AddObjectsToJson(pathText, element);
            File.WriteAllText(pathText, updatedJson);
            WriteLine("New quiz element successfully added!");
            WriteLine("\n");
            Thread.Sleep(5000);
    
            Menu();
        }

        void AddQuizTrueFalse()
        {
            bool isTrue = false;
            Console.Clear();
            WriteLine("ADD TRUE/FALSE QUIZ______________________");
            WriteLine("\n");
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

        void AddQuizMultipleChoice()
        {
            Answer[] answers = new Answer[6];
            string correctAnswer = "";
            string wrongAnswer = "";
            int count = 0;

            Console.Clear();
            WriteLine("ADD MULTIPLE CHOICE QUIZ_________________");
            WriteLine("\n");
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
            Console.Clear();
            WriteLine("ADD SINGLE CHOICE QUIZ___________________");
            WriteLine("\n");
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