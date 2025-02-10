namespace Pryanik.Db.Models
{
    public class Question : ModelBase
    {
        
        private readonly int _testId;
        public int TestId => _testId;

        public Question(int id, int testId, string text) : base(id,text)
        {
            _testId = testId;
        }
    }
}