using System.Collections.Generic;
using System.Linq;

namespace DogGo.Models.ViewModels
{
    public class WalkerProfileViewModel
    {
        public Walker Walker { get; set; }
        public List<Walk> Walks { get; set; }
        public string TotalWalkTime
        {
            get
            {
                int totalMinutes = Walks.Select(w => w.Duration).Sum() / 60;
                int totalHours = totalMinutes / 60;
                int minutes = totalMinutes % 60;
                return $"{totalHours}hr {minutes}min";
            }
        }
    }
}
