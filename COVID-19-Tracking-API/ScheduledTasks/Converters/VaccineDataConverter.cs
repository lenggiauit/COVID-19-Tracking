using C19Tracking.Domain.Models.Entities;
using C19Tracking.ScheduledTasks.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.ScheduledTasks.Converters
{
    public class VaccineDataConverter : IConverter
    {
        private dynamic _jsonObject;
        public VaccineDataConverter(dynamic jsonObject)
        {
            _jsonObject = jsonObject;
        }
        public string Convert()
        {
            if (_jsonObject != null)
            {
                List<VaccineData> list = new List<VaccineData>();

                foreach (var item in _jsonObject["data"])
                {
                    try
                    {

                        VaccineData vaccineData = new VaccineData();
                        vaccineData.CountryName = item["REPORT_COUNTRY"].ToString();
                        vaccineData.ISO3 = item["ISO3"].ToString();
                        vaccineData.RegionCode = item["WHO_REGION"].ToString();
                        vaccineData.DateUpdated = item["DATE_UPDATED"];
                        vaccineData.PersonFullyVaccinated = item["PERSONS_FULLY_VACCINATED"] != null ? item["PERSONS_FULLY_VACCINATED"] : 0;
                        vaccineData.PersonVaccinated1PlusDose = item["PERSONS_VACCINATED_1PLUS_DOSE"] != null ? item["PERSONS_VACCINATED_1PLUS_DOSE"] : 0;
                        vaccineData.PersonVaccinated1PlusDosePer100 = item["PERSONS_VACCINATED_1PLUS_DOSE_PER100"] != null ? item["PERSONS_VACCINATED_1PLUS_DOSE_PER100"] : 0;
                        vaccineData.PersonFullyVaccinatedPer100 = item["PERSONS_FULLY_VACCINATED_PER100"] != null ? item["PERSONS_FULLY_VACCINATED_PER100"] : 0;
                        vaccineData.VaccinesUsed = item["VACCINES_USED"] != null ? item["VACCINES_USED"] : string.Empty;
                        vaccineData.TotalVaccinations = item["TOTAL_VACCINATIONS"] != null ? item["TOTAL_VACCINATIONS"] : 0;
                        list.Add(vaccineData);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    } 

                }
                return JsonConvert.SerializeObject(list);


            }
            else
            {
                return string.Empty;
            }
        }
    }
}
