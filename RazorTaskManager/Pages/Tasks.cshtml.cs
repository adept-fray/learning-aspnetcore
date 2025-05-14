using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTaskManager.Models;
using RazorTaskManager.Services;

namespace RazorTaskManager.Pages
{
    public class TasksModel : PageModel
    {
        private readonly TaskService _taskService;

        public TasksModel(TaskService taskService)
        {
            _taskService = taskService;
        }

        [BindProperty]
        public string NewTask { get; set; }
        public List<TaskItem> TaskList { get; set; } = new();

        public async Task OnGet()
        {
            TaskList = await _taskService.GetTasksAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!string.IsNullOrEmpty(NewTask))
            {
                await _taskService.AddTaskAsync(NewTask);
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _taskService.DeleteTaskAsync(id);

            return RedirectToPage();
        }
    }
}
