namespace SocialNetwork.Entities
{
    public enum AgeGroup
    {
        TwelveTo
    }

    public class SearchData
    {
        public string Name { get; set; }

        public Sex? Sex { get; set; }

        public int HometownId { get; set; }
    }
}