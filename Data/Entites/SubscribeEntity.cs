
using System.ComponentModel.DataAnnotations;

namespace Data.Entites
{
    public class SubscribeEntity
    {
        [Key]
        public string Email { get; set; } = null!;
        public bool DailyNewsletter { get; set; }
        public bool AdvertisingUpdate { get; set; }
        public bool WeekInReview { get; set; }
        public bool EventUpdates { get; set; }
        public bool StartupsWeekly { get; set; }
        public bool Podcasts { get; set; }
    }
}
