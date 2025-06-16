namespace webexperts.helpmom.platform.Chat.Domain.Model.ValueObjects
{
    public record class From
    {
        public int UserId { get; init; }
        public string Role { get; init; }

        // Constructor sin parámetros requerido por EF Core
        public From() { }

        // Constructor explícito para tu dominio
        public From(int userId, string role)
        {
            UserId = userId;
            Role = role;
        }
    }
}