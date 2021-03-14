using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace PensionGame.Core.Common
{
    public class RandomGenerator : IRandom
    {
        public IEnumerable<double> GenerateNormal(double mu, double sigma)
        {
            return GenerateWithDistribution(new Normal(mu, sigma));
        }

        public IEnumerable<double> GenerateUniform(double a, double b)
        {
            return GenerateWithDistribution(new ContinuousUniform(a, b));
        }

        public IEnumerable<int> GenerateBernoulli(double p)
        {
            return GenerateWithDistribution(new Bernoulli(p));
        }

        private IEnumerable<double> GenerateWithDistribution(IContinuousDistribution distribution)
        {
            while (true)
            {
                yield return distribution.Sample();
            }
        }

        private IEnumerable<int> GenerateWithDistribution(IDiscreteDistribution distribution)
        {
            while (true)
            {
                yield return distribution.Sample();
            }
        }
    }
}
