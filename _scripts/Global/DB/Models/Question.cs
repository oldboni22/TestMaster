namespace Pryanik.Db.Models
{
    public struct Question
    {
        private int _id;
        private int _testId;
        private int _length;
        private string _text;

        public int ID => _id;
        public int TestId => _testId;
        public int Length => _length;
        public string Text => _text;

        public Question(int id, int testId, int length, string text)
        {
            _id = id;
            _testId = testId;
            _length = length;
            _text = text;
        }
    }
}