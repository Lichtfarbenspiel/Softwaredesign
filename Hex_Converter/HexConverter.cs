using System;
using static System.Console;
using System.Collections.Generic;

class HexConverter{

    // public static void Main(){
    //      HexConverter.ConvertDecimalToHexal(15);
        
    //     // HexConverter.ConvertHexalToDecimal(23);

    //     // HexConverter.ConvertToBaseFromDecimal(16,150);

    //     // HexConverter.ConvertToDecimalFromBase(16,96);

    //     // HexConverter.ConvertNumberToBaseFromBase(15, 6, 16);
    // }
        

   static int ConvertDecimalToHexal(int dec){
        
        int MaxDecimal = 1023;
        int Base = 6;

        int power = 0;
        int result = 0;
       
        if(dec < 0 || dec > MaxDecimal){
            WriteLine("The input is above the max  decimal number " + MaxDecimal + "!");
            return 0;
        }
        
        for(int i = 0; i <= dec; i ++){
            int division = dec/Base;
            int modulo = dec%Base;
            result += (int)Math.Pow(10, power) * modulo;
            power++;
            dec = division;
        }
                    
        
        WriteLine("The hexal number is " + result);
        return result; 
    }

    static int ConvertHexalToDecimal(int hexal){
        int Base = 6;
        int result = 0;
     
        Char[] hexNumbers = hexal.ToString().ToCharArray();
        
        for(int i = 0; i < hexNumbers.Length; i++){

            int hexChar = (int)Char.GetNumericValue(hexal.ToString(), hexNumbers.Length - i - 1);
            int multiply = (int)Math.Pow(Base, i);
            
            result +=  hexChar * multiply;
        }
        
        WriteLine("The decimal number is " + result);
        return result;
    }

    static int ConvertToBaseFromDecimal(int toBase, int dec){

        int MaxDecimal = 1023;
        int Base = toBase;

        int power = 0;
        int result = 0;
       
        if(dec < 0 || dec > MaxDecimal){
            WriteLine("The input is above the max  decimal number " + MaxDecimal + "!");
            return 0;
        }
        
        for(int i = 0; i <= dec; i ++){
            int division = dec/Base;
            int modulo = dec%Base;
            result += (int)Math.Pow(10, power) * modulo;
            power++;
            dec = division;
        }
                    
        
        WriteLine("The converted number is " + result + " with base " + Base);
        return result; 
    }

    static int ConvertToDecimalFromBase(int fromBase, int number){
        int Base = fromBase;
        int result = 0;
     
        Char[] numberAsArray = number.ToString().ToCharArray();
        
        for(int i = 0; i < numberAsArray.Length; i++){

            int hexChar = (int)Char.GetNumericValue(number.ToString(), numberAsArray.Length - i - 1);
            int multiply = (int)Math.Pow(Base, i);
            
            result +=  hexChar * multiply;
        }
        
        WriteLine("The converted number is " + result + " with base " + Base);
        return result;
    }
    
    static int ConvertNumberToBaseFromBase(int number, int toBase, int fromBase){
        
        int dec = ConvertToDecimalFromBase(fromBase, number);
        int result = ConvertToBaseFromDecimal(toBase, dec);

        WriteLine("The converted number is " + result);
        return result;
    }


}