using CodeChallenge.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Data
{
    public class CalculosServicio
    {
        public double CalcularAlimentoDiario(Animal animal)
        {
            var total = 0D;
            switch (animal.Tipo)
            {
                case "Carnívoro":
                    total = animal.Peso * animal.Porcentaje;
                    break;
                case "Herbíboro":
                    total = 2 * animal.Peso + animal.Kilos;
                    break;
                case "Reptil":
                    total = (animal.Peso * animal.Porcentaje) / 7;
                    break;
                default:
                    break;
            }
            return Math.Round(total, 2);
        }
        public double CalcularAlimentoMensual(Animal animal)
        {
            var consumoDiario = CalcularAlimentoDiario(animal);
            var diasMes = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            double consumoMensual;
            if (animal.Tipo == "Reptil")
            {
                consumoMensual = consumoDiario * diasMes;
                var cantidadCambios = diasMes / animal.Periodo;
                var diasSinComer = cantidadCambios * 3;
                var comidaNoConsumida = diasSinComer * consumoDiario;
                consumoMensual = consumoMensual - comidaNoConsumida;
            }
            else
            {
                consumoMensual = consumoDiario * diasMes;
            }
            return Math.Round(consumoMensual, 2);
        }
        public double CalcularTotalMensual(List<Animal> animales)
        {
            var total = 0D;
            foreach (var animal in animales)
            {
                total += CalcularAlimentoMensual(animal);
            }
            return Math.Round(total, 2);
        }
    }
}
