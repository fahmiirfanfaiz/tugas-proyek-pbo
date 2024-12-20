using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaskClass.Models;
using TaskClass;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Moq.Protected;

namespace TaskClassTest
{
    [TestClass]
    public sealed class TaskManagerTest
    {
        private TaskManager _taskManager;
        private Mock<ToDoListDbContext> _mockContext;
        private Mock<DbSet<TaskToDo>> _mockDbSet;
        private Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private HttpClient _mockHttpClient;

        [TestInitialize]
        public void Initialize()
        {
            _mockContext = new Mock<ToDoListDbContext>();
            _mockDbSet = new Mock<DbSet<TaskToDo>>();

            _mockContext.Setup(m => m.TaskToDos).Returns(_mockDbSet.Object);

            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            _mockHttpClient = new HttpClient(_mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };

            _taskManager = new TaskManager(_mockHttpClient, _mockContext.Object);
        }

        [TestMethod]
        public async Task AddTask_ShouldAddTaskToDatabaseAndApi()
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

            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.OK));

            // Act
            await _taskManager.AddTask(task.NameTask, task.Description, task.DueDate, task.Category);

            // Assert
            _mockDbSet.Verify(m => m.AddAsync(It.IsAny<TaskToDo>(), default), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
            _mockHttpMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [TestMethod]
        public async Task MarkTaskAsComplete_ShouldSetIsCompleteToTrue()
        {
            // Arrange
            var task = new TaskToDo { Id = 1, IsComplete = false };
            _mockDbSet.Setup(m => m.FindAsync(It.IsAny<int>())).ReturnsAsync(task);

            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.OK));

            // Act
            await _taskManager.MarkTaskAsComplete(task.Id);

            // Assert
            Assert.IsTrue(task.IsComplete);
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
            _mockHttpMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [TestMethod]
        public async Task RemoveTask_ShouldRemoveTaskFromDatabaseAndApi()
        {
            // Arrange
            var task = new TaskToDo { Id = 1 };
            _mockDbSet.Setup(m => m.FindAsync(It.IsAny<int>())).ReturnsAsync(task);

            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.OK));

            // Act
            await _taskManager.RemoveTask(task.Id);

            // Assert
            _mockDbSet.Verify(m => m.Remove(It.IsAny<TaskToDo>()), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
            _mockHttpMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [TestMethod]
        public async Task GetAllTasks_ShouldReturnAllTasks()
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
            mockDbSet.As<IAsyncEnumerable<TaskToDo>>().Setup(m => m.GetAsyncEnumerator(default)).Returns(new TestAsyncEnumerator<TaskToDo>(tasks.GetEnumerator()));
            mockDbSet.As<IQueryable<TaskToDo>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<TaskToDo>(tasks.Provider));

            _mockContext.Setup(m => m.TaskToDos).Returns(mockDbSet.Object);

            // Act
            var result = await _taskManager.GetAllTasks();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Task 1", result[0].NameTask);
            Assert.AreEqual("Task 2", result[1].NameTask);
        }
    }

    internal class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;

        public TestAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public ValueTask DisposeAsync()
        {
            _inner.Dispose();
            return ValueTask.CompletedTask;
        }

        public ValueTask<bool> MoveNextAsync()
        {
            return new ValueTask<bool>(_inner.MoveNext());
        }

        public T Current => _inner.Current;
    }

    internal class TestAsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        internal TestAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new TestAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new TestAsyncEnumerable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression)
        {
            return new TestAsyncEnumerable<TResult>(expression);
        }

        public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Execute<TResult>(expression);
        }
    }

    internal class TestAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public TestAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        public TestAsyncEnumerable(Expression expression)
            : base(expression)
        { }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new TestAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        IQueryProvider IQueryable.Provider => new TestAsyncQueryProvider<T>(this);
    }

    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, Task<HttpResponseMessage>> _sendAsync;

        public MockHttpMessageHandler(Func<HttpRequestMessage, Task<HttpResponseMessage>> sendAsync)
        {
            _sendAsync = sendAsync;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return _sendAsync(request);
        }
    }
}
