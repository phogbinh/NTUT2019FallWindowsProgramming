namespace InputInspectingElements.InputInspectors
{
    public interface IInputInspector
    {
        /// <summary>
        /// Return true if the control is valid.
        /// </summary>
        bool IsValid();

        /// <summary>
        /// Return the error of this inspector.
        /// </summary>
        string GetError();
    }
}
