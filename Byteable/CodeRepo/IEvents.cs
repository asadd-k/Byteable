using Byteable.Models;

namespace Byteable.CodeRepo
{
    public interface IEvents
    {
        public void AddNewEvent(Events events);
        public List<Events> GetAllEvents();
        public Events ViewEventDetails(int id);
        public void RemoveEvent(int id);
        public void UpdateEvent(int id, Events events);
    }
}
