namespace TravelJournalAPI.Shared.Entities
{
    public class Holiday
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public User? User { get; set; }
        public Guid? UserId { get; set; }
        public List<Image>? Images { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
    }
}
