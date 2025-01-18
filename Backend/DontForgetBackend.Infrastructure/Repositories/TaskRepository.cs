using DontForgetBackend.Core.Interfaces;
using DontForgetBackend.Core.Model;
using DontForgetBackend.Infrastructure.Data;
using DontForgetBackend.Infrastructure.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontForgetBackend.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        private readonly DontForgetContext _db;
        public TaskRepository(DontForgetContext db)
        {
            _db = db;
        }
        public async Task<int> Create(TaskModel model)
        {
            var taskEntity = new TaskEntity
            {
                Id = model.Id,
                Description = model.Description,
                NameTask = model.NameTask,
                Date = model.Date,
                IdUser = model.IdUser
            };

            await _db.Tasks.AddAsync(taskEntity);
            await _db.SaveChangesAsync(); 

            return taskEntity.Id;

        }

        public async Task<int> Delete(int id)
        {
            await _db.Tasks
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }

        public async Task<List<TaskModel>> Get()
        {
            var taskEntities = await _db.Tasks
                .AsNoTracking()
                .ToListAsync();

            var tasks = taskEntities
                .Select(b => TaskModel.Create(b.Id, b.NameTask, b.Date, b.Description, b.IdUser).TaskModel)
                .ToList();

            return tasks;
        }


        public async Task<List<TaskModel>> GetById(int id)
        {
            var taskEntities = await _db.Tasks
                .AsNoTracking()
                .Where(b => b.Id == id)
                .ToListAsync();

            var tasks = taskEntities
                .Select(b => TaskModel.Create(b.Id, b.NameTask, b.Date, b.Description, b.IdUser).TaskModel)
                .ToList();

            return tasks;
        }


        public async Task<int> Update(int id, string? name, DateOnly? Date, string? desc, int? idUser)
        {
            await _db.Tasks
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.NameTask, b => name)
                .SetProperty(b => b.Description, b => desc)
                .SetProperty(b => b.Date, b=>Date)
                .SetProperty(b => b.IdUser, b => idUser)
                );

            return id;
        }
    }
}
