using System.Collections.Generic;

namespace PensionGame.Core.Common
{
    public interface IRandomSampler
    {
        IEnumerable<double> GenerateNormal(double mu, double sigma);

        //TODO VB implement
        //IReadOnlyCollection<double> GenerateLogNormal(double mu, double sigma);

        IEnumerable<double> GenerateUniform(double a, double b);

        IEnumerable<bool> GenerateBernoulli(double p);
    }
}
