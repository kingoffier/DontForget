namespace DontForgetBackend.API.Contracts
{
    public record TaskRequest
    (
        int Id,
        string? NameTask,
        DateOnly? Date,
        string? Description,
        int? IdUser
    );
}
