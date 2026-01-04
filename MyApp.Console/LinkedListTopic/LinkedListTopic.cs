namespace MyApp.Console.LinkedListTopic
{
    public class LinkedListTopic
    {
    }

    public class Node
    {
        public int Value { get; set; }
        public Node? Next { get; set; }
        public Node(int value = 0)
        {
            Value = value;
            Next = null;
        }
    }

    public class MyLinkedList
    {
        // size is length of linkedlist 
        public int Size { get; private set; }
        private Node _dummyHead;

        public MyLinkedList()
        {
            Size = 0;
            _dummyHead = new Node(0);
        }

        public int Get(int index)
        {
            //real length = size-1
            if (index < 0 || index >= Size) return -1;

            var currentNode = _dummyHead.Next;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next!;
            }
            return currentNode!.Value;
        }

        public void AddAtHead(int val)
        {
            var newHead = new Node(val);
            newHead.Next = _dummyHead.Next;
            _dummyHead.Next = newHead;
            this.Size++;
        }

        public void AddAtTail(int val)
        {
            var newTail = new Node(val);
            var current = _dummyHead;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newTail;
            this.Size++;
        }

        public void AddAtIndex(int index, int val)
        {
            if (index > Size) return;
            if (index < 0) index = 0;
            var prev = _dummyHead;
            for (int i = 0; i < index; i++)
            {
                prev = prev.Next!;
            }
            //ideal, 
            var newNode = new Node(val);
            newNode.Next = prev.Next;
            prev.Next = newNode;
            this.Size++;
        }

        public void DeleteAtIndex(int index)
        {
            //real length = size-1 => index should be lower than Size
            if (index < 0 || index >= Size) return;

            var prev = _dummyHead;
            for (int i = 0; i < index; i++)
            {
                prev = prev.Next!;
            }
            var deleted = prev.Next!;
            prev.Next = deleted.Next!;
            deleted.Next = null;
            this.Size--;
        }
    }
}
