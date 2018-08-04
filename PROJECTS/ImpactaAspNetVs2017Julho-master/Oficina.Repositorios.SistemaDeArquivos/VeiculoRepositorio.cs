using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Oficina.Repositorios.SistemaDeArquivos
{
    public class VeiculoRepositorio
    {
        private string _caminhoArquivo;
        private XDocument _arquivoXml;

        public VeiculoRepositorio()
        {
            //_caminhoArquivo =   ConfigurationManager.AppSettings["caminhoArquivoVeiculo"];
            _caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["caminhoArquivoModelo"]);
            _arquivoXml = XDocument.Load(_caminhoArquivo);
        }

        public void Inserir(Veiculo veiculo)
        {
            var registro = new StringWriter();
            new XmlSerializer(typeof(Veiculo)).Serialize(registro, veiculo);

            _arquivoXml.Root.Add(XElement.Parse(registro.ToString()));
            _arquivoXml.Save(_caminhoArquivo);
        }
    }
}