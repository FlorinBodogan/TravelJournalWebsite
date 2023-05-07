namespace TravelJournalAPI.Shared.Entities
{
    public class Holiday
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public List<Image> Images { get; set; }
    }
}
