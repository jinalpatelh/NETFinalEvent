using System;

namespace NETFinalEvent
{
    class Program
	{
		// Que Write classes for events, one class which exposes an event and another which handles the event.
		//1)    Create a class to pass as an argument for the event handlers
		//2)    Set up the delegate for the event
		//3)    Declare the code for the event
		//4)    Create code the will be run when the event occurs
		//5)    Associate the event with the event handler

		static void Main(string[] args)
        {
			var person = new Person();
			var notify = new Notification();
			notify.userevent += person.SendNotification;

			person.name = Console.ReadLine();
			person.Display();
			notify.Alarm();

		}
		public class Person
		{
			public string name { get; set; }

			public void SendNotification(object sender, NotifyEventArgs e)
			{
				Console.WriteLine($"Notification: {e._message}");
			}
			public void Display()
			{
				Console.WriteLine($"Hi {name} ");
			}

		}

		public class Notification
		{
			public event NotificationEventHandler userevent;

			public void Alarm()
			{
				NotificationEventHandler handeler = userevent;
				if (userevent != null)
				{
					handeler(this, new NotifyEventArgs("Welcome to the team"));
				}

			}
		}

		public delegate void NotificationEventHandler(object source, NotifyEventArgs e);

		public class NotifyEventArgs : EventArgs
		{
			public string _message { get; set; }
			public NotifyEventArgs(string message)
			{
				this._message = message;

			}
		}
	}
}
