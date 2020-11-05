using ConsoleApp4.Model;
using ConsoleApp4.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Tests.Mock {
    public class SalleServiceMock : SalleService {

        public SalleServiceMock(IDemandeALutilisateur _demandeSrv)
            : base(_demandeSrv) {
        }


        private List<Salle> _mesSallesMocked ;
        public override List<Salle> getAll() {
            
            if (_mesSallesMocked == null) {
                _mesSallesMocked = new List<Salle>();
                _mesSallesMocked.Add(new Salle() { Batiment = "B2", Numero = "202" });
                _mesSallesMocked.Add(new Salle() { Batiment = "B2", Numero = "203" });
            }

            return _mesSallesMocked;
        }

        public override string CreerMessageSalle(Salle s) {
            return base.CreerMessageSalle(s);
        }
    }
}
