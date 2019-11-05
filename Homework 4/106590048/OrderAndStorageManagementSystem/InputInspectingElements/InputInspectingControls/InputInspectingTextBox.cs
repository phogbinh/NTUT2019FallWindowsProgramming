using InputInspectingElements.InputInspectors;
using InputInspectingElements.InputInspectorsCollections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InputInspectingElements.InputInspectingControls
{
    public class InputInspectingTextBox : TextBox, IInputInspectingControl
    {
        public delegate void TextBoxInspectorsCollectionChangedEventHandler();
        private event TextBoxInspectorsCollectionChangedEventHandler _textBoxInspectorsCollectionChanged;
        public TextBoxInspectorsCollectionChangedEventHandler TextBoxInspectorsCollectionChanged
        {
            get
            {
                return _textBoxInspectorsCollectionChanged;
            }
            set
            {
                _textBoxInspectorsCollectionChanged = value;
            }
        }
        private TextBoxInspectorsCollection _textBoxInspectorsCollection;

        public InputInspectingTextBox()
        {
            _textBoxInspectorsCollection = new TextBoxInspectorsCollection();
            this.TextChanged += (sender, eventArguments) => UpdateTextBoxInspectorsCollection();
            this.Leave += (sender, eventArguments) => UpdateTextBoxInspectorsCollection();
        }

        /// <summary>
        /// Update the textbox inspectors collection.
        /// </summary>
        private void UpdateTextBoxInspectorsCollection()
        {
            _textBoxInspectorsCollection.Update(this.Text, this.MaxLength);
            NotifyObserverChangeTextBoxInspectorsCollection();
        }

        /// <summary>
        /// Notify observer change the textbox inspectors collection.
        /// </summary>
        private void NotifyObserverChangeTextBoxInspectorsCollection()
        {
            if ( TextBoxInspectorsCollectionChanged != null )
            {
                TextBoxInspectorsCollectionChanged();
            }
        }

        /// <summary>
        /// Add textbox inspectors to the textbox inspectors collection by textBoxInspectorTypeFlag.
        /// </summary>
        public void AddTextBoxInspectors(int textBoxInspectorTypeFlag)
        {
            _textBoxInspectorsCollection.AddTextBoxInspectors(textBoxInspectorTypeFlag, this.Text, this.MaxLength);
        }

        /// <summary>
        /// Get the input inspectors of the input inspecting control.
        /// </summary>
        public List<IInputInspector> GetInputInspectors()
        {
            return _textBoxInspectorsCollection.Inspectors;
        }

        /// <summary>
        /// Get error of the input inspectors of the input inspecting control.
        /// </summary>
        public string GetInputInspectorsError()
        {
            return _textBoxInspectorsCollection.GetError();
        }
    }
}
