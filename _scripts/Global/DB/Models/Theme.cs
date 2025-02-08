namespace Pryanik.Db.Models
{
    public struct Theme
    {
        private readonly int _id;
        private readonly string _name;
        
        public int ID => _id;
        public string Name => _name;

        public Theme(int id, string name)
        {
            _id = id;
            _name = name;
        }
    }
}
