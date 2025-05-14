using TaskApi.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<TaskItem> taskList = new();
int nextId = 1;

app.MapGet("/tasks", () => taskList);

app.MapPost("/tasks", (TaskItem input) =>
{
    var task = new TaskItem { Id = nextId++, Description = input.Description };
    taskList.Add(task);
    return Results.Created($"/tasks/{task.Id}", task);
});

app.MapDelete("/tasks/{id:int}", (int id) =>
{
    var task = taskList.FirstOrDefault(t => t.Id == id);
    if (task is null) return Results.NotFound();

    taskList.Remove(task);
    return Results.Ok(task);
});

app.Run();
