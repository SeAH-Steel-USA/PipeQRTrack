using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PipeQRTrack.Data;

namespace PipeQRTrack.Services
{
    public class DataService
    {

        private readonly AzureDbContext _azureDb;
        private readonly LocalDbContext _localDb;

        public DataService(AzureDbContext azureDb, LocalDbContext localDb)
        {
            _azureDb = azureDb;
            _localDb = localDb;
        }
        public async Task<string> UpdatePipeDetailP1TLC1WithValAsync()
        {
            try
            {
                var unprocessedValues = await _localDb.FloatTableP1TLC1
                    .Where(f => f.Reference == null && f.TagIndex == 0)
                    .OrderBy(f => f.DateAndTime)
                    .ToListAsync();

                if (!unprocessedValues.Any())
                {
                    return "No updates needed.";
                }

                int updatesCount = 0;

                foreach (var floatValue in unprocessedValues)
                {
                    var pipeDetail = await _azureDb.PipeDetailP1TLC1
                        .Where(p => p.Val == null && p.Status == null)
                        .OrderBy(p => p.DateTime)
                        .FirstOrDefaultAsync();

                    if (pipeDetail != null)
                    {
                        pipeDetail.Val = floatValue.Val;
                        pipeDetail.Status = '1'; // Processed
                        await _azureDb.SaveChangesAsync();

                        // add it to complete table

                        var completeDetail = new PipeDetailComplete
                        {
                            // Map properties from pipeDetail to completeDetail
                            // Adjust these according to your PipeDetailComplete model
                       
                            LotNumber = pipeDetail.LotNumber,
                            JointNumber = pipeDetail.JointNumber,
                            JobNumber = pipeDetail.JobNumber,
                            HeatNumber = pipeDetail.HeatNumber,
                            Millitm = pipeDetail.Millitm,
                            Marker = pipeDetail.Marker,
                            DateTime = pipeDetail.DateTime,
                            Val = pipeDetail.Val,
                            Status = pipeDetail.Status,

     
                        };

                        // Add the new entry to PipeDetailComplete table
                        _azureDb.PipeDetailComplete.Add(completeDetail);
                        await _azureDb.SaveChangesAsync();

                        updatesCount++;
                    }
                    else
                    {
                        // No more unprocessed pipe details
                        break;
                    }
                }

                // Bulk update Reference in FloatTableP1TLC2
                if (updatesCount > 0)
                {
                    var dateTimeList = unprocessedValues.Take(updatesCount).Select(v => v.DateAndTime).ToList();
                    var oldestDateTime = dateTimeList.Min();
                    var newestDateTime = dateTimeList.Max();

                    await _localDb.Database.ExecuteSqlRawAsync(
                        "UPDATE FloatTableP1TLC1 SET Reference = '1' WHERE Reference IS NULL AND TagIndex = 0 AND DateAndTime BETWEEN {0} AND {1}",
                        oldestDateTime, newestDateTime);
                }

                if (updatesCount > 0)
                {
                    return $"Successfully updated {updatesCount} records.";
                }
                else
                {
                    return "No updates were needed or possible.";
                }
            }
            catch (Exception ex)
            {

                return $"An error occurred: {ex.Message}";
            }
        }
        public async Task<string> UpdatePipeDetailP1TLC2WithValAsync()
        {
            try
            {
                var unprocessedValues = await _localDb.FloatTableP1TLC2
                    .Where(f => f.Reference == null && f.TagIndex == 0)
                    .OrderBy(f => f.DateAndTime)
                    .ToListAsync();

                if (!unprocessedValues.Any())
                {
                    return "No updates needed.";
                }

                int updatesCount = 0;

                foreach (var floatValue in unprocessedValues)
                {
                    var pipeDetail = await _azureDb.PipeDetailP1TLC2
                        .Where(p => p.Val == null && p.Status == null)
                        .OrderBy(p => p.DateTime)
                        .FirstOrDefaultAsync();

                    if (pipeDetail != null)
                    {
                        pipeDetail.Val = floatValue.Val;
                        pipeDetail.Status = '1'; // Processed
                        await _azureDb.SaveChangesAsync();

                        var completeDetail = new PipeDetailComplete
                        {
                            // Map properties from pipeDetail to completeDetail
                            // Adjust these according to your PipeDetailComplete model
                
                            LotNumber = pipeDetail.LotNumber,
                            JointNumber = pipeDetail.JointNumber,
                            JobNumber = pipeDetail.JobNumber,
                            HeatNumber = pipeDetail.HeatNumber,
                            Millitm = pipeDetail.Millitm,
                            Marker = pipeDetail.Marker,
                            DateTime = pipeDetail.DateTime,
                            Val = pipeDetail.Val,
                            Status = pipeDetail.Status,


                        };

                        // Add the new entry to PipeDetailComplete table
                        _azureDb.PipeDetailComplete.Add(completeDetail);
                        await _azureDb.SaveChangesAsync();
                        updatesCount++;
                    }
                    else
                    {
                        // No more unprocessed pipe details
                        break;
                    }
                }

                // Bulk update Reference in FloatTableP1TLC2
                if (updatesCount > 0)
                {
                    var dateTimeList = unprocessedValues.Take(updatesCount).Select(v => v.DateAndTime).ToList();
                    var oldestDateTime = dateTimeList.Min();
                    var newestDateTime = dateTimeList.Max();

                    await _localDb.Database.ExecuteSqlRawAsync(
                        "UPDATE FloatTableP1TLC2 SET Reference = '1' WHERE Reference IS NULL AND TagIndex = 0 AND DateAndTime BETWEEN {0} AND {1}",
                        oldestDateTime, newestDateTime);
                }

                if (updatesCount > 0)
                {
                    return $"Successfully updated {updatesCount} records.";
                }
                else
                {
                    return "No updates were needed or possible.";
                }
            }
            catch (Exception ex)
            {

                return $"An error occurred: {ex.Message}";
            }
        }
        /*
                public async Task UpdatePipeDetailsWithValAsync()
                {
                    var unprocessedValues = await _localDb.FloatTableP1TLC2
                        .Where(f => f.Reference == null && f.TagIndex == 0)
                        .OrderBy(f => f.DateAndTime)
                        .ToListAsync();

                    foreach (var floatValue in unprocessedValues)
                    {
                        var pipeDetail = await _azureDb.PipeDetails
                            .Where(p => p.Val == null && p.Status == null)
                            .OrderBy(p => p.DateTime)
                            .FirstOrDefaultAsync();

                        if (pipeDetail != null)
                        {
                            pipeDetail.Val = floatValue.Val;
                            pipeDetail.Status = '1'; // Processed
                            await _azureDb.SaveChangesAsync();

                            floatValue.Reference = '1';
                            await _localDb.SaveChangesAsync();
                        }
                        else
                        {
                            // No more unprocessed pipe details
                            break;
                        }
                    }
                }*/

    }
}
