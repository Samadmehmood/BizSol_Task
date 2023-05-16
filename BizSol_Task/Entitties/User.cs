using System.ComponentModel.DataAnnotations;

namespace BizSol_Task.Entitties;

public class User
{
    [Key]
    public int id { get; set; }
    [MaxLength(200)]
    public string name { get; set; }
    [MaxLength(300)]
    public string email { get; set; }
    [MaxLength(50)]
    public string phone { get; set; }
    public string imgUrl { get; set; }
    public bool status { get; set; }
}
