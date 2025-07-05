using Microsoft.EntityFrameworkCore;

namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.ValueObjects;
[Owned]
public class Baby
{
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public EGender Gender { get; set; }

    protected Baby()
    {

    }
    
    public Baby(string babyName, DateTime babyDateOfBirth, string babyGender)
    {
        Name = babyName;
        DateOfBirth = babyDateOfBirth;
        Gender = Enum.Parse<EGender>(babyGender, ignoreCase: true);
    }
}