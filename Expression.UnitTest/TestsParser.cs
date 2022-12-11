namespace Expression.UnitTest
{
    public class TestsParser
    {


        [Theory]
        [TestCaseSource(nameof(SourceList))]
        public void Test_Multiple_Sum(KeyValuePair<string, int> keyValuePair)
        {
            Assert.That(GetResult(keyValuePair.Key), Is.EqualTo(keyValuePair.Value));
        }

        private static int GetResult(string input)
        {
            var alberoDecisionale = new Parser(LeggiToken.Leggi(input)).GetEspressione();
            var risultato = new Evaluator(alberoDecisionale).Evaluate();
            return risultato;
        }

        private static IEnumerable<KeyValuePair<string, int>> SourceList
        {
            get
            {
                var dictionary = new Dictionary<string, int>()
                {
                    {"(1*2)*-(8+9)", -34 },
                    {"1+2", 3 },
                    {"1*3*4*6*7*0", 0 },

                };

                foreach (var item in dictionary)
                    yield return item;
            }
        }

    }
}