using System;
using UnityEngine;

namespace Homework
{
    /**
       Конвертер представляет собой преобразователь ресурсов, который берет ресурсы
       из зоны погрузки (справа) и через несколько секунд преобразовывает его в
       ресурсы другого типа (слева).

       Конвертер работает автоматически. Когда заканчивается цикл переработки
       ресурсов, то конвертер берет следующую партию и начинает цикл по новой, пока
       можно брать ресурсы из зоны загрузки или пока есть место для ресурсов выгрузки.

       Также конвертер можно выключать. Если конвертер во время работы был
       выключен, то он возвращает обратно ресурсы в зону загрузки. Если в это время
       были добавлены еще ресурсы, то при переполнении возвращаемые ресурсы
       «сгорают».

       Характеристики конвертера:
       - Зона погрузки: вместимость бревен
       - Зона выгрузки: вместимость досок
       - Кол-во ресурсов, которое берется с зоны погрузки
       - Кол-во ресурсов, которое поставляется в зону выгрузки
       - Время преобразования ресурсов
       - Состояние: вкл/выкл
     */
    public sealed class Converter
    {
        private readonly int _inputCapacity;
        private readonly int _outputCapacity;
        private readonly ConvertInstruction _instruction;

        private int _toConvertAmount;
        private int _readyAmount;

        public int ConvertAmount => _toConvertAmount;
        public int ReadyAmount => _readyAmount;
        public bool IsConverting => false;

        public Converter(
            int inputCapacity,
            int outputCapacity,
            ConvertInstruction instruction
        )
        {
            if (instruction == null)
            {
                throw new ArgumentNullException(nameof(instruction));
            }

            if (inputCapacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(inputCapacity));
            }

            if (outputCapacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(inputCapacity));
            }

            _inputCapacity = inputCapacity;
            _outputCapacity = outputCapacity;
            _instruction = instruction;
        }

        public bool Put()
        {
            if (_toConvertAmount == _inputCapacity)
            {
                return false;
            }

            _toConvertAmount++;
            return true;
        }

        public int Put(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            var freeSpace = _inputCapacity - _toConvertAmount;
            var addAmount = Mathf.Min(amount, freeSpace);
            _toConvertAmount += addAmount;
            return amount - addAmount;
        }

        public bool CanConvert()
        {
            var newInputAmount = _toConvertAmount - _instruction.InputConvertCount;
            var newOutputAmount = _readyAmount + _instruction.OutputConvertCount;

            return newInputAmount >= 0 && newOutputAmount <= _outputCapacity;
        }

        public bool Convert()
        {
            if (CanConvert() == false)
            {
                return false;
            }

            _toConvertAmount -= _instruction.InputConvertCount;
            _readyAmount += _instruction.OutputConvertCount;
            return true;
        }

        public bool Take()
        {
            if (_readyAmount == 0)
            {
                return false;
            }

            _readyAmount--;
            return true;
        }

        public bool Take(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            if (amount > _readyAmount)
            {
                return false;
            }

            _readyAmount -= amount;
            return true;
        }

        public void StartConversion()
        {
            throw new NotImplementedException();
        }
    }
}