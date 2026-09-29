using ClinicApp.Scheduling;

namespace ClinicApp;

internal class Recepcionist : IScheduler {

    private readonly Guid _id;
    private readonly String _name;
    private readonly String _email;


    //Nuevo requerimiento
    private readonly AppointmentScheduler _scheduler;

    //Pasar la referencia de APpointmentScheduler por constructor

    public Recepcionist(string name, string email, AppointmentScheduler scheduler) {
        ContactValidator.Validate(name, email);
        _id = Guid.NewGuid();
        _name = name;
        _email = email;
        _scheduler = scheduler;
    }

    public Guid GetId() {
        return _id;
    }

    public String GetName() {
        return _name;
    }

    public String GetEmail() {
        return _email;
    }

    public Appointment Schedule(Guid patientId, Guid dentistId, Guid officeId, DateTime start, DateTime end) {
        return _scheduler.Schedule(patientId, dentistId, officeId, start, end);
    }

    public void Cancel(Appointment appointment) {
        appointment.Cancel();
    }
}