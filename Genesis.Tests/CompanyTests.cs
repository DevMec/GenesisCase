using System;
using System.Collections.Generic;
using Genesis.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Genesis.Tests
{
    [TestClass]
    public class CompanyTests
    {
        /// <summary>
        /// Une entreprise a au moins une adresse Siège central mais peut aussi avoir d’autres adresses (entités satellites).
        /// </summary>
        [TestMethod]
        public void AnCompanyShouldHaveAnAddress()
        {
            string nullAddress = String.Empty;
            string notNullAddress = "not null address";
            var defaultVAT = "defaultVAT";

            ICompany _sut = null;

            Assert.ThrowsException<ArgumentNullException>(() => {
                _sut = new Company(It.IsAny<Guid>(), "companyNull", nullAddress, defaultVAT, It.IsAny<List<string>>());
            });

            Assert.IsNull(_sut);


            var companyName = "companyValid";
            _sut = new Company(It.IsAny<Guid>(), companyName, notNullAddress, defaultVAT, It.IsAny<List<string>>());
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOfType(_sut, typeof(Company));
            Assert.AreEqual((_sut as Company).Name, companyName);
        }


        /// <summary>
        /// Une entreprise a un numéro de TVA
        /// </summary>
        [TestMethod]
        public void ACompanyShouldHaveVAT()
        {
            string defaultAddress = "not null address";

            ICompany _sut = null;

            var notNullVAT = "defaultVAT";
            var nullVAT = String.Empty;

            Assert.ThrowsException<ArgumentNullException>(() => {
                _sut = new Company(It.IsAny<Guid>(), "companyNull", defaultAddress, nullVAT, It.IsAny<List<string>>());
            });
            Assert.IsNull(_sut);

            _sut = new Company(It.IsAny<Guid>(), "companyValid", defaultAddress, notNullVAT, It.IsAny<List<string>>());
            Assert.IsNotNull(_sut);
            Assert.IsInstanceOfType(_sut, typeof(Company));
            Assert.AreEqual((_sut as Company).VAT, notNullVAT);
        }

    }
}
