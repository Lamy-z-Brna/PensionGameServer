using System;

namespace PensionGame.Web.Helpers
{
    public static class FunNamesGenerator
    {
        private static readonly Random random = new();

        private static readonly string[] Subjects = { "Shymo", "Anička", "Adam", "Bači", "Miki", "Maja", "Matovič", "Zeman", "Sulík", "Ciťo", "Peťo 2D", "Peťo 3D", "Donald Trump", "Joe Biden", "Babiš", "A scientist", "An epidemologist" };
        private static readonly string[] Verbs = { "is", "is best in", "ordered", "maintains", "is looking forward to", "loves", "approves of", "is cooking up", "has", "took a photo of", "found a photo of", "doesn't have", "fixed", "created", "found", "knows nothing about", "predicts", "issued a warning about", "waits for", "saves for", "wants", "lost", "won", "won 6 times", "is looking for", "looks like", "caught", "cares about", "would like" };
        private static readonly string[] Adjectives = { "a huge", "a useless", "an expensive", "a toy", "a not great not terrible", "best in covid", "a crazy", "a dangerous", "an annoying", "no", "an inappropriate", "a cheap", "a fancy", "a tiny", "an overpriced", "a bad", "a significant", "a sleepy", "a malicious", "a stolen", "a massive", "your" };
        private static readonly string[] Objects = { "vaccine", "lock-down", "pension", "face mask", "Sputnik", "covid", "something", "sense of humour", "bug", "election", "election result", "election fraud", "joke", "result", "victory", "loss", "failure", "character" };

        public static string Generate()
        {
            var subjectNoun = PickRandom(Subjects);
            var verb = PickRandom(Verbs);
            var adjective = PickRandom(Adjectives);
            var objectNoun = PickRandom(Objects);

            return $"{subjectNoun} {verb} {adjective} {objectNoun}";
        }

        private static string PickRandom(string[] collection)
            => collection[random.Next(0, collection.Length)];
    }
}
