using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndStorageManagementSystem.Models.Utilities.InputInspectorUtilities
{
    public class InputInspectorManager
    {
        private const string ERROR_FREE = "";
        private int _controlsCount;
        private List<int> _textBoxIsNotEmptyInspectorControlIndices;
        private List<int> _textBoxIsOfFullLengthInspectorControlIndices;
        private List<int> _textBoxIsMailInspectorControlIndices;
        private List<int> _dropDownListIsSelectedInspectorControlIndices;
        private IDictionary<int, List<IInputInspector>> _controlWithInspectorsContainers;

        public InputInspectorManager(int controlsCountData, List<int> textBoxIsNotEmptyInspectorControlIndicesData, List<int> textBoxIsOfFullLengthInspectorControlIndicesData, List<int> textBoxIsMailInspectorControlIndicesData, List<int> dropDownListIsSelectedInspectorControlIndicesData)
        {
            _controlsCount = controlsCountData;
            _textBoxIsNotEmptyInspectorControlIndices = textBoxIsNotEmptyInspectorControlIndicesData;
            _textBoxIsOfFullLengthInspectorControlIndices = textBoxIsOfFullLengthInspectorControlIndicesData;
            _textBoxIsMailInspectorControlIndices = textBoxIsMailInspectorControlIndicesData;
            _dropDownListIsSelectedInspectorControlIndices = dropDownListIsSelectedInspectorControlIndicesData;
            // Initialize Input Inspectors
            InitializeControlWithInspectorsContainers();
            InitializeTextBoxIsNotEmptyInspectors();
            InitializeTextBoxIsOfFullLengthInspectors();
            InitializeTextBoxIsMailInspector();
            InitializeDropDownListIsSelectedInspectors();
        }

        /// <summary>
        /// Initialize _controlWithInspectorsContainers.
        /// </summary>
        private void InitializeControlWithInspectorsContainers()
        {
            _controlWithInspectorsContainers = new Dictionary<int, List<IInputInspector>>();
            for ( int i = 0; i < _controlsCount; i++ )
            {
                _controlWithInspectorsContainers.Add(i, new List<IInputInspector>());
            }
        }

        /// <summary>
        /// Initialize TextBoxIsNotEmptyInspector for all textboxes.
        /// </summary>
        private void InitializeTextBoxIsNotEmptyInspectors()
        {
            foreach ( int controlIndex in _textBoxIsNotEmptyInspectorControlIndices )
            {
                _controlWithInspectorsContainers[ controlIndex ].Add(new TextBoxIsNotEmptyInspector());
            }
        }

        /// <summary>
        /// Initialize TextBoxIsOfFullLengthInspector for card number and card security code textboxes.
        /// </summary>
        private void InitializeTextBoxIsOfFullLengthInspectors()
        {
            foreach ( int controlIndex in _textBoxIsOfFullLengthInspectorControlIndices )
            {
                _controlWithInspectorsContainers[ controlIndex ].Add(new TextBoxIsOfFullLengthInspector());
            }
        }

        /// <summary>
        /// Initialize TextBoxIsMailInspector for email textbox.
        /// </summary>
        private void InitializeTextBoxIsMailInspector()
        {
            foreach ( int controlIndex in _textBoxIsMailInspectorControlIndices )
            {
                _controlWithInspectorsContainers[ controlIndex ].Add(new TextBoxIsMailInspector());
            }
        }

        /// <summary>
        /// Initialize DropDownListIsSelectedInspector for all drop-down lists.
        /// </summary>
        private void InitializeDropDownListIsSelectedInspectors()
        {
            foreach ( int controlIndex in _dropDownListIsSelectedInspectorControlIndices )
            {
                _controlWithInspectorsContainers[ controlIndex ].Add(new DropDownListIsSelectedInspector());
            }
        }

        /// <summary>
        /// Update member variables of all TextBoxInspectors of the textbox at textBoxIndex.
        /// </summary>
        public void UpdateTextBoxInspectors(int textBoxIndex, string text, int maxTextLength)
        {
            Action<IInputInspector> setTextBoxInspectorFunction = (inspector) => ( ( TextBoxInspector )inspector ).Set(text, maxTextLength);
            UpdateControlInspectors(textBoxIndex, setTextBoxInspectorFunction);
        }

        /// <summary>
        /// Update member variable of all DropDownListInspectors of the drop-down list at dropDownListIndex.
        /// </summary>
        public void UpdateDropDownListInspectors(int dropDownListIndex, int selectedIndex)
        {
            Action<IInputInspector> setDropDownListIsSelectedInspectorFunction = (inspector) => ( ( DropDownListIsSelectedInspector )inspector ).Set(selectedIndex);
            UpdateControlInspectors(dropDownListIndex, setDropDownListIsSelectedInspectorFunction);
        }

        /// <summary>
        /// Update member variable(s) of all InputInspectors of the control at controlIndex.
        /// </summary>
        private void UpdateControlInspectors(int controlIndex, Action<IInputInspector> setInspectorFunction)
        {
            foreach ( IInputInspector inspector in _controlWithInspectorsContainers[ controlIndex ] )
            {
                setInspectorFunction(inspector);
            }
        }

        /// <summary>
        /// Return true if all inspectors are valid.
        /// </summary>
        public bool AreAllValidInspectors()
        {
            foreach ( KeyValuePair<int, List<IInputInspector>> container in _controlWithInspectorsContainers )
            {
                List<IInputInspector> inspectors = container.Value;
                foreach ( IInputInspector inspector in inspectors )
                {
                    if ( !inspector.IsValid() )
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Get the first InputInspector error of the control at controlIndex.
        /// </summary>
        public string GetControlError(int controlIndex)
        {
            foreach ( IInputInspector inspector in _controlWithInspectorsContainers[ controlIndex ] )
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
    }
}
