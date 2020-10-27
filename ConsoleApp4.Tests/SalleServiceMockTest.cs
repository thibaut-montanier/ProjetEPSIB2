using ConsoleApp4.Services;
using ConsoleApp4.Tests.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Tests {
    class SalleServiceMockTest {

        SalleService _sv;
        [SetUp]
        public void SetUp() {
            DemandeALutilisateur demSv = new DemandeALutilisateurMock();
            _sv = new SalleService(demSv);
        }


        [Test]
        public void CreateSalleTest() {
            _sv.CreateSalle();
            string message = _sv.CreerMessage();
            Assert.Greater(message.Length, 0);

        }
    }
}
