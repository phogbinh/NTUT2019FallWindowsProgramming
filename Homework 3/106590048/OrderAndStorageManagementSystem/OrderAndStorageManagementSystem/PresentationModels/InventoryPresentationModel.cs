using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.Utilities;

namespace OrderAndStorageManagementSystem.PresentationModels
{
    public class InventoryPresentationModel
    {
        private Model _model;

        public InventoryPresentationModel(Model modelData)
        {
            _model = modelData;
        }

        /// <summary>
        /// Get product by storageDataGridViewRowIndex.
        /// </summary>
        public Product GetProduct(int storageDataGridViewRowIndex)
        {
            int productId = AppDefinition.GetHumanIndex(storageDataGridViewRowIndex);
            return _model.GetProduct(productId);
        }
    }
}
