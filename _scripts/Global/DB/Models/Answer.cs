namespace Pryanik.Db.Models
{
    public class Answer : ModelBase
    {
        private readonly int _questionId;
        private readonly bool _isCorrect;
        
        public int QuestionId => _questionId;
        public bool IsCorrect => _isCorrect;

        public Answer(int id, int questionId, string text, int isCorrect) : base(id,text)
        {
            _questionId = questionId;
            _isCorrect = isCorrect == 1;
        }
    }
}