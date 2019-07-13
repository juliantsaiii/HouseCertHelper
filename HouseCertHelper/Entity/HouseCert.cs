using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseCertHelper.Entity
{
    /// <summary>
    /// 房产信息实体类
    /// </summary>
    public class HouseCert
    {
        //房产证号
        public string HouseID { get; set; }
        //权利人
        public string ChargePeople { get; set; }
        //共有情况
        public string ShareCondition { get; set; }
        //坐落
        public string Position { get; set; }
        //登记时间
        public string RegisterTime { get; set; }
        //房屋性质
        public string HousePropertity { get; set; }
        //房屋用途
        public string HousePurpose { get; set; }
        //建筑面积
        public string HouseArea { get; set; }
        //土地权利性质/取得方式
        public string PlaceProperty { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string 房产证号 { get; set; }
        /// <summary>
        /// 王刚礼张洪梅
        /// </summary>
        public string 权利人 { get; set; }
        /// <summary>
        /// 共同共有
        /// </summary>
        public string 共有情况 { get; set; }
        /// <summary>
        /// 江宁区东山街道湖山北路95号武夷水岸家园14幢402室
        /// </summary>
        public string 坐落 { get; set; }
        /// <summary>
        /// 2015年04月22日
        /// </summary>
        public string 登记时间 { get; set; }
        /// <summary>
        /// 私有疾产
        /// </summary>
        public string 房屋性质 { get; set; }
        /// <summary>
        /// 成套柱宅
        /// </summary>
        public string 房屋用途 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 建筑面积 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 土地权利性质_取得方式 { get; set; }
}

    public class Root
{
    /// <summary>
    /// 
    /// </summary>
    public string sid { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Data data { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int angle { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int height { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int width { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int orgHeight { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int orgWidth { get; set; }
}
}
