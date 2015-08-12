using FizzWare.NBuilder;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;

namespace NDDigital.DiarioAcademia.SecurityTests
{
    public class ObjectBuilder
    {
        public static Turma CreateTurma()
        {
            return Builder<Turma>.CreateNew()
            .WithConstructor(() =>
            new Turma(2014)).Build();
        }

        public static Aluno CreateAluno(Turma turma)
        {
            return Builder<Aluno>.CreateNew()
            .WithConstructor(() =>
            new Aluno("Thiago Sartor", turma)).Build();
        }

        private static Endereco CreateEndereco()
        {
            return Builder<Endereco>.CreateNew()
            .WithConstructor(() =>
            new Endereco("88509720",
            "Ferrovia",
            "Lages",
            "SC")).Build();
        }

        public static Aula CreateAula(Turma turma)
        {
            return Builder<Aula>.CreateNew()
            .WithConstructor(() =>
            new Aula(DateTime.Now, turma)).Build();
        }

        public static User CreateUser()
        {
            return new User { FirstName = "thiago", JoinDate = DateTime.Now, LastName = "sartor", Level = 2, Groups = CreateListGroups() ,UserName="ttt"};
        }

        public static Group CreateGroup()
        {
            return new Group { Name = "Administrador", IsAdmin = true, Permissions = CreateListPermissions() };
        }

        public static Permission CreatePermission()
        {
            return new Permission { PermissionId = "01" };
        }

        public static List<Permission> CreateListPermissions()
        {
            return new List<Permission>
            {
                new Permission { PermissionId = "01" },
                new Permission { PermissionId = "02" }
            };
        }

        public static List<Group> CreateListGroups()
        {
            return new List<Group>
            {
                 new Group { Name = "Administrador", IsAdmin = true, Permissions = CreateListPermissions() },
                 new Group { Name = "Editores", IsAdmin = false, Permissions = CreateListPermissions() }
            };
        }
    }

    public static class Db
    {
        #region Attributos

        public static readonly string connectionStringName =
            ConfigurationManager.AppSettings.Get("connectionDB");

        public static readonly string providerName =
            ConfigurationManager.ConnectionStrings[connectionStringName].ProviderName;

        public static readonly string connectionString =
            ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;

        public static readonly DbProviderFactory factory =
            DbProviderFactories.GetFactory(providerName);

        #endregion Attributos

        public static void Update(string sql, object[] parms = null)
        {
            sql = string.Format(sql, GetParameterPrefix());

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        #region public methods

        public static void SetParameters(this DbCommand command, object[] parms)
        {
            if (parms != null && parms.Length > 0)
            {
                for (int i = 0; i < parms.Length; i += 2)
                {
                    string name = GetParameterPrefix() + parms[i].ToString();

                    if (parms[i + 1] is string && (string)parms[i + 1] == "")
                        parms[i + 1] = null;

                    object value = parms[i + 1] ?? DBNull.Value;

                    var dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = name;
                    dbParameter.Value = value;

                    command.Parameters.Add(dbParameter);
                }
            }
        }

        public static string AppendIdentitySelect(this string sql)
        {
            switch (providerName)
            {
                // Microsoft Access não tem suporte a esse tipo de comando
                case "System.Data.OleDb": return sql;
                case "System.Data.SqlClient": return sql + ";SELECT SCOPE_IDENTITY()";
                case "System.Data.OracleClient": return sql + ";SELECT MySequence.NEXTVAL FROM DUAL";
                default: return sql + ";SELECT @@IDENTITY";
            }
        }

        public static string GetParameterPrefix()
        {
            switch (providerName)
            {
                // Microsoft Access não tem suporte a esse tipo de comando
                case "System.Data.OleDb": return "@";
                case "System.Data.SqlClient": return "@";
                case "System.Data.OracleClient": return ":";
                case "MySql.Data.MySqlClient": return "?";

                default:
                    return "@";
            }
        }

        #endregion public methods
    }
}