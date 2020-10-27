
using ConsoleApp4.Services;
using System;
using System.Collections.Generic;

namespace ConsoleApp4 {
    class Program {

        private static DemandeALutilisateur _DemandeALutilisateur = new DemandeALutilisateur();


        static void Main(string[] args) {
                SalleService _SalleService = new SalleService(_DemandeALutilisateur);
                MatieresService _MatieresService = new MatieresService(_DemandeALutilisateur, _SalleService);
                EtudiantsService _EtudiantsService = new EtudiantsService(_DemandeALutilisateur, _MatieresService);

            // ancienne partie du code => à conserver pour exercices
            var l = new List<Toto>();
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
                   
                } else if (choixUtilisateur == "5") {
                    _SalleService.CreateSalle();
                } else if (choixUtilisateur == "6") {
                    _SalleService.CreateFakeData();
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
            Console.WriteLine("4. Afficher les matières");
            Console.WriteLine("5. Créer une salle");
            Console.WriteLine("Q. Quitter");
            string choixUtilisateur = _DemandeALutilisateur.DemandeString("");
            return choixUtilisateur;
        }

    }

    public class Toto {
        public string description { get; set; } = "sdfqdfsqkj qsldkj qkjf mqsdjkf mfkjs sfk fsdqkj fskjh fdlkjfs lkj slkjh sdl";
        public string description2 { get; set; } = "sdfqdfsqkj qsldkj qkjf mqsdjkf mfkjs sfk fsdqkj fskjh fdlkjfs lkj slkjh sdl";
        public string description3 { get; set; } = "sdfqdfsqkj qsldkj qkjf mqsdjkf mfkjs sfk fsdqkj fskjh fdlkjfs lkj slkjh sdl";
    }
}
