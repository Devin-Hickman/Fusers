using System;

public class PubSubHandler
{
    public Queue<EventMessage> messageQueue = new Queue<EventMessage>();
    private List<Subscriber> subscriberList = new List<Subscriber>();

    public PubSubHandler()
    {

    }

    public void AddSubscriber(Subscriber s)
    {
        subscriberList.Add(s);
    }

    public void Forward()
    {
        while (messageQueue.Count > 0)
        {
            EventMessage tmpMessage = messageQueue.Dequeue();
            foreach (Subscriber subscriber in subscriberList)
            {
                foreach (EventTopic subscribedTopic in subscriber.subscribedTopics)
                {
                    if (tmpMessage.topic == subscribedTopic)
                    {
                        subscriber.ReceiveMessage(tmpMessage);
                    }
                }
            }
        }
    }
}
