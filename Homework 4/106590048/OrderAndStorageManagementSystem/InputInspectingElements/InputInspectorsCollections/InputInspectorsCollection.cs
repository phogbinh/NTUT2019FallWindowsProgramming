using InputInspectingElements.InputInspectors;
using System.Collections.Generic;

namespace InputInspectingElements.InputInspectorsCollections
{
    public class InputInspectorsCollection
    {
        private const string ERROR_FREE = "";
        public List<IInputInspector> Inspectors
        {
            get
            {
                return _inspectors;
            }
        }
        protected List<IInputInspector> _inspectors;

        public InputInspectorsCollection()
        {
            _inspectors = new List<IInputInspector>();
        }

        /// <summary>
        /// Return true if all input inspectors are valid.
        /// </summary>
        public bool AreAllValidInputInspectors()
        {
            foreach ( IInputInspector inspector in _inspectors )
            {
                if ( !inspector.IsValid() )
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Get error of this collection of input inspectors.
        /// </summary>
        public string GetError()
        {
            foreach ( IInputInspector inspector in _inspectors )
            {
                if ( !inspector.IsValid() )
                {
                    return GetInspectorError(inspector);
                }
            }
            return ERROR_FREE;
        }

        /// <summary>
        /// Get the error of the inspector.
        /// </summary>
        private string GetInspectorError(IInputInspector inspector)
        {
            return inspector.GetError();
        }

        /// <summary>
        /// Add an input inspectors list.
        /// </summary>
        public void AddInputInspectorsList(List<IInputInspector> inputInspectors)
        {
            _inspectors.AddRange(inputInspectors);
        }
    }
}
