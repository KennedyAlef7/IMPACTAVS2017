using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AspNetVS2017.Capitulo01.Vetores.Testes
{
    [TestClass]
    public class ColecoesTeste
    {
        [TestMethod]
        public void ListTeste()
        {
            var inteiros = new List<int>(50);
            inteiros.Add(5);
            inteiros.Add(3);
            inteiros.Add(28);
            //inteiros[10] = 27;

            var maisInteiros = new List<int> { 1, 3, 2, 9 };

            inteiros.AddRange(maisInteiros);

            inteiros.Insert(0, 32);

            inteiros.Remove(3);
            //inteiros.RemoveAll(i => i == 3);

            inteiros.RemoveAt(0);

            inteiros.Sort();

            var primeiro = inteiros[0];
            var ultimo = inteiros[inteiros.Count - 1];

            foreach (var inteiro in inteiros)
            {
                Console.WriteLine($"{inteiros.IndexOf(inteiro)}: {inteiro}");
            }
        }

        [TestMethod]
        public void DictionaryTeste()
        {
            var feriados = new Dictionary<DateTime, string>();
            feriados.Add(new DateTime(2018, 12, 25), "Natal");
            feriados.Add(new DateTime(2019, 1, 01), "Ano Novo");
            feriados.Add(new DateTime(2019, 1, 25), "Aniversário de São Paulo");

            var natal = feriados[new DateTime(2018, 12, 25)];

            //feriados.Add(new DateTime(2018, 12, 25), "Natal");

            foreach (var feriado in feriados)
            {
                Console.WriteLine($"{feriado.Key.ToString("dd-MM-yyyy")}: {feriado.Value}");
            }

            Console.WriteLine(feriados.ContainsKey(new DateTime(2018, 12, 25)));
            Console.WriteLine(feriados.ContainsValue("Ano Novo"));
        }

        [TestMethod]
        public void StackTeste()
        {
            var pilha = new Stack<int>();
            pilha.Push(1);
            pilha.Push(4);
            pilha.Push(7);

            Assert.AreEqual(pilha.Pop(), 7);
            Assert.AreEqual(pilha.Peek(), 4);

            Console.WriteLine($"A pilha está vazia? {pilha.Count == 0}");
        }

        [TestMethod]
        public void QueueTeste()
        {
            var fila = new Queue<int>();
            fila.Enqueue(1);
            fila.Enqueue(4);
            fila.Enqueue(2);

            Assert.AreEqual(fila.Dequeue(), 1);
            Assert.AreEqual(fila.Peek(), 4);
        }
    }
}
