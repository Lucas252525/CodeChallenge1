using CodeChallenge.Data;
using CodeChallenge.Data.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallengeTest
{
    public class Tests
    {
        private List<Animal> _animales;
        private CalculosServicio _calculosServicio;

        [SetUp]
        public void Setup()
        {
            _animales = new List<Animal>();
            _calculosServicio = new CalculosServicio();
        }

        [Test]
        public void CalcularAlimentoSinAnimales()
        {
            var result = _calculosServicio.CalcularTotalMensual(_animales);
            Assert.AreEqual(0,result);
        }

        [Test]
        public void CalcularAlimentoSoloCarnivoros()
        {
            _animales.AddRange(MockFactoryCarnivoros());
            var result = _animales.Sum(_calculosServicio.CalcularAlimentoDiario);
            Assert.AreEqual(22.5, result);
        }

        [Test]
        public void CalcularAlimentoSoloHerviboros()
        {
            _animales.AddRange(MockFactoryHerbiboros());
            var result = _animales.Sum(_calculosServicio.CalcularAlimentoDiario);
            Assert.AreEqual(185, result);
        }

        [Test]
        public void CalcularAlimentoTodos()
        {
            _animales.AddRange(MockFactoryTodos());
            var result = _animales.Sum(_calculosServicio.CalcularAlimentoDiario);
            Assert.AreEqual(208.21, result);
        }
        [Test]
        public void CalcularAlimentoMensualReptil()
        {
            var result = _calculosServicio.CalcularAlimentoMensual(MockReptil);
            Assert.AreEqual(6.39, result);
        }


        #region Mock Factory

      
        private List<Animal> MockFactoryCarnivoros()
        {
            return new List<Animal>() {
                new Animal{
                    Tipo = "Carnívoro",
                    Peso = 100,
                    Porcentaje = 0.05
                },
                new Animal{
                    Tipo = "Carnívoro",
                    Peso = 80,
                    Porcentaje = 0.1
                },
                new Animal{
                    Tipo = "Carnívoro",
                    Peso = 95,
                    Porcentaje = 0.1
                }
            };
        }

        private List<Animal> MockFactoryHerbiboros()
        {
            return new List<Animal>() {
                new Animal{
                    Tipo = "Herbíboro",
                    Peso = 30,
                    Kilos = 10
                },
                new Animal{
                    Tipo = "Herbíboro",
                    Peso = 50,
                    Kilos = 15
                }
            };
        }

        private List<Animal> MockFactoryTodos()
        {
            return new List<Animal>() {
                new Animal{
                    Tipo = "Carnívoro",
                    Peso = 100,
                    Porcentaje = 0.05
                },
                new Animal{
                    Tipo = "Carnívoro",
                    Peso = 80,
                    Porcentaje = 0.1
                },
                new Animal{
                    Tipo = "Carnívoro",
                    Peso = 95,
                    Porcentaje = 0.1
                },
                new Animal{
                    Tipo = "Herbíboro",
                    Peso = 30,
                    Kilos = 10
                },
                new Animal{
                    Tipo = "Herbíboro",
                    Peso = 50,
                    Kilos = 15
                },
                new Animal{
                    Tipo = "Reptil",
                    Peso = 50,
                    Kilos = 15,
                    Periodo = 4,
                    Porcentaje = 0.1
                }
            };

        }
        private Animal MockReptil = new Animal
        {
            Tipo = "Reptil",
            Peso = 50,
            Kilos = 15,
            Periodo = 4,
            Porcentaje = 0.1

            
    };
        #endregion
    }
}