using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaskClass.Models;
using TaskClass;

namespace TaskClassTest
{
    [TestClass]
    public sealed class TaskManagerTest
    {
        private TaskManager _taskManager;
        private Mock<ToDoListDbContext> _mockContext;
        private Mock<DbSet<TaskToDo>> _mockDbSet;

        [TestInitialize]
        public void Initialize()
        {
            _mockContext = new Mock<ToDoListDbContext>();
            _mockDbSet = new Mock<DbSet<TaskToDo>>();

            _mockContext.Setup(m => m.TaskToDos).Returns(_mockDbSet.Object);

            _taskManager = new TaskManager(_mockContext.Object);
        }

        [TestMethod]
        public void AddTask_ShouldAddTaskToDatabase()
        {
            // Arrange
            var task = new TaskToDo
            {
                NameTask = "Test Task",
                Description = "Test Description",
                DueDate = DateTime.Now,
                Category = "Test Category",
                IsComplete = false
            };

            // Act
            _taskManager.AddTask(task.NameTask, task.Description, task.DueDate, task.Category);

            // Assert
            _mockDbSet.Verify(m => m.Add(It.IsAny<TaskToDo>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void MarkTaskAsComplete_ShouldSetIsCompleteToTrue()
        {
            // Arrange
            var task = new TaskToDo { Id = 1, IsComplete = false };
            _mockDbSet.Setup(m => m.Find(It.IsAny<int>())).Returns(task);

            // Act
            _taskManager.MarkTaskAsComplete(task.Id);

            // Assert
            Assert.IsTrue(task.IsComplete);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void RemoveTask_ShouldRemoveTaskFromDatabase()
        {
            // Arrange
            var task = new TaskToDo { Id = 1 };
            _mockDbSet.Setup(m => m.Find(It.IsAny<int>())).Returns(task);

            // Act
            _taskManager.RemoveTask(task.Id);

            // Assert
            _mockDbSet.Verify(m => m.Remove(It.IsAny<TaskToDo>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void GetAllTasks_ShouldReturnAllTasks()
        {
            // Arrange
            var tasks = new List<TaskToDo>
            {
                new TaskToDo { Id = 1, NameTask = "Task 1" },
                new TaskToDo { Id = 2, NameTask = "Task 2" }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<TaskToDo>>();
            mockDbSet.As<IQueryable<TaskToDo>>().Setup(m => m.Provider).Returns(tasks.Provider);
            mockDbSet.As<IQueryable<TaskToDo>>().Setup(m => m.Expression).Returns(tasks.Expression);
            mockDbSet.As<IQueryable<TaskToDo>>().Setup(m => m.ElementType).Returns(tasks.ElementType);
            mockDbSet.As<IQueryable<TaskToDo>>().Setup(m => m.GetEnumerator()).Returns(tasks.GetEnumerator());

            _mockContext.Setup(m => m.TaskToDos).Returns(mockDbSet.Object);

            // Act
            var result = _taskManager.GetAllTasks();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Task 1", result[0].NameTask);
            Assert.AreEqual("Task 2", result[1].NameTask);
        }
    }
}
