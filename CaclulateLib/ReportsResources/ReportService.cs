using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OfficeOpenXml;
using OfficeOpenXml.Style;


namespace CaclulateLib.ReportsResources
{
    public class ReportService
    {
        public byte[] CreateReport(ReportModel model)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                using (ExcelPackage excelPackage = new ExcelPackage())
                {

                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Лист 1");

                    worksheet.Cells["A1:F1"].Merge = true;
                    worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells["A1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    worksheet.Cells["A1"].Value = "DESIGN BY ANTONIO UGARIO";


                    worksheet.Cells["A3"].Value = "Опасная скорость ветра, м/с";
                    worksheet.Cells["B3"].Value = model.Range;

                    worksheet.Cells["A5"].Value = "Количество пыли";
                    worksheet.Cells["B5"].Value = model.Dust;

                    worksheet.Cells["A7"].Value = "Расстояние по оси факела";
                    worksheet.Cells["B7"].Value = model.Xmfak;

                    worksheet.Cells["A8:E8"].Merge= true;
                    worksheet.Cells["A8"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells["A8"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    worksheet.Cells["A8"].Value= "Максимальная приземная концентрация";


                    worksheet.Cells["A9"].Value = model.Title1;
                    worksheet.Cells["B9"].Value = model.Title2;
                    worksheet.Cells["C9"].Value = model.Title3;
                    worksheet.Cells["D9"].Value = model.Title4;
                    worksheet.Cells["E9"].Value = model.Title5;

                    worksheet.Cells["A10:F10"].Merge = true;
                    worksheet.Cells["A10"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells["A10"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    worksheet.Cells["A10"].Value = "Приземная концентрация на расстояние X и Y";

                    worksheet.Cells["A11"].LoadFromCollection(model.RowReport);
                    byte[] bin = excelPackage.GetAsByteArray();
                    return bin;
                    
                  
                }
            }
            
        }


        public string CreateFile(byte[] fileArray)
        {
            string path = @"C:\SomeDir2";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            var filePath = $"{path}\\report{Guid.NewGuid()}.xlsx";


            using (FileStream fstream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                fstream.Write(fileArray, 0, fileArray.Length);
               
            }

            return filePath;
        }
    }
}
