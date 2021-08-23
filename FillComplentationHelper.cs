using AngleSharp.Dom;
using ilcatsParser.Ef;
using ilcatsParser.Ef.Models;
using ilcatsParser.Ef.Models.ComplectationFields;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ilcatsParser
{
    static class FillComplentationHelper
    {
        private static AppDbContext db = new AppDbContext();

        public static async Task FillComplectationAsync(string field, int indexOfTdElement,
            ComplectationModel[] complectationModels, IHtmlCollection<IElement> complectationElements)
        {
            List<string> fieldValues = FillTheFields(complectationElements, indexOfTdElement);

            switch (field)
            {
                case "Complectation":
                    for (int i = 0; i < complectationModels.Length; i++)
                    {
                        complectationModels[i].Complectation = fieldValues[i];
                        complectationModels[i].GroupUrl = GetGroupsUrl(complectationElements)[i];
                    }
                    break;

                case "Date":
                    for (int i = 0; i < complectationModels.Length; i++)
                        complectationModels[i].Date = fieldValues[i];
                    break;

                case "ENGINE 1":
                    List<Engine> engines = await AddComplectationFieldToDbAsync<Engine>(fieldValues);

                    for (int i = 0; i < complectationModels.Length; i++)
                    {
                        int engineId = engines.Where(t => t.Value == fieldValues[i]).Select(t => t.Id).FirstOrDefault();
                        complectationModels[i].EngineId = engineId == 0 ?
                            await db.Engines.Where(t => t.Value == fieldValues[i]).Select(t => t.Id).FirstOrDefaultAsync() : engineId;
                    }
                    break;

                case "BODY":
                    List<Body> bodies = await AddComplectationFieldToDbAsync<Body>(fieldValues);

                    for (int i = 0; i < complectationModels.Length; i++)
                    {
                        int bodyId = bodies.Where(t => t.Value == fieldValues[i]).Select(t => t.Id).FirstOrDefault();

                        complectationModels[i].BodyId = bodyId == 0 ?
                            await db.Bodies.Where(t => t.Value == fieldValues[i]).Select(t => t.Id).FirstOrDefaultAsync() : bodyId;
                    }

                    break;

                case "GRADE":
                    List<Grade> grades = await AddComplectationFieldToDbAsync<Grade>(fieldValues);

                    for (int i = 0; i < complectationModels.Length; i++)
                    {
                        int gradeId = grades.Where(t => t.Value == fieldValues[i]).Select(t => t.Id).FirstOrDefault();

                        complectationModels[i].GradeId = gradeId == 0 ?
                            await db.Grades.Where(t => t.Value == fieldValues[i]).Select(t => t.Id).FirstOrDefaultAsync() : gradeId;
                    }
                    break;

                case "ATM,MTM":
                    List<ATMOrMTM> ATMOrMTMs = await AddComplectationFieldToDbAsync<ATMOrMTM>(fieldValues);

                    for (int i = 0; i < complectationModels.Length; i++)
                    {
                        int ATMOrMTMId = ATMOrMTMs.Where(t => t.Value == fieldValues[i]).Select(t => t.Id).FirstOrDefault();

                        complectationModels[i].ATMOrMTMId = ATMOrMTMId == 0 ?
                            await db.ATMOrMTMs.Where(t => t.Value == fieldValues[i]).Select(t => t.Id).FirstOrDefaultAsync() : ATMOrMTMId;
                    }
                    break;

                case "GEAR SHIFT TYPE":
                    List<GearShiftType> gearShiftTypes = await AddComplectationFieldToDbAsync<GearShiftType>(fieldValues);

                    for (int i = 0; i < complectationModels.Length; i++)
                    {
                        int gearShiftTypeId = gearShiftTypes.Where(t => t.Value == fieldValues[i]).Select(t => t.Id).FirstOrDefault();

                        complectationModels[i].GearShiftTypeId = gearShiftTypeId == 0 ?
                            await db.GearShiftTypes.Where(t => t.Value == fieldValues[i]).Select(t => t.Id).FirstOrDefaultAsync() : gearShiftTypeId;
                    }
                    break;

                case "DRIVER'S POSITION":
                    List<DriversPosition> driversPositions = await AddComplectationFieldToDbAsync<DriversPosition>(fieldValues);

                    for (int i = 0; i < complectationModels.Length; i++)
                    {
                        int driversPositionId = driversPositions.Where(t => t.Value == fieldValues[i]).Select(t => t.Id).FirstOrDefault();

                        complectationModels[i].DriversPositionId = driversPositionId == 0 ?
                            await db.DriversPositions.Where(t => t.Value == fieldValues[i]).Select(t => t.Id).FirstOrDefaultAsync() : driversPositionId;
                    }
                    break;

                case "NO.OF DOORS":
                    List<NoOfDoors> ofDoors = await AddComplectationFieldToDbAsync<NoOfDoors>(fieldValues);

                    for (int i = 0; i < complectationModels.Length; i++)
                    {
                        int noOfDoorsId = ofDoors.Where(t => t.Value == fieldValues[i]).Select(t => t.Id).FirstOrDefault();

                        complectationModels[i].NoOfDoorsId = noOfDoorsId == 0 ?
                            await db.NoOfDoors.Where(t => t.Value == fieldValues[i]).Select(t => t.Id).FirstOrDefaultAsync() : noOfDoorsId;
                    }
                    break;
                case "DESTINATION 1":
                    List<Destination> destinations = await AddComplectationFieldToDbAsync<Destination>(fieldValues);

                    for (int i = 0; i < complectationModels.Length; i++)
                    {
                        int destinationId = destinations.Where(t => t.Value == fieldValues[i]).Select(t => t.Id).FirstOrDefault();

                        complectationModels[i].DestinationId = destinationId == 0 ?
                            await db.Destinations.Where(t => t.Value == fieldValues[i]).Select(t => t.Id).FirstOrDefaultAsync() : destinationId;
                    }
                    break;
            }
        }

        private static async Task<List<T>> AddComplectationFieldToDbAsync<T>(List<string> values) where T : DefaultComplectationsField, new()
        {
            List<T> complectationFields = new List<T>();

            foreach (var value in values.Distinct())
                complectationFields.Add(new T() { Value = value });
            foreach (var item in complectationFields)
            {
                using (AppDbContext context = new AppDbContext())
                {
                    context.Entry(item).State = EntityState.Added;
                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        //try catch needed to catch an exception when adding existing data
                    }
                }
            }
            return complectationFields;
        }

        private static List<string> FillTheFields(IHtmlCollection<IElement> trElements, int indexOfTdElement)
        {
            List<string> result = new List<string>();
            foreach (var complectation in trElements)
            {
                if (complectation != trElements.FirstOrDefault())
                    result.Add(complectation.Children[indexOfTdElement].TextContent);
            }
            return result;
        }

        private static List<string> GetGroupsUrl(IHtmlCollection<IElement> trElements)
        {
            List<string> result = new List<string>();
            foreach (var complectation in trElements)
            {
                if (complectation != trElements.FirstOrDefault())
                    result.Add(complectation.FirstElementChild.FirstElementChild.FirstElementChild.GetAttribute("href"));
            }
            return result;
        }
    }
}
