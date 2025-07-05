using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Entities;

public class Baby
{
    public int Id { get; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public EGender Gender { get; set; }

    public Baby()
    {
        Name = string.Empty;
        DateOfBirth = new DateTime();
        Gender = new EGender();
        
    }
    
    public Baby(string babyName, DateTime babyDateOfBirth, string babyGender)
    {
        Name = babyName;
        DateOfBirth = babyDateOfBirth;
        Gender = Enum.Parse<EGender>(babyGender, ignoreCase: true);
    }
}