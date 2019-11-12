using InputInspectingElements.InputInspectors;
using System.Collections.Generic;

namespace InputInspectingElements.InputInspectingControls
{
    interface IInputInspectingControl
    {
        /// <summary>
        /// Get the input inspectors of the input inspecting control.
        /// </summary>
        List<IInputInspector> GetInputInspectors();

        /// <summary>
        /// Get error of the input inspectors of the input inspecting control.
        /// </summary>
        string GetInputInspectorsError();

        /// <summary>
        /// Return true if all of its input inspectors is valid.
        /// </summary>
        bool IsValid();
    }
}
