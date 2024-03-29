﻿using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using QuanLyLopHocBL.IService;
using QuanLyLopHocCommon.Entity;
using QuanLyLopHocDL.IReponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyLopHocBL.ImplementService
{
    public class ScoreBL : BaseBL<score>, IScoreBL
    {
        IScoreDL _scoreDL;
        public ScoreBL(IScoreDL scoreDL) : base(scoreDL)
        {
            _scoreDL = scoreDL;
        }

        public int ImportScores(IFormFile formFile)
        {
            try
            {
                // kiểu tra tệp rỗng F
                if (formFile == null || formFile.Length <= 0)
                {
                    listMsgEr.Add(QuanLyLopHocCommon.CommonResource.GetResoureString("FileExist"));
                }
                // kiểu tra tệp đúng dịnh dạng ko 

                if (!Path.GetExtension(formFile.FileName).Equals(".xls", StringComparison.OrdinalIgnoreCase))
                {
                    listMsgEr.Add(QuanLyLopHocCommon.CommonResource.GetResoureString("FileNotFormat"));
                }
                var scores = new List<score>();
                using (var stream = new MemoryStream())
                {
                    formFile.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.Commercial;
                        // If you use EPPlus in a noncommercial context
                        // according to the Polyform Noncommercial license:
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;
                        var columnCout = worksheet.Dimension.Columns;
                        var yearSchool = ConvertObjectToString(worksheet.Cells[5, 5].Value);
                        Regex regex = new Regex(@"(\d{4}-\d{4})");
                        Regex regex1 = new Regex(@"(\d{1})");
                        Match match = regex.Match(yearSchool);
                        Match match1 = regex1.Match(yearSchool);
                        string year = match.Groups[1].Value;
                        string seleme = match1.Groups[1].Value;


                        for (int row = 9; row <= rowCount; row++)
                        {
                            for (int column = 12; column < columnCout; column = column + 2)
                            {
                                if (worksheet.Cells[7, column].Value == null)
                                {
                                    break;
                                }
                                Regex regex2 = new Regex(@"(\(\d{1}\))");
                                Regex regex3 = new Regex(@"(\d)");
                                Match match2 = regex2.Match(ConvertObjectToString(worksheet.Cells[7, column].Value));
                                var namesubject  = ConvertObjectToString(worksheet.Cells[7, column].Value).Substring(0, ConvertObjectToString(worksheet.Cells[7, column].Value).Length - match2.Groups[1].Value.Length);
                                match2 = regex3.Match(match2.Groups[1].Value);
                                string credits = match2.Groups[1].Value;
                                var score = new score()
                                {
                                    semester = Int32.Parse(seleme),
                                    school_year = year,
                                    number_credits = Int32.Parse(credits),
                                    subject_name = namesubject,
                                    user_code = ConvertObjectToString(worksheet.Cells[row, 2].Value),
                                    score_type = 1,

                                };

                                if (worksheet.Cells[row, column].Value != null)
                                {
                                    score.score_number = ConvertObjectToNumber(worksheet.Cells[row, column ].Value);
                                    score.study_times = 1;
                                    scores.Add(score);
                                }
                            
                            }
                        }
                    }
                }
                return _scoreDL.Import(scores);

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        /// <summary>
        ///    chuyển đổi kiểu đối tượng sang  dữ liệu dưới dạng chuỗi 
        ///    @created by : tvTam
        /// @create day : 1/3/2023
        /// </summary>
        /// <param name="value">đối tượng cần ép kiểu </param>
        /// <returns>dữ liệu dưới dạng chuỗi</returns>
        private string? ConvertObjectToString(object? value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return value.ToString();
            }
        }
        private double ConvertObjectToNumber(object? value)
        {
            if (value == null)
            {
                return 0;
            }
            else
            {
                double number;
                if (double.TryParse(value.ToString(), out number))
                {
                    return number;
                }
                return 0;
            }
        }

        /// <summary>
        /// object to int 
        /// @created by : tvTam
        /// @create day : 1/3/2023
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>int || 0 khi null hoặc vượt quá int </returns>
        private int ConvertObjectToNumberInt(object? value)
        {
            if (value == null)
            {
                return 0;
            }
            else
            {
                int Number;
                if (Int32.TryParse(value.ToString(), out Number))
                {
                    return Number;
                }
                else return 0;
            }
        }
    }
}
