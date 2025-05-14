using System;
using RazorTaskManager.Models;

namespace RazorTaskManager.Services
{
    public class TaskService
    {
        private readonly HttpClient _http;

        public TaskService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TaskItem>> GetTasksAsync()
        {
            return await _http.GetFromJsonAsync<List<TaskItem>>("/tasks") ?? new();
        }

        public async Task AddTaskAsync(string description)
        {
            var task = new TaskItem { Description = description };
            await _http.PostAsJsonAsync("/tasks", task);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _http.DeleteAsync($"/tasks/{id}");
        }
    }

}