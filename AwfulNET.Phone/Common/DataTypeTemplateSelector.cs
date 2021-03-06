﻿using AwfulNET.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
#if NETFX_CORE
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#endif

namespace AwfulNET.Common
{
    public class DataTypeTemplateSelector : DataTemplateSelector
    {
        private List<DataTypeTemplate> items = new List<DataTypeTemplate>();
        public List<DataTypeTemplate> Items
        {
            get { return items; }
            set { items = value; }
        }

        public DataTemplate DefaultTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object content, DependencyObject container)
        {
            ICommonDataModel model = content as ICommonDataModel;
            if (model == null)
                return null;

            var selected = items.SingleOrDefault(item => item.DataType.Equals(model.DataType));
            if (selected != null)
                return selected;


            return DefaultTemplate;
        }
    }

    public sealed class DataTypeTemplate : DataTemplate
    {
        public string DataType { get; set; }
    }
}
