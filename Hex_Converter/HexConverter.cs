using System;
using static System.Console;
using System.Collections.Generic;

class HexConverter{

   public static int ConvertDecimalToHexal(int dec){
        
        int MaxDecimal = 1023;
        int Base = 16;

        int division = 0;
        int modulo = 0;
        List<int> hex = new List<int>();
       
        if(dec >= 0 && dec < MaxDecimal){
            for(int i = 0; i <= dec; i ++){
                division = dec/Base;
                modulo = dec%Base;
                hex.Add(modulo);
                dec = division;
            }
            
        }
        else{
            WriteLine("The input is above the max  decimal number " + MaxDecimal + "!");
            return 0;
        }
        
        hex.Reverse();
        int result = int.Parse(string.Join(",",hex).Replace(",", ""));
        WriteLine(result);
        return result; 
    }

    public static int ConvertHexalToDecimal(int hexal){
        int Base = 16;

        string HexalAsString = hexal.ToString();
        Char[] Numbers = HexalAsString.ToCharArray();
        
        for(int i = 0; i <= hexal; i++){
            double multiply = Math.Pow(Base, i);
        }
        
        
        return 0;
    }

}