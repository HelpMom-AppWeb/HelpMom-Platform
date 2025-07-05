namespace webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Resources;

public record CreatePatientResource(
    int ProfileId, 
    string Phone, 
    int AssignedDoctorId, 
    string BabyName, 
    DateTime DateOfBirth, 
    string BabyGender
    );