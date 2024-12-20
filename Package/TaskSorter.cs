using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskSorter
{
    public class TaskToDo_2
    {
        public string NameTask { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Category { get; set; }
        public bool IsComplete { get; set; }
    }

    public class TaskSorterService
    {
        /// <summary>
        /// Sorts a list of tasks by their name in alphabetical order.
        /// </summary>
        /// <param name="tasks">The list of tasks to sort.</param>
        /// <returns>A sorted list of tasks.</returns>
        public List<TaskToDo_2> GetSortedTasks(List<TaskToDo_2> tasks)
        {
            return tasks.OrderBy(t => t.NameTask).ToList();
        }
    }
}
