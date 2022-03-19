using System;
using System.Linq;
using System.Windows.Controls;


namespace Calculator
{
    class Validator
    {

        private readonly Label _label;
        private readonly string _content;

        private bool _success = false;

        public Validator(Label label, string content)
            => (_label, _content) = (label, content);
        public Validator CheckCommaAdding()
        {
            if (_content != null && _content != "" && !_content.Contains(','))
                _success = true;
            return this;
        }
        public Validator CheckDigitAdding()
        {
            if (_content == "0")
                _label.Content = "";

            ChangeFontSize();

            if (string.Concat(_content.Where(char.IsDigit)).Length < 16)
                _success = true;

            return this;
        }
        public Validator CheckResultValue()
        {
            ChangeFontSize();

            if (string.Concat(_content.Where(char.IsDigit)).Length < 16)
                _success = true;
            return this;
        }
        private void ChangeFontSize()
        {
            if (_content.Length >= 8)
                _label.FontSize = 40;

            if (_content.Length >= 12)
                _label.FontSize = 32;
        }
        public void CheckValue()
        {
            if (_content.EndsWith(','))
                _label.Content += "0";           
        }
        public void Validate()
        {
            if (_success) 
                _label.Content = _content;
        }
        public void ValidateSpecial(String AddingElement)
        {
            if (_success)
                _label.Content +=  AddingElement;
            
        }
    }
}
