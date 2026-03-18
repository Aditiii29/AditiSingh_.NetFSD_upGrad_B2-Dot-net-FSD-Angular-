using System;

class Node
{
    public int empId;
    public string empName;
    public Node next;

    public Node(int id, string name)
    {
        empId = id;
        empName = name;
        next = null;
    }
}

class LinkedList
{
    Node head;

    // Insert at beginning
    public void InsertAtBeginning(int id, string name)
    {
        Node newNode = new Node(id, name);
        newNode.next = head;
        head = newNode;
    }

    // Insert at end
    public void InsertAtEnd(int id, string name)
    {
        Node newNode = new Node(id, name);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;
        while (temp.next != null)
        {
            temp = temp.next;
        }

        temp.next = newNode;
    }

    // Delete by employee ID
    public void Delete(int id)
    {
        if (head == null) return;

        // If head needs to be deleted
        if (head.empId == id)
        {
            head = head.next;
            return;
        }

        Node temp = head;

        while (temp.next != null && temp.next.empId != id)
        {
            temp = temp.next;
        }

        if (temp.next != null)
        {
            temp.next = temp.next.next;
        }
    }

    // Display list
    public void Display()
    {
        Node temp = head;

        while (temp != null)
        {
            Console.WriteLine(temp.empId + " - " + temp.empName);
            temp = temp.next;
        }
    }
}

class Program
{
    static void Main()
    {
        LinkedList list = new LinkedList();

        // Insert data
        list.InsertAtEnd(101, "John");
        list.InsertAtEnd(102, "Sara");
        list.InsertAtEnd(103, "Mike");

        // Delete employee with ID 102
        list.Delete(102);

        Console.WriteLine("Employee List After Deletion:");
        list.Display();
    }
}