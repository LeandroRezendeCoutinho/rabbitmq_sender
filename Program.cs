using System;

namespace rabbitmq_sender
{
  class Program
  {
    static void Main(string[] args)
    {
      var sender = new Sender();
      sender.Send();
    }
  }
}
