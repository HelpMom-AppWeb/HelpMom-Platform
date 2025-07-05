namespace webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Resources;

public record CreatePatientResource(
    string Name,
    string Email,
    string Phone, 
    int AssignedDoctorId, 
    string BabyName, 
    DateTime DateOfBirth, 
    string BabyGender
    );