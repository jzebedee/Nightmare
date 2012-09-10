#region Legal
/*
"BlackMagic" Copyright 2008 Shynd
Copyright 2009 scorpion

This file is part of N2.

N2 is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

N2 is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with N2.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;

namespace Utils
{
    public static class Helper
    {
        public static readonly Assembly Product = Assembly.GetEntryAssembly();
        public static readonly string
            ProductName = Product.GetName().Name,
            ProductPath = Product.Location,
            ProductID = Product.FullName,
            BaseDir = AppDomain.CurrentDomain.BaseDirectory;

        public static string FixPath(string path)
        {
            if (!Path.IsPathRooted(path))
                return Path.Combine(Helper.BaseDir, path);
            return path;
        }

        private static List<string> contents;
        public static List<string> GetContents(string path, bool empty = true)
        {
            if (empty)
                contents = new List<string>();
            string[] files = Directory.GetFiles(path);
            string[] folds = Directory.GetDirectories(path);
            foreach (string file in files) contents.Add(file);
            foreach (string fold in folds)
            {
                contents.Add(fold);
                GetContents(fold, false);
            }
            return contents;
        }

        public static string GetTemporaryFilePath()
        {
            return Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        }

        [DllImport("user32.dll", EntryPoint = "PostMessage")]
        public static extern bool PostMessage(IntPtr hWnd, uint msg, uint wParam, uint lParam);

        public static double NegativeAngle(double angle)
        {
            if (angle < 0) angle += Math.PI * 2;
            return angle;
        }

        public static bool InputBox(string Caption, string Message, out string EnteredText)
        {
            bool OK = false;

            var inputbox = new Window { Title = Caption, };

            var panel = new StackPanel { Orientation = Orientation.Vertical };

            panel.Children.Add(new TextBlock { Text = Message });

            var enteredbox = new TextBox();
            panel.Children.Add(enteredbox);

            var buttonPanel = new StackPanel { Orientation = Orientation.Horizontal };

            var btnOK = new Button { Content = "OK" };
            btnOK.Click += (s, e) => { OK = true; inputbox.Close(); };

            var btnCancel = new Button { Content = "Cancel" };
            btnCancel.Click += (s, e) => inputbox.Close();

            buttonPanel.Children.Add(btnOK);
            buttonPanel.Children.Add(btnCancel);

            panel.Children.Add(buttonPanel);

            inputbox.Content = panel;

            inputbox.ShowDialog();

            EnteredText = enteredbox.Text;
            return OK;
        }

        #region FindChild and FildChildInTab
        /// <summary>
        /// Finds a Child of a given item in the visual tree. 
        /// </summary>
        /// <param name="parent">A direct parent of the queried item.</param>
        /// <typeparam name="T">The type of the queried item.</typeparam>
        /// <param name="childName">x:Name or Name of child. </param>
        /// <returns>The first parent item that matches the submitted type parameter. 
        /// If not matching item can be found, a null parent is being returned.</returns>
        public static T FindChildInTab<T>(DependencyObject parent, string childName = null)
           where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            var frameworkParent = parent as FrameworkElement;
            if (frameworkParent != null && frameworkParent.Name == childName)
            {
                return (T)parent;
            }


            var tabParent = parent as TabControl;
            var tabItemParent = parent as TabItem;
            if (tabParent != null)
            {
                foreach (var item in tabParent.Items)
                {
                    var tab = item as TabItem;
                    if (tab != null)
                    {
                        foundChild = FindChildInTab<T>(tab, childName);
                    }
                    if (foundChild != null)
                        break;
                }
            }
            else if (tabItemParent != null)
            {
                foundChild = FindChildInTab<T>(tabItemParent.Content as FrameworkElement, childName);
            }
            else
            {

                int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < childrenCount; i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i);
                    // If the child is not of the request child type child
                    T childType = child as T;

                    var named = child as FrameworkElement;
                    if (named != null)
                    {
                        if (named.Name == childName)
                        {
                            foundChild = (T)child;
                            break;
                        }
                    }


                    // recursively drill down the tree
                    foundChild = FindChildInTab<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null)
                        break;
                }

            }

            return foundChild;
        }

        /// <summary>
        /// Finds a Child of a given item in the visual tree. 
        /// </summary>
        /// <param name="parent">A direct parent of the queried item.</param>
        /// <typeparam name="T">The type of the queried item.</typeparam>
        /// <param name="childName">x:Name or Name of child. </param>
        /// <returns>The first parent item that matches the submitted type parameter. 
        /// If not matching item can be found, a null parent is being returned.</returns>
        public static T FindChild<T>(DependencyObject parent, string childName = null)
           where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }

        /// <summary>
        /// Finds a Child of a given item in the visual tree, using a given condition.
        /// </summary>
        /// <param name="parent">A direct parent of the queried item.</param>
        /// <typeparam name="T">The type of the queried item.</typeparam>
        /// <param name="childName">x:Name or Name of child. </param>
        /// <returns>The first parent item that matches the submitted type parameter. 
        /// If not matching item can be found, a null parent is being returned.</returns>
        public static T FindChildSearch<T>(DependencyObject parent, Func<T, bool> condition)
           where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChildSearch<T>(child, condition);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else
                {
                    // child element of type found.
                    var castChild = (T)child;

                    if (condition(castChild))
                    {
                        foundChild = castChild;
                        break;
                    }
                }
            }

            return foundChild;
        }
        #endregion

        public static SortedDictionary<T, string> ToDictionary<T>(this Enum enm)
        {
            var enum_type = enm.GetType();

            var names = Enum.GetNames(enum_type);
            var values = Enum.GetValues(enum_type).Cast<T>().ToList();

            var retdict = new SortedDictionary<T, string>();
            for (int i = 0; i < names.Length; i++)
                retdict.Add(values[i], names[i]);

            return retdict;
        }
        public static SortedDictionary<int, string> ToDictionary(this Enum enm)
        {
            return ToDictionary<int>(enm);
        }

        #region GetEmbeddedFile
        public static Stream GetEmbeddedFile(System.Reflection.Assembly assembly, string fileName)
        {
            string assemblyName = assembly.GetName().Name;
            return GetEmbeddedFile(assemblyName, fileName);
        }

        public static Stream GetEmbeddedFile(Type type, string fileName)
        {
            string assemblyName = type.Assembly.GetName().Name;
            return GetEmbeddedFile(assemblyName, fileName);
        }

        public static XmlDocument GetEmbeddedXml(Type type, string fileName)
        {
            Stream str = GetEmbeddedFile(type, fileName);
            XmlTextReader tr = new XmlTextReader(str);
            XmlDocument xml = new XmlDocument();
            xml.Load(tr);
            return xml;
        }
        /// <summary>
        /// Extracts an embedded file out of a given assembly.
        /// </summary>
        /// <param name="assemblyName">The namespace of you assembly.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>A stream containing the file data.</returns>
        public static Stream GetEmbeddedFile(string assemblyName, string fileName)
        {
            try
            {
                System.Reflection.Assembly a = System.Reflection.Assembly.Load(assemblyName);
                Stream str = a.GetManifestResourceStream(assemblyName + "." + fileName);

                if (str == null)
                    throw new Exception("Could not locate embedded resource '" + fileName + "' in assembly '" + assemblyName + "'");
                return str;
            }
            catch (Exception e)
            {
                throw new Exception(assemblyName + ": " + e.Message);
            }
        }
        #endregion
    }
}