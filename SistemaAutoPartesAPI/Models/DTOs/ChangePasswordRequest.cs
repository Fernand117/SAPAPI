namespace SistemaAutoPartesAPI.Models.DTOs
{
    public class ChangePasswordRequest
    {
        public string Username { get; set; } = null!;
        public string OldPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }
}