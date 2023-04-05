namespace EKRLib
{
    /// <summary>
    /// Класс автомобиля - наследник класса транспорта.
    /// </summary>
    public class Car : Transport
    {
        /// <summary>
        /// Переопределённый метод, дающий информацию об автомобиле.
        /// </summary>
        /// <returns> Строка, содержащая информацию об автомобиле. </returns>
        public override string ToString()
            => $"Car. {base.ToString()}";

        /// <summary>
        /// Переопределённый метод для получения звука, издаваемого автомобилем.
        /// </summary>
        /// <returns> Звук, издаваемый автомобилем, в виде строки. </returns>
        public override string StartEngine()
            => $"{Model}: Vroom";
        
        /// <summary>
        /// Конструктор автомобиля.
        /// Вызывает конструктор базового класса.
        /// </summary>
        /// <param name="model"> Имя модели. </param>
        /// <param name="power"> Мощность автомобиля. </param>
        public Car(string model, uint power) : base(model, power) { }
    }
}