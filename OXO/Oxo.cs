using System;
using static System.Console;

class Oxo{
    int[] boardArray;
    bool win = false;
    int player = 1;
    int playerInput = 0;

    // public static void Main(){
    //     int[] boardArray = new int[9];

                

    // }

    public void TakeTurn(){

        WriteLine("Please give a position in numbers from 1 to 9 to set on the board");
        Write(">");
        playerInput = int.Parse(Console.ReadLine());

        if(playerInput > 0 && playerInput <= 9){                    //Check if position is empty
            CheckWin();
            CreateBoard(playerInput);
        }             
        else WriteLine("The selected position is invalid!");

    }

    public void CreateBoard(int input){

        for(int i = 1; i <= boardArray.Length; i++){
            if (boardArray[input] == 0)
                WriteLine("Error: The selected position is already taken!");
            else{
                boardArray[input] = player;

            }
        }

        WriteLine(boardArray[7] + " | " + boardArray[8] + " | " + boardArray[9]);
        WriteLine("-------------");
        WriteLine(boardArray[4] + " | " + boardArray[5] + " | " + boardArray[6]);
        WriteLine("-------------");
        WriteLine(boardArray[1] + " | " + boardArray[2] + " | " + boardArray[3]);

    }

    public void CheckWin(){

        for(int i = 1; i <= boardArray.Length; i ++ ){

            // check horizontal rows
            if(boardArray[7] == boardArray[8] && boardArray[8] == boardArray[9]){
                win = true;
            }
            else if(boardArray[4] == boardArray[5] && boardArray[5] == boardArray[6]){
                win = true;
            }
            else if(boardArray[1] == boardArray[2] && boardArray[2] == boardArray[3]){
                win = true;
            }

            // check vertical rows
            else if(boardArray[7] == boardArray[4] && boardArray[4] == boardArray[1]){
                win = true;
            }
            else if(boardArray[8] == boardArray[5] && boardArray[5] == boardArray[2]){
                win = true;
            }
            else if(boardArray[9] == boardArray[6] && boardArray[6] == boardArray[3]){
                win = true;
            }


            // check diagonal rows
            else if(boardArray[7] == boardArray[5] && boardArray[5] == boardArray[3]){
                win = true;
            }
            else if(boardArray[1] == boardArray[5] && boardArray[5] == boardArray[9]){
                win = true;
            }

            else win = false;
            
        }

    }

}