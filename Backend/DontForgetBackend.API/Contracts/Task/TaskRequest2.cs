namespace DontForgetBackend.API.Contracts
{
    public record TaskRequest2
    (
        string? NameTask,
        DateOnly? Date,
        string? Description,
        int? IdUser
    );
}
