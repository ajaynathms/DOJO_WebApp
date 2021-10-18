using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApp.Models;

namespace WebApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_FirstName_Required()
        {
            User cusotmer = new User
            {
                LastName = "David",
                Email = "test@test.com",
                City = "Albany",
                PhoneNumber = "(999)123-4567",
                DOB = new DateTime(2000, 12, 5),
                State = "New York",
                Country = "United States",
                StreetAddress1 = "Test",
                ZipCode = "12345"
            };
            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(cusotmer, new ValidationContext(cusotmer), validationResultList);
            var message = validationResultList[0].ErrorMessage;
            Assert.AreEqual("First Name is required", message);
        }
        [TestMethod]
        public void Test_LastName_Required()
        {
            User cusotmer = new User
            {
                FirstName = "John",
                Email = "test@test.com",
                City = "Albany",
                PhoneNumber = "(999)123-4567",
                DOB = new DateTime(2000, 12, 5),
                State = "New York",
                Country = "United States",
                StreetAddress1 = "Test",
                ZipCode = "12345"
            };
            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(cusotmer, new ValidationContext(cusotmer), validationResultList);
            var message = validationResultList[0].ErrorMessage;
            Assert.AreEqual("Last Name is required", message);
        }

        [TestMethod]
        public void Test_Email_Invalid()
        {
            User cusotmer = new User
            {
                FirstName = "John",
                LastName = "David",
                Email = "testcom",
                City = "Albany",
                PhoneNumber = "(999)123-4567",
                DOB = new DateTime(2000, 12, 5),
                State = "New York",
                Country = "United States",
                StreetAddress1 = "Test",
                ZipCode = "12345"
            };
            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(cusotmer, new ValidationContext(cusotmer), validationResultList);
            var message = validationResultList[0].ErrorMessage;
            Assert.AreEqual("Invalid Email", message);
        }
        [TestMethod]
        public void Test_Phone_Invalid()
        {
            User cusotmer = new User
            {
                FirstName = "John",
                LastName = "David",
                Email = "test@test.com",
                City = "Albany",
                PhoneNumber = "146",
                DOB = new DateTime(2000, 12, 5),
                State = "New York",
                Country = "United States",
                StreetAddress1 = "Test",
                ZipCode = "12345"
            };
            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(cusotmer, new ValidationContext(cusotmer), validationResultList);
            var message = validationResultList[0].ErrorMessage;
            Assert.AreEqual("Invalid PhoneNumber", message);
        }
        [TestMethod]
        public void Test_StreetAddress1_Required()
        {
            User cusotmer = new User
            {
                FirstName = "John",
                LastName = "David",
                Email = "test@test.com",
                City = "Albany",
                PhoneNumber = "(999)123-4567",
                DOB = new DateTime(2000, 12, 5),
                State = "New York",
                Country = "United States",
                ZipCode = "12345"
            };
            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(cusotmer, new ValidationContext(cusotmer), validationResultList);
            var message = validationResultList[0].ErrorMessage;
            Assert.AreEqual("Street Address 1 is required", message);
        }
        [TestMethod]
        public void Test_City_Invalid()
        {
            User cusotmer = new User
            {
                FirstName = "John",
                LastName = "David",
                Email = "test@test.com",
                PhoneNumber = "(999)123-4567",
                DOB = new DateTime(2000, 12, 5),
                State = "New York",
                Country = "United States",
                StreetAddress1 = "Test",
                ZipCode = "12345"
            };
            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(cusotmer, new ValidationContext(cusotmer), validationResultList);
            var message = validationResultList[0].ErrorMessage;
            Assert.AreEqual("City is required", message);
        }

        [TestMethod]
        public void Test_State_Invalid()
        {
            User cusotmer = new User
            {
                FirstName = "John",
                LastName = "David",
                Email = "test@test.com",
                City = "Albany",
                PhoneNumber = "(999)123-4567",
                DOB = new DateTime(2000, 12, 5),
                State = "abc",
                Country = "United States",
                StreetAddress1 = "Test",
                ZipCode = "12345"
            };
            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(cusotmer, new ValidationContext(cusotmer), validationResultList);
            var message = validationResultList[0].ErrorMessage;
            Assert.AreEqual("Invalid State", message);
        }
        [TestMethod]
        public void Test_Country_Invalid()
        {
            User cusotmer = new User
            {
                FirstName = "John",
                LastName = "David",
                Email = "test@test.com",
                City = "Albany",
                PhoneNumber = "(999)123-4567",
                DOB = new DateTime(2000, 12, 5),
                State = "New York",
                Country = "Abc",
                StreetAddress1 = "Test",
                ZipCode = "12345"
            };
            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(cusotmer, new ValidationContext(cusotmer), validationResultList);
            var message = validationResultList[0].ErrorMessage;
            Assert.AreEqual("Invalid Country", message);
        }
        [TestMethod]
        public void Test_DOB_Future_Date()
        {
            User cusotmer = new User
            {
                FirstName = "John",
                LastName = "David",
                Email = "test@test.com",
                City = "Albany",
                PhoneNumber = "(999)123-4567",
                DOB = DateTime.Now.AddDays(100),
                State = "New York",
                Country = "United States",
                StreetAddress1 = "Test",
                ZipCode = "12345"
            };
            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(cusotmer, new ValidationContext(cusotmer), validationResultList);
            var message = validationResultList[0].ErrorMessage;
            Assert.AreEqual("Invalid Date Of Birth", message);
        }
        [TestMethod]
        public void Test_Validate_All()
        {
            User cusotmer = new User
            {
                FirstName = "John",
                LastName = "David",
                Email = "test@test.com",
                City = "Albany",
                PhoneNumber = "(999)123-4567",
                DOB = new DateTime(2000, 12, 5),
                State = "New York",
                Country = "United States",
                StreetAddress1 = "Test",
                ZipCode = "12345"
            };
            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(cusotmer, new ValidationContext(cusotmer), validationResultList);
            Assert.AreEqual(validationResultList.Any(), false);
        }

       
    }
}

