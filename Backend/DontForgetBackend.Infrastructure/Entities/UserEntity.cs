using System;
using System.Collections.Generic;

namespace DontForgetBackend.Infrastructure.Entites;

public partial class UserEntity
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? Password { get; set; }

    public string? Login { get; set; }

    public virtual ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
}
