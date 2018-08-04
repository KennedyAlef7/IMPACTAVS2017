using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaDeArquivos
{
    public class MarcaRepositorio
    {
        //private string _caminhoArquivo = ConfigurationManager.AppSettings["caminhoArquivoMarca"];
        private string _caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["caminhoArquivoMarca"]);

        public List<Marca> Selecionar()
        {
            var marcas = new List<Marca>();

            //if (true) return null; 

            foreach (var linha in File.ReadAllLines(_caminhoArquivo))
            {
                var propriedades = linha.Split('|');

                var marca = new Marca();

                marca.Id = Convert.ToInt32(propriedades[0]);
                marca.Nome = propriedades[1];

                marcas.Add(marca);
            }

            return marcas;
        }

        public Marca Selecionar(int marcaId)
        {
            Marca marca = null;

            foreach (var linha in File.ReadAllLines(_caminhoArquivo))
            {
                var propriedades = linha.Split('|');

                if (propriedades[0] == marcaId.ToString())
                {
                    marca = new Marca();

                    marca.Id = marcaId;
                    marca.Nome = propriedades[1];

                    break;
                }
            }

            return marca;
        }
    }
}
