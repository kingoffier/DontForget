using DontForgetBackend.Core.Model;
using DontForgetBackend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontForgetBackend.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> Get();
        Task<List<TaskModel>> GetById(int id);
        Task<int> Create(TaskModel model);
        Task<int> Update(int id, string? name, DateOnly? Date, string? desc, int? idUser);
        Task<int> Delete(int id);
    }
}
