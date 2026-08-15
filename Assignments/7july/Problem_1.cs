// An automated conveyor belt processes 20 packages. Package IDs are generated from 1001 to 1020 using a loop.
// For each package:
// * If the package ID is divisible by 4, it is marked as Quality Check Required.
// * Else if the package ID is divisible by 5, it is marked as Priority Shipment.
// * Otherwise, it is marked as Normal Processing.
// At the end of the program, display:
// * Total packages processed
// * Number of packages requiring quality check
// * Number of priority shipments
// * Number of normal packages


using System;

class Problem_1
{
    public void Run()
    {
        int normalProcressingCount, qualityCheckedRequiredCount, priorityShipmentCount, totalProcessedCount;
        normalProcressingCount = qualityCheckedRequiredCount = priorityShipmentCount = totalProcessedCount = 0;
        for (int id = 1001; id <= 1020; id++)
        {
            if (id % 4 == 0)
            {
                qualityCheckedRequiredCount++;
            }
            else if (id % 5 == 0)
            {
                priorityShipmentCount++;
            }
            else
            {
                normalProcressingCount++;
            }
            totalProcessedCount++;
        }
        Console.WriteLine($"Total packages processed : {totalProcessedCount}");
        Console.WriteLine($"Normal packages processed : {normalProcressingCount}");
        Console.WriteLine($"Quality check required packages : {qualityCheckedRequiredCount}");
        Console.WriteLine($"Priority shipment packages : {priorityShipmentCount}");
    }
}
