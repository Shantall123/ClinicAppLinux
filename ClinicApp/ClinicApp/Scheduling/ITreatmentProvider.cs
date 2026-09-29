using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicApp.Scheduling;
public interface ITreatmentProvider {
   void CompleteTratment (Appointment appointment);
}
