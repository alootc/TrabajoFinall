using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaSimplemente<T>
{
    private class Node
    {
        public T value { get; set; }

        public Node Next{ get; set; }

        public Node(T t)
        {
            value = t;
            Next = null;
        }
    }
    private Node head;
    public int length = 0;
    public int Length { get { return length; } }

    public void InsertNodeStart(T value)
    {
        Node new_node = new Node(value);
        if (head == null)
        {
            head = new_node; 
        }
        else
        {
            new_node.Next = head;    
            head = new_node;
        }
        length = length + 1;
    }

    public void InsertNodeEnd(T value)
    {
        Node new_node = new Node(value);

        if(head == null)
        {
            head = new_node;
        }
        else
        {
            Node tmp = head; 

            while(tmp.Next != null)
            {
                tmp = tmp.Next;
            }
            tmp.Next = new_node;
        }
        length++;
    }

    //public bool Contains(T value)
    //{
    //    Node tmp = head;
    //    while (tmp != null)
    //    {
    //        if (tmp.value.Equals(value))
    //        {
    //            return true;
    //        }
    //        tmp = tmp.Next;
    //    }
    //    return false;
    //}

    public void PrintAllNodess()
    {
        Node tmp = head;
        while (tmp != null)
        {
            Debug.Log(tmp.value + " ");
            tmp = tmp.Next;
        }
        Debug.Log("");
    }

    public T this[int index]
    {
        get
        {
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                if (current == null)
                {
                    return default(T); // Return default value if index is out of range
                }
                current = current.Next;
            }
            return current != null ? current.value : default(T); // Return value or default if null
        }
        set
        {
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                if (current == null)
                {
                    return; // Do nothing if index is out of range
                }
                current = current.Next;
            }
            if (current != null)
            {
                current.value = value; // Set value if node exists
            }
        }
    }
}
