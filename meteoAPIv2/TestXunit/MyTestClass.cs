using Bunit;
using Xunit;

namespace meteoAPI
{
    public class MyTestClass : TestContext // Cette classe hérite de TestContext pour pouvoir utiliser BUnit
    {
        // Ce test vérifie si la méthode RoundTemperature arrondit correctement la température
        [Fact]
        public void TestRoundTemperature()
        {
            // Arrange : Préparation des données de test
            var favorite = new FavoriteLocation(); // Crée une instance de FavoriteLocation
            favorite.Temperature = 3.6; // Définit la température de l'instance favorite

            // Act : Exécution de la méthode à tester
            favorite.RoundTemperature(); // Appel de la méthode RoundTemperature sur l'instance favorite

            // Assert : Vérification des résultats
            Assert.Equal(4, favorite.Temperature); // Vérifie si la température a été correctement arrondie à 4 degrés
        }

        // Ce test vérifie également si la méthode RoundTemperature arrondit correctement la température
        [Fact]
        public void TestFavoriteLocationCreation()
        {
            // Arrange : Préparation des données de test

            // Act : Exécution de la méthode à tester
            var favorite = new FavoriteLocation("Paris", "France");

            // Assert : Vérification des résultats
            Assert.NotNull(favorite); // Vérifie si l'instance de FavoriteLocation est créée avec succès
            Assert.Equal("Paris", favorite.CityName); // Vérifie si la ville est correctement définie
            Assert.Equal("France", favorite.Country); // Vérifie si le pays est correctement défini
        }




    }
}
