using System;
using System.Threading;
using Cysharp.Threading.Tasks;
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
    public sealed class Converter<TResource>
    {
        private readonly int _inputCapacity;
        private readonly int _outputCapacity;
        private readonly ConvertInstruction<TResource> _instruction;

        private int _inputAmount;
        private int _outputAmount;
        private CancellationTokenSource _cancellationTokenSource;

        public int InputAmount => _inputAmount;
        public int OutputAmount => _outputAmount;
        public bool IsConverting { get; private set; }

        public Converter(
            int inputCapacity,
            int outputCapacity,
            ConvertInstruction<TResource> instruction
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

        public bool Convert()
        {
            if (CanConvert() == false)
            {
                return false;
            }

            _inputAmount -= _instruction.InputConvertCount;
            _outputAmount += _instruction.OutputConvertCount;
            return true;
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

        public async UniTaskVoid StartConversion()
        {
            if (IsConverting)
            {
                return;
            }

            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();
            await ConvertAllAsync();
        }

        public void StopConversion()
        {
            if (IsConverting == false)
            {
                return;
            }

            _cancellationTokenSource.Cancel();
            Put(_instruction.InputConvertCount);
            IsConverting = false;
        }
        
        private async UniTask ConvertAllAsync()
        {
            var convertDelay = TimeSpan.FromSeconds(_instruction.ConvertDuration);

            IsConverting = true;

            while (CanConvert())
            {
                _inputAmount -= _instruction.InputConvertCount;
                await UniTask.Delay(convertDelay, cancellationToken: _cancellationTokenSource.Token);
                
                Put(_instruction.InputConvertCount);
                Convert();
            }

            IsConverting = false;
        }
    }
}