using ConsoleApp4.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleApp4.Services {
    public class SalleService {

        private DemandeALutilisateur _DemandeALutilisateur;
        private List<Salle> _mesSalles = new List<Salle>();

        public SalleService(DemandeALutilisateur demandeALutilisateur) {
            this._DemandeALutilisateur = demandeALutilisateur;
        }


        public Salle CreateSalle() {
            
            Salle s ;
            s = new Salle();
            s.Numero = _DemandeALutilisateur.DemandeString("Numéro de la salle?");
            s.Batiment = _DemandeALutilisateur.DemandeString("Batiment");
            _mesSalles.Add(s);
            return s;
        }


        public void AddSalle(Salle s) {
            _mesSalles.Add(s);
        }
        public void CreateFakeData() {

            Salle s = new Salle();
            s.Numero = "212";
            s.Batiment= "2";
            _mesSalles.Add(s);

            s = new Salle();
            s.Numero = "213";
            s.Batiment = "2";
            _mesSalles.Add(s);

            s = new Salle();
            s.Numero = "214";
            string num = s.Numero.Trim();
            s.Batiment = "2";
            _mesSalles.Add(s);

            

        }

        public Salle DemandeSalle() {

            Salle result=null;
            while (result == null) {
                string saisieUtilisateur = _DemandeALutilisateur.DemandeString("Numéro de la salle ?");
                foreach(Salle s in this._mesSalles) {
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
            // pourcours de ma liste de salle
            //foreach (Salle s in _mesSalles) {
            //    // ajout de la salle au message
            //    result += "Batiment : " + s.Batiment + ", Numero : " + s.Numero + "\n";
            //}
            //if (result.EndsWith("\n")) {
            //    result = result.Substring(0, result.Length - 1);
            //}
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
