using System.ComponentModel.DataAnnotations;

namespace BizSol_Task.DTOs;

public class UpdateUserRequestDto
{
    public int id { get; set; }
    [Required(ErrorMessage = "Name is obligatory")]
    [MaxLength(200, ErrorMessage = "Too much text for a name"), MinLength(3, ErrorMessage = "name must be atleast 3 characters long")]
    public string name { get; set; }
    [Required(ErrorMessage = "Email is obligatory")]
    [EmailAddress(ErrorMessage = "must be a valid email")]
    [MaxLength(200, ErrorMessage = "Too much text for an email"), MinLength(3, ErrorMessage = "name must be atleast 5 characters long")]

    public string email { get; set; }

    [Phone(ErrorMessage = "Must be a valid phone number")]
    [MaxLength(50, ErrorMessage = "Too much text for a phone"), MinLength(7, ErrorMessage = "name must be atleast 7 characters long")]
    public string phone { get; set; }
    [Required(ErrorMessage = "Image is obligatory")]

    public string img { get; set; }
}
