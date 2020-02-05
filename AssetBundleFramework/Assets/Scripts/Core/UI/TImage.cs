﻿/*
 * Description:             TImage.cs
 * Author:                  TONYTANG
 * Create Date:             2020//02/05
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TUI
{
    /// <summary>
    /// TImage.cs
    /// 重写Image组件，方便资源管理和自定义一些特性
    /// Note:
    /// 默认在编辑器赋值的通过依赖加载的不提供资源信息接口(ABI),
    /// 避免依赖当前TImage组件卸载时发现资源被提前卸载
    /// </summary>
    public class TImage : Image
    {
        /// <summary>
        /// 资源引用信息
        /// </summary>
        public AbstractResourceInfo ABI
        {
            get;
            set;
        }

        /// <summary>
        /// 当前图片图集名
        /// </summary>
        [HideInInspector]
        public string AtlasName;

        /// <summary>
        /// 当前图片名
        /// </summary>
        [HideInInspector]
        public string SpriteName;

        /// <summary>
        /// 打印当前TImage图集使用信息
        /// </summary>
        public void printTImageInfo()
        {
            DIYLog.Log($"AtlasName = {AtlasName} SpriteName = {SpriteName}");
            var refcount = ABI != null ? ABI.RefCount.ToString() : "无";
            DIYLog.Log($"AtlasName引用计数 = {refcount}");
        }
    }
}