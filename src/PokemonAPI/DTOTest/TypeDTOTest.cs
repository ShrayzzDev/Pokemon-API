using DTO;

namespace DTOTest
{
    public class TypeDTOTest
    {
        public static IEnumerable<object[]> CtorTestData()
        {
            yield return new object[] { "name", "typing" };
            yield return new object[] { "other", "typing" };
            yield return new object[] { "name", "another" };
            yield return new object[] { "other", "another" };
        }

        [Theory]
        [MemberData(nameof(CtorTestData))]
        public void TypeCtorTest(string name, string typing)
        {
            var type = new TypeDTO(name, typing);

            Assert.Equal(name, type.Name);
            Assert.Equal(typing, type.Typing);
        }
    }
}