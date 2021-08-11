using System;
using TPQPrototype.Enums;

namespace TPQPrototype.Shared.Response
{
    public class SearchResponseModel
    {
        public Guid Id { get; set; }
        public OperatorType OperatorType { get; set; }
        public ContentType ContentType { get; set; }
        public string Content { get; set; }
    }
}
