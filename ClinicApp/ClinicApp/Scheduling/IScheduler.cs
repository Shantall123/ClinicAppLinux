using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicApp.Scheduling;
public interface IScheduler {
    Appointment Schedule(Guid patientId, Guid dentistId, Guid officeId, DateTime startDate, DateTime endDate);
    void Cancel(Appointment appointment);
}
