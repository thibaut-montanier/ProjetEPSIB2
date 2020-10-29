using ConsoleApp4.Model;
using ConsoleApp4.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Tests.Mock {
    public class SalleServiceMock : SalleService {

        public SalleServiceMock(IDemandeALutilisateur _demandeSrv) 
            : base(_demandeSrv)
        {
               
        }
        private List<Salle> _mesSalles ;
        public override List<Salle> getAll() {
            if (_mesSalles == null) {
                _mesSalles = new List<Salle>();
                _mesSalles.Add(new Salle() { Batiment = "B2", Numero = "202" });
                _mesSalles.Add(new Salle() { Batiment = "B2", Numero = "203" });
            }

            return _mesSalles;
        }
    }
}
