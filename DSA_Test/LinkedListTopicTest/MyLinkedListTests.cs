
using MyApp.Console.LinkedListTopic;

namespace DSA_Test.LinkedListTopicTest
{

    public class MyLinkedListTests
    {
        // Helper method
        private MyLinkedList CreateList(params int[] values)
        {
            var list = new MyLinkedList();
            foreach (var v in values)
            {
                list.AddAtTail(v);
            }
            return list;
        }

        [Fact]
        public void Constructor_GivenNewList_WhenCreated_ThenSizeIsZero()
        {
            // Arrange

            // Act
            var list = new MyLinkedList();

            // Assert
            Assert.Equal(0, list.Size);
            Assert.Equal(-1, list.Get(0));
        }

        [Fact]
        public void AddAtHead_GivenEmptyList_WhenCalled_ThenElementIsInsertedAtHead()
        {
            // Arrange
            var list = new MyLinkedList();

            // Act
            list.AddAtHead(10);

            // Assert
            Assert.Equal(1, list.Size);
            Assert.Equal(10, list.Get(0));
        }

        [Fact]
        public void AddAtTail_GivenNonEmptyList_WhenCalled_ThenElementIsAppended()
        {
            // Arrange
            var list = CreateList(1, 2);

            // Act
            list.AddAtTail(3);

            // Assert
            Assert.Equal(3, list.Size);
            Assert.Equal(3, list.Get(2));
        }

        [Fact]
        public void AddAtIndex_GivenIndexZero_WhenCalled_ThenInsertAtHead()
        {
            // Arrange
            var list = CreateList(1, 2);

            // Act
            list.AddAtIndex(0, 99);

            // Assert
            Assert.Equal(3, list.Size);
            Assert.Equal(99, list.Get(0));
        }

        [Fact]
        public void AddAtIndex_GivenIndexEqualsSize_WhenCalled_ThenInsertAtTail()
        {
            // Arrange
            var list = CreateList(1, 2);

            // Act
            list.AddAtIndex(2, 99);

            // Assert
            Assert.Equal(3, list.Size);
            Assert.Equal(99, list.Get(2));
        }

        [Fact]
        public void AddAtIndex_GivenNegativeIndex_WhenCalled_ThenInsertAtHead()
        {
            // Arrange
            var list = CreateList(1, 2);

            // Act
            list.AddAtIndex(-1, 99);

            // Assert
            Assert.Equal(3, list.Size);
            Assert.Equal(99, list.Get(0));
        }

        [Fact]
        public void AddAtIndex_GivenIndexGreaterThanSize_WhenCalled_ThenListUnchanged()
        {
            // Arrange
            var list = CreateList(1, 2);

            // Act
            list.AddAtIndex(5, 99);

            // Assert
            Assert.Equal(2, list.Size);
            Assert.Equal(1, list.Get(0));
            Assert.Equal(2, list.Get(1));
        }

        [Theory]
        [InlineData(0, 10)]
        [InlineData(1, 20)]
        [InlineData(2, 30)]
        public void Get_GivenValidIndex_WhenCalled_ThenReturnCorrectValue(
            int index, int expected)
        {
            // Arrange
            var list = CreateList(10, 20, 30);

            // Act
            var result = list.Get(index);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(3)]
        [InlineData(100)]
        public void Get_GivenInvalidIndex_WhenCalled_ThenReturnMinusOne(int index)
        {
            // Arrange
            var list = CreateList(1, 2, 3);

            // Act
            var result = list.Get(index);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void DeleteAtIndex_GivenValidIndex_WhenCalled_ThenNodeIsRemoved()
        {
            // Arrange
            var list = CreateList(1, 2, 3);

            // Act
            list.DeleteAtIndex(1);

            // Assert
            Assert.Equal(2, list.Size);
            Assert.Equal(1, list.Get(0));
            Assert.Equal(3, list.Get(1));
        }

        [Fact]
        public void DeleteAtIndex_GivenInvalidIndex_WhenCalled_ThenListUnchanged()
        {
            // Arrange
            var list = CreateList(1, 2);

            // Act
            list.DeleteAtIndex(5);

            // Assert
            Assert.Equal(2, list.Size);
            Assert.Equal(1, list.Get(0));
            Assert.Equal(2, list.Get(1));
        }

        [Fact]
        public void Operations_GivenMultipleActions_WhenExecuted_ThenSizeInvariantIsMaintained()
        {
            // Arrange
            var list = new MyLinkedList();

            // Act
            list.AddAtHead(1);
            list.AddAtTail(2);
            list.AddAtIndex(1, 3);
            list.DeleteAtIndex(0);

            // Assert
            Assert.Equal(2, list.Size);
            Assert.Equal(3, list.Get(0));
            Assert.Equal(2, list.Get(1));
        }
    }

}
