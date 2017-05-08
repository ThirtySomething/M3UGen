using System;
using System.Reflection;
using System.Text;

namespace net
{
    namespace derpaul
    {
        namespace utility
        {
            namespace m3ugen
            {
                /// <summary>
                /// Helper class
                /// </summary>
                public class Debug
                {
                    /// <summary>
                    /// Helper method to display object properties
                    /// </summary>
                    /// <param name="objObject">object do display information</param>
                    /// <returns>string</returns>
                    public static string DisplayObjectInfo(Object objObject)
                    {
                        StringBuilder objStringBuilder = new StringBuilder();

                        Type objType = objObject.GetType();
                        objStringBuilder.Append("Type: " + objType.Name);

                        objStringBuilder.Append("\r\n\r\nFields:");
                        FieldInfo[] arrFieldInfo = objType.GetFields();
                        if (0 < arrFieldInfo.Length)
                        {
                            foreach (FieldInfo objFieldInfo in arrFieldInfo)
                            {
                                objStringBuilder.Append("\r\n " + objFieldInfo.ToString() + " = " + objFieldInfo.GetValue(objObject));
                            }
                        }
                        else
                        {
                            objStringBuilder.Append("\r\n None");
                        }

                        objStringBuilder.Append("\r\n\r\nProperties:");
                        PropertyInfo[] arrPropertyInfo = objType.GetProperties();
                        if (0 < arrPropertyInfo.Length)
                        {
                            foreach (PropertyInfo objPropertyInfo in arrPropertyInfo)
                            {
                                objStringBuilder.Append("\r\n " + objPropertyInfo.ToString() + " = " + objPropertyInfo.GetValue(objObject, null));
                            }
                        }
                        else
                        {
                            objStringBuilder.Append("\r\n None");
                        }

                        return objStringBuilder.ToString();
                    }
                }
            }
        }
    }
}
