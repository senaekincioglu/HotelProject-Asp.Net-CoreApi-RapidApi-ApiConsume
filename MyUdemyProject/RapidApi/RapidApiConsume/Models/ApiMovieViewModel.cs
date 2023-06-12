namespace RapidApiConsume.Models
{
    public class ApiMovieViewModel//Bunların içerisinde bazı property ler dahil olacak. Bunlar ise sitedeki result ın içerisindeki değerlerden olacak.Neyi getirmek istiyorsan onu yazacaksın
    {
        public int rank { get; set; }
        public string title { get; set; }
        public string rating { get; set; }
        public string trailer { get; set; }
    }
}
