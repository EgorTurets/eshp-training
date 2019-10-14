using EshpProductAPI.ViewModels;
using EshpProductCommon;

namespace EshpProductService.Mappers
{
    public static class ProductMapper
    {
        public static ProductBase MapToModel (this ProductBaseVM vm)
        {
            if (vm == null)
                return null;

            return new ProductBase
            {
                Id = vm.Id,
                Name = vm.Name,
                BaseDescription = vm.BaseDescription,
            };
        }

        public static ProductBaseVM MapToVM (this ProductBase model)
        {
            if (model == null)
                return null;

            return new ProductBaseVM
            {
                Id = model.Id,
                Name = model.Name,
                BaseDescription = model.BaseDescription,
                OffersCount = model.Offers != null ? model.Offers.Count : 0,
            };
        }
    }
}
