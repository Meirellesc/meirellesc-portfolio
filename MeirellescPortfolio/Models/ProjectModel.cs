namespace MeirellescPortfolio.Models
{
    public enum ProjectType
    {
        Game,
        Website
    }

    public enum ProjectDevice
    {
        None,
        Desktop,
        Mobile,
        Console
    }

    public record ProjectModel
    {
        public int Id { get; set; }
        public String? GameTitle { get; set; }
        public String? GameSubtitle { get; set; }
        public String? AddressPath { get; set; }
        public String? ImagePath { get; set; }
        public ProjectType? ProjectType { get; set; }
        public ProjectDevice ProjectDevice { get; set; }
    }
}
