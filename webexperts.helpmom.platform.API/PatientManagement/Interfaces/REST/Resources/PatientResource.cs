namespace webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Resources;

public record PatientResource(
    int Id, 
    string Name, 
    string Email, 
    string Phone, 
    BabyResource Baby, 
    int AssignedDoctorId);