using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace ConsoleApp4.Services {
    
    
    /// <summary>
    /// Demande des information simples à l'utilisateur
    /// </summary>
    public class DemandeALutilisateur {

        public  virtual int DemandeEntier(string message) {
            Console.WriteLine(message);
            string age;
            age = Console.ReadLine();
            int intValue;
            while (!int.TryParse(age, out intValue)) {
                Console.WriteLine("la saisie est invalide");
                age = Console.ReadLine();
            }
            return intValue;
        }

        public virtual string DemandeString(string message) {
            Console.WriteLine(message);
            string saisieUtilisateur= Console.ReadLine();
            while (string.IsNullOrEmpty(saisieUtilisateur)) {
                Console.WriteLine("la saisie est invalide");
                saisieUtilisateur = Console.ReadLine();
            }
            return saisieUtilisateur;
        }
    }
}
