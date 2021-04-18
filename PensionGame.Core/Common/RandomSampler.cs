using MathNet.Numerics.Distributions;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Common
{
    public class RandomSampler : IRandomSampler
    {
        public IEnumerable<double> GenerateNormal(double mu, double sigma)
        {
            return GenerateWithDistribution(new Normal(mu, sigma));
        }

        //TODO VB implement + unit test
        //public IReadOnlyCollection<double> GenerateLogNormal(double mu, double sigma)
        //{
        //    return GenerateWithDistribution(new LogNormal(mu, sigma));
        //}

        public IEnumerable<double> GenerateUniform(double a, double b)
        {
            return GenerateWithDistribution(new ContinuousUniform(a, b));
        }

        public IEnumerable<bool> GenerateBernoulli(double p)
        {
            return GenerateWithDistribution(new Bernoulli(p))
                .Select(i => i == 1);
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
