using System;

class Problem_2
{
    public void Run()
    {
        int powerConsumption, totalPowerConsumption, countLightsMaintainence, countLightsNormalOperations, countefficentEnergy;
        powerConsumption = totalPowerConsumption = countLightsMaintainence = countLightsNormalOperations = countefficentEnergy = 0;
        float averagePowerConsumption = 0f;

        for (int lightNumber = 1; lightNumber <= 30; lightNumber++)
        {
            powerConsumption = 80 + (lightNumber * 5);
            if (powerConsumption > 180)
            {
                countLightsMaintainence++;
                Console.WriteLine($"Maintainence required for light number {lightNumber}");
            }
            else if (powerConsumption > 140 && powerConsumption < 180)
            {
                countLightsNormalOperations++;
                Console.WriteLine($"Light number {lightNumber} is under normal operation");
            }
            else
            {
                countefficentEnergy++;
                Console.WriteLine($"Light number {lightNumber} is energy efficient");
            }
            totalPowerConsumption += powerConsumption;
        }
        averagePowerConsumption = (float)totalPowerConsumption / 30;
        Console.WriteLine($"Total power consumption : {totalPowerConsumption}");
        Console.WriteLine($"Average power consumption : {averagePowerConsumption}");
        Console.WriteLine($"Total bulbs needed maintainence : {countLightsMaintainence} toatal under normal working : {countLightsNormalOperations} and total under efficient consumption {countefficentEnergy}");

    }
}