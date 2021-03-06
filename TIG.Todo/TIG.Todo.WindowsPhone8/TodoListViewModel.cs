﻿using System.Collections.ObjectModel;
using System.Diagnostics;
using TIG.Todo.Common;

namespace TIG.Todo.WindowsPhone8
{
    public class TodoListViewModel : Bindable
    {
        private readonly TaskManager taskManager = new TaskManager();

        public ObservableCollection<TodoItem> TodoItems
        {
            get { return taskManager.TodoItems; }
        }

        public TodoItem NewTodoItem
        {
            get { return taskManager.NewTodoItem; }
        }

        private DelegateCommand<object> _addCommand;
        public DelegateCommand<object> AddCommand
        {
            get
            {
                return _addCommand = _addCommand ?? new DelegateCommand<object>(AddExecutedHandler, AddCanExecuteHandler);
            }
        }
        private bool AddCanExecuteHandler(object obj)
        {
            return true;
        }
        private void AddExecutedHandler(object obj)
        {
            taskManager.AddTodoItem();
            OnPropertyChanged("NewTodoItem");
        }

        private DelegateCommand<TodoItem> _deleteCommand;
        public DelegateCommand<TodoItem> DeleteCommand
        {
            get
            {
                return _deleteCommand = _deleteCommand ?? new DelegateCommand<TodoItem>(DeleteExecutedHandler, DeleteCanExecuteHandler);
            }
        }
        private bool DeleteCanExecuteHandler(TodoItem todoItem)
        {
            return true;
        }
        private void DeleteExecutedHandler(TodoItem todoItem)
        {
            taskManager.RemoveItem(todoItem);
        }
    }

}