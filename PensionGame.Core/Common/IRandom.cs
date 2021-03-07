using System.Collections.Generic;

namespace PensionGame.Core.Common
{
    public interface IRandom
    {
        IEnumerable<double> GenerateNormal(double mu, double sigma);

        IEnumerable<double> GenerateUniform(double a, double b);

        IEnumerable<double> GenerateAlternative(double p);
    }
}
