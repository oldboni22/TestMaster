namespace Pryanik.Db.Models
{
    public struct Test
    {
        private int _id;
        private int _themeId;
        private string _name;
        private int _duration;

        public int ID => _id;
        public int ThemeId => _themeId;
        public string Name => _name;
        public int Duration => _duration;


        public Test(int id, int themeId, string name, int duration)
        {
            _id = id;
            _themeId = themeId;
            _name = name;
            _duration = duration;
        }
    }
}