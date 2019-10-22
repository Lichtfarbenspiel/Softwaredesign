using System;

public class Person{
    public String FirstName;
    public String LastName;
    public DateTime DateOfBirth;
    public DateTime DateOfDeath;
    public int LifeSpan;

    public Person Mom;
    public Person Dad;
    

    public override string ToString(){
        
        return new String(LastName + ", " + FirstName + ", Date of Birth: " + DateOfBirth + ", Date of Death: " + DateOfDeath);
    }
}