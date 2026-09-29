
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicApp.Notifications;

public class SmsNotifier : INotificationChannel {
    public void Send(Appointment appointment) {
        // TODO: enviaria un mensaje SMS con los datos de la cita aqui
        Console.WriteLine("SMS enviado para la cita: " + appointment.GetId());
    }
}