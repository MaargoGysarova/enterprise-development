namespace PharmacyManagementSystem.Shared.Models;

public class PharmacyDto
{
    public int PharmacyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string DirectorFullName { get; set; } = string.Empty;
}
