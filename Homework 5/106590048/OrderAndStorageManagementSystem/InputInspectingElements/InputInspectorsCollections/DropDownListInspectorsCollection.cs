using InputInspectingElements.InputInspectors;
using System;

namespace InputInspectingElements.InputInspectorsCollections
{
    public class DropDownListInspectorsCollection : InputInspectorsCollection
    {
        private const string ERROR_DROP_DOWN_LIST_INSPECTOR_TYPE_FLAG_IS_OUT_OF_RANGE = "The given drop-down list inspector type flag is out of range.";

        /// <summary>
        /// Add drop-down list inspectors by dropDownListInspectorTypeFlag.
        /// </summary>
        public void AddDropDownListInspectors(int dropDownListInspectorTypeFlag, int selectedIndex)
        {
            if ( !InputInspectorTypeHelper.IsInRangeOfDropDownListInspectorTypes(dropDownListInspectorTypeFlag) )
            {
                throw new ArgumentOutOfRangeException(ERROR_DROP_DOWN_LIST_INSPECTOR_TYPE_FLAG_IS_OUT_OF_RANGE);
            }
            if ( InputInspectorTypeHelper.IsContainingDropDownListIsSelectedFlag(dropDownListInspectorTypeFlag) )
            {
                _inspectors.Add(new DropDownListIsSelectedInspector(selectedIndex));
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
