using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorTaskManager.Pages
{
    public class TasksModel : PageModel
    {
        private static List<string> _taskList { get; set; } = new();

        public List<string> TaskList => _taskList;

        [BindProperty]
        public string NewTask { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(NewTask))
                _taskList.Add(NewTask);

            return RedirectToPage();
        }
    }
}
