using System.Net;
using DynemicSun.Models;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace DynemicSun.Services.ITranslateServices;
public class TranslateService : ITranslateService
{
    public async Task<List<Year>> FromExcelsToYears(IFormFileCollection collections)
    {
        List<Year> response = new List<Year>();
        foreach (var formFile in collections)
        {
            try
            {
                Year year = await FromExcelsToYear(formFile.OpenReadStream());
                response.Add(year);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        return response;
    }
    
    private async Task<Year> FromExcelsToYear(Stream collections)
    {
        List<Month> months = new List<Month>();
        XSSFWorkbook workbook = new(collections);
            foreach (var sheet in workbook)
            {
                ICell cell;
                List<WeatherMeasurement> measurements = new();
                for (int i = 4;; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row is null)
                        break;

                    cell = row.GetCell(0);
                    string measurmentDate = cell.StringCellValue;

                    cell = row.GetCell(1);
                    string measurmentTime = cell.StringCellValue;

                    cell = row.GetCell(2);
                    double temperature = cell.NumericCellValue;
                    
                    cell = row.GetCell(3);
                    int AirRelativeHumidity = (int)cell.NumericCellValue;
                    
                    cell = row.GetCell(4);
                    double DewPoint = cell.NumericCellValue;
                    
                    cell = row.GetCell(5);
                    int Pressure = (int)cell.NumericCellValue;
                    
                    cell = row.GetCell(6);
                    string AirDirection = cell.StringCellValue;

                    int? airPowe;
                    try
                    {
                        cell = row.GetCell(7);
                        airPowe = (int)cell.NumericCellValue;
                    }
                    catch (Exception ex)
                    {
                        string buff = cell.StringCellValue;
                        try
                        {
                            airPowe = int.Parse(buff);
                        }
                        catch (Exception e)
                        {
                            airPowe = null;
                        }
                    }

                    int? cloudCover;
                    try
                    {
                        cell = row.GetCell(8);
                        cloudCover = (int)cell.NumericCellValue;
                    }
                    catch (Exception ex)
                    {
                        string buff = cell.StringCellValue;
                        try
                        {
                            cloudCover = int.Parse(buff);
                        }
                        catch (Exception e)
                        {
                            cloudCover = null;
                        }
                    }
                    
                    
                    int? dawnCloudBorder;
                    try
                    {
                        cell = row.GetCell(9);
                        dawnCloudBorder = (int)cell.NumericCellValue;
                    }
                    catch (Exception ex)
                    {
                        string buff = cell.StringCellValue;
                        try
                        {
                            dawnCloudBorder = int.Parse(buff);
                        }
                        catch (Exception e)
                        {
                            dawnCloudBorder = null;
                        }
                    }
                    

                    double? VV;
                    try
                    {
                        cell = row.GetCell(10);
                        VV = cell.NumericCellValue;
                    }
                    catch (Exception ex)
                    {
                        string buff = cell.StringCellValue;
                        try
                        {
                            VV = double.Parse(buff);
                        }
                        catch (Exception e)
                        {
                            VV = null;
                        }
                    }

                    string? WeatherPhenomena;
                    try
                    {
                        cell = row.GetCell(11);
                        WeatherPhenomena = cell.StringCellValue;
                    }
                    catch (Exception exception)
                    {
                        WeatherPhenomena = null;
                    }
                    
                    measurements.Add(new WeatherMeasurement()
                    {
                        Date = DateOnly.Parse(measurmentDate),
                        Time = TimeOnly.Parse(measurmentTime),
                        Temperature = temperature,
                        AirRelativeHumidity = AirRelativeHumidity,
                        DewPoint = DewPoint,
                        AtmospericPressure = Pressure,
                        AirDirection = AirDirection,
                        AirSpeed = airPowe,
                        CloudCover = cloudCover,
                        LowerCloudLimit = dawnCloudBorder,
                        VisualVisibility = VV,
                        WeatherPhenomena = WeatherPhenomena,
                    });
                }
                months.Add(new Month()
                {
                    Name = sheet.SheetName,
                    WeatherMeasurements = measurements,
                });
            }
            workbook.Close();
            return new Year()
            {
                Value = int.Parse(months.FirstOrDefault().Name.Split(' ')[1]),
                Months = months,
            };
    }
}