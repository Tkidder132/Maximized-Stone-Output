using System;

namespace MaximumStoneCalculator
{
    public class StoneCalculator
    {
        //Input Values
        int sawmillLevel = 22; //10
        int warehouseLevel = 22; //11
        double legendaryBonus = .04; //12
        int woodcuttingDamageLevel = 2; //13

        //Woodcutting
        int axeSharpening = 13; //15
        int woodcuttingEnergyCapacity = 28; //26
        int goldLogging = 10; //17
        int logSplitting = 10; //18
        int criticalAxe = 8; //19
        int woodcuttingDamageAscension = 5; //20
        int logGainsAscension = 5; //21
        double woodcuttingDamageOrb = .80; //22
        int woodcuttingNode = 26; //23

        //Mining
        int miningEnergyCapacity = 25; //25
        double stoneYieldOrb = .32; //26
        int miningDepth = 131; //27

        //NRG Regen Upgrades
        int woodcuttingNRGAscension = 1; //29
        int miningNRGAscension = 1; //30
        int woodcuttingNRGReductionTrophy = 18; //31
        int miningNRGReductionTrophy = 8; //32

        //Guild Bonuses
        int guildLevel = 53; //K2
        double woodDmg = .09; //N1
        double woodYield = .04; //N2
        double stoneChance = .02; //P1
        double stoneYield = .16; //P2

        //Guild Building Levels
        int guildSawmillLevel = 40; //B2
        int guildWarehouseLevel = 42; //D2

        //Global Bonuses
        double woodGlobal = .15; //F2
        double stoneGlobal = .15; //G2

        //WC, MINE
        int[,] combinations = {{20, 2}, {19, 6}, {18, 8}, {17,10}, {16,11}, {15,12}, {15,13}, {14,14}, {13,15}, {11,16}, {10,17}, {8,18}, {6,19}, {2,20}};
        int[,] totalAmountsGained = new int[14,2];

        public void CalculateAllCombos()
        {
            for(int i = 0; i < combinations.Length / 2; i++)
            {
                woodcuttingNRGReductionTrophy = combinations[i, 0];
                miningNRGReductionTrophy = combinations[i, 1];
                Console.WriteLine($"Woodcutting Trophy: {woodcuttingNRGReductionTrophy}, Mining Trophy: {miningNRGReductionTrophy}");
                var logsGained = CalculateEstimatedLogsPerDay();
                var stoneGained = CalculateEstimatedStonePerDay();
                totalAmountsGained[i, 0] += logsGained * 30;
                totalAmountsGained[i, 1] += stoneGained * 30;

                Console.WriteLine($"Wood/Day: {logsGained}, Stone/Day: {stoneGained}");
                Console.WriteLine($"Wood after 30 days: {string.Format("{0:n0}", logsGained * 30)}, stone after 30 days {string.Format("{0:n0}", stoneGained * 30)}");
                Console.WriteLine();
            }
        }

        public void GoThrough30Days()
        {
            //cost to next level:
            //50 * (miningDepth^2)
            //logs per pile = (miningDepth * 30) + 1
            var initialWood = 670415;
            var initialStone = 19556;

            for(int i = 0; i <= 30; i++)
            {
                initialWood += CalculateEstimatedLogsPerDay();
                initialStone += CalculateEstimatedStonePerDay();
                if(initialWood > (50 * Math.Pow(miningDepth, 2)))
                {
                    miningDepth += 1;
                    initialWood -= Convert.ToInt32(Math.Round((50 * Math.Pow(miningDepth, 2))));
                }
            }

            Console.WriteLine($"Ending depth: {miningDepth}");
            Console.WriteLine($"Ending Estimated Logs: {CalculateEstimatedLogsPerDay()}");
            Console.WriteLine($"Ending Estimated Stone: {CalculateEstimatedStonePerDay()}");
        }

        public string FormattedValue(int value)
        {
            return string.Format("{0:n0}", value);
        }

