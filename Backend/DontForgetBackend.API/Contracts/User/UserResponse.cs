namespace DontForgetBackend.API.Contracts
{
    public record UserResponse(
        int Id,
        string? Email,
        string? FirstName,
        string? SecondName,
        string? Password,
        string? Login
        );
}
