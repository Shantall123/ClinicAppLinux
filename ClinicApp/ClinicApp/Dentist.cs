using ClinicApp.Scheduling;

namespace ClinicApp;

public class Dentist : IScheduler, ITreatmentProvider {
    private readonly Guid _id;
    private readonly string _name;
    private readonly string _email;
    private readonly AppointmentScheduler _scheduler;

    public Dentist(string name, string email, AppointmentScheduler scheduler) {
        ContactValidator.Validate(name, email);

        _id = Guid.NewGuid();
        _name = name;
        _email = email;
        _scheduler = scheduler;
    }

    public Guid GetId() {
        return _id;
    }

    public string GetName() {
        return _name;
    }

    public string GetEmail() {
        return _email;
    }

    public void CompleteTratment(Appointment appointment) {
        appointment.Complete();
    }

    public Appointment Schedule(Guid patientId, Guid dentistId, Guid officeId, DateTime startDate, DateTime endDate) {
        return _scheduler.Schedule(patientId, dentistId, officeId, startDate, endDate);
    }

    public void Cancel(Appointment appointment) {
        appointment.Cancel();
    }
}