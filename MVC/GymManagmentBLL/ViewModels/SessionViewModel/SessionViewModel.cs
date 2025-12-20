using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.SessionViewModel
{
    public class SessionViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string TrainerName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Capacity { get; set; }
        public int AvailableSlots { get; set; }

        #region computed properties
        public string DateDisplay => $"{StartDate: MM dd, yyyy}";
        public string TimeRange => $"{StartDate:hh:mm tt} - {EndDate:hh:mm tt}";
        public TimeSpan Duration => EndDate - StartDate;
        public string Status {
            get
            { 
                if (StartDate > DateTime.Now)
                    return "Upcoming";
                else if (EndDate < DateTime.Now)
                    return "Completed";
                else
                    return "Ongoing";
            }
        }
        #endregion

    }
}
