using DTO;

namespace DTOExtensions
{
    public static class TypeExtensions
    {
        public static TypeDTO ToDTO(this Model.Type model)
        {
            return new TypeDTO(
                model.Name,
                model.Typing
            );
        }

        public static IEnumerable<TypeDTO> ToDTOs(this IEnumerable<Model.Type> models)
        {
            var list = new List<TypeDTO>(models.Count());
            foreach (var model in models)
            {
                list.Add(model.ToDTO());
            }
            return list;
        }
    }
}
