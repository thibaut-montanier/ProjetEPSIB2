using ConsoleApp4.Model;
using ConsoleApp4.Services;
using ConsoleApp4.Tests.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
            /// on récupère l'état avant
            var resultsavant = _sv.getAll();
            int nbSallesAvant = resultsavant.Count;
            /// exécution de la méthode à tester
            _sv.CreateSalle();

            //analyse du résultat après
            var resultApres = _sv.getAll();
            int nbSallesApres = resultApres.Count;

            // la question : est-ce qu'une salle a bien été ajoutée
            Assert.AreEqual(nbSallesAvant +1 , nbSallesApres);

            // est-ce que je trouve bien la nouvelle salle qui s'appelle "toto" et qui est en dernière position
            var nouvelleSalle = resultApres.Last();
            Assert.IsNotNull(nouvelleSalle);
            Assert.AreEqual("toto", nouvelleSalle.Numero);
            Assert.AreEqual("toto", nouvelleSalle.Batiment);
        }


        [Test]
        public void CreateSalle2Test() {
            /// on récupère l'état avant
          
            /// exécution de la méthode à tester
            _sv.CreateSalle();

            //analyse du résultat après
            Assert.IsNotNull(_sv);
        }
        #endregion
        [Test]
        public void CreerMessageSalleTest() {
            // préparation de données pour le test
            var s = new Salle();
            s.Numero = "123";
            s.Batiment = "B2";
            // appel de la fonction à tester
            var result = _sv.CreerMessageSalle(s);
            // on s'assure que la fonction a bien fait le job
            var expectedResult = "Batiment : B2, Numero : 123";
            Assert.AreEqual(expectedResult, result);
        }


        
        [Test]
        public void CreerMessageTest() {
            var result = _sv.CreerMessage();
            var expected = "Batiment : B2, Numero : 202\nBatiment : B2, Numero : 203";
            Assert.AreEqual(expected, result);
        }

        [TestCase("202")]
        [TestCase("203")]
        public void GetByIDNumero(string num) {
            var result =  _sv.getByNumero(num);

            Assert.IsNotNull(result);
            Assert.AreEqual(num, result.Numero);
            

        }
        [Test]
        public void GetByIDNumeroFail() {

            try {
                _sv.getByNumero("TOTO");
                // normalement, getByID doit lever une erreur du type ItemNotFoundException
                // la ligne suivante ne doit pas être exécutée, on doit rentrer dans le catch ci-après
                Assert.Fail("getByNumero aurait du lever une erreur de type 'ItemNotFoundException'");
            } catch (ItemNotFoundException e) {
                Assert.AreEqual("TOTO", e.NumRecherche, "L'erreur est bien levée mais la valeur de numRecherche n'est pas bonne");
            }
            //  ce code sera exécuté qu'une exception soit levée ou pas
        }
    }
}
