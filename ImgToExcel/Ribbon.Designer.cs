namespace ImgToExcel
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon));
            this.tabImgToExcel = this.Factory.CreateRibbonTab();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.txtSize = this.Factory.CreateRibbonEditBox();
            this.btnChangeSize = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.txtWidth = this.Factory.CreateRibbonEditBox();
            this.txtHeight = this.Factory.CreateRibbonEditBox();
            this.btnLoad = this.Factory.CreateRibbonButton();
            this.tabImgToExcel.SuspendLayout();
            this.group2.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabImgToExcel
            // 
            this.tabImgToExcel.Groups.Add(this.group2);
            this.tabImgToExcel.Groups.Add(this.group1);
            this.tabImgToExcel.Label = "ImgToExcel";
            this.tabImgToExcel.Name = "tabImgToExcel";
            // 
            // group2
            // 
            this.group2.Items.Add(this.txtSize);
            this.group2.Items.Add(this.btnChangeSize);
            this.group2.Label = "Масштаб сетки";
            this.group2.Name = "group2";
            // 
            // txtSize
            // 
            this.txtSize.Label = "Ширина сетки Excel";
            this.txtSize.Name = "txtSize";
            this.txtSize.ScreenTip = "Ширина сетки Excel в пикселях";
            this.txtSize.SizeString = "100";
            this.txtSize.Text = "10";
            // 
            // btnChangeSize
            // 
            this.btnChangeSize.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeSize.Image")));
            this.btnChangeSize.Label = "Изменить размер сетки";
            this.btnChangeSize.Name = "btnChangeSize";
            this.btnChangeSize.ShowImage = true;
            this.btnChangeSize.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ChangeSize);
            // 
            // group1
            // 
            this.group1.Items.Add(this.txtWidth);
            this.group1.Items.Add(this.txtHeight);
            this.group1.Items.Add(this.btnLoad);
            this.group1.Label = "Загрузка изображения";
            this.group1.Name = "group1";
            // 
            // txtWidth
            // 
            this.txtWidth.Label = "Ширина";
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ScreenTip = "Новая ширина в пикселях";
            this.txtWidth.SuperTip = "Укажите размер изображения в пикселях, если хотите установить новые размеры";
            this.txtWidth.Text = "100";
            // 
            // txtHeight
            // 
            this.txtHeight.Label = "Высота";
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ScreenTip = "Новая высота в пикселях";
            this.txtHeight.SuperTip = "Укажите размер изображения в пикселях, если хотите установить новые размеры";
            this.txtHeight.Text = "0";
            // 
            // btnLoad
            // 
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.Label = "Загрузить изображение";
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.ShowImage = true;
            this.btnLoad.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Import);
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tabImgToExcel);
            this.tabImgToExcel.ResumeLayout(false);
            this.tabImgToExcel.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabImgToExcel;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnLoad;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox txtWidth;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox txtHeight;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox txtSize;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnChangeSize;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
