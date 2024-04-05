using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Utility;
using Assignment3;

namespace Assignment3.Tests
{
    internal class LinkedListTest
    {
        ILinkedListADT users;
        [SetUp]
        public void setup()
        {
            users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void teardown()
        {
            users = null;
        }

        [Test]
        public void ListIsEmpty()
        {
            users.Clear();
            Assert.IsTrue(users.IsEmpty());
        }

        // Adds to the beginning of the list
        [Test]
        public void PrependData()
        {
            User user = new User(0, "Joe Biden", "jbiden@gmail.com", "passssword");
            users.AddFirst(user);
            Assert.IsFalse(users.IsEmpty());
            Assert.AreEqual(user.Name, users.GetValue(0).Name);
        }

        // Adds to the end of the List
        [Test]
        public void AppendData()
        {
            User user = new User(5, "Keanu Reeves", "kreeves@gmail.com", "passingword");
            users.AddLast(user);
            Assert.IsFalse(users.IsEmpty());
            Assert.AreEqual(users.GetValue(users.Count()-1), user);
        }

        // Compares if the node at 2nd index after adding is the same as the newUser
        [Test]
        public void InsertAtIndex()
        {
            User user = new User(6, "Justin Bieber", "jbeaber@gmail.com", "babyoh");
            Assert.IsFalse(users.IsEmpty());
            users.Add(user, 2);
            Assert.AreEqual(user, users.GetValue(2));
        }

        // Compares if the index replaced is the same as the newUser.
        [Test]
        public void ReplaceAtIndex()
        {
            User user = new User(69, "Michael Jackson", "mjackson@gmail.com", "babyoh");
            Assert.IsFalse(users.IsEmpty());
            users.Replace(user, 1);
            Assert.AreEqual(user, users.GetValue(1));
        }

        // holds previous Head, then compares the Head after deletion to the Head before deletion
        [Test]
        public void DeleteFirst()
        {
            User holder = users.GetValue(0);
            Assert.IsFalse(users.IsEmpty());
            users.RemoveFirst();
            Assert.AreNotEqual(holder, users.GetValue(0));
        }

        // holds previous Tail, then compares the Tail after deletion to the Tail before deletion
        [Test]
        public void DeleteEnd()
        {
            User holder = users.GetValue(users.Count()-1);
            Assert.IsFalse(users.IsEmpty());
            users.RemoveLast();
            Assert.AreNotEqual(holder, users.GetValue(users.Count()-1));
        }

        // Holds previous node of the index, deletes index, then compares old to new node
        [Test]
        public void DeleteFromMiddle()
        {
            User holder = users.GetValue(2);
            Assert.IsFalse(users.IsEmpty());
            users.Remove(2);
            Assert.AreNotEqual(holder.Name, users.GetValue(2).Name);
        }

        // creates identical user, gets index using identical user, then compares identical user to actual object in linkedlist
        [Test]
        public void FindItemAndRetrieve()
        {
            User user = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            Assert.IsTrue(users.Contains(user));
            int index = users.IndexOf(user);
            Assert.AreEqual(user, users.GetValue(index));
        }

    }
}
