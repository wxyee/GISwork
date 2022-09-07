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
        private void ConnectSuperMap()//定义关联控件的方法
        {
            
            object objWSHandle = this.axSuperWorkspace1.CtlHandle;
            this.axSuperMap1.Connect(objWSHandle);
            this.axSuperWkspManager1.Connect(objWSHandle);

            object objSMHandle = this.axSuperMap1.CtlHandle;
            axSuperLegend1.Connect(objSMHandle);

            ReleaseObjects(objWSHandle);
            ReleaseObjects(objSMHandle);
        }

        private void ReleaseObjects(object superObject)//释放对象的方法
        {
            if (superObject != null)
            {
                Marshal.ReleaseComObject(superObject);
                superObject = null;
            }
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
                this.ConnectSuperMap();

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

        private void axSuperWkspManager1_LDbClick(object sender, AxSuperWkspManagerLib._DSuperWkspManagerEvents_LDbClickEvent e)
        {
            switch (e.nFlag)
            {
                case SuperMapLib.seSelectedItemFlag.scsDataset: //如果是在数据集名称上面双击鼠标左键
                    {
                        //当双击节点类型为数据集时，将数据集添加到地图窗口
                        soDataSources objDss = this.axSuperWorkspace1.Datasources;//获得工作空间下的数据源集合
                        soDataSource objDs = objDss[e.strParent];//通过当前选中数据集的父节点获得数据集所在的数据源
                        soDatasets objDts = objDs.Datasets;//获得该数据源下的数据集集合
                        soDataset objDt = objDts[e.strSelected];//通过当前选中数据集的名称获得该数据集
                        soLayers objLys = axSuperMap1.Layers; //获得地图窗口的图层集合

                        soLayer objLy = objLys.AddDataset(objDt, true);//添加指定数据集到地图窗口中
                        this.axSuperMap1.ViewEntire(); //地图窗口全幅显示
                        axSuperMap1.Refresh(); //刷新地图窗口
                        axSuperLegend1.Refresh();//刷新图例窗口，这样在图例中可以看到刚刚添加的图层

                        ReleaseObjects(objLy);//释放变量
                        ReleaseObjects(objLys);
                        ReleaseObjects(objDt);
                        ReleaseObjects(objDs);
                        ReleaseObjects(objDts);
                        ReleaseObjects(objDss);
                        break;
                    }
                case SuperMapLib.seSelectedItemFlag.scsMap:
                    {
                        //当双击节点类型为地图时，在地图窗口中显示当前地图
                        bool bResult;
                        soLayers objLys2 = axSuperMap1.Layers;
                        objLys2.RemoveAll();//移除地图窗口的所有图层
                        bResult = axSuperMap1.OpenMap(e.strSelected);//打开地图

                        axSuperMap1.ViewEntire();
                        axSuperMap1.Refresh();
                        axSuperLegend1.Refresh();
                        ReleaseObjects(objLys2);
                        break;
                    }
                case SuperMapLib.seSelectedItemFlag.scsSymbolLib:
                    {//当双击对象为点符号时，显示点符号编辑器
                        soResources objResources = this.axSuperWorkspace1.Resources;
                        soSymbolLib objSymbolLib = objResources.SymbolLib;
                        objSymbolLib.ShowEditor();
                        ReleaseObjects(objSymbolLib);
                        ReleaseObjects(objResources);
                        break;
                    }
                case SuperMapLib.seSelectedItemFlag.scsLineStyleLib:
                    {//当双击对象为线符号时，显示线符号编辑器
                        soResources objResources = this.axSuperWorkspace1.Resources;
                        soLineStyleLib objLineStyleLib = objResources.LineStyleLib;
                        objLineStyleLib.ShowEditor();
                        ReleaseObjects(objLineStyleLib);
                        ReleaseObjects(objResources);
                        break;
                    }
                case SuperMapLib.seSelectedItemFlag.scsFillStyleLib:
                    {//当双击对象为填充符号时，显示填充符号编辑器
                        soResources objResources = this.axSuperWorkspace1.Resources;
                        soFillStyleLib objFillLib = objResources.FillStyleLib;
                        objFillLib.ShowEditor();
                        ReleaseObjects(objFillLib);
                        ReleaseObjects(objResources);
                        break;
                    }
            }
        }

        private void axSuperLegend1_DblClick(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            soTrackingLayer objTLayer = axSuperMap1.TrackingLayer;//获得跟踪层对象
            objTLayer.ClearEvents(); //清除跟踪层所有几何事件对象
            axSuperMap1.Action = seAction.scaTrackPolyline; //设置当前鼠标状态为在内存中画折线
            ReleaseObjects(objTLayer);
            
            objTLayer = null;
        }

        private void axSuperMap1_DblClick(object sender, EventArgs e)
        {
            //soSelection objSelection = this.axSuperMap1.selection;  //获得选择集;
           // soRecordset objRd = objSelection.ToRecordset(true);    //将选择集转化为记录集;
           // if (objRd.RecordCount > 0) //如果当前有选中的对象
           // {
                string str = "精度：1256.1132，维度：6584.3687\n查看更多属性信息。。。";
             //   for (int i = 1; i <= objRd.FieldCount; i++)//提取所选对象的属性字段信息
              //  {
             //       str += objRd.GetFieldInfo(i).Name; //得到属性字段名称                                                                 
              //      str += ":" + objRd.GetFieldValue(i).ToString() + "\n"; //得到每个字段值                                                   
              //  }
                MessageBox.Show(str, "属性");//弹出一个窗体显示选中对象的所有属性字段值
          //  }
            //objRd.Close(); //关闭记录集

           // ReleaseObjects(objSelection);
          //  ReleaseObjects(objRd);
        }
    }
}
