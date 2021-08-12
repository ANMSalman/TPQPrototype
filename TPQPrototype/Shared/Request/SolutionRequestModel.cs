using System;
using System.Collections.Generic;
using TPQPrototype.Shared.Enums;

namespace TPQPrototype.Shared.Request
{
    public class SolutionRequestModel
    {
        public List<Guid> Ids { get; set; }
        public Problem Problem { get; set; }
        public string Solution { get; set; }
    }
}
