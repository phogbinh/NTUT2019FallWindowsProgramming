namespace OrderAndStorageManagementSystem.PresentationModelNamespace
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
        private bool _enabled;

        public ControlStates()
        {
            _enabled = true;
        }
    }
}
