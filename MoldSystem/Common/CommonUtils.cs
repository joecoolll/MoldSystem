using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;
using System.Xml.Linq;
using DevExpress.Web;
using System.Data;
using System.Reflection;

namespace Common
{
    public static class CommonUtils
    {
        const char SerializedStringArraySeparator = '|';
        const string StateHiddenFieldContextKey = "216A8C03-7A8A-4735-8CBB-4C62E0D4D23C";


        public static HttpContext Context { get { return HttpContext.Current; } }

        static ASPxHiddenField StateHiddenField
        {
            get { return  Context.Items[StateHiddenFieldContextKey] as ASPxHiddenField; }
            set { Context.Items[StateHiddenFieldContextKey] = value; }
        }


        public static List<T> ConvertToDoList<T>(DataTable pDataTable) where T : new()
        {
            try
            {
                List<T> lst = new List<T> { };
                if (pDataTable != null)
                {
                    foreach (DataRow row in pDataTable.Rows)
                    {
                        T obj = new T();
                        ConvertToDo(obj, row);

                        lst.Add(obj);
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private static void ConvertToDo(object pObjectDo, DataRow pRowValue)
        {
            try
            {
                if (pObjectDo != null && pRowValue != null)
                {
                    foreach (PropertyInfo property in pObjectDo.GetType().GetProperties())
                    {
                        if (pRowValue.Table.Columns.IndexOf(property.Name) > -1)
                        {
                            bool bIsFoundItem = false;
                            Type columnType = pRowValue[property.Name].GetType();
                            if (property.PropertyType == columnType)
                                bIsFoundItem = true;
                            //else if (property.PropertyType != typeof(string)
                            //            && property.PropertyType.GetProperties().Length > 1) //If Nullable will check in this condition.
                            else if (property.PropertyType.Name == "Nullable`1")
                            {
                                //Property[0] is integer.
                                //Property[1] is type of nullable (Nullable<type>)
                                if (property.PropertyType.GetProperties()[1].PropertyType == columnType)
                                    bIsFoundItem = true;
                                else if (property.PropertyType.GetProperties()[1].PropertyType == typeof(int)
                                            && (columnType == typeof(Byte) || columnType == typeof(Int16))) //For TinyInt
                                {
                                    bIsFoundItem = false;
                                    pObjectDo.GetType().GetProperty(property.Name).SetValue(pObjectDo, Convert.ToInt32(pRowValue[property.Name]), null);
                                }
                            }

                            if (bIsFoundItem == true)
                                pObjectDo.GetType().GetProperty(property.Name).SetValue(pObjectDo, pRowValue[property.Name], null);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<string> DeserializeCallbackArgs(string data)
        {
            List<string> items = new List<string>();
            if (!string.IsNullOrEmpty(data))
            {
                int currentPos = 0;
                int dataLength = data.Length;
                while (currentPos < dataLength)
                {
                    string item = DeserializeStringArrayItem(data, ref currentPos);
                    items.Add(item);
                }
            }
            return items;
        }
        static string DeserializeStringArrayItem(string data, ref int currentPos)
        {
            int indexOfFirstSeparator = data.IndexOf(SerializedStringArraySeparator, currentPos);
            string itemLengthString = data.Substring(currentPos, indexOfFirstSeparator - currentPos);
            int itemLength = Int32.Parse(itemLengthString);
            currentPos += itemLengthString.Length + 1;
            string item = data.Substring(currentPos, itemLength);
            currentPos += itemLength;
            return item;
        }
        public static void RegisterStateHiddenField(ASPxHiddenField hf)
        {
            StateHiddenField = hf;
        }

    }
}
