using ConsoleApp4.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Services {
    public class MatieresService {

        private List<Matiere> lesMatieres = new List<Matiere>();
        private IDemandeALutilisateur _demandeALUtilisateur;

        private SalleService _salleService;

        public MatieresService(IDemandeALutilisateur demandeALutilisateur, SalleService salleService) {
            this._demandeALUtilisateur = demandeALutilisateur;
            this._salleService = salleService;
        }

        public Matiere CreerMatiere() {

            Matiere result = new Matiere();
            // renseigner les champs
            result.Code = _demandeALUtilisateur.DemandeString("Code de la matiere ?");
            result.Nom = _demandeALUtilisateur.DemandeString("Nom de la matière ?");
            result.Salle = _salleService.DemandeSalle();
            // on ajoute la matière à la liste
            lesMatieres.Add(result);
            return result;


        }



        public Matiere DemandeMatiere() {
            Console.WriteLine("Veuille indiquer le code de la matière");

            // ajout de la matière correspondant au code à Oulimata.
            Matiere result = null;
            while (result == null) {
                string code = Console.ReadLine();
                if (code == "Q") {
                    break;
                }
                foreach (Matiere m in lesMatieres) {
                    if (m.Code == code) {
                        result = m;
                    }
                }

                if (result == null) {
                    Console.WriteLine("Je n'ai pas compris, veuillez recommencer");
                }
            }

            // on renvoie le résultat
            return result;
        }
    }
}
