namespace OrderAndStorageManagementSystem.PresentationModelNamespace
{
    public class RichTextBoxStates : ControlStates
    {
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }
        private string _text;
    }
}
