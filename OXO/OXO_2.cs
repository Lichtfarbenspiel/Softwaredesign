using System;
using System.Text.RegularExpressions;
using static System.Console;

class OXO_2{
    
    int[,] board = new int[3,3];

    // static void Main(){
    //     bool player = true;
    // }

    void DrawBoard(){
        
        WriteLine(" A B C");
        WriteLine("1" + board[1,3]);
        WriteLine("2" + board[2,3]);
        WriteLine("3" + board[3,3]);

    }

    private static readonly Regex inputFormat = new Regex(@"^\d\d$");

    void ReadPlayerInput(){
        bool check = false;

        WriteLine("Please give the desired line and column seperated by - to set the position on the board!");
        Write(">");

        string playerInput = ReadLine();
        
        
        if(inputFormat.IsMatch(playerInput))
            check = true;
        else{
            check = false; 
            WriteLine("Error: The given position is invalid!");
        }

        if(check == true){
            char[] inputCharacters = playerInput.ToCharArray();
            
                int number = inputCharacters[0];
            char letter = inputCharacters[1];

        }
        

    }

    void CheckWinConditions(){

    }

    void CheckIfBoardIsFull(){

    }
}