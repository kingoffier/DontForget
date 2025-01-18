using DontForgetBackend.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontForgetBackend.Core.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetTask();
        Task<List<TaskModel>> GetTaskById(int id);
        Task<int> CreateTask(TaskModel model);
        Task<int> UpdateTask(int id, string? name, DateOnly? Date, string? desc, int? idUser);
        Task<int> DeleteTask(int id);
    }
}
