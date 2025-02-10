namespace Pryanik.Db.Models
{
    public class Test : ModelBase
    {
        
        private readonly int _themeId;
        private readonly int _duration;
        private readonly int _length;

        public int Length => _length;
        public int ThemeId => _themeId;
        public int Duration => _duration;
        
        public Test(int id, int themeId, string text, int duration,int length) : base(id,text)
        {
            _themeId = themeId;
            _duration = duration;
            _length = length;
        }
    }
}