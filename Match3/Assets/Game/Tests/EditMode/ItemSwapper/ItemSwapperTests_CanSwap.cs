using System.Collections.Generic;
using Game.Gameplay;
using NUnit.Framework;
using UnityEngine;

namespace Game.Tests
{
    public partial class ItemSwapperTests
    {
        [TestCaseSource(nameof(CanSwapCases))]
        public bool CanSwap(ItemSwapper itemSwapper, Vector2Int first, Vector2Int second)
        {
            //Arrange:
            //Act:
            //Assert:
            return itemSwapper.CanSwap(first, second);
        }

        private static IEnumerable<TestCaseData> CanSwapCases()
        {
            yield return new TestCaseData(
                CreateItemSwapper(),
                Vector2Int.zero,
                new Vector2Int(0, 1)
            ).Returns(true);  
            
            yield return new TestCaseData(
                CreateItemSwapper(),
                new Vector2Int(3, 3),
                new Vector2Int(3, 2)
            ).Returns(true);  
            
            yield return new TestCaseData(
                CreateItemSwapper(),
                new Vector2Int(3, 3),
                new Vector2Int(3, 4)
            ).Returns(true);  
            
            yield return new TestCaseData(
                CreateItemSwapper(),
                new Vector2Int(3, 3),
                new Vector2Int(2, 3)
            ).Returns(true);  

            yield return new TestCaseData(
                CreateItemSwapper(),
                new Vector2Int(3, 3),
                new Vector2Int(4, 3)
            ).Returns(true);  
            
            yield return new TestCaseData(
                CreateItemSwapper(),
                new Vector2Int(3, 3),
                new Vector2Int(4, 4)
            ).Returns(false);  
            
            yield return new TestCaseData(
                CreateItemSwapper(),
                new Vector2Int(3, 3),
                new Vector2Int(2, 2)
            ).Returns(false);  

            yield return new TestCaseData(
                CreateItemSwapper(),
                new Vector2Int(3, 3),
                new Vector2Int(2, 4)
            ).Returns(false);  
            
            yield return new TestCaseData(
                CreateItemSwapper(),
                Vector2Int.zero,
                Vector2Int.zero
            ).Returns(false);
            
            yield return new TestCaseData(
                CreateItemSwapper(),
                Vector2Int.zero,
                new Vector2Int(0, -1)
            ).Returns(false);  
        }
    }
}