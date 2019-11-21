using OrderAndStorageManagementSystem.Models;
using System;

namespace OrderAndStorageManagementSystem.PresentationModels
{
    public class ProductTypesManagementTabPagePresentationModel
    {
        private const string ERROR_MODEL_IS_NULL = "The given model is null.";
        private Model _model;

        public ProductTypesManagementTabPagePresentationModel(Model modelData)
        {
            if ( modelData == null )
            {
                throw new ArgumentNullException(ERROR_MODEL_IS_NULL);
            }
            _model = modelData;
        }
    }
}
