using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;

namespace BizSol_Task.DTOs;

public class CreateUserDto
{
    [MaxLength(200)]
    public string name { get; set; }

    [MaxLength(300)]
    public string email { get; set; }

    [MaxLength(50)]
    public string phone { get; set; }
    public string img { get; set; }

    public bool status { get; set; }
}
