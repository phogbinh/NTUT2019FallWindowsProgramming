using InputInspectingElements.InputInspectors;
using System;

namespace InputInspectingElements.InputInspectorsCollections
{
    public class DropDownListInspectorsCollection : InputInspectorsCollection
    {
        private const string ERROR_INVALID_DROP_DOWN_LIST_INSPECTOR_TYPE_FLAG = "The given drop-down list type flag is invalid.";

        /// <summary>
        /// Add drop-down list inspectors by dropDownListInspectorTypeFlag.
        /// </summary>
        public void AddDropDownListInspectors(int dropDownListInspectorTypeFlag)
        {
            if ( !InputInspectorTypeHelper.IsInRangeOfDropDownListInspectorTypes(dropDownListInspectorTypeFlag) )
            {
                throw new ArgumentException(ERROR_INVALID_DROP_DOWN_LIST_INSPECTOR_TYPE_FLAG);
            }
            if ( InputInspectorTypeHelper.IsContainingDropDownListIsSelectedFlag(dropDownListInspectorTypeFlag) )
            {
                _inspectors.Add(new DropDownListIsSelectedInspector());
            }
        }

        /// <summary>
        /// Update drop-down list inspectors.
        /// </summary>
        public void Update(int selectedIndex)
        {
            foreach ( DropDownListIsSelectedInspector inspector in _inspectors )
            {
                inspector.Set(selectedIndex);
            }
        }
    }
}
