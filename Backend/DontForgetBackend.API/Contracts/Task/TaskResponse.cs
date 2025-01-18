namespace DontForgetBackend.API.Contracts
{
    public record TaskResponse
    (
        int Id,
        string? NameTask,
        DateOnly? Date,
        string? Description,
        int? IdUser
    );
}
