using System.ComponentModel.DataAnnotations;
namespace BLL.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required][StringLength(80)] public string Name { get; set; } = null!;
        [StringLength(20)] public string? Phone { get; set; }
        [EmailAddress][StringLength(80)] public string? Email { get; set; }
        public bool IsMember { get; set; }
    }
}
