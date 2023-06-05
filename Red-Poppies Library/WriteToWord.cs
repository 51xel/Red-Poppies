using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace Red_Poppies_Library {
    public class WriteToWord {
        public static bool WriteToFile(List<HolidaymakersToView> list, string pathToFile) {
            if (!String.IsNullOrWhiteSpace(pathToFile)) {
                if (!File.Exists(pathToFile)) {
                    File.Create(pathToFile);
                }

                try {
                    Application wordApp = new Application();
                    wordApp.Visible = false;
                    Document document = wordApp.Documents.Add();

                    string[] headers = { "Ім'я та Фамілія", "№", "Тип", "До сплати", "Дні", "Дата заїзду" };

                    int numRows = list.Count;
                    int numCols = headers.Length;
                    Table table = document.Tables.Add(document.Range(0, 0), numRows, numCols);

                    float[] columnWidths = { 80f, 20f, 50f, 50f, 30f, 100f };
                    for (int i = 1; i <= numCols; i++) {
                        table.Columns[i].Width = columnWidths[i - 1];
                    }
                    for (int i = 1; i <= numCols; i++) {
                        table.Cell(1, i).Range.Text = headers[i - 1];
                    }
                    table.Rows[1].HeadingFormat = -1;
                    foreach (Row row in table.Rows) {
                        foreach (Cell cell in row.Cells) {
                            cell.Range.Borders.Enable = 1;
                            cell.Range.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                            cell.Range.Borders.OutsideLineWidth = WdLineWidth.wdLineWidth150pt;
                        }
                    }
                    table.Rows.Add();
                    for (int row = 2; row <= numRows + 1; row++) {
                        table.Cell(row, 1).Range.Text = list[row - 2].Name;
                        table.Cell(row, 2).Range.Text = list[row - 2].Number_of_room.ToString();
                        table.Cell(row, 3).Range.Text = list[row - 2].Type_of_room;
                        table.Cell(row, 4).Range.Text = list[row - 2].Pay.ToString();
                        table.Cell(row, 5).Range.Text = list[row - 2].Days.ToString();
                        table.Cell(row, 6).Range.Text = list[row - 2].Date.ToString();
                    }

                    document.SaveAs2(Path.Combine(Environment.CurrentDirectory, pathToFile));
                    document.Close();
                    wordApp.Quit();
                }
                catch (Exception ex) {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
