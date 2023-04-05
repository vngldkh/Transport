using System;
using System.Text;

namespace EKRLib
{
    /// <summary>
    /// Абстрактный класс транспорта.
    /// </summary>
    public abstract class Transport
    {
        private string _Model;
        /// <summary>
        /// Строковое свойство, отвечающее за модель транспортного средства.
        /// </summary>
        /// <exception cref="TransportException">
        /// Вызывается, если в названии модели есть невалидные символы.
        /// </exception>
        public string Model
        {
            get => _Model;
            set
            {
                if (value is null || value.Length != 5)
                    throw new TransportException($"Недопустимая модель {_Model}");
                
                bool valid = true;
                foreach (var symbol in value)
                {
                    valid = validSymbols.Contains(symbol);
                    if (!valid)
                        break;
                }

                if (!valid)
                    throw new TransportException($"Недопустимая модель {_Model}");

                _Model = value;
            }
        }

        private uint _Power;
        /// <summary>
        /// Целочисленное свойство, соответствующее мощности транспортного средства.
        /// </summary>
        /// <exception cref="TransportException">
        /// Возникает, если значение меньше 20.
        /// </exception>
        public uint Power
        {
            get => _Power;
            set
            {
                if (value < 20)
                    throw new TransportException("Мощность не может быть меньше 20 л.с.");
                _Power = value;
            }
        }

        /// <summary>
        /// Абстрактный метод для получения звука,издаваемого транспортным средством.
        /// </summary>
        /// <returns>
        /// Звук, издаваемый транспортным средством, в виде строки.
        /// </returns>
        public abstract string StartEngine();
        
        /// <summary>
        /// Переопределнный метод, который даёт информацию о транспортном средстве.
        /// </summary>
        /// <returns>
        /// Информация о транспортном средстве в виде строки.
        /// </returns>
        public override string ToString()
            => $"Model: {Model}, Power: {Power}";

        // Символы, допустимые в имени модели.
        private const string validSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        
        /// <summary>
        /// Конструктор транспортного средства.
        /// </summary>
        /// <param name="model"> Имя модели. </param>
        /// <param name="power"> Мощность транспортного средства. </param>
        public Transport(string model, uint power)
            => (Model, Power) = (model, power);

        /// <summary>
        /// Статический метод, генерирующий параметры для транспортного средства.
        /// </summary>
        /// <returns> Кортеж параметров. </returns>
        public static (string, uint) GenerateParameters()
        {
            var rnd = new Random();
            var model = new StringBuilder(5);
            for (var j = 0; j < 5; j++)
                model.Append(validSymbols[rnd.Next(0, validSymbols.Length)]);
            return (model.ToString(), (uint) rnd.Next(10, 100));
        }
    }
}