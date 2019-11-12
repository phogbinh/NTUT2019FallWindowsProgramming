using InputInspectingElements.InputInspectors;
using InputInspectingElements.InputInspectorsCollections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InputInspectingElements.InputInspectingControls
{
    public class InputInspectingDropDownList : ComboBox, IInputInspectingControl
    {
        public delegate void DropDownListInspectorsCollectionChangedEventHandler();
        private event DropDownListInspectorsCollectionChangedEventHandler _dropDownListInspectorsCollectionChanged;
        public DropDownListInspectorsCollectionChangedEventHandler DropDownListInspectorsCollectionChanged
        {
            get
            {
                return _dropDownListInspectorsCollectionChanged;
            }
            set
            {
                _dropDownListInspectorsCollectionChanged = value;
            }
        }
        private DropDownListInspectorsCollection _dropDownListInspectorsCollection;

        public InputInspectingDropDownList()
        {
            _dropDownListInspectorsCollection = new DropDownListInspectorsCollection();
            this.TextChanged += (sender, eventArguments) => UpdateDropDownListInspectorsCollection();
            this.Leave += (sender, eventArguments) => UpdateDropDownListInspectorsCollection();
        }

        /// <summary>
        /// Update the drop-down list inspectors collection.
        /// </summary>
        private void UpdateDropDownListInspectorsCollection()
        {
            _dropDownListInspectorsCollection.Update(this.SelectedIndex);
            NotifyObserverChangeDropDownListInspectorsCollection();
        }

        /// <summary>
        /// Notify observer change the drop-down list inspectors collection.
        /// </summary>
        private void NotifyObserverChangeDropDownListInspectorsCollection()
        {
            if ( DropDownListInspectorsCollectionChanged != null )
            {
                DropDownListInspectorsCollectionChanged();
            }
        }

        /// <summary>
        /// Add drop-down inspectors to the drop-down list inspectors collection by dropDownListInspectorTypeFlag.
        /// </summary>
        public void AddDropDownListInspectors(int dropDownListInspectorTypeFlag)
        {
            _dropDownListInspectorsCollection.AddDropDownListInspectors(dropDownListInspectorTypeFlag, this.SelectedIndex);
        }

        /// <summary>
        /// Get the input inspectors of the input inspecting control.
        /// </summary>
        public List<IInputInspector> GetInputInspectors()
        {
            return _dropDownListInspectorsCollection.Inspectors;
        }

        /// <summary>
        /// Get error of the input inspectors of the input inspecting control.
        /// </summary>
        public string GetInputInspectorsError()
        {
            return _dropDownListInspectorsCollection.GetError();
        }

        /// <summary>
        /// Return true if all of its input inspectors is valid.
        /// </summary>
        public bool IsValid()
        {
            return _dropDownListInspectorsCollection.AreAllValidInputInspectors();
        }
    }
}
