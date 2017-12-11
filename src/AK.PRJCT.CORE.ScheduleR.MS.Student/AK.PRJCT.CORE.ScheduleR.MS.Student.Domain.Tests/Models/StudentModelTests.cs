using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Shouldly;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Domain.Models;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Domain.Tests.Models
{
    [TestFixture]
    public class StudentModelTests
    {
        [Test]
        public void make_sure_properties_not_changed()
        {
            var sourceFields = typeof(Domain.Models.StudentModel).GetRuntimeFields();

            sourceFields.Count().ShouldBe(13);
            sourceFields.Single(s => s.Name.Contains("StudentId")).FieldType.ToString().ShouldBe("System.Int32");
            sourceFields.Single(s => s.Name.Contains("<FirstName>")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(s => s.Name.Contains("<LastName>")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(s => s.Name.Contains("ParentId")).FieldType.ToString().ShouldBe("System.Int32");
            sourceFields.Single(s => s.Name.Contains("Title")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(s => s.Name.Contains("ParentFirstName")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(s => s.Name.Contains("ParentLastName")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(s => s.Name.Contains("PhoneNumber")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(s => s.Name.Contains("Email")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(s => s.Name.Contains("Address")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(s => s.Name.Contains("City")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(s => s.Name.Contains("State")).FieldType.ToString().ShouldBe("System.String");
            sourceFields.Single(s => s.Name.Contains("Zip")).FieldType.ToString().ShouldBe("System.String");            
        }

        [Test]
        public void can_set_and_get_properties()
        {
            var obj = new StudentModel{
                StudentId = 1,
                FirstName ="TEST",
                LastName ="TEST",
                ParentId=1,
                Title = "TEST",
                ParentFirstName = "TEST",
                ParentLastName ="TEST",
                PhoneNumber ="1234567890",
                Email ="TEST@TEST.COM",
                Address ="TEST",
                City ="TEST",
                State ="TEST",
                Zip  = "12345"
            };

            obj.ShouldNotBeNull();
            obj.StudentId.ShouldBe(1);
            obj.FirstName.ShouldBe("TEST");
            obj.LastName.ShouldBe("TEST");
            obj.ParentId.ShouldBe(1);
            obj.Title.ShouldBe("TEST");
            obj.ParentFirstName.ShouldBe("TEST");
            obj.ParentLastName.ShouldBe("TEST");
            obj.PhoneNumber.ShouldBe("1234567890");
            obj.Email.ShouldBe("TEST@TEST.COM");
            obj.Address.ShouldBe("TEST");
            obj.City.ShouldBe("TEST");
            obj.State.ShouldBe("TEST");
            obj.Zip.ShouldBe("12345");
        }
    }
}