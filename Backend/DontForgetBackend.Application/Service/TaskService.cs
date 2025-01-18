using DontForgetBackend.Core.Interfaces;
using DontForgetBackend.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontForgetBackend.Application.Service
{
    public class TaskService : ITaskService
    {

        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<int> CreateTask(TaskModel model)
        {
            return await _taskRepository.Create(model);
        }

        public async Task<int> DeleteTask(int id)
        {
            return await _taskRepository.Delete(id);
        }

        public async Task<List<TaskModel>> GetTask()
        {
            return await _taskRepository.Get();
        }

        public async Task<List<TaskModel>> GetTaskById(int id)
        {
            return await _taskRepository.GetById(id);
        }

        public async Task<int> UpdateTask(int id, string? name, DateOnly? Date, string? desc, int? idUser)
        {
            return await _taskRepository.Update(id, name, Date, desc, idUser);
        }
    }
}
