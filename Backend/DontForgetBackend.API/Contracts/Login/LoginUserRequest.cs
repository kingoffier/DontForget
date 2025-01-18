namespace DontForgetBackend.API.Contracts
{
    public record LoginUserRequest
    (
        string? Login,
            string? Password
    );
}
