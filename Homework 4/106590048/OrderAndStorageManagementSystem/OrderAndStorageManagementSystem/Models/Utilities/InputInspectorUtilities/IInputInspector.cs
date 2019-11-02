namespace OrderAndStorageManagementSystem.Models.Utilities.InputInspectorUtilities
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
