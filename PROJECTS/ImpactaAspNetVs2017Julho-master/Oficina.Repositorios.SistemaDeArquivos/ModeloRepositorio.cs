using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Oficina.Repositorios.SistemaDeArquivos
{
    public class ModeloRepositorio
    {
        XDocument _arquivoXml = 
            XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["caminhoArquivoModelo"]));
       // private string _caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["caminhoArquivoModelo"]);

        public List<Modelo> SelecionarPorMarca(int marcaId)
        {
            var modelos = new List<Modelo>();

            foreach (var elemento in _arquivoXml.Descendants("modelo"))
            {
                if (elemento.Element("marcaId").Value == marcaId.ToString())
                {
                    var modelo = new Modelo();
                    modelo.Id = Convert.ToInt32(elemento.Element("id").Value);
                    modelo.Nome = elemento.Element("nome").Value;
                    modelo.Marca = new MarcaRepositorio().Selecionar(marcaId);

                    modelos.Add(modelo);
                }
            }

            return modelos;
        }

        public Modelo Selecionar(int modeloId)
        {
            Modelo modelo = null;

            foreach (var elemento in _arquivoXml.Descendants("modelo"))
            {
                if (elemento.Element("id").Value == modeloId.ToString())
                {
                    /*var*/ modelo = new Modelo();
                    modelo.Id = Convert.ToInt32(elemento.Element("id").Value);
                    modelo.Nome = elemento.Element("nome").Value;

                    var marcaId = Convert.ToInt32(elemento.Element("marcaId").Value);
                    modelo.Marca = new MarcaRepositorio().Selecionar(marcaId);

                    break;
                    //modelos.Add(modelo);
                }
            }

            return modelo;
        }
    }
}
