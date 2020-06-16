using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class Event : Baseentity<Guid>
    {
        private Event()
        {

        }
        public Event(DateTime dates)
        {
            date = dates;
        }
        public string actionName { get; set; }
        public string jsonRequest { get; set; }
        public string jsonResponse { get; set; }
        public string EntityName { get; set; }
        public DateTime date { get; set; }
        public bool Issucces { get; set; }
    }
}
