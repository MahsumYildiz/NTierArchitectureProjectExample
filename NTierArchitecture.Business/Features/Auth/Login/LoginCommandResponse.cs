namespace NTierArchitecture.Business.Features.Auth.Login
{
    public sealed record LoginCommandResponse(
        string AccesToken,
        Guid UserId
        );
}

