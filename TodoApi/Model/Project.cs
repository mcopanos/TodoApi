using System;
using System.Collections.Generic;

namespace TodoApi.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<TodoItem> TodoItems { get; set; }

    }
}
