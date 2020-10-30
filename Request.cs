using System;

namespace rabbitmq_sender
{
  public class Request
  {
    public Guid RequestId { get; set; }
    public Header Header { get; set; }
    public string Body { get; set; }
  }
}