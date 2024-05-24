namespace MeirellescPortfolio.Models
{
    public record ProjectModel
    {
        public int Id { get; set; }
        public String? GameTitle { get; set; }
        public String? GameSubtitle { get; set; }
        public String? AddressPath { get; set; }
        public String? ImagePath { get; set; }
        public String? IconPath { get; set; }
    }
}
