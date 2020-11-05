using ConsoleApp4.Model;
using ConsoleApp4.Services;
using ConsoleApp4.Tests.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Tests {
    public class SalleServiceTest {
        SalleService _sv;
        [SetUp]
        public void SetUp() {
            DemandeALutilisateur demSv = new DemandeALutilisateur();
            _sv = new SalleService(demSv);
        }

        [Test]
        public void CreerMessageTest() {
            
            string message = _sv.CreerMessage();

            Assert.AreEqual("", message);

        }

        [Test]
        public void CreerMessageAvecDonneesTest() {
            // création de données
            Salle s = new Salle();
            s.Numero = "212";
            s.Batiment = "2";
            _sv.AddSalle(s);

            s = new Salle();
            s.Numero = "213";
            s.Batiment = "2";
            _sv.AddSalle(s);

            s = new Salle();
            s.Numero = "214";
            string num = s.Numero.Trim();
            s.Batiment = "2";
            _sv.AddSalle(s);
            string message = _sv.CreerMessage();
            string expected = "Batiment : 2, Numero : 212\nBatiment : 2, Numero : 213\nBatiment : 2, Numero : 214";
            Assert.AreEqual(expected, message);

        }


        [Test]
        public void CreerMessageAvecDonneesVideTest() {
            // création de données
            Salle s = new Salle();
            s.Numero = "212";
            s.Batiment = "2";
            _sv.AddSalle(s);

            s = new Salle();
            s.Numero = "";
            s.Batiment = "";
            _sv.AddSalle(s);

            s = new Salle();
            s.Numero = "214";
            string num = s.Numero.Trim();
            s.Batiment = "2";
            _sv.AddSalle(s);
            string message = _sv.CreerMessage();
            string expected = "Batiment : 2, Numero : 212\nBatiment : , Numero : \nBatiment : 2, Numero : 214";
            Assert.AreEqual(expected, message);

        }


        [Test]
        public void CreerMessageAvecDonneesNullTest() {
            // création de données

            _sv.AddSalle(null);
            // créer message va lever une erreur (c'est normal)
            // il faut vous assurer que CreerMessage lève bien l'erreur
            try {
                string message = _sv.CreerMessage(); 
               Assert.Fail("Creer message aurait du planter");
            }catch (Exception e) {
                e = null;
                Assert.Pass();
            }
        }


     

        [Test]
        public void GetByIDFailTest() {

            try {
                _sv.getByNumero("TOTO");
                // normalement, getByID doit lever une erreur du type ItemNotFoundException
                // la ligne suivante ne doit pas être exécutée, on doit rentrer dans le catch ci-après
                Assert.Fail("le test aurait du planter");
            }catch(ItemNotFoundException e) {
                Assert.AreEqual(0,0);
            }catch (NullReferenceException e) {

            } finally {
                //  ce code sera exécuté qu'une exception soit levée ou pas
            }
            //  ce code sera exécuté qu'une exception soit levée ou pas

        }

        
    }
}
