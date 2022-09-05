using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SuperMapLib;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//打开数据集
        {
            if (this.openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                this.axSuperMap1.Connect(this.axSuperWorkspace1.CtlHandle);//和workspace控件的关联
                this.axSuperWorkspace1.Open(this.openFileDialog1.FileName);//打开工作空间的文件名
                soDataSources soDss = this.axSuperWorkspace1.Datasources;//获得数据源集合
               
                soDatasets soDtss = soDss[1].Datasets;
               
                soLayers soLys = axSuperMap1.Layers; //获得地图窗口的图层集合

                soLayer objLy = soLys.AddDataset(soDtss[1], true);//添加指定数据集到地图窗口中
                this.axSuperMap1.ViewEntire(); //地图窗口全幅显示
                axSuperMap1.Refresh(); //刷新地图窗口
                axSuperLegend1.Refresh();//刷新图例窗口
            }
        }

        private void axSuperWorkspace1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//打开工作空间
        {
            bool blnOpen = false;
            string strOpenPath = string.Empty;
            this.openFileDialog1.Title = "打开工作空间";
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.Filter = "工作空间(.smw)|*.smw";//设置对话框打开文件的类型
            this.openFileDialog1.InitialDirectory = "..\\..\\..\\Data\\";//对话框打开时的初始文件路径
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strOpenPath = this.openFileDialog1.FileName;
                object objWSHandle = this.axSuperWorkspace1.CtlHandle;

                blnOpen = this.axSuperWorkspace1.Open(strOpenPath, "");
                if (!blnOpen)
                {
                    MessageBox.Show("打开工作空间失败");
                    return;
                }
                else
                {
                  
                    soSelection objSelection = axSuperMap1.selection;//获得选择集
                    soStyle objStyle = objSelection.Style; //选择集风格
                    objStyle.BrushStyle = 0; //填充风格，取值为填充库中的编码
                    objStyle.PenStyle = 0; //线型，取值为线型的编码
                    objStyle.BrushColor = System.Convert.ToUInt32(System.Drawing.ColorTranslator.ToOle(Color.FromArgb(255, 190, 189))); //填充颜色
                    objStyle.PenColor = System.Convert.ToUInt32(System.Drawing.ColorTranslator.ToOle(Color.FromArgb(0, 0, 255)));//线颜色

                   //ReleaseObjects(objStyle);
                   // ReleaseObjects(objSelection);
                    //刷新工作空间管理器，将打开的工作空间可视化在工作空间管理器中
                    this.axSuperWkspManager1.Refresh();
                }
            }
            else
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)//关闭工作空间
        {
            axSuperWkspManager1.Disconnect();
            axSuperLegend1.Disconnect();
            axSuperMap1.Disconnect();
            axSuperMap1.Close();
            axSuperWorkspace1.Close();
            axSuperMap1.Refresh();
        }

        private void axSuperMap1_GeometrySelected(object sender, AxSuperMapLib._DSuperMapEvents_GeometrySelectedEvent e)
        {

        }

        private void axSuperWkspManager1_LClick(object sender, AxSuperWkspManagerLib._DSuperWkspManagerEvents_LClickEvent e)
        {

        }

        private void axSuperLegend1_Modified(object sender, EventArgs e)
        {

        }
    }
}
