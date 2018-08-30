using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class EventMessage
    {
        public EventMessage(EventTopic t)
        {
            topic = t;
        }
        public EventTopic topic;
    }
}
