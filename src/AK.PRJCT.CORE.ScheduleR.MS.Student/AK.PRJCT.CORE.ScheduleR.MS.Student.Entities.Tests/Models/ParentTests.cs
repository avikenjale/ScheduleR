using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Shouldly;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Entities.Tests.Models
{
    [TestFixture]
    public class ParentTests
    {
        [Test]
        public void make_sure_properties_not_changed()
        {
            var sourceFields = typeof(Entities.Models.Parent).GetRuntimeFields();

            sourceFields.Count().ShouldBe(10);
            sourceFields.Single(p => p.Name.Contains("ParentId")).FieldType.ToString().ShouldBe("System.Int32");
            sourceFields.Single(p => p.Name.Contains("Title")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(p => p.Name.Contains("FirstName")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(p => p.Name.Contains("LastName")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(p => p.Name.Contains("PhoneNumber")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(p => p.Name.Contains("Email")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(p => p.Name.Contains("Address")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(p => p.Name.Contains("City")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(p => p.Name.Contains("State")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(p => p.Name.Contains("Zip")).FieldType.ToString().ShouldBe("System.String");
        }

        [Test]
        public void can_set_and_get_properties()
        {
            var obj = new Entities.Models.Parent{
                ParentId = 1,
                FirstName = "TEST",
                LastName ="TEST",
                PhoneNumber = "1234567890",
                Email ="TEST@TEST.COM",
                Address = "TEST",
                City ="TEST",
                State ="TEST",
                Zip ="12345"
            };

            obj.ShouldNotBeNull();
            obj.ParentId.ShouldBe(1);
            obj.FirstName.ShouldBe("TEST");
            obj.LastName.ShouldBe("TEST");
            obj.PhoneNumber.ShouldBe("1234567890");
            obj.Email.ShouldBe("TEST@TEST.COM");
            obj.Address.ShouldBe("TEST");
obj.City.ShouldBe("TEST");
obj.State.ShouldBe("TEST");
obj.Zip.ShouldBe("12345");
        }
    }
}