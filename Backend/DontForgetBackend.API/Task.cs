using System;
using System.Collections.Generic;

namespace DontForgetBackend.API;

public partial class Task
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public DateOnly? Date { get; set; }

    public int? IdUser { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
