using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaximumStoneCalculator;

namespace MaximumStoneCalculatorTests
{
    [TestClass]
    public class UnitTestMain
    {
        StoneCalculator calc = new StoneCalculator();
        
        [TestMethod]
        public void CalculateSawmillTotalYieldBonusTest()
        {
            //Act
            var sawmillTotalYieldBonus = calc.CalculateSawmillTotalYieldBonus();

            //Assert
            Assert.AreEqual(sawmillTotalYieldBonus, 217.80, .1);
        }
        
        [TestMethod]
        public void CalculateTreeHPTest()
        {
            //Act
            var treeHP = calc.CalculateTreeHP();

            //Assert
            Assert.AreEqual(treeHP, 63591, 50);
        }

        [TestMethod]
        public void CalculateRegularAxeHitTest()
        {
            //Act
            var regularAxeHit = calc.CalculateRegularAxeHit();

            //Assert
            Assert.AreEqual(regularAxeHit, 1347, 5);
        }

        [TestMethod]
        public void CalculateCriticalAxeHitTest()
        {
            //Act
            var criticalAxeHit = calc.CalculateCriticalAxeHit();

            //Assert
            Assert.AreEqual(criticalAxeHit, 2694, 5);
        }

        [TestMethod]
        public void CalculateCriticalAxeChanceTest()
        {
            //Act
            var criticalAxeChance = calc.CalculateCriticalAxeChance();

            //Assert
            Assert.AreEqual(criticalAxeChance, 26, .1);
        }

        [TestMethod]
        public void CalculateRegularAxeChanceTest()
        {
            //Act
            var regularAxeChance = calc.CalculateRegularAxeChance();

            //Assert
            Assert.AreEqual(regularAxeChance, 74, .1);
        }

        [TestMethod]
        public void CalculateAverageDamagePerSwingTest()
        {
            //Act
            var averageDamagePerSwing = calc.CalculateAverageDamagePerSwing();

            //Assert
            Assert.AreEqual(averageDamagePerSwing, 1697.22, 1);
        }

        [TestMethod]
        public void CalculateAverageSwingsPerTreeTest()
        {
            //Act
            var averageSwingsPerTree = calc.CalculateAverageSwingsPerTree();

            //Assert
            Assert.AreEqual(averageSwingsPerTree, 37.47, .5);
        }

        [TestMethod]
        public void CalculateRegularLogsRewardTest()
        {
            //Act
            var regularLogsReward = calc.CalculateRegularLogsReward();

            //Assert
            Assert.AreEqual(regularLogsReward, 38541, 10);
        }

        [TestMethod]
        public void CalculateDoubleLogsRewardTest()
        {
            //Act
            var doubleLogsReward = calc.CalculateDoubleLogsReward();

            //Assert
            Assert.AreEqual(doubleLogsReward, 77082, 10);
        }

        [TestMethod]
        public void CalculateDoubleLogsChanceTest()
        {
            //Act
            var doubleLogsChance = calc.CalculateDoubleLogsChance();

            //Assert
            Assert.AreEqual(doubleLogsChance, 30, .1);
        }

        [TestMethod]
        public void CalculateRegularLogsChanceTest()
        {
            //Act
            var regularLogschance = calc.CalculateRegularLogsChance();

            //Assert
            Assert.AreEqual(regularLogschance, 70, .1);
        }

        [TestMethod]
        public void CalculateAverageLogsPerTree()
        {
            //Act
            var averageLogsPerTree = calc.CalculateAverageLogsPerTree();

            //Assert
            Assert.AreEqual(averageLogsPerTree, 50103.31, 5);
        }

        [TestMethod]
        public void CalculateAverageLogsPerSwingTest()
        {
            //Act
            var averageLogsPerSwing = calc.CalculateAverageLogsPerSwing();

            //Assert
            Assert.AreEqual(averageLogsPerSwing, 1337.24, 1);
        }

        [TestMethod]
        public void CalculateWoodcuttingNRGRegenIntervalReductionTest()
        {
            //Act
            var woodcuttingNRGRegenIntervalReduction = calc.CalculateWoodcuttingNRGRegenIntervalReduction();

            //Assert
            Assert.AreEqual(woodcuttingNRGRegenIntervalReduction, 24);
        }

        [TestMethod]
        public void CalculateNRGRegenIntervalTest()
        {
            //Act
            var NRGRegenInterval = calc.CalculateNRGRegenInterval();

            //Assert
            Assert.AreEqual(NRGRegenInterval, 912);
        }

        [TestMethod]
        public void CalculateWoodcuttingNRGPerRegenTest()
        {
            //Act
            var woodcuttingNRGPerRegen = calc.CalculateWoodcuttingNRGPerRegen();

            //Assert
            Assert.AreEqual(woodcuttingNRGPerRegen, 2);
        }

        [TestMethod]
        public void CalculateWoodcuttingNRGPerDayTest()
        {
            //Act
            var woodcuttingNRGPerDay = calc.CalculateWoodcuttingNRGPerDay();

            //Assert
            Assert.AreEqual(woodcuttingNRGPerDay, 189.47, 5);
        }

        [TestMethod]
        public void CalculateWarehouseTotalYieldBonusTest()
        {
            //Act
            var warehouseTotalYieldBonus = calc.CalculateWarehouseTotalYieldBonus();

            //Assert
            Assert.AreEqual(warehouseTotalYieldBonus, 111.90, 1);
        }

        [TestMethod]
        public void CalculateStonePerRockTest()
        {
            //Act
            var stonePerRock = calc.CalculateStonePerRock();

            //Assert
            Assert.AreEqual(stonePerRock, 4892, 10);
        }

        [TestMethod]
        public void CalculateStonePerTileTest()
        {
            //Act
            var stonePerTile = calc.CalculateStonePerTile();

            //Assert
            Assert.AreEqual(stonePerTile, 19666, 10);
        }

        [TestMethod]
        public void CalculateStonePerClearTest()
        {
            //Act
            var stonePerclear = calc.CalculateStonePerClear();

            //Assert
            Assert.AreEqual(stonePerclear, 314653, 50);
        }

        [TestMethod]
        public void CalculateStonePerNRGTest()
        {
            //Act
            var stonePerNRG = calc.CalculateStonePerNRG();

            //Assert
            Assert.AreEqual(stonePerNRG, 1966.58, 10);
        }

        [TestMethod]
        public void CalculateMiningNRGRegenIntervalReductionTest()
        {
            //Act
            var miningNRGRegenIntervalReduction = calc.CalculateMiningNRGRegenIntervalReduction();

            //Assert
            Assert.AreEqual(miningNRGRegenIntervalReduction, 14.5, 1);
        }

        [TestMethod]
        public void CalculateMiningNRGRegenIntervalSecondsTest()
        {
            //Act
            var miningNRGRegenIntervalSeconds = calc.CalculateMiningNRGRegenIntervalSeconds();

            //Assert
            Assert.AreEqual(miningNRGRegenIntervalSeconds, 1026, 10);
        }

        [TestMethod]
        public void CalculateMiningNRGPerRegenTest()
        {
            //Act
            var miningNRGPerRegen = calc.CalculateMiningNRGPerRegen();

            //Assert
            Assert.AreEqual(miningNRGPerRegen, 2);
        }

        [TestMethod]
        public void CalculateMiningNRGPerDayTest()
        {
            //Act
            var miningNRGPerDay = calc.CalculateMiningNRGPerDay();

            //Assert
            Assert.AreEqual(miningNRGPerDay, 168.42, .1);
        }
    }
}
