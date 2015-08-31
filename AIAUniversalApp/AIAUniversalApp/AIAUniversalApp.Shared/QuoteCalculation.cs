using AIARestApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIAUniversalApp
{
    public class QuoteCalculation
    {
        public static List<decimal> driverCostFinal = new List<decimal>();
        public static List<decimal> vehicleCostFinal = new List<decimal>();
        public static List<long> driverId = new List<long>();
        public static List<long> vehicleId = new List<long>();

        public static decimal calcQuote(Quote quote, List<Driver> drivers, List<Vehicle> vehicles)
        {
            decimal VehicleQuoteMultiplier = 1;
            decimal currentQuoteMultiplier = 1;
            decimal driverQuoteMultiplier = 1;
            decimal baseVehicleCost = 0;
            decimal vehicleCost;
            decimal driverCost;
            decimal driverBase = 0;
            decimal policyBase = 100;

            bool lessThan3years = false;

            switch (quote.State)
            {
                case "VT":
                    {
                        foreach (var d in drivers)
                        {

                            driverCost = 0;
                            driverBase += 200;

                            if (d.SafeDrivingSchool)
                            {
                                driverQuoteMultiplier *= .95m;
                            }
                            if (d.Dob > DateTime.Now.AddYears(-23)) { driverQuoteMultiplier *= 1.10m; }
                            if (d.LicenseDateStart > DateTime.Now.AddYears(-3)) { lessThan3years = true; }
                            driverBase *= driverQuoteMultiplier;
                            driverCost += driverBase;
                            policyBase += driverCost;
                            driverCostFinal.Add(driverCost);
                            driverId.Add(d.Id);

                        }
                        foreach (var v in vehicles)
                        {
                            baseVehicleCost = 0;
                            vehicleCost = 0;
                            baseVehicleCost += v.CurrentValue * .03m;
                            if (v.HasDaytimeRunningLights) { VehicleQuoteMultiplier *= .99m; }
                            if (v.HasAntilockBrakingSystem) { VehicleQuoteMultiplier *= .98m; }
                            if (v.AnnualMiles < 6000) { VehicleQuoteMultiplier *= .98m; }
                            if (v.PassiveRestraints) { VehicleQuoteMultiplier *= .97m; }
                            if (v.AntiTheft) { VehicleQuoteMultiplier *= .97m; }
                            if (v.DaysDrivenPerWeek > 4) { VehicleQuoteMultiplier *= 1.02m; }
                            if (v.MilesDrivenToWork <= 25) { VehicleQuoteMultiplier *= .98m; }
                            if (v.ReduceUse) { VehicleQuoteMultiplier *= .94m; }
                            if (v.GarageDifferent) { VehicleQuoteMultiplier *= 1.03m; }
                            baseVehicleCost *= VehicleQuoteMultiplier;
                            vehicleCost += baseVehicleCost;
                            policyBase += vehicleCost;
                            vehicleCostFinal.Add(vehicleCost);
                            vehicleId.Add(v.Id);
                        }

                        if (lessThan3years) { currentQuoteMultiplier *= 1.15m; }

                        if (quote.ClaimInLastFive) { currentQuoteMultiplier *= 1.20m; }
                        if (quote.ForceMultiDiscount) { currentQuoteMultiplier *= .95m; }

                        if (quote.MovingViolation) { currentQuoteMultiplier *= 1.20m; }

                        if (quote.PreviousCarrier == "Lizard Insurance") { currentQuoteMultiplier *= 1.05m; }
                        if (quote.PreviousCarrier == "Pervasive Insurance") { currentQuoteMultiplier *= .97m; }
                        policyBase *= currentQuoteMultiplier;
                        break;
                    }
                case "ME":
                    {
                        foreach (var d in drivers)
                        {

                            driverCost = 0;
                            driverBase += 200;

                            if (d.SafeDrivingSchool)
                            {
                                driverQuoteMultiplier *= .95m;
                            }
                            if (d.Dob > DateTime.Now.AddYears(-23)) { driverQuoteMultiplier *= 1.10m; }
                            if (d.LicenseDateStart > DateTime.Now.AddYears(-3)) { lessThan3years = true; }
                            driverBase *= driverQuoteMultiplier;
                            driverCost += driverBase;
                            policyBase += driverCost;
                            driverCostFinal.Add(driverCost);
                            driverId.Add(d.Id);
                        }
                        foreach (var v in vehicles)
                        {
                            baseVehicleCost = 0;
                            vehicleCost = 0;
                            baseVehicleCost += v.CurrentValue * .03m;
                            if (v.HasDaytimeRunningLights) { VehicleQuoteMultiplier *= .99m; }
                            if (v.HasAntilockBrakingSystem) { VehicleQuoteMultiplier *= .99m; }
                            if (v.AnnualMiles < 6000) { VehicleQuoteMultiplier *= .99m; }
                            if (v.PassiveRestraints) { VehicleQuoteMultiplier *= .97m; }
                            if (v.AntiTheft) { VehicleQuoteMultiplier *= .97m; }
                            if (v.DaysDrivenPerWeek > 4) { VehicleQuoteMultiplier *= 1.02m; }
                            if (v.MilesDrivenToWork <= 25) { VehicleQuoteMultiplier *= .98m; }
                            if (v.ReduceUse) { VehicleQuoteMultiplier *= .94m; }
                            if (v.GarageDifferent) { VehicleQuoteMultiplier *= 1.03m; }
                            baseVehicleCost *= VehicleQuoteMultiplier;
                            vehicleCost += baseVehicleCost;
                            policyBase += vehicleCost;
                            vehicleCostFinal.Add(vehicleCost);
                            vehicleId.Add(v.Id);
                        }


                        if (quote.ClaimInLastFive) { currentQuoteMultiplier *= 1.20m; }
                        if (lessThan3years) { currentQuoteMultiplier *= 1.15m; }
                        if (quote.ForceMultiDiscount) { currentQuoteMultiplier *= .95m; }

                        if (quote.MovingViolation) { currentQuoteMultiplier *= 1.23m; }
                        if (quote.PreviousCarrier == "Lizard Insurance") { currentQuoteMultiplier *= 1.05m; }
                        if (quote.PreviousCarrier == "Pervasive Insurance") { currentQuoteMultiplier *= .97m; }
                        policyBase *= currentQuoteMultiplier;
                        break;
                    }
                case "MA":
                    {
                        foreach (var d in drivers)
                        {

                            driverCost = 0;
                            driverBase += 200;

                            if (d.SafeDrivingSchool)
                            {
                                driverQuoteMultiplier *= .94m;
                            }
                            if (d.Dob > DateTime.Now.AddYears(-23)) { driverQuoteMultiplier *= 1.10m; }
                            if (d.LicenseDateStart > DateTime.Now.AddYears(-3)) { lessThan3years = true; }
                            driverBase *= driverQuoteMultiplier;
                            driverCost += driverBase;
                            policyBase += driverCost;
                            driverCostFinal.Add(driverCost);
                            driverId.Add(d.Id);
                        }
                        foreach (var v in vehicles)
                        {
                            baseVehicleCost = 0;
                            vehicleCost = 0;
                            baseVehicleCost += v.CurrentValue * .03m;
                            if (v.HasDaytimeRunningLights) { VehicleQuoteMultiplier *= .98m; }
                            if (v.HasAntilockBrakingSystem) { VehicleQuoteMultiplier *= .98m; }
                            if (v.AnnualMiles < 6000) { VehicleQuoteMultiplier *= .99m; }
                            if (v.PassiveRestraints) { VehicleQuoteMultiplier *= .97m; }
                            if (v.AntiTheft) { VehicleQuoteMultiplier *= .95m; }
                            if (v.DaysDrivenPerWeek > 4) { VehicleQuoteMultiplier *= 1.02m; }
                            if (v.MilesDrivenToWork <= 25) { VehicleQuoteMultiplier *= .99m; }
                            if (v.ReduceUse) { VehicleQuoteMultiplier *= .96m; }
                            if (v.GarageDifferent) { VehicleQuoteMultiplier *= 1.03m; }
                            baseVehicleCost *= VehicleQuoteMultiplier;
                            vehicleCost += baseVehicleCost;
                            policyBase += vehicleCost;
                            vehicleCostFinal.Add(vehicleCost);
                            vehicleId.Add(v.Id);
                        }

                        if (quote.ClaimInLastFive) { currentQuoteMultiplier *= 1.25m; }
                        if (lessThan3years) { currentQuoteMultiplier *= 1.20m; }
                        //if (quote.) { currentQuoteMultiplier *= .95m; }

                        if (quote.MovingViolation) { currentQuoteMultiplier *= 1.25m; }
                        if (quote.PreviousCarrier == "Lizard Insurance") { currentQuoteMultiplier *= 1.05m; }
                        if (quote.PreviousCarrier == "Pervasive Insurance") { currentQuoteMultiplier *= .97m; }
                        policyBase *= currentQuoteMultiplier;
                        break;
                    }
                case "NH":
                    {
                        foreach (var d in drivers)
                        {

                            driverCost = 0;
                            driverBase += 200;

                            if (d.SafeDrivingSchool)
                            {
                                driverQuoteMultiplier *= .95m;
                            }
                            if (d.Dob > DateTime.Now.AddYears(-23)) { driverQuoteMultiplier *= 1.10m; }
                            if (d.LicenseDateStart > DateTime.Now.AddYears(-3)) { lessThan3years = true; }
                            driverBase *= driverQuoteMultiplier;
                            driverCost += driverBase;
                            policyBase += driverCost;
                            driverCostFinal.Add(driverCost);
                            driverId.Add(d.Id);
                        }
                        foreach (var v in vehicles)
                        {
                            baseVehicleCost = 0;
                            vehicleCost = 0;
                            baseVehicleCost += v.CurrentValue * .03m;
                            if (v.HasDaytimeRunningLights) { VehicleQuoteMultiplier *= .99m; }
                            if (v.HasAntilockBrakingSystem) { VehicleQuoteMultiplier *= .98m; }
                            if (v.AnnualMiles < 6000) { VehicleQuoteMultiplier *= .99m; }
                            if (v.PassiveRestraints) { VehicleQuoteMultiplier *= .97m; }
                            if (v.AntiTheft) { VehicleQuoteMultiplier *= .97m; }
                            if (v.DaysDrivenPerWeek > 4) { VehicleQuoteMultiplier *= 1.02m; }
                            if (v.MilesDrivenToWork <= 25) { VehicleQuoteMultiplier *= .98m; }
                            if (v.ReduceUse) { VehicleQuoteMultiplier *= .94m; }
                            if (v.GarageDifferent) { VehicleQuoteMultiplier *= 1.03m; }
                            baseVehicleCost *= VehicleQuoteMultiplier;
                            vehicleCost += baseVehicleCost;
                            policyBase += vehicleCost;
                            vehicleCostFinal.Add(vehicleCost);
                            vehicleId.Add(v.Id);
                        }

                        if (quote.ClaimInLastFive) { currentQuoteMultiplier *= 1.20m; }
                        if (lessThan3years) { currentQuoteMultiplier *= 1.15m; }
                        if (quote.ForceMultiDiscount) { currentQuoteMultiplier *= .95m; }

                        if (quote.MovingViolation) { currentQuoteMultiplier *= 1.20m; }
                        if (quote.PreviousCarrier == "Lizard Insurance") { currentQuoteMultiplier *= 1.05m; }
                        if (quote.PreviousCarrier == "Pervasive Insurance") { currentQuoteMultiplier *= .97m; }
                        policyBase *= currentQuoteMultiplier;
                        break;
                    }
                case "CT":
                    {
                        foreach (var d in drivers)
                        {

                            driverCost = 0;
                            driverBase += 200;

                            if (d.SafeDrivingSchool)
                            {
                                driverQuoteMultiplier *= .95m;
                            }
                            if (d.Dob > DateTime.Now.AddYears(-23)) { driverQuoteMultiplier *= 1.10m; }
                            if (d.LicenseDateStart > DateTime.Now.AddYears(-3)) { lessThan3years = true; }
                            driverBase *= driverQuoteMultiplier;
                            driverCost += driverBase;
                            policyBase += driverCost;
                            driverCostFinal.Add(driverCost);
                            driverId.Add(d.Id);
                        }
                        foreach (var v in vehicles)
                        {
                            baseVehicleCost = 0;
                            vehicleCost = 0;
                            baseVehicleCost += v.CurrentValue * .03m;
                            if (v.HasDaytimeRunningLights) { VehicleQuoteMultiplier *= .99m; }
                            if (v.HasAntilockBrakingSystem) { VehicleQuoteMultiplier *= .97m; }
                            if (v.AnnualMiles < 6000) { VehicleQuoteMultiplier *= .99m; }
                            if (v.PassiveRestraints) { VehicleQuoteMultiplier *= .97m; }
                            if (v.AntiTheft) { VehicleQuoteMultiplier *= .97m; }
                            if (v.DaysDrivenPerWeek > 4) { VehicleQuoteMultiplier *= 1.02m; }
                            if (v.MilesDrivenToWork <= 25) { VehicleQuoteMultiplier *= .98m; }
                            if (v.ReduceUse) { VehicleQuoteMultiplier *= .94m; }
                            if (v.GarageDifferent) { VehicleQuoteMultiplier *= 1.03m; }
                            baseVehicleCost *= VehicleQuoteMultiplier;
                            vehicleCost += baseVehicleCost;
                            policyBase += vehicleCost;
                            vehicleCostFinal.Add(vehicleCost);
                            vehicleId.Add(v.Id);
                        }

                        if (quote.ClaimInLastFive) { currentQuoteMultiplier *= 1.20m; }
                        if (lessThan3years) { currentQuoteMultiplier *= 1.15m; }
                        if (quote.ForceMultiDiscount) { currentQuoteMultiplier *= .95m; }

                        if (quote.MovingViolation) { currentQuoteMultiplier *= 1.20m; }
                        if (quote.PreviousCarrier == "Lizard Insurance") { currentQuoteMultiplier *= 1.05m; }
                        if (quote.PreviousCarrier == "Pervasive Insurance") { currentQuoteMultiplier *= .97m; }
                        policyBase *= currentQuoteMultiplier;
                        break;
                    }
                case "PA":
                    {
                        foreach (var d in drivers)
                        {

                            driverCost = 0;
                            driverBase += 200;

                            if (d.SafeDrivingSchool)
                            {
                                driverQuoteMultiplier *= .95m;
                            }
                            if (d.Dob > DateTime.Now.AddYears(-23)) { driverQuoteMultiplier *= 1.10m; }
                            if (d.LicenseDateStart > DateTime.Now.AddYears(-3)) { lessThan3years = true; }
                            driverBase *= driverQuoteMultiplier;
                            driverCost += driverBase;
                            policyBase += driverCost;
                            driverCostFinal.Add(driverCost);
                            driverId.Add(d.Id);
                        }
                        foreach (var v in vehicles)
                        {
                            baseVehicleCost = 0;
                            vehicleCost = 0;
                            baseVehicleCost += v.CurrentValue * .03m;
                            if (v.HasDaytimeRunningLights) { VehicleQuoteMultiplier *= .99m; }
                            if (v.HasAntilockBrakingSystem) { VehicleQuoteMultiplier *= .98m; }
                            if (v.AnnualMiles < 6000) { VehicleQuoteMultiplier *= .99m; }
                            if (v.PassiveRestraints) { VehicleQuoteMultiplier *= .97m; }
                            if (v.AntiTheft) { VehicleQuoteMultiplier *= .97m; }
                            if (v.DaysDrivenPerWeek > 4) { VehicleQuoteMultiplier *= 1.02m; }
                            if (v.MilesDrivenToWork <= 25) { VehicleQuoteMultiplier *= .98m; }
                            if (v.ReduceUse) { VehicleQuoteMultiplier *= .94m; }
                            if (v.GarageDifferent) { VehicleQuoteMultiplier *= 1.03m; }
                            baseVehicleCost *= VehicleQuoteMultiplier;
                            vehicleCost += baseVehicleCost;
                            policyBase += vehicleCost;
                            vehicleCostFinal.Add(vehicleCost);
                            vehicleId.Add(v.Id);
                        }

                        if (quote.ClaimInLastFive) { currentQuoteMultiplier *= 1.20m; }
                        if (lessThan3years) { currentQuoteMultiplier *= 1.15m; }
                        if (quote.ForceMultiDiscount) { currentQuoteMultiplier *= .95m; }

                        if (quote.MovingViolation) { currentQuoteMultiplier *= 1.20m; }
                        if (quote.PreviousCarrier == "Lizard Insurance") { currentQuoteMultiplier *= 1.05m; }
                        if (quote.PreviousCarrier == "Pervasive Insurance") { currentQuoteMultiplier *= .97m; }
                        policyBase *= currentQuoteMultiplier;
                        break;
                    }
                case "NY":
                    {
                        foreach (var d in drivers)
                        {

                            driverCost = 0;
                            driverBase += 200;

                            if (d.SafeDrivingSchool)
                            {
                                driverQuoteMultiplier *= .94m;
                            }
                            if (d.Dob > DateTime.Now.AddYears(-23)) { driverQuoteMultiplier *= 1.10m; }
                            if (d.LicenseDateStart > DateTime.Now.AddYears(-3)) { lessThan3years = true; }
                            driverBase *= driverQuoteMultiplier;
                            driverCost += driverBase;
                            policyBase += driverCost;
                            driverCostFinal.Add(driverCost);
                            driverId.Add(d.Id);
                        }
                        foreach (var v in vehicles)
                        {
                            baseVehicleCost = 0;
                            vehicleCost = 0;
                            baseVehicleCost += v.CurrentValue * .03m;
                            if (v.HasDaytimeRunningLights) { VehicleQuoteMultiplier *= .99m; }
                            if (v.HasAntilockBrakingSystem) { VehicleQuoteMultiplier *= .97m; }
                            if (v.AnnualMiles < 6000) { VehicleQuoteMultiplier *= .99m; }
                            if (v.PassiveRestraints) { VehicleQuoteMultiplier *= .97m; }
                            if (v.AntiTheft) { VehicleQuoteMultiplier *= .94m; }
                            if (v.DaysDrivenPerWeek > 4) { VehicleQuoteMultiplier *= 1.02m; }
                            if (v.MilesDrivenToWork <= 25) { VehicleQuoteMultiplier *= .99m; }
                            if (v.ReduceUse) { VehicleQuoteMultiplier *= 1m; }
                            if (v.GarageDifferent) { VehicleQuoteMultiplier *= 1.03m; }
                            baseVehicleCost *= VehicleQuoteMultiplier;
                            vehicleCost += baseVehicleCost;
                            policyBase += vehicleCost;
                            vehicleCostFinal.Add(vehicleCost);
                            vehicleId.Add(v.Id);
                        }

                        if (quote.ClaimInLastFive) { currentQuoteMultiplier *= 1.30m; }
                        if (lessThan3years) { currentQuoteMultiplier *= 1.22m; }
                        if (quote.ForceMultiDiscount) { currentQuoteMultiplier *= 1m; }

                        if (quote.MovingViolation) { currentQuoteMultiplier *= 1.30m; }
                        if (quote.PreviousCarrier == "Lizard Insurance") { currentQuoteMultiplier *= 1.05m; }
                        if (quote.PreviousCarrier == "Pervasive Insurance") { currentQuoteMultiplier *= 1m; }
                        policyBase *= currentQuoteMultiplier;
                        break;
                    }
                case "SC":
                    {
                        foreach (var d in drivers)
                        {

                            driverCost = 0;
                            driverBase += 200;

                            if (d.SafeDrivingSchool)
                            {
                                driverQuoteMultiplier *= .93m;
                            }
                            if (d.Dob > DateTime.Now.AddYears(-23)) { driverQuoteMultiplier *= 1.10m; }
                            if (d.LicenseDateStart > DateTime.Now.AddYears(-3)) { lessThan3years = true; }
                            driverBase *= driverQuoteMultiplier;
                            driverCost += driverBase;
                            policyBase += driverCost;
                            driverCostFinal.Add(driverCost);
                            driverId.Add(d.Id);
                        }
                        foreach (var v in vehicles)
                        {
                            baseVehicleCost = 0;
                            vehicleCost = 0;
                            baseVehicleCost += v.CurrentValue * .03m;
                            if (v.HasDaytimeRunningLights) { VehicleQuoteMultiplier *= .98m; }
                            if (v.HasAntilockBrakingSystem) { VehicleQuoteMultiplier *= .98m; }
                            if (v.AnnualMiles < 6000) { VehicleQuoteMultiplier *= 1m; }
                            if (v.PassiveRestraints) { VehicleQuoteMultiplier *= .98m; }
                            if (v.AntiTheft) { VehicleQuoteMultiplier *= .97m; }
                            if (v.DaysDrivenPerWeek > 4) { VehicleQuoteMultiplier *= 1.02m; }
                            if (v.MilesDrivenToWork <= 25) { VehicleQuoteMultiplier *= .99m; }
                            if (v.ReduceUse) { VehicleQuoteMultiplier *= .96m; }
                            if (v.GarageDifferent) { VehicleQuoteMultiplier *= 1.03m; }
                            baseVehicleCost *= VehicleQuoteMultiplier;
                            vehicleCost += baseVehicleCost;
                            policyBase += vehicleCost;
                            vehicleCostFinal.Add(vehicleCost);
                            vehicleId.Add(v.Id);
                        }

                        if (quote.ClaimInLastFive) { currentQuoteMultiplier *= 1.22m; }
                        if (lessThan3years) { currentQuoteMultiplier *= 1.18m; }
                        if (quote.ForceMultiDiscount) { currentQuoteMultiplier *= 1m; }

                        if (quote.MovingViolation) { currentQuoteMultiplier *= 1.15m; }
                        if (quote.PreviousCarrier == "Lizard Insurance") { currentQuoteMultiplier *= 1m; }
                        if (quote.PreviousCarrier == "Pervasive Insurance") { currentQuoteMultiplier *= 1m; }
                        policyBase *= currentQuoteMultiplier;
                        break;
                    }
                case "WV":
                    {
                        foreach (var d in drivers)
                        {

                            driverCost = 0;
                            driverBase += 200;

                            if (d.SafeDrivingSchool)
                            {
                                driverQuoteMultiplier *= .95m;
                            }
                            if (d.Dob > DateTime.Now.AddYears(-23)) { driverQuoteMultiplier *= 1.10m; }
                            if (d.LicenseDateStart > DateTime.Now.AddYears(-3)) { lessThan3years = true; }
                            driverBase *= driverQuoteMultiplier;
                            driverCost += driverBase;
                            policyBase += driverCost;
                            driverCostFinal.Add(driverCost);
                            driverId.Add(d.Id);
                        }
                        foreach (var v in vehicles)
                        {
                            baseVehicleCost = 0;
                            vehicleCost = 0;
                            baseVehicleCost += v.CurrentValue * .03m;
                            if (v.HasDaytimeRunningLights) { VehicleQuoteMultiplier *= .99m; }
                            if (v.HasAntilockBrakingSystem) { VehicleQuoteMultiplier *= .98m; }
                            if (v.AnnualMiles < 6000) { VehicleQuoteMultiplier *= .99m; }
                            if (v.PassiveRestraints) { VehicleQuoteMultiplier *= .97m; }
                            if (v.AntiTheft) { VehicleQuoteMultiplier *= .97m; }
                            if (v.DaysDrivenPerWeek > 4) { VehicleQuoteMultiplier *= 1.02m; }
                            if (v.MilesDrivenToWork <= 25) { VehicleQuoteMultiplier *= .98m; }
                            if (v.ReduceUse) { VehicleQuoteMultiplier *= .94m; }
                            if (v.GarageDifferent) { VehicleQuoteMultiplier *= 1.03m; }
                            baseVehicleCost *= VehicleQuoteMultiplier;
                            vehicleCost += baseVehicleCost;
                            policyBase += vehicleCost;
                            vehicleCostFinal.Add(vehicleCost);
                            vehicleId.Add(v.Id);
                        }

                        if (quote.ClaimInLastFive) { currentQuoteMultiplier *= 1.18m; }
                        if (lessThan3years) { currentQuoteMultiplier *= 1.15m; }
                        if (quote.ForceMultiDiscount) { currentQuoteMultiplier *= 1m; }

                        if (quote.MovingViolation) { currentQuoteMultiplier *= 1.20m; }
                        if (quote.PreviousCarrier == "Lizard Insurance") { currentQuoteMultiplier *= 1.05m; }
                        if (quote.PreviousCarrier == "Pervasive Insurance") { currentQuoteMultiplier *= .97m; }
                        policyBase *= currentQuoteMultiplier;
                        break;
                    }
                case "VA":
                    {
                        foreach (var d in drivers)
                        {

                            driverCost = 0;
                            driverBase += 200;

                            if (d.SafeDrivingSchool)
                            {
                                driverQuoteMultiplier *= .95m;
                            }
                            if (d.Dob > DateTime.Now.AddYears(-23)) { driverQuoteMultiplier *= 1.10m; }
                            if (d.LicenseDateStart > DateTime.Now.AddYears(-3)) { lessThan3years = true; }
                            driverBase *= driverQuoteMultiplier;
                            driverCost += driverBase;
                            policyBase += driverCost;
                            driverCostFinal.Add(driverCost);
                            driverId.Add(d.Id);
                        }
                        foreach (var v in vehicles)
                        {
                            baseVehicleCost = 0;
                            vehicleCost = 0;
                            baseVehicleCost += v.CurrentValue * .03m;
                            if (v.HasDaytimeRunningLights) { VehicleQuoteMultiplier *= .99m; }
                            if (v.HasAntilockBrakingSystem) { VehicleQuoteMultiplier *= .98m; }
                            if (v.AnnualMiles < 6000) { VehicleQuoteMultiplier *= .99m; }
                            if (v.PassiveRestraints) { VehicleQuoteMultiplier *= .97m; }
                            if (v.AntiTheft) { VehicleQuoteMultiplier *= .97m; }
                            if (v.DaysDrivenPerWeek > 4) { VehicleQuoteMultiplier *= 1.02m; }
                            if (v.MilesDrivenToWork <= 25) { VehicleQuoteMultiplier *= .98m; }
                            if (v.ReduceUse) { VehicleQuoteMultiplier *= .94m; }
                            if (v.GarageDifferent) { VehicleQuoteMultiplier *= 1.03m; }
                            baseVehicleCost *= VehicleQuoteMultiplier;
                            vehicleCost += baseVehicleCost;
                            policyBase += vehicleCost;
                            vehicleCostFinal.Add(vehicleCost);
                            vehicleId.Add(v.Id);
                        }

                        if (quote.ClaimInLastFive) { currentQuoteMultiplier *= 1.20m; }
                        if (lessThan3years) { currentQuoteMultiplier *= 1.15m; }
                        if (quote.ForceMultiDiscount) { currentQuoteMultiplier *= 1m; }

                        if (quote.MovingViolation) { currentQuoteMultiplier *= 1.20m; }
                        if (quote.PreviousCarrier == "Lizard Insurance") { currentQuoteMultiplier *= 1.05m; }
                        if (quote.PreviousCarrier == "Pervasive Insurance") { currentQuoteMultiplier *= .97m; }
                        policyBase *= currentQuoteMultiplier;
                        break;
                    }
                default:
                    {
                        // policyBase = 0;
                        throw new Exception("Invalid Information");

                    }



            }

            return policyBase;
        }


        public static List<decimal> driverCost()
        {
            return driverCostFinal;
        }
        public List<decimal> vehicleCost()
        {
            return vehicleCostFinal;
        }

        public static List<long> driversId()
        {
            return driverId;
        }
        public static List<long> vehiclesId()
        {
            return vehicleId;
        }
    }
    
    
}
