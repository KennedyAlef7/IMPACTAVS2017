using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Oficina.Repositorios.SistemaDeArquivos
{
    public class CorRepositorio
    {
        //private string _caminhoArquivo = ConfigurationManager.AppSettings["caminhoArquivoCor"];
        private string _caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,ConfigurationManager.AppSettings["caminhoArquivoCor"]);

        public List<Cor> Selecionar()
        {
            var cores = new List<Cor>();

            //if (true) return null; 

            foreach (var linha in File.ReadAllLines(_caminhoArquivo))
            {
                var cor = new Cor();

                cor.Id = Convert.ToInt32(linha.Substring(0, 5));
                cor.Nome = linha.Substring(5);

                cores.Add(cor);
            }

            return cores;
        }

        public Cor Selecionar(int corId)
        {
            Cor cor = null;

            foreach (var linha in File.ReadAllLines(_caminhoArquivo))
            {
                var linhaId = Convert.ToInt32(linha.Substring(0, 5));

                if (linhaId == corId)
                {
                    cor = new Cor();

                    cor.Id = linhaId;
                    cor.Nome = linha.Substring(5);

                    break;
                }
            }

            return cor;
        }
    }
}
