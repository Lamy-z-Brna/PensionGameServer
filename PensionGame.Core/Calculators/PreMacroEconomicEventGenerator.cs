﻿using PensionGame.Core.Calculators.Parameters;
using PensionGame.Core.Common;
using PensionGame.Core.Events.PreMacroEconomicEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Calculators
{
    public sealed class PreMacroEconomicEventGenerator : IPreMacroEconomicEventGenerator
    {
        private readonly IRandomSampler _random;
        private readonly IPreMacroEconomicEventParameters _parameters;

        public PreMacroEconomicEventGenerator(IRandomSampler random, IPreMacroEconomicEventParameters parameters)
        {
            _random = random;
            _parameters = parameters;
        }        

        public IEnumerable<IPreMacroEconomicEvent> Generate()
        {
            var isCrisis = _random.GenerateBernoulli(_parameters.CrisisProbability)
                .First();

            if (isCrisis)
                yield return new CrisisEvent();
        }
    }
}