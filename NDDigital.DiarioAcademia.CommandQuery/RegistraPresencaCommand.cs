using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.CommandQuery
{

    /*
     *  IEnumerable<CustomersListQuery> GetCustomersList();  

        CustomerResumeQuery GetCustomerResume(int id);

        CustomerFullQuery GetCustomerFull(int id, bool includeReviews = false);
        
        IEnumerable<BeersListQuery> GetBeersKitList(string customerName, DateTime kitDate);
     */

    public class RegistraPresencaCommand
    {
        public RegistraPresencaCommand()
        {
            PresencaAlunos = new List<PresencaAlunosCommand>();
        }

        public int AnoTurma { get; set; }

        public DateTime DataAula { get; set; }

        public List<PresencaAlunosCommand> PresencaAlunos { get; set; }
    }

    public class PresencaAlunosCommand
    {
        public Guid AlunoId { get; set; }

        public string Status { get; set; }

    }
}