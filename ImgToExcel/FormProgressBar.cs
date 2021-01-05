using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ImgToExcel
{
    public partial class FormProgressBar : Form
    {
        private readonly int WidthIndicator;
        private readonly Stopwatch timerProcess;

        #region Свойства

        /// <summary>
        /// Дочерний прогрессбар
        /// </summary>
        public FormProgressBar SubBar { get; set; }

        /// <summary>
        /// Заголовок прогрессбара, то что будет написано в названии формы
        /// </summary>
        public string Title
        {
            get => title;
            private set
            {
                title = value;
                LabelNameProcess.Text = title;
            }
        }
        private string title;

        /// <summary>
        /// Название задачи
        /// </summary>
        public string TaskName
        {
            get => taskName;
            private set
            {
                taskName = value;
                LabelNameTask.Text = taskName;
            }
        }
        private string taskName;

        /// <summary>
        /// Уровень прогрессбара
        /// </summary>
        public int Level { get; set; } = 1;

        /// <summary>
        /// Начальная позиция прогресбара
        /// </summary>
        public int Start { get; set; } = 0;

        /// <summary>
        /// Шаг прогрессбара
        /// </summary>
        public int Step { get; set; } = 1;

        /// <summary>
        /// Общее количество итераций
        /// </summary>
        public int Count { get; set; } = 0;


        /// <summary>
        /// Текущее значение прогрессбара
        /// </summary>
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                lblIndicator.Width = (int)(((double)Value / (double)Count) * WidthIndicator);

                if (_value == Count) Close();
                SetTimeLost();
                Application.DoEvents();
            }
        }
        private int _value;

        /// <summary>
        /// Нажата кнопка отмены
        /// </summary>
        public bool IsCancel { get; set; } = false;

        #endregion

        #region События

        /// <summary>
        /// Событие клика кнопки отмены
        /// </summary>
        public event Action CancelClick;

        /// <summary>
        /// Событие выполнения задачи
        /// </summary>
        public event Action TaskDoned;

        /// <summary>
        /// Событие увеличения размеров прогрессбара
        /// </summary>
        public event Action<int> ResisingPlus;

        /// <summary>
        /// Событие уменьшения размеров прогрессбара
        /// </summary>
        public event Action<int> ResisingMinus;

        #endregion

        #region --- События формы ---

        /// <summary>
        /// Закрытие формы прогрессбара
        /// </summary>
        private void FormProgressBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerProcess.Stop();
            IsCancel = true;
        }

        /// <summary>
        /// Закрытие дочерней формы
        /// </summary>
        private void SubBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResizeMinus(SubBar.Count);
        }

        /// <summary>
        /// Кнопка закрытия формы
        /// </summary>
        private void CancelBox_Click(object sender, EventArgs e)
        {
            Cancel();
            CancelClick?.Invoke();
        }

        #endregion

        /// <summary>
        /// Инициализация прогрессбара
        /// </summary>
        /// <param name="title">Описание глобальной задачи</param>
        /// <param name="count">Количество итераций</param>
        /// <param name="start">Старт</param>
        /// <param name="step">Шаг</param>
        public FormProgressBar(string title, int count, int start = 0, int step = 1)
        {
            InitializeComponent();

            Title = title;
            Count = count;
            Start = start;
            Step = step;

            WidthIndicator = lblIndicator.Width;
            lblIndicator.Width = (int)(((double)start / (double)Count) * WidthIndicator);

            TaskName = "Запуск прогрессбара";
            timerProcess = Stopwatch.StartNew();
        }

        #region Методы

        /// <summary>
        /// Старт задачи
        /// </summary>
        /// <param name="taskName">Наименование задачи</param>
        public void TaskStart(string taskName, int step)
        {
            Step = step;
            TaskName = taskName;
            Application.DoEvents();
        }

        /// <summary>
        /// Завершение задачи
        /// </summary>
        /// <param name="count">вес задачи</param>
        public void TaskDone()
        {
            Value += Step;
            TaskDoned?.Invoke();
        }

        /// <summary>
        /// Отмена операции
        /// </summary>
        public void Cancel()
        {
            IsCancel = true;
            SubBar?.Cancel();
            Close();
        }

        /// <summary>
        /// Добавление дочернего прогрессбара
        /// </summary>
        /// <param name="title"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <param name="step"></param>
        public void AddSubBar(string title, int count, int start = 0, int step = 1)
        {
            ResizePlus(count);

            SubBar = new FormProgressBar(title, count, start, step);
            SubBar.Show();
            SubBar.btnCancelBox.Visible = false;
            SubBar.Level = Level++;
            SubBar.Top = Top + Height - 1;
            SubBar.Left = Left;

            SubBar.TaskDoned += TaskDone;
            SubBar.CancelClick += Cancel;
            CancelClick += SubBar.Cancel;
            SubBar.FormClosing += SubBar_FormClosing;

            SubBar.ResisingPlus += ResizePlus;
            SubBar.ResisingMinus += ResizeMinus;
        }

        /// <summary>
        /// Увеличение размеров прогрессбара
        /// </summary>
        /// <param name="count">количество в дочернем прогрессбаре</param>
        public void ResizePlus(int count)
        {
            if (count == 0) return;
            Count *= count;
            Value *= count;
            ResisingPlus?.Invoke(count);
        }

        /// <summary>
        /// Уменьшение размеров прогрессбара
        /// </summary>
        /// <param name="count">количество в дочернем прогрессбаре</param>
        public void ResizeMinus(int count)
        {
            if (count == 0) return;
            Count /= count;
            Value = (Value + Step) / count - 1;
            Step = 1;
            ResisingMinus?.Invoke(count);
        }

        private void SetTimeLost()
        {
            lblIndicator.Text = Count == 0 ? "0%" : ((double)Value / (double)Count).ToString("##0%");
            if (Value == 0)
            {
                LabelTimeLost.Text = "-";
                return;
            }

            TimeSpan ts = TimeSpan.FromMilliseconds(timerProcess.Elapsed.TotalMilliseconds / Value * (Count - Value));
            if (ts.Days > 0)
            {
                LabelTimeLost.Text = String.Format("{0:#0}дн. {1:#0}ч", ts.Days, ts.Hours);
            }
            else if (ts.Hours > 0)
            {
                LabelTimeLost.Text = String.Format("{0:#0}ч {1:#0}мин", ts.Hours, ts.Minutes);
            }
            else if (ts.Minutes > 0)
            {
                LabelTimeLost.Text = String.Format("{0:#0}:{1:00}", ts.Minutes, ts.Seconds);
            }
            else
            {
                LabelTimeLost.Text = String.Format("{0:#0} сек", ts.Seconds);
            }
        }

        #endregion

        Point oldPos;
        bool isDragging = false;
        Point oldMouse;
        private void MyForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.isDragging = true;
            this.oldPos = this.Location;
            this.oldMouse = e.Location;
        }

        private void MyForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isDragging)
            {
                this.Location = new Point(oldPos.X + (e.X - oldMouse.X), oldPos.Y + (e.Y - oldMouse.Y));
            }
        }

        private void MyForm_MouseUp(object sender, MouseEventArgs e)
        {
            this.isDragging = false;
        }

    }
}
