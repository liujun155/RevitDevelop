using DotNet.REVIT.External;
using RevitDevelop.Command.Low;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitDevelop.ViewModel
{
    public class MainViewModel
    {
        #region 初级
        /// <summary>
        /// 加载族
        /// </summary>
        public RevitCommand LoadFamily { get; set; }
        /// <summary>
        /// 创建族实例
        /// </summary>
        public RevitCommand CreateInstance { get; set; }
        /// <summary>
        /// 获取实例参数
        /// </summary>
        public RevitCommand GetParameter { get; set; }
        /// <summary>
        /// 修改实例参数
        /// </summary>
        public RevitCommand EditParameter { get; set; }
        /// <summary>
        /// 过滤族实例
        /// </summary>
        public RevitCommand FilterInstance { get; set; }
        public RevitCommand CreateLine { get; set; }
        public RevitCommand MoveElem { get; set; }
        public RevitCommand RotateElem { get; set; }
        #endregion

        public MainViewModel()
        {
            LoadFamily = new CmdLoadFamily();
            CreateInstance = new CmdCreateInstance();
            GetParameter = new CmdGetParameter();
            EditParameter = new CmdEditParameter();
            FilterInstance = new CmdFilterInstance();
        }
    }
}
