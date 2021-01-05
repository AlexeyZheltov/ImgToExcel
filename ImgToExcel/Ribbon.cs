using Microsoft.Office.Tools.Ribbon;

using System.Drawing;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace ImgToExcel
{
    public partial class Ribbon
    {

        private void Import(object sender, RibbonControlEventArgs e)
        {
            Excel.Worksheet worksheet = Globals.ThisAddIn.Application.ActiveSheet;

            if (!int.TryParse(txtWidth.Text, out int width))
            {
                MessageBox.Show("Укажите верную ширину. Целое число больше или равное 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtHeight.Text, out int height))
            {
                MessageBox.Show("Укажите верную высоту. Целое число больше или равное 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Image image;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                image = Image.FromFile(openFileDialog.FileName);
            }

            if (height > 0 && width > 0)
                image = ImageCompressor.ResizeImage(image, width, height);

            if (height == 0 && width > 0)
                image = ImageCompressor.ResizeImage(image, width);

            Bitmap bitmap = new Bitmap(image);

            Progress progress = new Progress("Загрузка изображения", bitmap.Height);

            for (int y = 0; y < bitmap.Height - 1; y++)
            {
                if (!progress.TaskStart("", 1)) break;
                for (int x = 0; x < bitmap.Width - 1; x++)
                {

                    Color color = bitmap.GetPixel(x, y);
                    if (color.A != 0) worksheet.Cells[y + 1, x + 1].Interior.Color = color;
                }
            }
            progress.Finish();

        }

        private void ChangeSize(object sender, RibbonControlEventArgs e)
        {
            Excel.Application application = Globals.ThisAddIn.Application;
            Excel.Worksheet worksheet = application.ActiveSheet;

            float y = 3f / 4f;

            if (!int.TryParse(txtSize.Text, out int size))
            {
                MessageBox.Show("Укажите верный масштаб. Целое число больше 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            worksheet.Cells.RowHeight = y * size;
            worksheet.Cells.ColumnWidth = 2f / 19f * size;

            double x = application.CentimetersToPoints(size / 3.779f / 10);

            while (worksheet.Columns[2].Left - worksheet.Columns[1].Left - 0.1f > x)
            {
                Application.DoEvents();
                worksheet.Cells.ColumnWidth = worksheet.Cells.ColumnWidth - 0.1f;
            }
            while (worksheet.Columns[2].Left - worksheet.Columns[1].Left - 0.1f < x)
            {
                Application.DoEvents();
                worksheet.Cells.ColumnWidth = worksheet.Cells.ColumnWidth + 0.1f;
            }

            worksheet.Cells.ColumnWidth = worksheet.Cells.ColumnWidth - 0.1f;
        }
    }
}
