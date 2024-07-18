using Entities;

namespace EntityExtensions
{
    public static class TypeExtensions
    {
        public static Model.Type ToModel(this TypeEntity type)
        {
            return new Model.Type(
                type.Name,
                type.Typing
            );
        }

        public static IEnumerable<Model.Type> ToModels(this IEnumerable<TypeEntity> entities)
        {
            var list = new List<Model.Type>(entities.Count());
            foreach(var entity in entities)
            {
                list.Add(entity.ToModel());
            }
            return list;
        }
    }
}
