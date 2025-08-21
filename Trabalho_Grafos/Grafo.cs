using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Grafos
{
    class Grafo
    {
        private int _numVertices;
        private Aresta[] _arestas;
        private double _densidade;
        public List<Aresta>[] listaSucessores;
        public double[,] _matrizAdjacencia;


        public Grafo(int numVertices, Aresta[] arestas)
        {
            _numVertices = numVertices;
            _arestas = arestas;

            listaSucessores = new List<Aresta>[_numVertices];
            for (int i = 0; i < _numVertices; i++)
                listaSucessores[i] = new List<Aresta>();
        }
        public double GetDensidade()
        {
            return _densidade;
        }

        public double CalcularDensidade()
        {
            int numArestas = _arestas.Length;
            _densidade = (double)numArestas / (_numVertices * (_numVertices - 1));
            return _densidade;
        }

        public double [,] MatrizAdjacencia()
        {
            _matrizAdjacencia = new double[_numVertices, _numVertices];

            for (int i = 0; i < _numVertices; i++)
            {
                for (int j = 0; j < _numVertices; j++)
                {
                    _matrizAdjacencia[i, j] = 0;
                }
            }

            foreach (var a in _arestas)
            {
                _matrizAdjacencia[a._VerticeInicio - 1, a._VerticeFim - 1] = a._Peso;
            }

            return _matrizAdjacencia;
        }
        public void ImprimirMatrizAdjacencia()
        {
            Console.WriteLine("Matriz de Adjacência:");
            for (int i = 0; i < _matrizAdjacencia.GetLength(0); i++)
            {
                for (int j = 0; j < _matrizAdjacencia.GetLength(1); j++)
                {
                    Console.Write($"{_matrizAdjacencia[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public void ListaAdjacencia()
        {
            for (int i = 0; i < _numVertices; i++)
                listaSucessores[i].Clear();

            foreach (var a in _arestas)
            {
                listaSucessores[a._VerticeInicio - 1].Add(new Aresta(a._VerticeInicio, a._VerticeFim, a._Peso));
            }

        }

        public void ImprimirListaAdjacencia()
        {
            Console.WriteLine("Lista de Adjacência:");
            for (int i = 0; i < listaSucessores.Length; i++)
            {
                Console.Write($"Vértice {i + 1}: ");
                foreach (Aresta a in listaSucessores[i])
                {
                    Console.Write($" -> (Destino: {a._VerticeFim}, Peso: {a._Peso}) ");
                }
                Console.WriteLine();
            }
        }
    }
}
