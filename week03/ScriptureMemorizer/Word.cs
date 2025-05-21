using System;

namespace ScriptureMemorizer
{
    public class Word
    {
        private string _text;
        private bool _hidden;

        public Word(string text)
        {
            _text = text;
            _hidden = false;
        }

        public bool IsHidden => _hidden;

        public void Hide()
        {
            _hidden = true;
        }

        public override string ToString()
        {
            if (!_hidden)
                return _text;
            else
                return new string('_', _text.Length);
        }
    }
}
