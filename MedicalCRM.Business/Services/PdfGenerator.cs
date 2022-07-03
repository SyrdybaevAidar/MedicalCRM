using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services {
    public class TransactionReport {
        public MemoryStream CreateExcelDoc(MemoryStream mem) {
            SpreadsheetDocument document = SpreadsheetDocument.Create(mem, SpreadsheetDocumentType.Workbook);

            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();

            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet();

            // Adding style
            WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
            stylePart.Stylesheet = GenerateStylesheet();
            stylePart.Stylesheet.Save();

            // Setting up columns
            Columns columns = new Columns(
                    new Column // Id column
                    {
                        Min = 1,
                        Max = 1,
                        Width = 4,
                        CustomWidth = true
                    },
                    new Column // Name and Birthday columns
                    {
                        Min = 2,
                        Max = 2,
                        Width = 15,
                        CustomWidth = true
                    },
                    new Column // Name and Birthday columns
                    {
                        Min = 3,
                        Max = 3,
                        Width = 10,
                        CustomWidth = true
                    },
                    new Column // Name and Birthday columns
                    {
                        Min = 4,
                        Max = 4,
                        Width = 15,
                        CustomWidth = true
                    },
                    new Column // Name and Birthday columns
                    {
                        Min = 5,
                        Max = 5,
                        Width = 35,
                        CustomWidth = true
                    }
                    ,
                    new Column // Name and Birthday columns
                    {
                        Min = 6,
                        Max = 7,
                        Width = 10,
                        CustomWidth = true
                    },
                    new Column // Name and Birthday columns
                    {
                        Min = 8,
                        Max = 8,
                        Width = 20,
                        CustomWidth = true
                    });

            worksheetPart.Worksheet.AppendChild(columns);

            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

            Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Remittance" };

            sheets.Append(sheet);

            workbookPart.Workbook.Save();

            SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

            // Constructing header
            Row row = new Row();

            row.Append(
                ConstructCell("Id", CellValues.String, 2),
                ConstructCell("Дата Транзакции", CellValues.String, 2),
                ConstructCell("Сумма", CellValues.String, 2),
                ConstructCell("Проект", CellValues.String, 2),
                ConstructCell("Операция", CellValues.String, 2),
                ConstructCell("Тип операции", CellValues.String, 2),
                ConstructCell("Счет", CellValues.String, 2),
                ConstructCell("Контрагент", CellValues.String, 2));

            // Insert the header row to the Sheet Data
            sheetData.AppendChild(row);

            worksheetPart.Worksheet.Save();
            document.Close();

            return mem;
        }

        private Cell ConstructCell(string value, CellValues dataType, uint styleIndex = 0) {
            return new Cell() {
                CellValue = new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType),
                StyleIndex = styleIndex
            };
        }

        private Stylesheet GenerateStylesheet() {
            Stylesheet styleSheet = null;

            Fonts fonts = new Fonts(
                new Font( // Index 0 - default
                    new FontSize() { Val = 8 }

                ),
                new Font( // Index 1 - header
                    new FontSize() { Val = 8 },
                    new Bold(),
                    new Color() { Rgb = "FFFFFF" }

                ));

            Fills fills = new Fills(
                    new Fill(new PatternFill() { PatternType = PatternValues.None }), // Index 0 - default
                    new Fill(new PatternFill() { PatternType = PatternValues.Gray125 }), // Index 1 - default
                    new Fill(new PatternFill(new ForegroundColor { Rgb = new HexBinaryValue() { Value = "66666666" } }) { PatternType = PatternValues.Solid }) // Index 2 - header
                );

            Borders borders = new Borders(
                    new Border(), // index 0 default
                    new Border( // index 1 black border
                        new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new DiagonalBorder())
                );

            CellFormats cellFormats = new CellFormats(
                    new CellFormat(), // default
                    new CellFormat { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true }, // body
                    new CellFormat { FontId = 1, FillId = 2, BorderId = 1, ApplyFill = true } // header
                );

            styleSheet = new Stylesheet(fonts, fills, borders, cellFormats);

            return styleSheet;
        }
    }
}
