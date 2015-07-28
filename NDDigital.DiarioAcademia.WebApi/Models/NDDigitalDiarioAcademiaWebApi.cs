using System.Data.Entity;

namespace NDDigital.DiarioAcademia.WebApi.Models
{
    public class NDDigitalDiarioAcademiaWebApi : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        //
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public NDDigitalDiarioAcademiaWebApi() : base("name=NDDigitalDiarioAcademiaWebApi")
        {
        }

        public System.Data.Entity.DbSet<NDDigital.DiarioAcademia.Aplicacao.DTOs.AlunoDTO> AlunoDTOes { get; set; }
    }
}