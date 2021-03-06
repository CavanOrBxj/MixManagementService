﻿
using System;
using Dos.ORM;

namespace MixManagementService.EntityModule
{
    /// <summary>
    /// 实体类TModule。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("moduleinfo")]
    [Serializable]
    public partial class TModule : Entity
    {
        #region Model
        private int _id;
        private string _name;
        private string _path;
        private int _autostart;
        private int _delay;
        private int _state;
        private int _startindex;
        private string _arguments;
        private int _temtype;

        /// <summary>
        /// 
        /// </summary>
        [Field("id")]
        public int id
        {
            get { return _id; }
            set
            {
                this.OnPropertyValueChange("id");
                this._id = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("name")]
        public string name
        {
            get { return _name; }
            set
            {
                this.OnPropertyValueChange("name");
                this._name = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("path")]
        public string path
        {
            get { return _path; }
            set
            {
                this.OnPropertyValueChange("path");
                this._path = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("autostart")]
        public int autostart
        {
            get { return _autostart; }
            set
            {
                this.OnPropertyValueChange("autostart");
                this._autostart = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("delay")]
        public int delay
        {
            get { return _delay; }
            set
            {
                this.OnPropertyValueChange("delay");
                this._delay = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("state")]
        public int state
        {
            get { return _state; }
            set
            {
                this.OnPropertyValueChange("state");
                this._state = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("startindex")]
        public int startindex
        {
            get { return _startindex; }
            set
            {
                this.OnPropertyValueChange("startindex");
                this._startindex = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("arguments")]
        public string arguments
        {
            get { return _arguments; }
            set
            {
                this.OnPropertyValueChange("arguments");
                this._arguments = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("temtype")]
        public int temtype
        {
            get { return _temtype; }
            set
            {
                this.OnPropertyValueChange("temtype");
                this._temtype = value;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        public override Field[] GetPrimaryKeyFields()
        {
            return new Field[] {
                _.id,
            };
        }
        /// <summary>
        /// 获取实体中的标识列
        /// </summary>
        public override Field GetIdentityField()
        {
            return _.id;
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
                _.id,
                _.name,
                _.path,
                _.autostart,
                _.delay,
                _.state,
                _.startindex,
                _.arguments,
                _.temtype,
            };
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
                this._id,
                this._name,
                this._path,
                this._autostart,
                this._delay,
                this._state,
                this._startindex,
                this._arguments,
                this._temtype,
            };
        }
        /// <summary>
        /// 是否是v1.10.5.6及以上版本实体。
        /// </summary>
        /// <returns></returns>
        public override bool V1_10_5_6_Plus()
        {
            return true;
        }
        #endregion

        #region _Field
        /// <summary>
        /// 字段信息
        /// </summary>
        public class _
        {
            /// <summary>
            /// * 
            /// </summary>
            public readonly static Field All = new Field("*", "moduleinfo");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field id = new Field("id", "moduleinfo", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field name = new Field("name", "moduleinfo", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field path = new Field("path", "moduleinfo", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field autostart = new Field("autostart", "moduleinfo", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field delay = new Field("delay", "moduleinfo", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field state = new Field("state", "moduleinfo", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field startindex = new Field("startindex", "moduleinfo", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field arguments = new Field("arguments", "moduleinfo", "");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field temtype = new Field("temtype", "moduleinfo", "");
        }
        #endregion
    }
}