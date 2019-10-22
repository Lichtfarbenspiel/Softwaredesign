using System;
using static System.Console;

public class Familytree
    {
        // Ergebnisse in Array speichern 
        
        public static Person Find(Person person) // Verweis auf Array mitgeben als Parameter  
        {
            // var LifeSpan = person.DateOfDeath - person.DateOfBirth;

            Person ret = null;
             if (person.LastName != "Battenberg")
                  return person;

            if(person == null){
                return null;
            }

            
            if (person.Mom != null){
                ret = Find(person.Mom);
            }
            if (ret != null)
                return ret;

            if (person.Dad != null){
                ret = Find(person.Dad);
            }
            if (ret != null)
                return ret;
            return null;
        }


        public static Person BuildTree()
        {
            return  
                new Person { FirstName = "Willi", LastName = "Cambridge", DateOfBirth=new DateTime(1982, 07, 21),
                    Mom = new Person { FirstName = "Diana", LastName = "Spencer", DateOfBirth = new DateTime(1961, 07, 01),
                        Mom = new Person {FirstName = "Franzi", LastName="Roche", DateOfBirth = new DateTime(1936, 01, 20), DateOfDeath = new DateTime(2000, 12, 21),
                            Mom = new Person {FirstName = "Ruth", LastName="Gill", DateOfBirth = new DateTime(1908, 06, 07), DateOfDeath = new DateTime(1982, 02, 15)},
                            Dad = new Person {FirstName = "Moritz", LastName="Roche", DateOfBirth = new DateTime(1885, 07, 08), DateOfDeath = new DateTime(1853, 10, 24)}
                        },
                        Dad = new Person {FirstName = "Eddie", LastName="Spencer", DateOfBirth = new DateTime(1924, 01, 24), DateOfDeath = new DateTime(1992, 06, 01),
                            Mom = new Person {FirstName = "Cynthia", LastName="Hamilton", DateOfBirth = new DateTime(1897, 08, 16), DateOfDeath = new DateTime(1975, 07, 18)},
                            Dad = new Person {FirstName = "Albert", LastName="Spencer", DateOfBirth = new DateTime(1892, 05, 23), DateOfDeath = new DateTime(1968, 12, 24)}
                        },
                    },
                    Dad = new Person {FirstName = "Charlie", LastName = "Wales", DateOfBirth = new DateTime(1948, 11, 14), 
                        Mom = new Person {FirstName = "Else", LastName="Windsor", DateOfBirth = new DateTime(1926, 04, 21), DateOfDeath = new DateTime(2001, 08, 19),
                            Mom = new Person {FirstName = "Lisbeth", LastName="Bowes-Lyon", DateOfBirth = new DateTime(1900, 08, 04), DateOfDeath = new DateTime(1977, 10, 06)},
                            Dad = new Person {FirstName = "Schorsch-Albert", LastName="York", DateOfBirth = new DateTime(1895, 12, 14), DateOfDeath = new DateTime(1979, 04, 22)}
                        },
                        Dad = new Person {FirstName = "Philip", LastName="Battenberg", DateOfBirth = new DateTime(1921, 06, 10), DateOfDeath = new DateTime(1995, 08, 16),
                            Mom = new Person {FirstName = "Alice", LastName="Battenberg", DateOfBirth = new DateTime(1885, 02, 25), DateOfDeath = new DateTime(1958, 10, 12)},
                            Dad = new Person {FirstName = "Andi", LastName="ElGreco", DateOfBirth = new DateTime(1882, 02, 01), DateOfDeath = new DateTime(1960, 07, 10)},
                        },
                    },
                };
        }
    }