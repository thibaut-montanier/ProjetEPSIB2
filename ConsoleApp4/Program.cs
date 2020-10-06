
using ConsoleApp4.Services;
using System;
using System.Collections.Generic;

namespace ConsoleApp4 {
    class Program {


        private static DemandeALutilisateur _DemandeALutilisateur = new DemandeALutilisateur();
        private static EtudiantsService _EtudiantsService = new EtudiantsService(_DemandeALutilisateur);
        private static MatieresService _MatieresService = new MatieresService(_DemandeALutilisateur);
        static void Main(string[] args) {
            //// présentaiton du fonctionnement du lien entre les objets
            //Matiere CsharpNiveau1 = new Matiere();
            //CsharpNiveau1.Code= "C#";
            //CsharpNiveau1.Nom = "C# Les fondamentaux";

            //Matiere UML = new Matiere();
            //UML.Code = "UML";
            //UML.Nom = "UML - le diagramme de classe";

            //List<Matiere> lesMatieres = new List<Matiere>();
            //lesMatieres.Add(CsharpNiveau1);
            //lesMatieres.Add(UML);

            //Etudiant p1 = new Etudiant();
            //p1.Prenom = "Thibaut";

            //p1.Matieres = new List<Matiere>();
            //p1.Matieres.Add(CsharpNiveau1);
            //p1.Matieres.Add(UML);


            //Etudiant p2 = new Etudiant();
            //p2.Prenom = "Oulimata";
            //p2.Matieres = new List<Matiere>();


            //List<Etudiant> etudiants = new List<Etudiant>();
            //etudiants.Add(p1);
            //etudiants.Add(p2);


            //Matiere m = DemandeMatiere(lesMatieres);
            //if (m!= null)
            //    p2.Matieres.Add(m);
            //// ajout de la matière correspondant au code à Oulimata.


            //// Modification du nom de la matière => l'affichage sera impacté pour tous les édutiants qui suivent cette matière
            //CsharpNiveau1.Nom = "C# Niveau 1";
            ////********** - Afficher la liste des étudiants et les matières qu'ils suivent ***************** /
            //_EtudiantsService.AfficheEtudiants(etudiants);


            // ancienne partie du code => à conserver pour exercices

            Console.WriteLine("Hello World!");
            // déclaration d'une liste de personne
            
            while (true) {
                string choixUtilisateur = MenuUtilisateur();

                if (choixUtilisateur == "1") {
                    _EtudiantsService.CreateEtudiants();
                } else if (choixUtilisateur == "2") {
                    _EtudiantsService.AfficheEtudiants();
                } else if (choixUtilisateur == "3") {
                    // exercice : permettre de créer une matière
                    _MatieresService.CreerMatiere();
                } else if (choixUtilisateur == "4") {
                    // exercice : afficher la liste des matières
                } else if (choixUtilisateur == "Q") {
                    break;
                } else {
                    Console.WriteLine("Je n'ai pas compris");
                }
            }
            // pour laisser la fenetre ouverte et attendre 
            // que l'utilisateur ferme
            Console.ReadKey();
        }




       

        public static int ModifieNum(ref int num1, int num2) {


            num1 = num1 + 1;
            return num1 + num2;
        }

        private static string MenuUtilisateur() {
            Console.WriteLine("Que voulez-vous faire ?");
            Console.WriteLine("1. Créer une personne");
            Console.WriteLine("2. Afficher la liste des personnes");
            Console.WriteLine("3. Créer une matière");
            Console.WriteLine("Q. Quitter");
            string choixUtilisateur = _DemandeALutilisateur.DemandeString("");
            return choixUtilisateur;
        }

    }
}
