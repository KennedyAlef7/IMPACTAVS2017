using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AspNetVS2017.Capitulo01.Vetores.Testes
{
    [TestClass]
    public class VetoresTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            string[] strings = new string[10];
            strings[0] = "Vítor";

            var decimais = new decimal[] { 0.5m, 1, 1.59m };

            int[] inteiros = { 1, 58, 10, 0 };

            foreach (var inteiro in inteiros)
            {
                Console.WriteLine(inteiro);
            }

            Console.WriteLine($"Tamanho do vetor: {inteiros.Length}");

            var soma = inteiros.Where(i => i > 1).Sum();

            Console.WriteLine(soma);
        }

        [TestMethod]
        public void RedimensionamentoTeste()
        {
            var decimais = new decimal[] { 0.5m, 1, 1.59m };

            Array.Resize(ref decimais, 5);

            decimais[4] = 2.1m;
        }

        [TestMethod]
        public void OrdenacaoTeste()
        {
            var decimais = new decimal[] { 0.5m, 1, 1.59m, 0.4m };

            Array.Sort(decimais);

            Assert.AreEqual(decimais[0], 0.4m);
        }

        [TestMethod]
        public void ParamsTeste()
        {
            var decimais = new decimal[] { 0.5m, 1, 1.59m, 0.4m };

            Console.WriteLine(Media(decimais));

            Console.WriteLine(Media(2, 3.5m, 8));
        }

        //private decimal Media(decimal valor1, decimal valor2)
        //{
        //    return (valor1 + valor2) / 2;
        //}

        private decimal Media(params decimal[] decimais)
        {
            var soma = 0m;

            foreach (var @decimal in decimais)
            {
                //soma = soma + @decimal;
                soma += @decimal;
            }

            return soma / decimais.Length;

            //return decimais.Average();
        }

        [TestMethod]
        public void TodaStringEhUmVetorTeste()
        {
            var nome = "Vítor";

            foreach (var caractere in nome)
            {
                Console.WriteLine(caractere);
            }

            Assert.AreEqual(nome.First(), 'V');
        }
    }
}
