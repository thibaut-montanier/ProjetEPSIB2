using ConsoleApp4.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Services {

    /// <summary>
    /// Etudiant service : s'occupe de gérer des étudiants
    /// </summary>
    public class EtudiantsService {
        /// <summary>
        /// Dépendance vers le service "DemandeALutilisateur"
        /// </summary>
        private IDemandeALutilisateur _DemandeALutilisateur;
        private MatieresService _MatieresService;
        private List<Etudiant> ListeEtudiants = new List<Etudiant>();

        /// <summary>
        /// Constructeur => permet d'imposer le fait qu'on doive fournir
        /// Un objet de type DemandeALutilisateur lors de l'instanciation de l'objet
        /// </summary>
        /// <param name="demandeALutilisateur"></param>
        public EtudiantsService(IDemandeALutilisateur demandeALutilisateur, MatieresService matieresService) {
            _DemandeALutilisateur = demandeALutilisateur;
            _MatieresService = matieresService;
        }


        /// <summary>
        /// Affiche la liste des étudiants
        /// </summary>
        /// <param name="etudiants"></param>
        public void AfficheEtudiants() {
            // affichage des étudiants
            foreach (Etudiant e in ListeEtudiants) {
                Console.WriteLine(e.Prenom);
                Console.WriteLine("Les matières : ");
                // affichage des matières
                if (e.Matieres != null) {

                    foreach (Matiere m in e.Matieres) {
                        Console.WriteLine(m.Nom);
                    }

                }
            }
        }

        public Etudiant CreateEtudiants() {

            // initialisation de la personne et ajout à la liste
            Etudiant p = new Etudiant();

            // demande du prénom
            p.Prenom = _DemandeALutilisateur.DemandeString("Comment t'appelles-tu ?");
            // demande des autres informations
            p.Age = _DemandeALutilisateur.DemandeEntier("Bonjour, quel âge as-tu ?");
            p.NbEnfants = _DemandeALutilisateur.DemandeEntier("Combien d'enfants as-tu ?");


            // Exercice : demander la liste des matières associé à l'étudiant
            // 1. Demander la première matière (on s'arrête à 1)$

            p.Matieres = new List<Matiere>();
            while(true) {
                Matiere m = _MatieresService.DemandeMatiere();
                p.Matieres.Add(m);

                
                string saisie = _DemandeALutilisateur.DemandeString("voulez-vous continuer ?");
                if (saisie == "Q")
                    break;
            }
            
            // Exercice : Demander d'autres matières à l'utilisateur

            // construction du message
            string message;
            message = CreerMesageEtudiant(p);
            // affichage du message
            Console.WriteLine(message);
            ListeEtudiants.Add(p);
            return p;
        }

        public string CreerMesageEtudiant(Etudiant p) {
            string result;

            if (p.Age == 0) {
                result = "Bonjour " + p.Prenom + " tu es un tout jeune bébé.";
            } else if (p.Age == 1) {
                result = "Bonjour " + p.Prenom + " tu as " + p.Age + " an.";
            } else {
                result = "Bonjour " + p.Prenom + " tu as " + p.Age + " ans.";
            }
            result = result + " Tu as " + p.NbEnfants + " enfants.";
            return result;
        }
    }
}
