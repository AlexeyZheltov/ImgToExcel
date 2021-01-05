using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgToExcel
{
    class Progress
    {
        public Progress SubBar;
        public bool IsCancel = false;

        private readonly FormProgressBar Form;
        private bool isTaskStart = false;

        /// <summary>
        /// Инициализация прогрессбара
        /// </summary>
        /// <param name="title">Заголовок (описание общей задачи)</param>
        /// <param name="count">Количество итераций</param>
        /// <param name="start">Начальная позиция</param>
        /// <param name="step">Шаг итерации</param>
        public Progress(string title, int count, int start = 0, int step = 1)
        {
            Form = new FormProgressBar(title, count, start, step);
            Form.CancelClick += Form_CancelClick;
            Form.Show();
        }

        private Progress(FormProgressBar form)
        {
            Form = form.SubBar;
            Form.CancelClick += Form_CancelClick;
            Form.Show();
        }
        private void Form_CancelClick()
        {
            IsCancel = true;
        }

        /// <summary>
        /// Запуск новой задачи. Также завершает предыдущую задачу если она была
        /// </summary>
        /// <param name="taskName">Название задачи</param>
        /// <param name="count">Объем задачи</param>
        /// <returns>Если пользователь отменил процесс - возвращает false</returns>
        public bool TaskStart(string taskName, int count)
        {
            if (IsCancel) return false;
            if (Form.SubBar != null)
            {
                EndProgress(Form.SubBar);
                Form.SubBar = null;
                isTaskStart = false;
            }
            if (isTaskStart) TaskEnd();

            Form.TaskStart(taskName, count);
            isTaskStart = true;
            return true;
        }

        /// <summary>
        /// Завершает текущую задачу
        /// </summary>
        /// <param name="count">Объем задачи</param>
        public void TaskEnd()
        {
            if (IsCancel) return;
            Form.TaskDone();
            isTaskStart = false;
        }

        /// <summary>
        /// Выключение прогрессбара
        /// </summary>
        public void Finish()
        {
            if (Form.SubBar != null)
            {
                EndProgress(Form.SubBar);
                Form.SubBar = null;
            }
            EndProgress(Form);
        }

        /// <summary>
        /// Добавление вложенного прогрессбара к текущему
        /// </summary>
        /// <param name="title">Заголовок вложенного прогрессбара</param>
        /// <param name="count">Количество итераций</param>
        /// <param name="start">Начальная позиция</param>
        /// <param name="step">Шаг прогрессбара</param>
        /// <returns>Если пользователь отменил процесс - возвращает false</returns>
        public bool AddNewLevel(string title, int count, int start = 0, int step = 1)
        {
            if (IsCancel) return false;
            if (Form.SubBar != null)
            {
                EndProgress(Form.SubBar);
                Form.SubBar = null;
            }

            Form.AddSubBar(title, count, start, step);
            SubBar = new Progress(Form);
            return true;
        }

        private void EndProgress(FormProgressBar form)
        {
            form.Step = form.Count - form.Value;
            form.TaskDone();
        }
    }
}
