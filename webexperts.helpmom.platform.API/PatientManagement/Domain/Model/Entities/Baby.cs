namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Entities;

public class Baby
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public int? MotherId { get; set; }

    public Baby()
    {
        Name = string.Empty;
        DateOfBirth = new DateTime();
        Gender = string.Empty;
    }
}