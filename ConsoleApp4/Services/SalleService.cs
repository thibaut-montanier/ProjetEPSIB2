using ConsoleApp4.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleApp4.Services {
    public class SalleService {

        private IDemandeALutilisateur _DemandeALutilisateur;
        private List<Salle> _mesSalles = new List<Salle>();

        public SalleService(IDemandeALutilisateur demandeALutilisateur) {
            this._DemandeALutilisateur = demandeALutilisateur;
        }

        /// <summary>
        /// Créer une nouvelle salle en demandant des informations à l'utilisateur
        /// et ajoute la salle à la liste des salles disponibles
        /// </summary>
        /// <returns></returns>
        public Salle CreateSalle() {

            Salle s;
            s = new Salle();
            s.Numero = _DemandeALutilisateur.DemandeString("Numéro de la salle?");
            s.Batiment = _DemandeALutilisateur.DemandeString("Batiment");
            getAll().Add(s);
            return null;
        }

        /// <summary>
        /// Charge les données depuis la base de données
        /// </summary>
        /// <returns></returns>
        public virtual List<Salle> getAll() {
            if (_mesSalles == null) {
                using (var sr = new StreamReader("monfichier.csv")) {
                    var result = sr.ReadToEnd();
                    var i = 0.1;
                    // chargement des données dans ma liste

                    _mesSalles = new List<Salle>();
                    // parcours du fichier pour charger les données
                    throw new NotImplementedException();
                }
            }
            return _mesSalles;
        }

        public void AddSalle(Salle s) {
            getAll().Add(s);
        }
        

        public Salle DemandeSalle() {

            Salle result=null;
            while (result == null) {
                string saisieUtilisateur = _DemandeALutilisateur.DemandeString("Numéro de la salle ?");
                foreach(Salle s in this.getAll()) {
                    if (s.Numero == saisieUtilisateur) {
                        result= s;
                    }
                }
            }

            return result;
        }


        /// <summary>
        /// Cherche une salle par son numéro
        /// La retourne si elle est trouvé
        /// Lève une exception si elle n'est pas trouvée
        /// </summary>
        /// <param name="NumeroSalle"></param>
        /// <returns></returns>
        public Salle getByNumero(string NumeroSalle) {

            if (string.IsNullOrEmpty(NumeroSalle)) {
                throw new NumeroSalleInvalidException();
            }
            var result = getAll().Where(s => s.Numero == NumeroSalle).FirstOrDefault();

            if (result != null)
                return result;
            else {
                throw new ItemNotFoundException(NumeroSalle);
            }

        }
        public string CreerMessage() {
            string result = "";
            //pourcours de ma liste de salle
            foreach (Salle s in getAll()) {
                // ajout de la salle au message
                result += "Batiment : " + s.Batiment + ", Numero : " + s.Numero + "\n";
            }
            if (result.EndsWith("\n")) {
                result = result.Substring(0, result.Length - 1);
            }
            return result;
        }


        public string CreerMessageSalle(Salle s) {
           return  "Batiment : " + s.Batiment + ", Numero : " + s.Numero ;
        }


    }



    public class ItemNotFoundException : Exception {

        public ItemNotFoundException(string num) {
            this.NumRecherche = num;
        }
        public string NumRecherche { get; set; }
    }
}
