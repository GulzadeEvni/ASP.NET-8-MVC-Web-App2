using StarWars.Entity;

namespace StarWars.Models
{
    public class TopContentViewModel
    {
        //public List<string>? PageTitles { get; set; } birden fazla (string değerli) sütun olduğu için mi böyle tutulamaz 
        public List<TopContent> Contents { get; set; } = new List<TopContent>();

        //List<T> yapısı, tür güvenliği sağlayarak yalnızca belirtilen türdeki öğeleri tutmaya olanak tanır.TopContent türündeki nesneleri içerir.
    }
}
