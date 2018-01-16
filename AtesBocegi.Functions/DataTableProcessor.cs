using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AtesBocegi.Models.DataTables;

namespace AtesBocegi.Functions
{
    public class DataTableProcessor<T>
    {

        public static IEnumerable<T> ProcessCollection(IEnumerable<T> lstElements, DataTablePostModel dataTableModel)
        {
            var skip = dataTableModel.start;
            var pageSize = dataTableModel.length;

            if (dataTableModel.order != null)
            {
                if (dataTableModel.order[0].column.ToString() != null)
                {
                    var columnName = dataTableModel.columns[dataTableModel.order[0].column].data;
                    var sortDirection = dataTableModel.order[0].dir.ToLower();
                    if (columnName != null)
                    {
                        var order = CreateGetter(typeof(T), columnName);
                        if (sortDirection == "asc")
                        {
                            lstElements = lstElements.OrderBy(o => order(o));
                        }
                        else
                        {
                            lstElements = lstElements.OrderByDescending(o => order(o));
                        }
                        if (pageSize > 0)
                        {
                            return lstElements.Skip(skip).Take(pageSize);
                        }
                        else
                        {
                            return lstElements;
                        }
                    }
                }
            }
            return null;
        }
        private PropertyInfo getProperty(string name)
        {
            var properties = typeof(T).GetProperties();
            PropertyInfo prop = null;
            foreach (var item in properties)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    prop = item;
                    break;
                }
            }
            return prop;
        }

        public static Func<object, object> CreateGetter(Type runtimeType, string propertyName)
        {
            var columnName = propertyName.First().ToString().ToUpper() + propertyName.Substring(1);
            var propertyInfo = runtimeType.GetProperty(columnName);

            // create a parameter (object obj)
            var obj = Expression.Parameter(typeof(object), "obj");

            // cast obj to runtimeType
            var objT = Expression.TypeAs(obj, runtimeType);

            // property accessor
            var property = Expression.Property(objT, propertyInfo);

            var convert = Expression.TypeAs(property, typeof(object));
            return (Func<object, object>)Expression.Lambda(convert, obj).Compile();
        }
    }
}
