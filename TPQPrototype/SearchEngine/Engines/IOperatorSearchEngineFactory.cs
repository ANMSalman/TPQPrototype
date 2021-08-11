﻿using System.Collections.Generic;
using TPQPrototype.Enums;

namespace TPQPrototype.SearchEngine.Engines
{
    public interface IOperatorSearchEngineFactory
    {
        List<IOperatorSearchEngine> GetEngines(List<OperatorType> operators);
    }
}