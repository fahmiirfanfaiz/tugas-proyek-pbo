using System;
using System.Collections.Generic;
using System.Linq;
using TaskClass.Models;

namespace TaskSorterClass
{
    public class TaskSorter
    {
        /// <summary>
        /// Sorts a list of tasks by their name in alphabetical order.
        /// </summary>
        /// <param name="tasks">The list of tasks to sort.</param>
        /// <returns>A sorted list of tasks.</returns>
        public List<TaskToDo> SortTasksByName(List<TaskToDo> tasks)
        {
            return tasks.OrderBy(t => t.NameTask).ToList();
        }

        /// <summary>
        /// Sorts a list of tasks by their due date.
        /// </summary>
        /// <param name="tasks">The list of tasks to sort.</param>
        /// <returns>A sorted list of tasks.</returns>
        public List<TaskToDo> SortTasksByDueDate(List<TaskToDo> tasks)
        {
            return tasks.OrderBy(t => t.DueDate).ToList();
        }

        /// <summary>
        /// Filters tasks by their completion status.
        /// </summary>
        /// <param name="tasks">The list of tasks to filter.</param>
        /// <param name="isComplete">The completion status to filter by.</param>
        /// <returns>A filtered list of tasks.</returns>
        public List<TaskToDo> FilterTasksByCompletionStatus(List<TaskToDo> tasks, bool isComplete)
        {
            return tasks.Where(t => t.IsComplete == isComplete).ToList();
        }

        /// <summary>
        /// Filters tasks by their category.
        /// </summary>
        /// <param name="tasks">The list of tasks to filter.</param>
        /// <param name="category">The category to filter by.</param>
        /// <returns>A filtered list of tasks.</returns>
        public List<TaskToDo> FilterTasksByCategory(List<TaskToDo> tasks, string category)
        {
            return tasks.Where(t => t.Category == category).ToList();
        }
    }
}