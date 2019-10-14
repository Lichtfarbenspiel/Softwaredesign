using System;

public class Person{
    public String FirstName;
    public String LastName;
    public DateTime DateOfBirth;

    

    public override string ToString(){
        
        return new String(LastName + ", " + FirstName + ", Date of Birth: " + DateOfBirth);
    }

    public static void People(){

        Person[] ListOfPeople = new Person[5];
        
        ListOfPeople[0] = new Person{LastName="Bond", FirstName="James", DateOfBirth = new DateTime(1920,11,11)};
        ListOfPeople[1] = new Person{LastName="Johnson", FirstName="Mark", DateOfBirth = new DateTime(1985,08,23)};
        ListOfPeople[2] = new Person{LastName="Lange", FirstName="Dorothea", DateOfBirth = new DateTime(1895,05,26)};
        ListOfPeople[3] = new Person{LastName="Poppins", FirstName="Mary", DateOfBirth = new DateTime(1964,08,27)};
        ListOfPeople[4] = new Person{LastName="Watson", FirstName="Emma", DateOfBirth = new DateTime(1990,04,15)};

        int year = 1950;
        string character = "o";
        
        int count = 0; 


        Console.WriteLine("People born before: " + year + ":");
        foreach(Person element in ListOfPeople)
        {

            if (element.DateOfBirth.Year <= 1950){
                Console.WriteLine(element.ToString());
                count++;
            }
        }

        Console.WriteLine("\n");
        Console.WriteLine("Names that contain the letter " + character + ":");
        foreach(Person element in ListOfPeople)
        {            
            if (element.LastName.Contains(character)){
                Console.WriteLine(element.ToString());
                count++;
            }
            // else{
            //     Console.WriteLine("Error: There is no name in this list that contains the letter " + character + "!");
            //     count ++;
            // }
        }
    }
}
