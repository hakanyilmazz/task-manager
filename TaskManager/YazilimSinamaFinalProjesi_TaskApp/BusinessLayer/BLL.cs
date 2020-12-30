using DataLayer;

namespace BusinessLayer
{
    public class BLL
    {
        protected Helper database;

        public BLL()
        {
            database = Helper.CreateInstance;
        }
    }
}
