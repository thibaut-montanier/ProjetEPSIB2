using ConsoleApp4.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleApp4.Services {
    public class SalleService {

        private IDemandeALutilisateur _DemandeALutilisateur;
        private List<Salle> _mesSalles = new List<Salle>();

        public SalleService(IDemandeALutilisateur demandeALutilisateur) {
            this._DemandeALutilisateur = demandeALutilisateur;
        }


        public Salle CreateSalle() {
            
            Salle s ;
            s = new Salle();
            s.Numero = _DemandeALutilisateur.DemandeString("Numéro de la salle?");
            s.Batiment = _DemandeALutilisateur.DemandeString("Batiment");
            getAll().Add(s);
            return s;
        }

        /// <summary>
        /// Charge les données depuis la base de données
        /// </summary>
        /// <returns></returns>
        public List<Salle> getAll() {
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



        public Salle getByID(int SalleID) {
            throw new ItemNotFoundException(SalleID);
            return new Salle();
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


    }

    public class ItemNotFoundException : Exception {

        public ItemNotFoundException(int id) {
            this.IDRecherche = id;
        }
        public int IDRecherche { get; set; }
    }
}
