using System;
using System.Collections.Generic;
using static System.Console;

class TreeNode<T>{

    public T Type;
    public TreeNode<T> parent;
    public List<TreeNode<T>> children;

    public TreeNode()
    {
        this.children = new List<TreeNode<T>>();

    }

    public TreeNode(T type)
    {
        this.Type = type;
        this.parent = null;
        this.children = new List<TreeNode<T>>();
    }

    public TreeNode<T> CreateNode( T Type){
        return new TreeNode<T>(Type);
    }

    public void AppendChild(TreeNode<T> child){

        this.children.Add(child);
        child.parent = this;
    }

    public void RemoveChild(TreeNode<T> child){
        children.Remove(child);
    }

    public void PrintTree(){
        WriteLine(this.Type);
        PrintChildren("", this);
    }

    private void PrintChildren(string generation, TreeNode<T> parent){
        generation += "*";

        foreach(TreeNode<T> child in parent.children){
            WriteLine(generation + child.Type.ToString());

            PrintChildren(generation, child);
        }
        
    }

    public void ForEach(Func<string> function){
        foreach(TreeNode<T> child in this.children){
            function();
            child.ForEach(function);
    }
}