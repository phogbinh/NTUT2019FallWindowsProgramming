namespace OrderAndStorageManagementSystem.PresentationModels.Utilities
{
    public class ControlStates
    {
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }
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
        private bool _enabled;
        private string _text;

        public ControlStates()
        {
            _enabled = true;
        }
    }
}
