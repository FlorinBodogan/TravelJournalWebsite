namespace TravelJournalAPI.Shared.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }
        public Holiday Holiday { get; set; }
        public Guid HolidayId { get; set; }
    }
}
