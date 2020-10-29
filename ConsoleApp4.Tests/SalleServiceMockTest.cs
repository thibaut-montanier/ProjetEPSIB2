using ConsoleApp4.Services;
using ConsoleApp4.Tests.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Tests {
    class SalleServiceMockTest {
        #region
        SalleService _sv;
        [SetUp]
        public void SetUp() {
            DemandeALutilisateurMock demSv = new DemandeALutilisateurMock();
            _sv = new SalleServiceMock(demSv);
        }


        [Test]
        public void CreateSalleTest() {
            _sv.CreateSalle();
            string message = _sv.CreerMessage();
            Assert.Greater(message.Length, 0);

        }

        #endregion
        [Test]
        public void CreerMessageTest() {
            var result = _sv.CreerMessage();
            var expected = "Batiment : B2, Numero : 202\nBatiment : B2, Numero : 203";
            Assert.AreEqual(expected, result);
        }
    }
}
