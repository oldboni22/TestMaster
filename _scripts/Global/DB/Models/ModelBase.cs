namespace Pryanik.Db.Models
{
    public abstract class ModelBase
    {
        private readonly int _id;
        private readonly string _text;
        
        public int ID => _id;
        public string Text => _text;

        protected ModelBase(int id, string text)
        {
            _id = id;
            _text = text;
        }
        
    }
    
}