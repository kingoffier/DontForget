using System;
using System.Collections.Generic;

namespace DontForgetBackend.API;

public partial class User
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? Password { get; set; }

    public string? Login { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
