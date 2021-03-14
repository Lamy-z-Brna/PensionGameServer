using NUnit.Framework;
using PensionGame.Core.Common;
using System;
using System.Linq;

namespace PensionGame.Tests
{
    [TestFixture]
    public class RandomGeneratorTest
    {
        [Test]
        public void Normal_Does_Not_Repeat_Itself()
        {
            var norm1 = new RandomSampler().GenerateNormal(10, 5).First();
            var norm2 = new RandomSampler().GenerateNormal(10, 5).First();

            Assert.AreNotEqual(norm1, norm2);
        }

        [TestCase(10, 5)]
        [TestCase(-3.5, 0.5)]
        public void Normal_Correct_Mean_And_Deviation(double mu, double sigma)
        {
            var norm = new RandomSampler().GenerateNormal(mu, sigma).Take(1000).ToList();

            var mean = norm.Average();

            var deviation = Math.Sqrt(norm.Select(x => (mean - x) * (mean - x)).Average());

            //var histogram = norm.GroupBy(x => (int)x)
            //                    .OrderBy(g => g.Key)
            //                    .ToDictionary(g => g.Key, g => g.Count());

            Assert.AreEqual(mu, mean, 0.1 * sigma);
            Assert.AreEqual(sigma, deviation, 0.1 * sigma);
        }

        [Test]
        public void Uniform_Does_Not_Repeat_Itself()
        {
            var num1 = new RandomSampler().GenerateUniform(2, 5).First();
            var num2 = new RandomSampler().GenerateUniform(2, 5).First();

            Assert.AreNotEqual(num1, num2);
        }

        [TestCase(1, 5)]
        public void Uniform_Boundaries(double a, double b)
        {
            var values = new RandomSampler().GenerateUniform(a, b).Take(1000).ToList();

            Assert.GreaterOrEqual(values.Min(), a);
            Assert.LessOrEqual(values.Max(), b);
        }

        [TestCase(0.3)]
        public void Bernoulli_Probs(double p)
        {
            var values = new RandomSampler().GenerateBernoulli(p).Take(1000).ToList();

            Assert.AreEqual(p, ((double)values.Count(x => x))/values.Count, 0.04);
        }
    }
}
