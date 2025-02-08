namespace Pryanik.Db.Models
{
    public struct Answer
    {
        private int _id;
        private int _questionId;
        private string _text;
        private bool _isCorrect;


        public int ID => _id;
        public int QuestionId => _questionId;
        public string Text => _text;
        public bool IsCorrect => _isCorrect;

        public Answer(int id, int questionId, string text, int isCorrect)
        {
            _id = id;
            _questionId = questionId;
            _text = text;
            _isCorrect = isCorrect == 1;
        }
    }
}