using System;
using TPQPrototype.Shared.Enums;

namespace TPQPrototype.Entities
{
    public class ProcessingQueue
    {
        public Guid Id { get; set; }
        public OperatorType OperatorType { get; set; }
        public ContentType ContentType { get; set; }
        public string Content { get; set; }
    }
}
