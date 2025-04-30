using System.ComponentModel.DataAnnotations;

namespace MoolahTodoAPI.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsDone { get; set; } = false;
        public string Tag { get; set; } = string.Empty;
    }
}

