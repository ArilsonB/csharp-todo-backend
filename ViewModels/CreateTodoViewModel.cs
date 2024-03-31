using System.ComponentModel.DataAnnotations;

namespace TodoBackend.ViewModels;

public class CreateTodoViewModel
{
    [Required]
    public string Title { get; set; }
}