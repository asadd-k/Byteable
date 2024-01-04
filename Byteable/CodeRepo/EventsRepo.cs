using Byteable.Models;

namespace Byteable.CodeRepo
{
    public class EventsRepo : IEvents
    {
        private readonly ByteableDbContext _context;

        public EventsRepo(ByteableDbContext context)
        {
            _context=context;
        }

        public void AddNewEvent(Events events)
        {
            var CompType = (Competition)events._competitontype;
            events.CompetitionType = CompType.ToString();

            if (!ValidateDate(events.StartDate, events.EndDate, events.Month, events.Year))
            {
                throw new InvalidOperationException("Invalid Date");
            }
            _context.Add(events);
            _context.SaveChanges();
        }
        private bool ValidateDate(string startday, string end_day, string month, string year)
        {
            string[] Months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            int StartDay = System.Convert.ToInt32(startday);
            int EndDay = System.Convert.ToInt32(end_day);
            int Year = System.Convert.ToInt32(year);

            if (StartDay < 1 || StartDay > 31)
            {
                return false;
            }
            if (EndDay < 1 || EndDay > 31)
            {
                return false;
            }

            if (Year < 0001 || EndDay > 9999)
            {
                return false;
            }
            bool MonthPresent = false;
            foreach (string _month in Months)
            {
                if (month == _month)
                {
                    MonthPresent = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
            if (!MonthPresent)
            {
                return false;
            }

            return true;
        }

        public List<Events> GetAllEvents()
        {
            var result = _context.Events.ToList();
            return result;
        }

        public Events ViewEventDetails(int id)
        {
            var result = _context.Events.Find(id);

            if (result == null)
            {
                //throw new InvalidOperationException($"No Competition exists with ID {id}");
                return null;
            }

            return result;
        }
        public void RemoveEvent(int id)
        {
            var result = _context.Events.Find(id);

            if (result == null)
            {
                throw new InvalidOperationException($"No Competition exists with ID {id}");
            }

            _context.Remove(result);
            _context.SaveChanges();
        }
        public void UpdateEvent(int id, Events events)
        {
            var existingEvent = _context.Events.Find(id);
            if (existingEvent == null) { throw new InvalidOperationException($"No Competition exists with ID {id}"); }

            existingEvent.EventName = events.EventName;
            existingEvent.EventType = events.EventType;
            existingEvent.EventColor = events.EventColor;
            existingEvent._competitontype = events._competitontype;
            existingEvent.CompetitionType= events.CompetitionType;
            existingEvent.StartDate = events.StartDate;
            existingEvent.EndDate = events.EndDate;
            existingEvent.Month = events.Month;
            existingEvent.Year = events.Year;

            var CompType = (Competition)events._competitontype;
            existingEvent.CompetitionType = CompType.ToString();

            if (!ValidateDate(existingEvent.StartDate, existingEvent.EndDate, existingEvent.Month, existingEvent.Year))
            {
                throw new InvalidOperationException("Invalid Date");
            }

            _context.Update(existingEvent);
            _context.SaveChanges();
        }


    }
}
