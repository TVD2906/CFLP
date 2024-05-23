//Să presupunem că dezvolți un sistem de gestionare a notificărilor pentru o aplicație mobilă. Utilizatorii pot subscrie la diferite tipuri de notificări, cum ar fi notificări despre actualizări ale aplicației, notificări de mesaje primite sau notificări despre evenimente în calendar.

//Creează o clasă NotificationService care să gestioneze aceste notificări. Această clasă ar trebui să permită subscrierea utilizatorilor la diferite tipuri de notificări și trimiterea acestora atunci când sunt disponibile.

//Cerințe:

//Definirea clasei NotificationService cu următoarele funcționalități:
//Metoda Subscribe care primește un ID de utilizator și tipul de notificare la care să se aboneze.
//Metoda Unsubscribe care primește un ID de utilizator și tipul de notificare de la care să se dezaboneze.
//Metoda SendNotification care primește un tip de notificare și trimite notificarea tuturor utilizatorilor abonați la acel tip de notificare.
//Definirea unei clase de tip EventArgs pentru a transporta informații despre notificări.
//Definirea evenimentelor corespunzătoare pentru fiecare tip de notificare.
//Implementarea metodelor Subscribe, Unsubscribe și SendNotification.
//Utilizarea evenimentelor pentru a trimite notificări la subscrieri.


using System;
using System.Collections.Generic;

class NotificationEventArgs : EventArgs {
    public string Message { get; }

    public NotificationEventArgs(string message) {
        Message = message;
    }
}

class NotificationService {
    public event EventHandler<NotificationEventArgs> AppUpdateNotification;
    public event EventHandler<NotificationEventArgs> MessageNotification;
    public event EventHandler<NotificationEventArgs> CalendarEventNotification;

    private Dictionary<int, HashSet<string>> subscriptions = new Dictionary<int, HashSet<string>>();

    public void Subscribe(int userId, string notificationType) {
        if (!subscriptions.ContainsKey(userId)) {
            subscriptions[userId] = new HashSet<string>();
        }
        subscriptions[userId].Add(notificationType);
    }

    public void Unsubscribe(int userId, string notificationType) {
        if (subscriptions.ContainsKey(userId)) {
            subscriptions[userId].Remove(notificationType);
        }
    }

    public void SendNotification(string notificationType, string message) {
        NotificationEventArgs args = new NotificationEventArgs(message);
        switch (notificationType) {
            case "AppUpdate":
                AppUpdateNotification?.Invoke(this, args);
                break;
            case "Message":
                MessageNotification?.Invoke(this, args);
                break;
            case "CalendarEvent":
                CalendarEventNotification?.Invoke(this, args);
                break;
        }
    }
}

class Program {
    static void Main(string[] args) {
        NotificationService notificationService = new NotificationService();

        notificationService.Subscribe(1, "AppUpdate");
        notificationService.Subscribe(2, "Message");
        notificationService.Subscribe(3, "CalendarEvent");
        notificationService.Subscribe(1, "CalendarEvent");

        notificationService.AppUpdateNotification += (sender, e) => Console.WriteLine($"App Update Notification: {e.Message}");
        notificationService.MessageNotification += (sender, e) => Console.WriteLine($"Message Notification: {e.Message}");
        notificationService.CalendarEventNotification += (sender, e) => Console.WriteLine($"Calendar Event Notification: {e.Message}");

        notificationService.SendNotification("AppUpdate", "New version available!");
        notificationService.SendNotification("Message", "You have a new message!");
        notificationService.SendNotification("CalendarEvent", "Reminder: Meeting tomorrow.");

        notificationService.Unsubscribe(1, "AppUpdate");
        notificationService.SendNotification("AppUpdate", "New version available!");
    }
}
