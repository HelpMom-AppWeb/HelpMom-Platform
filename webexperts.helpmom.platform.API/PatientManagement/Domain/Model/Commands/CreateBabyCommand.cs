namespace webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Commands;

public record CreateBabyCommand(string Name, DateTime DateOfBirth, string Gender, int MotherId);