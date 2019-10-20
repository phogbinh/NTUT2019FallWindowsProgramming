using OrderAndStorageManagementSystem.Models;
using System.Drawing;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Views.Utilities
{
    public static class DataGridViewHelper
    {
        // Protest on Dr.Smell
        public static void InitializeButtonImageOfButtonColumn(DataGridViewCellPaintingEventArgs eventArguments, int buttonColumnIndex, Image buttonImage)
        {
            if ( eventArguments.RowIndex < 0 )
            {
                return;
            }
            if ( eventArguments.ColumnIndex == buttonColumnIndex )
            {
                eventArguments.Paint(eventArguments.CellBounds, DataGridViewPaintParts.All);
                int width = buttonImage.Width;
                int height = buttonImage.Height;
                int left = eventArguments.CellBounds.Left + ( eventArguments.CellBounds.Width - width ) / AppDefinition.TWO;
                int top = eventArguments.CellBounds.Top + ( eventArguments.CellBounds.Height - height ) / AppDefinition.TWO;
                eventArguments.Graphics.DrawImage(buttonImage, new Rectangle(left, top, width, height));
                eventArguments.Handled = true;
            }
        }
    }
}