        public void GoThrough30DaysOfCombos()
        {
            var daysLength = 180;
            for (int j = 0; j < combinations.Length / 2; j++)
            {
                var initialWood = 635879;
                var initialStone = 628713188;
                miningDepth = 248;
                Console.WriteLine($"Starting Logs: {FormattedValue(initialWood)}");
                Console.WriteLine($"Starting Stone: {FormattedValue(initialStone)}");

                woodcuttingNRGReductionTrophy = combinations[j, 0];
                miningNRGReductionTrophy = combinations[j, 1];
                Console.WriteLine($"Woodcutting Trophy: {woodcuttingNRGReductionTrophy}, Mining Trophy: {miningNRGReductionTrophy}");
                for (int i = 0; i <= daysLength; i++)
                {
                    initialWood += CalculateEstimatedLogsPerDay();
                    initialStone += CalculateEstimatedStonePerDay();
                    if (initialWood > (50 * Math.Pow(miningDepth, 2)))
                    {
                        miningDepth += 1;
                        initialWood -= Convert.ToInt32(Math.Round((50 * Math.Pow(miningDepth, 2))));
                    }
                }

                Console.WriteLine($"Ending depth: {miningDepth}");
                Console.WriteLine($"Ending Logs: {FormattedValue(initialWood)}");
                Console.WriteLine($"Ending Stone: {FormattedValue(initialStone)}");
                Console.WriteLine($"Ending Estimated Logs/Day: {FormattedValue(CalculateEstimatedLogsPerDay())}");
                Console.WriteLine($"Ending Estimated Stone/Day: {FormattedValue(CalculateEstimatedStonePerDay())}");
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        //7
        public int CalculateEstimatedLogsPerDay()
        {
            return Convert.ToInt32(Math.Round(CalculateAverageLogsPerSwing() * CalculateWoodcuttingNRGPerDay()));
        }

        //8
        public int CalculateEstimatedStonePerDay()
        {
            return Convert.ToInt32(Math.Round(CalculateStonePerNRG() * CalculateMiningNRGPerDay()));
        }

        //40
        public double CalculateSawmillTotalYieldBonus()
        {
            return ((guildSawmillLevel + sawmillLevel + (guildLevel * 0.2)) * 0.03) * 100;
        }

        //41
        public int CalculateTreeHP()
        {
            return Convert.ToInt32(Math.Round(250 * (Math.Pow(woodcuttingNode, 1.7))));
        }

        //42
        public int CalculateRegularAxeHit()
        {
            return Convert.ToInt32(Math.Round((50 + 30 * axeSharpening) * (1 + 0.1 * woodcuttingDamageAscension) * (1 + woodcuttingDamageOrb) * (1 + woodDmg) * (1 + (woodcuttingDamageLevel * 0.02))));
        }

        //43
        public int CalculateCriticalAxeHit()
        {
            return CalculateRegularAxeHit() * 2;
        }

        //44
        public double CalculateCriticalAxeChance()
        {
            return (criticalAxe > 10 ? (criticalAxe - 10) * 0.005 + 0.3 : criticalAxe > 5 ? (criticalAxe - 5) * 0.02 + 0.2 : criticalAxe * 0.04) * 100;
        }

        //45
        public double CalculateRegularAxeChance()
        {
            return 100 - CalculateCriticalAxeChance();
        }

        //46
        public double CalculateAverageDamagePerSwing()
        {
            return ((CalculateCriticalAxeChance() * CalculateCriticalAxeHit()) + (CalculateRegularAxeChance() * CalculateRegularAxeHit())) / 100;
        }

        //47
        public double CalculateAverageSwingsPerTree()
        {
            return Math.Round(CalculateTreeHP() / CalculateAverageDamagePerSwing(), 2);
        }

        //48
        public int CalculateRegularLogsReward()
        {
            return Convert.ToInt32(Math.Round(10 * (Math.Pow(woodcuttingNode, 2)) * (1 + (0.1 * logGainsAscension)) * (1 + (CalculateSawmillTotalYieldBonus() / 100)) * (1 + woodGlobal) * (1 + woodYield)));
        }

        //49
        public int CalculateDoubleLogsReward()
        {
            return CalculateRegularLogsReward() * 2;
        }

        //50
        public double CalculateDoubleLogsChance()
        {
            return (logSplitting > 10 ? (logSplitting - 10) * 0.005 + 0.3 : logSplitting > 5 ? (logSplitting - 5) * 0.02 + 0.2 : logSplitting * 0.4) * 100;
        }

        //51
        public double CalculateRegularLogsChance()
        {
            return 100 - CalculateDoubleLogsChance();
        }

        //52
        public double CalculateAverageLogsPerTree()
        {
            return (CalculateDoubleLogsChance() * CalculateDoubleLogsReward() + CalculateRegularLogsChance() * CalculateRegularLogsReward()) / 100;
        }

        //53
        public double CalculateAverageLogsPerSwing()
        {
            return Math.Round(CalculateAverageLogsPerTree() / CalculateAverageSwingsPerTree(), 2);
        }

        //54
        public double CalculateWoodcuttingNRGRegenIntervalReduction()
        {
            return (woodcuttingNRGReductionTrophy > 15 ? 0.005 * (woodcuttingNRGReductionTrophy - 15) + 0.225 : woodcuttingNRGReductionTrophy > 10 ?
                0.01 * (woodcuttingNRGReductionTrophy - 10) + 0.175 : woodcuttingNRGReductionTrophy > 5 ?
                0.015 * (woodcuttingNRGReductionTrophy - 5) + 0.1 : 0.02 * woodcuttingNRGReductionTrophy) * 100;
        }

        //55
        public double CalculateNRGRegenInterval()
        {
            return 12 * (100 - CalculateWoodcuttingNRGRegenIntervalReduction());
        }

        //56
        public int CalculateWoodcuttingNRGPerRegen()
        {
            return 1 + woodcuttingNRGAscension * 1;
        }

        //57
        public double CalculateWoodcuttingNRGPerDay()
        {
            return CalculateWoodcuttingNRGPerRegen() * (86400 / CalculateNRGRegenInterval());
        }

        //59
        public double CalculateWarehouseTotalYieldBonus()
        {
            return ((guildWarehouseLevel + warehouseLevel + (guildLevel * 0.2)) * 0.015) * 100;
        }

        //60
        public int CalculateStonePerRock()
        {
            return Convert.ToInt32(Math.Round((10 * miningDepth + 1) * (1 + (CalculateWarehouseTotalYieldBonus()/100)) * (1 + stoneGlobal) * (1 + stoneYieldOrb) * (1 + stoneYield)));
        }

        //61
        public int CalculateStonePerTile()
        {
            return miningDepth > 249 ? Convert.ToInt32(Math.Round(CalculateStonePerRock() * (5 * (1 - stoneChance) + 6 * (1 * stoneChance)))) : 
                miningDepth > 99 ? Convert.ToInt32(Math.Round(CalculateStonePerRock() * (4 * (1 - stoneChance) + 5 * (1 * stoneChance)))) :
                Convert.ToInt32(Math.Round(CalculateStonePerRock() * (3 * (1 - stoneChance) + 4 * (1 * stoneChance))));
        }

        //62
        public int CalculateStonePerClear()
        {
            return CalculateStonePerTile() * 16;
        }

        //63
        public double CalculateStonePerNRG()
        {
            return CalculateStonePerTile() / 10;
        }

        //64
        public double CalculateMiningNRGRegenIntervalReduction()
        {
            return (miningNRGReductionTrophy > 15 ? 0.005 * (miningNRGReductionTrophy - 15) + 0.225 : miningNRGReductionTrophy > 10 ? 0.01 * (miningNRGReductionTrophy - 10) + 0.175 : miningNRGReductionTrophy > 5 ? 0.015 * (miningNRGReductionTrophy - 5) + 0.1 : 0.02 * miningNRGReductionTrophy) * 100;
        }

        //65
        public double CalculateMiningNRGRegenIntervalSeconds()
        {
            return 12 * (100 - CalculateMiningNRGRegenIntervalReduction());
        }

        //66
        public double CalculateMiningNRGPerRegen()
        {
            return 1 + miningNRGAscension * 1;
        }

        //67
        public double CalculateMiningNRGPerDay()
        {
            return CalculateMiningNRGPerRegen() * (86400 / CalculateMiningNRGRegenIntervalSeconds());
        }
    }
}
