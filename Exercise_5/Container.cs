using System;

class Container{

    private object[] ObjectsList; 
    private int counts;

    public Container(){
        ObjectsList = new object[2];
        counts = 0;
    }

    public void AddObjects(object obj){
        if(counts == ObjectsList.Length){
            object[] oldArray = ObjectsList;
            ObjectsList = new object[2 * oldArray.Length];
            Array.Copy(oldArray, ObjectsList, counts);
        }
        ObjectsList[counts] = 0;
        counts++;
    }

    public object GetAt(int i){
        return ObjectsList[i];
    }

    public int Count
    {
        get { return counts; }
    }
}