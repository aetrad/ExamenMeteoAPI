namespace meteoAPI
{
    public class FavoriteLocation
    {
        public string CityName { get; set; }
        public string Country { get; set; }
        public double Temperature { get; set; } // Ajout de la propriété Temperature
        public string Description { get; set; } // Ajout de la propriété Description
        public string Comment { get; set; } // Ajout de la propriété Comment

        // Constructeur par défaut
        public FavoriteLocation()
        {
        }

        // Constructeur avec paramètres
        public FavoriteLocation(string cityName, string country)
        {
            CityName = cityName;
            Country = country;
        }

        // Changez cette méthode pour qu'elle ne soit plus statique
        public void RoundTemperature()
        {
            // Utilisation de la propriété Temperature de l'instance courante
            Temperature = Math.Round(Temperature);
        }
    }
}
