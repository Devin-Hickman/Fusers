using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Publisher
    {
        public Publisher()
        {
        }

        public void Send(EventMessage message, PubSubHandler pubSubHandler)
        {
            pubSubHandler.messageQueue.Enqueue(message);
        }
    }

    public enum EventTopic
    {
        ENEMY_DEATH,
        ENEMY_REACHED_GOAL,
        ITEMS_DROPPED
    }
}


