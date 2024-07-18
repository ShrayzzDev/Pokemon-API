using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOTest
{
    public class MoveDTOTest
    {
        public static IEnumerable<object[]> CtorTestData()
        {
            yield return new object[] { 1, "name", new TypeDTO("name", "typing"), 10, 10, 100 };
            yield return new object[] { 11, "name", new TypeDTO("name", "typing"), 10, 10, 100 };
            yield return new object[] { 1, "name", new TypeDTO("name", "typing"), 10, 10, 100 };
            yield return new object[] { 1, "name", new TypeDTO("name", "typing"), 100, 10, 100 };
            yield return new object[] { 1, "name", new TypeDTO("name", "typing"), 10, 100, 100 };
            yield return new object[] { 1, "name", new TypeDTO("name", "typing"), 10, 10, 1000 };
        }

        [Theory]
        [MemberData(nameof(CtorTestData))]
        public void MoveCtorTest(int id, string name, TypeDTO type, int Power, int PP, int Accuracy)
        {
            var move = new MoveDTO(id, name, type, Power, PP, Accuracy);

            Assert.Equal(id, move.Id);
            Assert.Equal(name, move.Name);
            Assert.Equal(type.Name, move.Type.Name);
            Assert.Equal(Power, move.Power);
            Assert.Equal(PP, move.PP);
            Assert.Equal(Accuracy, move.Accuracy);
        }
    }
}
