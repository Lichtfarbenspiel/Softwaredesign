using System;
using System.Collections.Generic;
using static System.Console;

class TreeNode<T>{

    public T Type;
    // public TreeNode<T> parent;
    public List<TreeNode<T>> children;

    public TreeNode()
    {
        // this.parent = new TreeNode<T>();
        this.children = new List<TreeNode<T>>();

    }

    public TreeNode(T type)
    {
        this.Type = type;
        // this.parent = new TreeNode<T>();
        this.children = new List<TreeNode<T>>();
    }

    public TreeNode<T> CreateNode( T Type){
        return new TreeNode<T>(Type);
    }

    public void AppendChild(TreeNode<T> child){
        children.Add(child);
    }

    public void RemoveChild(TreeNode<T> child){
        children.Remove(child);
    }

    public void PrintTree(){
        WriteLine(this.Type.ToString());
        PrintChildren("", this);
    }

    private void PrintChildren(string generation, TreeNode<T> parent){
        generation = "*";
        foreach(TreeNode<T> child in parent.children){
            
            WriteLine(generation + child.Type.ToString());
        }
        PrintChildren(generation, parent);
    }
}