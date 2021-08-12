using System;
using System.Collections.Generic;
using TPQPrototype.Shared.Enums;

namespace TPQPrototype.Shared.Request
{
    public class SearchRequestModel
    {
        public List<OperatorType> Operators { get; set; }
        public List<long> Networks { get; set; }
        public OperatorSearchParameters OperatorSearchParameters { get; set; }
    }

    public class OperatorSearchParameters
    {
        public List<ContentType> ContentTypes { get; set; }
        public ContentSearchParameters ContentSearchParameters { get; set; }
    }

    public class ContentSearchParameters
    {
        public string SearchText { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
