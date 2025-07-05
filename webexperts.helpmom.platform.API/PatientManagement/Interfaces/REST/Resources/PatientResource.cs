namespace webexperts.helpmom.platform.API.PatientManagement.Interfaces.REST.Resources;

public record PatientResource(int Id, int ProfileId, string Phone, BabyResource Baby, DoctorResource AssignedDoctor);