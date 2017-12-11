using NUnit.Framework;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Entities;
using Shouldly;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Entities.Tests.Models
{
    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void make_sure_properties_not_changed()
        {
            var sourceFields = typeof(Entities.Models.Student).GetRuntimeFields();

            sourceFields.Count().ShouldBe(4);
            sourceFields.Single(s => s.Name.Contains("<StudentId>")).FieldType.ToString().ShouldBe("System.Int32");
            sourceFields.Single(s => s.Name.Contains("<FirstName>")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(s => s.Name.Contains("<LastName>")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(s => s.Name.Contains("<Parent>")).FieldType.ToString().ShouldBe("AK.PRJCT.CORE.ScheduleR.MS.Student.Entities.Models.Parent");
        }

        [Test]
        public void can_set_and_get_properties()
        {
            var obj = new Entities.Models.Student
            {
                StudentId = 1,
                FirstName = "TEST",
                LastName = "TEST",
                Parent = new Entities.Models.Parent { }
            };

            obj.ShouldNotBeNull();
            obj.StudentId.ShouldBe(1);
            obj.FirstName.ShouldBe("TEST");
            obj.LastName.ShouldBe("TEST");
            obj.Parent.ShouldNotBeNull();
        }
    }
}