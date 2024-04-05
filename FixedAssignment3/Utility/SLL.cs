using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

/*using System.Runtime.Remoting.Messaging;*/
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    [DataContract]
    public class SLL : ILinkedListADT
    {
        [DataMember]
        public Node Head { get; set; }
        [DataMember]
        public Node Tail { get; set; }

        /// <summary>
        /// Checks if the list is empty.
        /// </summary>
        /// <returns>True if it is empty.</returns>
        public bool IsEmpty()
        {
            if (Head == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Clears the list.
        /// </summary>
        public void Clear()
        {
            Head = null;
        }

        /// <summary>
        /// Adds to the end of the list.
        /// </summary>
        /// <param name="value">Value to append.</param>
        public void AddLast(User value)
        {
            Node newNode = new Node(value);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }
        }

        /// <summary>
        /// Prepends (adds to beginning) value to the list.
        /// </summary>
        /// <param name="value">Value to store inside element.</param>
        public void AddFirst(User value)
        {
            Node newNode = new Node(value);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
        }

        /// <summary>
        /// Adds a new element at a specific position.
        /// </summary>
        /// <param name="value">Value that element is to contain.</param>
        /// <param name="index">Index to add new element at.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or past the size of the list.</exception>
        public void Add(User value, int index)
        {
            Node current = Head;
            Node newNode = new Node(value);
            int currentIndex = 0;

            if (index < 0 || index >= Count())
            {
                throw new IndexOutOfRangeException();
            }

            // recycled
            if (index == 0)
            {
                newNode.Next = Head;
                Head = newNode;
            }

            while (current != null && currentIndex < index-1)
            {
                current = current.Next;
                currentIndex++;
            }

            if (current != null)
            {
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Replaces the value  at index.
        /// </summary>
        /// <param name="value">Value to replace.</param>
        /// <param name="index">Index of element to replace.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
        public void Replace(User value, int index)
        {
            Node node = new Node(value);
            Node current = Head;
            Node holder;
            int currentIndex = 0;

            if (index < 0 || index >= Count())
            {
                throw new IndexOutOfRangeException();
            }

            while (current != null)
            {
                if (currentIndex == index)
                {
                    current.Data = node.Data;
                    return;
                }
                current = current.Next;
                currentIndex++;
            }
        }

        /// <summary>
        /// Gets the number of elements in the list.
        /// </summary>
        /// <returns>Size of list (0 meaning empty)</returns>
        public int Count()
        {
            Node node = Head;
            int count = 0;
            while (node != null)
            {
                count++;
                node = node.Next;
            }
            return count;
        }

        /// <summary>
        /// Removes first element from list
        /// </summary>
        /// <exception cref="CannotRemoveException">Thrown if list is empty.</exception>
        public void RemoveFirst()
        {

            if (IsEmpty())
            {
                throw new Exception("CannotRemoveExeption");
            }

            if (Head == Tail)
            {
                Head = Tail = null;
                return;
            }

            Node second = Head.Next;
            Head.Next = null;
            Head = second;
        }

        /// <summary>
        /// Removes last element from list
        /// </summary>
        /// <exception cref="CannotRemoveException">Thrown if list is empty.</exception>
        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new Exception("CannotRemoveException");
            }

            if (Head == Tail)
            {
                Head = Tail = null;
                return;
            }

            Node current = Head;
            while (current.Next != Tail)
            {
                current = current.Next;
            }

            current.Next = null;
            Tail = current;
        }

        /// <summary>
        /// Removes element at index from list, reducing the size.
        /// </summary>
        /// <param name="index">Index of element to remove.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
        public void Remove(int index)
        {
            Node current = Head;
            Node holder = null;
            int currentIndex = 0;
            if (index < 0 || index >= Count())
            {
                throw new IndexOutOfRangeException();
            }

            if (currentIndex == 0)
            {
                if (current.Next != null)
                {
                    Head = current.Next;
                }
                return;
            }

            while (current != null && currentIndex < index)
            {
                holder = current;
                current = current.Next;
                currentIndex++;
            }

            if (current != null)
            {
                holder.Next = current.Next;
            }
        }

        /// <summary>
        /// Gets the value at the specified index.
        /// </summary>
        /// <param name="index">Index of element to get.</param>
        /// <returns>Value of node at index</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
        public User GetValue(int index)
        {
            Node current = Head;
            int currentIndex = 0;

            if (index < 0 || index >= Count())
            {
                throw new IndexOutOfRangeException();
            }

            while (current != null && currentIndex != index)
            {
                current = current.Next;
                currentIndex++;
            }

            return current.Data;
        }

        /// <summary>
        /// Gets the first index of element containing value.
        /// </summary>
        /// <param name="value">Value to find index of.</param>
        /// <returns>First of index of node with matching value or -1 if not found.</returns>
        public int IndexOf(User value)
        {
            Node current = Head;
            int currentIndex = 0;

            while (current != null)
            {
                if (current.Data.GetHashCode() == value.GetHashCode())
                {
                    return currentIndex;
                }
                current = current.Next;
                currentIndex++;
            }

            return -1;
        }

        /// <summary>
        /// Go through nodes and check if one has value.
        /// </summary>
        /// <param name="value">Value to find index of.</param>
        /// <returns>True if element exists with value.</returns>
        public bool Contains(User value)
        {
            Node current = Head;
           

            while (current != null)
            {

                if (current.Data.GetHashCode() == value.GetHashCode())
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        // a holder takes the current
        public void ReverseOrder()
        {
            Node holder = Head;
            Head = null;

            while (holder != null)
            {
                AddFirst(holder.Data);
                holder = holder.Next;
            }

        }
    }
}

