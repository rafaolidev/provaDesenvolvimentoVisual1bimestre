using System;
using API_AMIGO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API_AMIGO.Data

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        //Tabelas do Banco em "memória" feitas pela LIB Entity
    
        public DbSet<Carro> Carro { get; set; }
    }
}