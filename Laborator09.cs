//Trebuie să dezvolți o aplicație de gestionare a listei de activități, care să permită utilizatorului să filtreze și să sorteze activitățile. Pentru aceasta, vei folosi delegările în C#.

//Cerințe:

//Definește o clasă Activity cu proprietățile Id, Name, Priority și DueDate.

//Implementează o clasă ActivityManager cu o listă de activități și metode pentru adăugarea, filtrarea și sortarea acestora.

//Creează un delegat PriorityFilterDelegate care primește o activitate și returnează un boolean.

//Implementează o metodă FilterByPriority în ActivityManager, care primește un delegat PriorityFilterDelegate și returnează o listă filtrată de activități.

//Definește un delegat DateSortDelegate care primește două activități și returnează un număr întreg.

//Implementează o metodă SortByDate în ActivityManager, care primește un delegat DateSortDelegate și sortează lista de activități după data limită.


using System;
using System.Collections.Generic;

class Activity {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public DateTime DueDate { get; set; }
}

class ActivityManager {
    private List<Activity> activities = new List<Activity>();

    public void AddActivity(Activity activity) {
        activities.Add(activity);
    }

    public List<Activity> FilterByPriority(Func<Activity, bool> filterDelegate) {
        List<Activity> filteredActivities = new List<Activity>();
        foreach (var activity in activities) {
            if (filterDelegate(activity)) {
                filteredActivities.Add(activity);
            }
        }
        return filteredActivities;
    }

    public void SortByDate(Comparison<Activity> comparisonDelegate) {
        activities.Sort(comparisonDelegate);
    }
}

class Program {
    static void Main(string[] args) {
        ActivityManager manager = new ActivityManager();

        manager.AddActivity(new Activity { Id = 1, Name = "Task 1", Priority = 3, DueDate = DateTime.Now.AddDays(5) });
        manager.AddActivity(new Activity { Id = 2, Name = "Task 2", Priority = 2, DueDate = DateTime.Now.AddDays(3) });
        manager.AddActivity(new Activity { Id = 3, Name = "Task 3", Priority = 1, DueDate = DateTime.Now.AddDays(7) });

        var filtered = manager.FilterByPriority(activity => activity.Priority >= 2);

        manager.SortByDate((a1, a2) => a1.DueDate.CompareTo(a2.DueDate));

        Console.WriteLine("Activitati filtrate:");
        foreach (var activity in filtered) {
            Console.WriteLine($"Id: {activity.Id}, Name: {activity.Name}, Priority: {activity.Priority}, DueDate: {activity.DueDate}");
        }

        Console.WriteLine("\nActivitati sortate:");
        foreach (var activity in manager.Activities) {
            Console.WriteLine($"Id: {activity.Id}, Name: {activity.Name}, Priority: {activity.Priority}, DueDate: {activity.DueDate}");
        }
    }
}
