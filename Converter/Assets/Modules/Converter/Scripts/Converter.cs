using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Converter.Scripts
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
    public sealed class Converter<TResource>
    {
        private readonly int _inputCapacity;
        private readonly int _outputCapacity;
        private readonly Instruction _instruction;

        private int _inputAmount;
        private int _outputAmount;
        private float _passedTime;

        public int InputAmount => _inputAmount;
        public int OutputAmount => _outputAmount;
        public bool IsConverting { get; private set; }

        public Converter(
            int inputCapacity,
            int outputCapacity,
            Instruction instruction,
            int inputAmount = 0,
            int outputAmount = 0
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
            _inputAmount = inputAmount;
            _outputAmount = outputAmount;
        }

        public bool Put()
        {
            if (_inputAmount == _inputCapacity)
            {
                return false;
            }

            _inputAmount++;
            return true;
        }

        public int Put(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            var freeSpace = _inputCapacity - _inputAmount;
            var addAmount = Mathf.Min(amount, freeSpace);
            _inputAmount += addAmount;
            return amount - addAmount;
        }

        public bool CanConvert()
        {
            var newInputAmount = _inputAmount - _instruction.InputConvertCount;
            var newOutputAmount = _outputAmount + _instruction.OutputConvertCount;

            return newInputAmount >= 0 && newOutputAmount <= _outputCapacity;
        }

        public bool Take()
        {
            if (_outputAmount == 0)
            {
                return false;
            }

            _outputAmount--;
            return true;
        }

        public bool Take(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            if (amount > _outputAmount)
            {
                return false;
            }

            _outputAmount -= amount;
            return true;
        }

        public void StartConversion()
        {
            if (IsConverting)
            {
                return;
            }

            IsConverting = true;
            _inputAmount -= _instruction.InputConvertCount;
        }

        public void StopConversion()
        {
            if (IsConverting == false)
            {
                return;
            }

            IsConverting = false;
            Put(_instruction.InputConvertCount);
        }

        public void Update(float deltaTime)
        {
            if (IsConverting == false)
            {
                return;
            }

            _passedTime += deltaTime;
            
            while (_passedTime >= _instruction.ConvertDuration)
            {
                _outputAmount += _instruction.OutputConvertCount;
                _passedTime -= _instruction.ConvertDuration;

                if (CanConvert())
                {
                    _inputAmount -= _instruction.InputConvertCount;
                }
                else
                {
                    IsConverting = false;
                    _passedTime = 0f;
                    return;
                }
            }
        }

        public int GetAvailableConvertsCount()
        {
            var freeInputSpace = _inputCapacity - _inputAmount;
            var availableInputConverts = freeInputSpace / _instruction.InputConvertCount;
            
            var freeOutputSpace = _outputCapacity - _outputAmount;
            var availableOutputConverts = freeOutputSpace / _instruction.OutputConvertCount;
            
            return Mathf.Min(availableInputConverts, availableOutputConverts);
        }

        public class Instruction
        {
            public TResource InputResource { get; }
            public int InputConvertCount { get; }
            public TResource OutputResource { get; }
            public int OutputConvertCount { get; }
            public float ConvertDuration { get; }

            public Instruction(TResource inputResource,
                int inputConvertCount,
                TResource outputResource,
                int outputConvertCount,
                float convertDuration
            )
            {
                InputResource = inputResource;
                InputConvertCount = inputConvertCount;
                OutputResource = outputResource;
                OutputConvertCount = outputConvertCount;
                ConvertDuration = convertDuration;
            }

            public Instruction(
                KeyValuePair<TResource, int> inputResource,
                KeyValuePair<TResource, int> outputResource,
                float convertDuration
            )
            {
                InputResource = inputResource.Key;
                InputConvertCount = inputResource.Value;
                OutputResource = outputResource.Key;
                OutputConvertCount = outputResource.Value;
                ConvertDuration = convertDuration;
            }
        }
    }
}