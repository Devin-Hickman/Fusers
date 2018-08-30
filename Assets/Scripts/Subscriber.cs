using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Subscriber
    {
        public List<EventTopic> subscribedTopics = new List<EventTopic>();
        private Queue<EventMessage> receivedMessages = new Queue<EventMessage>();

        public Subscriber(PubSubHandler p, List<EventTopic> et)
        {
            subscribedTopics = et;
            try
            {
                p.AddSubscriber(this);
            }
            catch (ArgumentNullException e)
            {

            }

        }

        public void ReceiveMessage(EventMessage e)
        {
            receivedMessages.Enqueue(e);
            Print(e);
        }

        private void Print(EventMessage e)
        {
            Console.WriteLine("Received message {0}", e.topic);
        }
    }
}


