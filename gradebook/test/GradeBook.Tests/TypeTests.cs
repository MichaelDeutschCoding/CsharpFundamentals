using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);


    public class TypeTests
    {
        int count = 0;
        
        
        [Fact]
        public void WriteLogDelegateCanPoint()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello");
            Assert.Equal(3, count);
        }
        string IncrementCount(string message)
        {
            count++;
            return message;
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }


        [Fact]
        public void CanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "Spamalot");

            Assert.Equal("Spamalot", book1.Name);
        }

        private void GetBookSetName(ref MemoryBook book, string name)
        {
            book = new MemoryBook(name);
        }


        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "Spamalot");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(MemoryBook book, string name)
        {
            book = new MemoryBook(name);
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;
            book2.Name = "Spam";
            
            Assert.Equal("Spam", book1.Name);
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        MemoryBook GetBook(string name)
        {
            return new MemoryBook(name);
        }
    }
}
