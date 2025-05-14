using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTaskManager.Models;

namespace RazorTaskManager.Pages
{
    public class TasksModel : PageModel
    {
        private static List<TaskItem> _taskList { get; set; } = new();
        private static int _nextId = 1;

        public List<TaskItem> TaskList => _taskList;

        [BindProperty]
        public string NewTask { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(NewTask))
            {
                _taskList.Add(new TaskItem
                {
                    Id = _nextId++,
                    Description = NewTask
                });
            }

            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            var task = _taskList.FirstOrDefault(t => t.Id == id);
            if (task != null)
                _taskList.Remove(task);

            return RedirectToPage();
        }
    }
}
