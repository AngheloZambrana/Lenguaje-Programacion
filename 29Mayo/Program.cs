using System;
using System.Collections;
using System.Collections.Generic;

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; set; }

    public Node(T value)
    {
        Value = value;
        Next = null;
    }
}

public class LinkedListEnumerator<T> : IEnumerator<T>
{
    private Node<T> _current;
    private Node<T> _head;

    public LinkedListEnumerator(Node<T> head)
    {
        _head = head;
        _current = null;
    }

    public T Current => _current.Value;

    object IEnumerator.Current => Current;

    public void Dispose() { }

    public bool MoveNext()
    {
        if (_current == null)
        {
            _current = _head;
        }
        else
        {
            _current = _current.Next;
        }

        return _current != null;
    }

    public void Reset()
    {
        _current = null;
    }
}

public class LinkedList<T> : IList<T>
{
    private Node<T> _head;
    private int _count;

    public LinkedList()
    {
        _head = null;
        _count = 0;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException();
            }

            Node<T> current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }
        set
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException();
            }

            Node<T> current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Value = value;
        }
    }

    public int Count => _count;

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        Node<T> newNode = new Node<T>(item);
        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            Node<T> current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        _count++;
    }

    public void Clear()
    {
        _head = null;
        _count = 0;
    }

    public bool Contains(T item)
    {
        Node<T> current = _head;
        while (current != null)
        {
            if (current.Value.Equals(item))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        }

        if (array.Length - arrayIndex < _count)
        {
            throw new ArgumentException("The number of elements in the source LinkedList<T> is greater than the available space from arrayIndex to the end of the destination array.");
        }

        Node<T> current = _head;
        for (int i = arrayIndex; i < arrayIndex + _count; i++)
        {
            array[i] = current.Value;
            current = current.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new LinkedListEnumerator<T>(_head);
    }

    public int IndexOf(T item)
    {
        Node<T> current = _head;
        for (int i = 0; i < _count; i++)
        {
            if (current.Value.Equals(item))
            {
                return i;
            }
            current = current.Next;
        }
        return -1;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > _count)
        {
            throw new ArgumentOutOfRangeException();
        }

        Node<T> newNode = new Node<T>(item);

        if (index == 0)
        {
            newNode.Next = _head;
            _head = newNode;
        }
        else
        {
            Node<T> current = _head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
        }
        _count++;
    }

    public bool Remove(T item)
    {
        if (_head == null)
        {
            return false;
        }

        if (_head.Value.Equals(item))
        {
            _head = _head.Next;
            _count--;
            return true;
        }

        Node<T> current = _head;
        while (current.Next != null && !current.Next.Value.Equals(item))
        {
            current = current.Next;
        }

        if (current.Next == null)
        {
            return false;
        }

        current.Next = current.Next.Next;
        _count--;
        return true;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (index == 0)
        {
            _head = _head.Next;
        }
        else
        {
            Node<T> current = _head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
        }
        _count--;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> list = new LinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Index of 2: " + list.IndexOf(2));

        list.Insert(1, 5);
        Console.WriteLine("After inserting 5 at index 1:");

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        list.Remove(2);
        Console.WriteLine("After removing 2:");

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}
