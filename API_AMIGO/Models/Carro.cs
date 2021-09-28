
using System;
namespace API_AMIGO.Models

{
    public class Carro
    {
        public Carro()
        {
            CriadoEm = DateTime.Now;
        }
        public int Id { get; set; }

        public string Modelo { get; set; }
        
        public int AnoFabricacao { get; set; }

        public string Cor { get; set; }

        public string Marca { get; set; }

        public DateTime CriadoEm { get; set; }

        public override string ToString()
        {
            return $"Modelo: {Modelo} | Cor: {Cor} | Cadastrado em: {CriadoEm}";
        }
    }
}