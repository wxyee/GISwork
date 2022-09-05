
namespace WindowsFormsApp8
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.axSuperWorkspace1 = new AxSuperMapLib.AxSuperWorkspace();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.axSuperWkspManager1 = new AxSuperWkspManagerLib.AxSuperWkspManager();
            this.axSuperTopo1 = new AxSuperTopoLib.AxSuperTopo();
            this.axSuperMap1 = new AxSuperMapLib.AxSuperMap();
            this.axSuperLegend1 = new AxSuperLegendLib.AxSuperLegend();
            ((System.ComponentModel.ISupportInitialize)(this.axSuperWorkspace1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSuperWkspManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSuperTopo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSuperMap1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSuperLegend1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(418, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "打开数据集";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // axSuperWorkspace1
            // 
            this.axSuperWorkspace1.Enabled = true;
            this.axSuperWorkspace1.Location = new System.Drawing.Point(723, 294);
            this.axSuperWorkspace1.Name = "axSuperWorkspace1";
            this.axSuperWorkspace1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSuperWorkspace1.OcxState")));
            this.axSuperWorkspace1.Size = new System.Drawing.Size(32, 32);
            this.axSuperWorkspace1.TabIndex = 1;
            this.axSuperWorkspace1.Enter += new System.EventHandler(this.axSuperWorkspace1_Enter);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(418, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "打开工作空间";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(418, 184);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "关闭工作空间";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // axSuperWkspManager1
            // 
            this.axSuperWkspManager1.Enabled = true;
            this.axSuperWkspManager1.Location = new System.Drawing.Point(12, 1);
            this.axSuperWkspManager1.Name = "axSuperWkspManager1";
            this.axSuperWkspManager1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSuperWkspManager1.OcxState")));
            this.axSuperWkspManager1.Size = new System.Drawing.Size(385, 287);
            this.axSuperWkspManager1.TabIndex = 4;
            this.axSuperWkspManager1.LClick += new AxSuperWkspManagerLib._DSuperWkspManagerEvents_LClickEventHandler(this.axSuperWkspManager1_LClick);
            // 
            // axSuperTopo1
            // 
            this.axSuperTopo1.Enabled = true;
            this.axSuperTopo1.Location = new System.Drawing.Point(670, 294);
            this.axSuperTopo1.Name = "axSuperTopo1";
            this.axSuperTopo1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSuperTopo1.OcxState")));
            this.axSuperTopo1.Size = new System.Drawing.Size(32, 32);
            this.axSuperTopo1.TabIndex = 5;
            // 
            // axSuperMap1
            // 
            this.axSuperMap1.Enabled = true;
            this.axSuperMap1.Location = new System.Drawing.Point(12, 294);
            this.axSuperMap1.Name = "axSuperMap1";
            this.axSuperMap1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSuperMap1.OcxState")));
            this.axSuperMap1.Size = new System.Drawing.Size(303, 167);
            this.axSuperMap1.TabIndex = 6;
            // 
            // axSuperLegend1
            // 
            this.axSuperLegend1.Enabled = true;
            this.axSuperLegend1.Location = new System.Drawing.Point(321, 294);
            this.axSuperLegend1.Name = "axSuperLegend1";
            this.axSuperLegend1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSuperLegend1.OcxState")));
            this.axSuperLegend1.Size = new System.Drawing.Size(304, 167);
            this.axSuperLegend1.TabIndex = 7;
            this.axSuperLegend1.Modified += new System.EventHandler(this.axSuperLegend1_Modified);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 473);
            this.Controls.Add(this.axSuperLegend1);
            this.Controls.Add(this.axSuperMap1);
            this.Controls.Add(this.axSuperTopo1);
            this.Controls.Add(this.axSuperWkspManager1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.axSuperWorkspace1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axSuperWorkspace1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSuperWkspManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSuperTopo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSuperMap1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSuperLegend1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private AxSuperMapLib.AxSuperWorkspace axSuperWorkspace1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private AxSuperWkspManagerLib.AxSuperWkspManager axSuperWkspManager1;
        private AxSuperTopoLib.AxSuperTopo axSuperTopo1;
        private AxSuperMapLib.AxSuperMap axSuperMap1;
        private AxSuperLegendLib.AxSuperLegend axSuperLegend1;
    }
}

