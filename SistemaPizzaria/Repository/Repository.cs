using Dapper;
using Dapper.Contrib.Extensions;
using SistemaPizzaria.Moldels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlog.Repositories
{
    public class Repository<T> where T : class // criaçao de uma classe generica onde e feita uma condiçao
                                               // para aceitar objetos do tipo classe
    {
        private readonly SqlConnection _connection; //somanete leitura

        public Repository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<T> Get()
          => _connection.GetAll<T>(); //método é usado para obter todos os registros de uma tabela de um banco de dados.

        public T Getq(int Id)
          => _connection.Get<T>(Id);


        public void Create(T model)
         => _connection.Insert<T>(model);


        public void Update(T model)
          => _connection.Update<T>(model); 


        public void Delete(T model)
        => _connection.Delete<T>(model); 
        public void Update(int id)
        {
            var model = _connection.Get<T>(id);
            _connection.Delete<T>(model); 
        }



        


    }
}
