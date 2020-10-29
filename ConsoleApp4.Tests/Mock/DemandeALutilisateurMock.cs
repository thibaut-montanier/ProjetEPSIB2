using ConsoleApp4.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Tests.Mock {
    public class DemandeALutilisateurMock : IDemandeALutilisateur {
        public int DemandeEntier(string message) {
            return 1;
        }

        public string DemandeString(string message) {
            return "toto";
        }
    }
}
