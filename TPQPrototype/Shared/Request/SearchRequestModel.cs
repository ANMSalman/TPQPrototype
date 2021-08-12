using System;
using System.Collections.Generic;
using TPQPrototype.Shared.Enums;

namespace TPQPrototype.Shared.Request
{
    public class SearchRequestModel
    {
        public List<OperatorType> Operators { get; set; }
        public List<long> Networks { get; set; }
        public List<ContentType> ContentTypes { get; set; }
        public SearchParameters SearchParameters { get; set; }
    }

    public class SearchParameters
    {
        public string SearchText { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
