using System;
using static System.Console;

class Quiz{

    Elements[] defaultElements;
    Elements[] userGeneratedElements;

    static void Main(){
        Player currentPlayer = new Player();

    }

    static void SelectOptions(Player p){
        WriteLine("To start the game: type '2'. "+"To add custom Questions: type '1'. " + "To quit the Game: type '0'.");
        Write(">");
        int playerInput = int.Parse(Console.ReadLine());

        if(playerInput == 2){
            StartGame(player);
        }
        

    }

    static void GenerateElements(Player p){

    }

    static void StartGame(Player p){

    }

    static Elements MergeElementsArrays(Elements[] d, Elements[] u){

        return;
    }

    static void EvaluateAnswer(Elements q, int a, int b, Player p){

    }

    static int CalculatePoints(Player p){

        return 1;
    }
   
}