using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace webapi.Data.Models
{
    public class TravelModel:BaseModel
    {
        public string Description { get; set; } = String.Empty;
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; } = DateTime.UtcNow;
        public virtual List<Comment>? Comments { get; set; }
        public virtual List<User>? Users { get; set; }
        
        public List<Media>? Media { get; set; }
        public double Price { get; set; }

    }
}
