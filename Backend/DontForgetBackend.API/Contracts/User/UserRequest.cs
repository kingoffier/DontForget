namespace DontForgetBackend.API.Contracts
{
    public record UserRequest(
        int Id,
        string? Email,
        string? FirstName,
        string? SecondName,
        string? Password,
        string? Login
        );
}