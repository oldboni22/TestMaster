namespace Pryanik.Db.Models
{
    public struct Question
    {
        private int _id;
        private int _testId;
        private int _length;
        private float _text;

        public int ID => _id;
        public int TestId => _testId;
        public int Length => _length;
        public float Text => _text;

        public Question(int id, int testId, int length, float text)
        {
            _id = id;
            _testId = testId;
            _length = length;
            _text = text;
        }
    }
}