namespace EKRLib
{
    /// <summary>
    /// Класс моторной лодки - наследник класса транспорта.
    /// </summary>
    public class MotorBoat : Transport
    {
        /// <summary>
        /// Переопределённый метод, дающий информацию о моторной лодке.
        /// </summary>
        /// <returns> Строка, содержащая информацию о моторной лодке. </returns>
        public override string ToString()
            => $"MotorBoat. {base.ToString()}";

        /// <summary>
        /// Переопределённый метод для получения звука, издаваемого моторной лодкой.
        /// </summary>
        /// <returns> Звук, издаваемый моторной лодкой, в виде строки. </returns>
        public override string StartEngine()
            => $"{Model}: Brrrbr";
        
        /// <summary>
        /// Конструктор моторной лодки.
        /// Вызывает конструктор базового класса.
        /// </summary>
        /// <param name="model"> Имя модели. </param>
        /// <param name="power"> Мощность моторной лодки. </param>
        public MotorBoat(string model, uint power) : base(model, power) { }
    }
}