using webexperts.helpmom.platform.API.Domain.Model.Entities;
        
        namespace webexperts.helpmom.platform.API.Domain.Model.Aggregate;
        
        public class Prescription
        {
            public int Id { get; private set; }
            public int PatientId { get; private set; }
            public int DoctorId { get; private set; }
            public DateTime PrescriptionDate { get; private set; }
            public string Notes { get; private set; }
            public bool IsActive { get; private set; }
        
            private readonly List<Medication> _medications;
            public IReadOnlyCollection<Medication> Medications => _medications.AsReadOnly();
        
            public Prescription()
            {
                Notes = string.Empty;
                IsActive = true;
                _medications = new List<Medication>();
                PrescriptionDate = DateTime.UtcNow;
            }
        
            public Prescription(int patientId, int doctorId, string notes)
            {
                PatientId = patientId;
                DoctorId = doctorId;
                Notes = notes;
                IsActive = true;
                PrescriptionDate = DateTime.UtcNow;
                _medications = new List<Medication>();
            }
        
            public void AddMedication(Medication medication)
            {
                _medications.Add(medication);
            }
        
            public void RemoveMedication(Guid medicationId) 
            {
                var medication = _medications.FirstOrDefault(m => m.Id == medicationId);
                if (medication != null)
                {
                    _medications.Remove(medication);
                }
            }
        
            public void UpdateNotes(string notes)
            {
                Notes = notes;
            }
        
            public void DeactivatePrescription()
            {
                IsActive = false;
            }
        
            public void ActivatePrescription()
            {
                IsActive = true;
            }
        }