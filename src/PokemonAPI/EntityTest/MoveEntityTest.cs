using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTest
{
    public class MoveEntityTest
    {
        public static IEnumerable<object[]> CtorTestData()
        {
            yield return new object[] { 1, "name", "typeId", 10, 10, 100};
            yield return new object[] { 11, "name", "typeId", 10, 10, 100 };
            yield return new object[] { 1, "other", "typeId", 10, 10, 100 };
            yield return new object[] { 1, "name", "another", 10, 10, 100 };
            yield return new object[] { 1, "name", "another", 100, 10, 100 };
            yield return new object[] { 1, "name", "another", 10, 100, 100 };
            yield return new object[] { 1, "name", "another", 10, 10, 1000 };
        }

        [Theory]
        [MemberData(nameof(CtorTestData))]
        public void MoveCtorTest(int id, string name, string typeId, int Power, int PP, int Accuracy)
        {
            var move = new MoveEntity(id, name, typeId, Power, PP, Accuracy);

            Assert.Equal(id, move.Id);
            Assert.Equal(name, move.Name);
            Assert.Equal(typeId, move.TypeId);
            Assert.Equal(Power, move.Power);
            Assert.Equal(PP, move.PP);
            Assert.Equal(Accuracy, move.Accuracy);
        }
    }
}
