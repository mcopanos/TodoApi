using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Model
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public bool Completed { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
