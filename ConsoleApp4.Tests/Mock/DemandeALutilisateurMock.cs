using ConsoleApp4.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Tests.Mock {
    public class DemandeALutilisateurMock : DemandeALutilisateur {
        public override int DemandeEntier(string message) {
            return 1;
        }

        public override string DemandeString(string message) {
            return "toto";
        }
    }
}
