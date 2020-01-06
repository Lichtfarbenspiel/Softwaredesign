using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace Tree{
    class Tree<T>{
        public TreeNode CreateNode(T type){
            return new TreeNode(type);
        }
        public void Print(TreeNode node, string indent = "")
            {
                string output = node.ToString();
                Console.WriteLine(indent + output);
                indent += "-";

                foreach (var child in node.children)
                {
                    this.Print(child, indent);
                }
            }

        public class TreeNode : IEnumerable<TreeNode>{

            public delegate void EventHandler();
            public T type;
            public TreeNode parent;
            public List<TreeNode> children;
            private Dictionary<string, EventHandler> listeners;
        

            public TreeNode(T type)
            {
                this.type = type;
                this.parent = null;
                this.children = new List<TreeNode> {};
                this.listeners = new Dictionary<string, EventHandler> {};
            }

            public void AppendChild(TreeNode child){

                if (listeners.ContainsKey("AppendChild"))
                {
                    EventHandler handler = listeners["AppendChild"];
                    handler();
                }

                if(child.parent != null)
                    this.children.Remove(child);
                
                this.children.Add(child);
                child.parent = this;
            }

            public void RemoveChild(TreeNode child){

                if (listeners.ContainsKey("RemoveChild"))
                {
                    EventHandler listener = listeners["RemoveChild"];
                    listener();
                }

                child.parent = null;
                children.Remove(child);
            }

            public void Print(TreeNode parent ,string generation = ""){
                
                generation += "*";
                WriteLine(generation + parent.ToString());

                foreach(var child in parent.children){

                    this.Print(child, generation);
                }  
            }


            public void ForEach(Action<TreeNode> func)
            {
                func(this);
                foreach (var child in children)
                {
                    child.ForEach(func);
                }
            }

            override public string ToString(){
                return type.ToString();
            }

            public TreeNode FindRoot(){
                if(parent == null)
                    return this;
                else
                    return parent.FindRoot();
            }

            public void AddListener(string listenerType, EventHandler handler){
                if(listeners .ContainsKey(listenerType)){
                    Console.WriteLine("Added a new handler to " + listenerType + ".");
                    listeners[listenerType] += handler;
                }
                else{

                    Console.WriteLine("Added the first handler to " + listenerType + ".");
                    listeners.Add(listenerType, handler);
                }
            }

            public void RemoveListeners(string type, EventHandler handler){
                if(listeners.ContainsKey(type)){
                    if(listeners[type].Method == handler.Method){
                        Console.WriteLine("Removing handler from " + type + ".");
                        listeners[type] -= handler;
                    }
                }
            }

            public IEnumerator<TreeNode> GetEnumerator(){
                yield return this;
                foreach(var childNode in this.children){
                    foreach(var child in childNode){
                        yield return child;
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator(){
                return GetEnumerator();
            }
        }
    }   
}