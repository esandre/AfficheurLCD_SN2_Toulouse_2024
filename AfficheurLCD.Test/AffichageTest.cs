using System.Runtime.InteropServices;

namespace AfficheurLCD.Test
{
    public class AffichageTest
    {
        public static IEnumerable<object[]> CasTestChiffre()
        {
            yield return [1, Nombres.Un];
            yield return [2, Nombres.Deux];
            yield return [3, Nombres.Trois];
            yield return [4, Nombres.Quatre];
            yield return [5, Nombres.Cinq];
            yield return [6, Nombres.Six];
            yield return [7, Nombres.Sept];
            yield return [8, Nombres.Huit];
            yield return [9, Nombres.Neuf];
            yield return [0, Nombres.Zero];
        }

        [Theory]
        [MemberData(nameof(CasTestChiffre))]
        public void TestChiffre(int n, string attendu)
        {
            Assert.Equal(attendu, n.AsLCD());
        }

        [Fact]
        public void CentOnze_Horizontal()
        {
            var attendu =
                "           " + Environment.NewLine +
                "  |   |   |" + Environment.NewLine +
                "  |   |   |" + Environment.NewLine;

            Assert.Equal(attendu, 111.AsLCD());
        }

        [Fact]
        public void Onze_Horizontal()
        {
            var attendu =
                "       " + Environment.NewLine +
                "  |   |" + Environment.NewLine +
                "  |   |" + Environment.NewLine;

            Assert.Equal(attendu, 11.AsLCD());
        }
    }
}