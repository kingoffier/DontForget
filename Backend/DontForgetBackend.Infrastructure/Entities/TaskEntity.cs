using System;
using System.Collections.Generic;

namespace DontForgetBackend.Infrastructure.Entites;

public partial class TaskEntity
{
    public int Id { get; set; }

    public string? NameTask { get; set; }

    public string? Description { get; set; }

    public DateOnly? Date { get; set; }

    public int? IdUser { get; set; }

    public virtual UserEntity? IdUserNavigation { get; set; }
}
