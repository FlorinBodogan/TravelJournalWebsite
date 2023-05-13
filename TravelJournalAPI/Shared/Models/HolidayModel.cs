using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelJournalAPI.Shared.Models
{
    public class HolidayModel
    {
        public DateTime startDate {  get; set; }
        public DateTime endDate { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid UserId { get; set; }
    }
}
