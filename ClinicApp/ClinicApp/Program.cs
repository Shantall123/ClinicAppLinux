using ClinicApp.Notifications;
using ClinicApp.Scheduling;
using ClinicApp.Storage;

namespace ClinicApp;

class Program {
    static void Main(string[] args) {
        // Crear los almacenes
        IPatientStore patientStore = new InMemoryPatientStore();
        IDentistStore dentistStore = new InMemoryDentistStore();
        IDentalOfficeStore officeStore = new InMemoryDentalOfficeStore();
        IAppointmentStore appointmentStore = new InMemoryAppointmentStore();

        // Crear los canales de notificación
        List<INotificationChannel> channels = new List<INotificationChannel>
        {
            new EmailNotifier(),
            new WhatsAppNotifier(),
        };

        // Crear el servicio que contiene la lógica
        // para programar las citas
        AppointmentScheduler appointmentscheduler = new AppointmentScheduler(
            patientStore,
            dentistStore,
            officeStore,
            appointmentStore,
            channels
        );

        // Crear los objetos
        Patient patientJuan = new Patient("Juan Perez", "juan@correo.com");
        Dentist dentistCarlos = new Dentist(
            "Carlos Ruiz",
            "carlos@clinicapp.com",
            appointmentscheduler
        );
        DentalOffice centralOffice = new DentalOffice("Consultorio Centro");
        Recepcionist recepcionistSthepani = new Recepcionist("Sthepani", "sthepani@gmail.com", appointmentscheduler);


        // Almacenar los objetos
        patientStore.Add(patientJuan);
        dentistStore.Add(dentistCarlos);
        officeStore.Add(centralOffice);

        // ======================================================
        //    LSP: USAR LA ABSTRACCION (Interfaz: IScheduler)
        // ====================================================== 

        IScheduler scheduler;

        //El dentista puede agendar
        scheduler = dentistCarlos;

        Appointment appointment1 = scheduler.Schedule(patientJuan.GetId(),
            dentistCarlos.GetId(), centralOffice.GetId(), DateTime.Now.AddDays(1),
            DateTime.Now.AddDays(1).AddHours(1));

        Console.WriteLine("Cita agendada por el dentista: " + appointment1.GetId());

        //Una recepcionista puede agendar
        scheduler = recepcionistSthepani;

        Appointment appointment2 = scheduler.Schedule(patientJuan.GetId(),
            dentistCarlos.GetId(), centralOffice.GetId(), DateTime.Now.AddDays(1),
            DateTime.Now.AddDays(1).AddHours(1));

        Console.WriteLine("Cita agendada por la recepcionista: " + appointment2.GetId());


    }
}