using System;
using static System.Console;
using System.Collections.Generic;

namespace Tree{
    
    // class Test{

    //     static void Main(string[] args)
    //     {

    //         var tree = new Tree<string>();

    //         var root = tree.CreateNode("root");

    //         root.AddListener("AppendChild", HandleAppendChild);
    //         root.AddListener("AppendChild", HandleAppendChild);

    //         var child_A = tree.CreateNode("child_A");
    //         var child_B = tree.CreateNode("child_B");

    //         root.AppendChild(child_A);
    //         root.AppendChild(child_B);

    //         var grand_A1 = tree.CreateNode("grand_A1");
    //         var grand_A2 = tree.CreateNode("grand_A2");
    //         var grand_A3 = tree.CreateNode("grand_A3");

    //         child_A.AppendChild(grand_A1);
    //         child_A.AppendChild(grand_A2);
    //         child_A.AppendChild(grand_A3);

    //         var grand_B1 = tree.CreateNode("grand_B1");
    //         var grand_B2 = tree.CreateNode("grand_B2");
            
    //         child_B.AppendChild(grand_B1);
    //         child_B.AppendChild(grand_B2);
    //         // child_A.RemoveChild(grand_A1);

    //         tree.Print(root); 

    //         root.ForEach(Function<string>);

    //         foreach (var child in root)
    //         {
    //             Console.WriteLine(child.type);
    //         }
    //     }

    //     static void Function<T>(Tree<T>.TreeNode node)
    //     {
    //         Console.Write(node.type + ", ");
    //     }

    //     static void HandleAppendChild()
    //     {
    //         Console.WriteLine("Child was added");
    //     }
    //     static void HandleRemoveChild()
    //     {
    //         Console.WriteLine("Child was removed");
    //     }
    // }
}