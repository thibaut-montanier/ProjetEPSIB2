using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Services {
    public interface IDemandeALutilisateur {
        public int DemandeEntier(string message);

        public string DemandeString(string message);
    }
}
