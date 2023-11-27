using System.ComponentModel.DataAnnotations;

public class ContactDataModel
{
  public int Id { get; set; } 

  [Required]
  public string Name { get; set; }

  [Required]
  [EmailAddress] 
  public string Email { get; set; } 

  [Required]
  public string Message { get; set; }

  public bool Branding { get; set; }

  public bool DigitalMarketing { get; set; }

  public bool WebDevelopment { get; set; }
}
