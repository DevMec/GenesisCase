using System;
using Moq;
using Genesis.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Genesis.Tests
{
    [TestClass]
    public class ContactTests
    {
        /// <summary>
        /// Un contact doit avoir une adresse
        /// </summary>
        [TestMethod]
        public void AnContactShouldHaveAnAddress()
        {
            string nullAddress = String.Empty;
            string notNullAddress = "not null address";

            IContact _sut = null;

            Assert.ThrowsException<ArgumentNullException>(() => {
                _sut = new Contact(It.IsAny<Guid>(), "contactNull", nullAddress, null);
            });

            Assert.IsNull(_sut);


            var contactName = "contactValid";
            _sut = new Contact(It.IsAny<Guid>(), contactName, notNullAddress, null);
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOfType(_sut, typeof(Contact));
            Assert.AreEqual((_sut as Contact).Name, contactName);
        }

        /// <summary>
        /// Un Freelance doit avoir une TVA
        /// </summary>
        [TestMethod]
        public void AContactFreelancerShouldHaveVAT()
        {
            string defaultAddress = "not null address";

            IContact _sut = null;

            var notNullVAT = "defaultVAT";
            var nullVAT = String.Empty;

            Assert.ThrowsException<ArgumentNullException>(() => {
                _sut = new Contact(It.IsAny<Guid>(), "freelancerNull", defaultAddress, nullVAT, isFreelancer:true);
            });
            Assert.IsNull(_sut);

            //Employee has no VAT
            _sut = new Contact(It.IsAny<Guid>(), "freelancerNull", defaultAddress, nullVAT, isFreelancer:false);
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOfType(_sut, typeof(Contact));
            Assert.IsNull((_sut as Contact).VAT);
            Assert.IsFalse((_sut as Contact).IsFreelancer);

            //Freelancer must have VAT
            _sut = new Contact(It.IsAny<Guid>(), "freelancerNull", defaultAddress, notNullVAT, isFreelancer:true);
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOfType(_sut, typeof(Contact));
            Assert.IsNull((_sut as Contact).VAT);
            Assert.IsTrue((_sut as Contact).IsFreelancer);
        }

        /// <summary>
        /// Un contact travaille dans une ou plusieurs entreprises
        /// </summary>
        [TestMethod]
        public void AnContactWorkInOneOrManyCompany()
        {
            string defaultAddress = "not null address";
            var defaultVAT = "Default VAT";
            var company1 = new Company(null, "Company1", defaultAddress, defaultVAT, null);

            Contact _sut = new Contact(null, "Employee1", defaultAddress, null);
            _sut.AddCompany(company1);

            Assert.IsNotNull(_sut.CompanyList);
            Assert.AreEqual(_sut.CompanyList.Count, 1);
            Assert.AreEqual(_sut.CompanyList.First(), company1);

            var company2 = new Company(null, "Company2", defaultAddress, defaultVAT, null);

            _sut.AddCompany(company2);

            Assert.IsNotNull(_sut.CompanyList);
            Assert.AreEqual(_sut.CompanyList.Count, 2);
            Assert.AreEqual(_sut.CompanyList.Last(), company2);
        }
    }
}
