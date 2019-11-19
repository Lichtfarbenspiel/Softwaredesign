using System;
 
class AnotherPerson{
    public string Name;
    public int Age;

    public int Gender;

    public virtual string GetFormOfAddress(){

        if(Age < 21)
            return "Hey " + Name;
        else
            return "Dear Mr/Mrs/Ms " + Name;
    }

}

class Woman : AnotherPerson{
    public override string GetFormOfAddress(){
        return "Dear Mrs/Ms " + Name;
    }
}

class Man : AnotherPerson{
    public override string GetFormOfAddress(){
        return "Dear Mr " + Name;
    }
}