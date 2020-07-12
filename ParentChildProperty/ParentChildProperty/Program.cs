#region Library
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Automation;
#endregion

namespace ParentChildProperty
{
    class Program 
    {
        static AutomationElement FindElementById(AutomationElement rootElement, string automationId) 
        {
            return rootElement.FindFirst(TreeScope.Element | TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));
        }

        #region FindElementsByName
        /*
         static IEnumerable<AutomationElement> FindElementsByName(AutomationElement rootElement, string name) {
            return rootElement.FindAll(
                TreeScope.Element | TreeScope.Descendants,
                new PropertyCondition(AutomationElement.NameProperty, name))
                .Cast<AutomationElement>();
        }

        static IEnumerable<AutomationElement> FindButtonsByName(AutomationElement rootElement, string name) {
            const string BUTTON_CLASS_NAME = "Button";
            return from x in FindElementsByName(rootElement, name)
                   where x.Current.ClassName == BUTTON_CLASS_NAME
                   select x;
        }*/
        #endregion

        static void Main(string[] args) 
        {
            try
            {

                if (Process.GetProcessesByName("explorer.exe").Count() <= 0)
                {
                    Console.WriteLine("Launch explorer");
                }

                var mainForm = AutomationElement.FromHandle(Process.GetProcessesByName("explorer").First().MainWindowHandle);
                AutomationElement elementNode = TreeWalker.ControlViewWalker.GetFirstChild(mainForm);
                Console.WriteLine("--------------Parent----------------");
                Console.WriteLine("ClassName: {0}", mainForm.Current.ClassName);
                Console.WriteLine("Name: {0}", mainForm.Current.Name);
                Console.WriteLine("IsContentElement: {0}", mainForm.Current.IsContentElement);
                Console.WriteLine("IsControlElement: {0}", mainForm.Current.IsControlElement);
                Console.WriteLine("HasKeyboardFocus: {0}", mainForm.Current.HasKeyboardFocus);
                Console.WriteLine("AcceleratorKey: {0}", mainForm.Current.AcceleratorKey);
                Console.WriteLine("AccessKey: {0}", mainForm.Current.AccessKey);
                Console.WriteLine("AutomationId: {0}", mainForm.Current.AutomationId);
                Console.WriteLine("BoundingRectangle: {0}", mainForm.Current.BoundingRectangle);
                Console.WriteLine("ControlType: {0}", mainForm.Current.ControlType);
                Console.WriteLine("FrameworkId: {0}", mainForm.Current.FrameworkId);
                Console.WriteLine("HelpText: {0}", mainForm.Current.HelpText);
                Console.WriteLine("IsEnabled: {0}", mainForm.Current.IsEnabled);
                Console.WriteLine("IsKeyboardFocusable: {0}", mainForm.Current.IsKeyboardFocusable);
                Console.WriteLine("IsOffscreen: {0}", mainForm.Current.IsOffscreen);
                Console.WriteLine("IsPassword: {0}", mainForm.Current.IsPassword);
                Console.WriteLine("IsRequiredForForm: {0}", mainForm.Current.IsRequiredForForm);
                Console.WriteLine("ItemStatus: {0}", mainForm.Current.ItemStatus);
                Console.WriteLine("ItemType: {0}", mainForm.Current.ItemType);
                Console.WriteLine("LabeledBy: {0}", mainForm.Current.LabeledBy);
                Console.WriteLine("LocalizedControlType: {0}", mainForm.Current.LocalizedControlType);
                Console.WriteLine("NativeWindowHandle: {0}", mainForm.Current.NativeWindowHandle);
                Console.WriteLine("Orientation: {0}", mainForm.Current.Orientation);
                Console.WriteLine("ProcessId: {0}", mainForm.Current.ProcessId);
                Console.WriteLine();

                #region Comment
                /*
            var btnClear = FindElementsByName(mainForm, "").First();
            Console.WriteLine(btnClear.Current.NativeWindowHandle);

            var xx = btnClear.FindAll(TreeScope.Children | TreeScope.Descendants,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button));

            var xx = FindElementsByName(mainForm, "");

            WalkControlElements(mainForm);
            Console.WriteLine(xx.Count());
            Console.WriteLine(xx.Current.NativeWindowHandle);
            */
                #endregion

                Console.WriteLine("--------------Child----------------");
                while (elementNode != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Name: {0}", elementNode.Current.Name);
                    Console.WriteLine("LocalizedControlType: {0}", elementNode.Current.ControlType.LocalizedControlType);
                    Console.WriteLine("ClassName: {0}", elementNode.Current.ClassName);
                    Console.WriteLine("IsContentElement: {0}", elementNode.Current.IsContentElement);
                    Console.WriteLine("IsControlElement: {0}", elementNode.Current.IsControlElement);
                    Console.WriteLine("HasKeyboardFocus: {0}", elementNode.Current.HasKeyboardFocus);
                    Console.WriteLine("AcceleratorKey: {0}", elementNode.Current.AcceleratorKey);
                    Console.WriteLine("AccessKey: {0}", elementNode.Current.AccessKey);
                    Console.WriteLine("AutomationId: {0}", elementNode.Current.AutomationId);
                    Console.WriteLine("BoundingRectangle: {0}", elementNode.Current.BoundingRectangle);
                    Console.WriteLine("ControlType: {0}", elementNode.Current.ControlType);
                    Console.WriteLine("FrameworkId: {0}", elementNode.Current.FrameworkId);
                    Console.WriteLine("HelpText: {0}", elementNode.Current.HelpText);
                    Console.WriteLine("IsEnabled: {0}", elementNode.Current.IsEnabled);
                    Console.WriteLine("IsKeyboardFocusable: {0}", elementNode.Current.IsKeyboardFocusable);
                    Console.WriteLine("IsOffscreen: {0}", elementNode.Current.IsOffscreen);
                    Console.WriteLine("IsPassword: {0}", elementNode.Current.IsPassword);
                    Console.WriteLine("IsRequiredForForm: {0}", elementNode.Current.IsRequiredForForm);
                    Console.WriteLine("ItemStatus: {0}", elementNode.Current.ItemStatus);
                    Console.WriteLine("ItemType: {0}", elementNode.Current.ItemType);
                    Console.WriteLine("LabeledBy: {0}", elementNode.Current.LabeledBy);
                    Console.WriteLine("LocalizedControlType: {0}", elementNode.Current.LocalizedControlType);
                    Console.WriteLine("NativeWindowHandle: {0}", elementNode.Current.NativeWindowHandle);
                    Console.WriteLine("Orientation: {0}", elementNode.Current.Orientation);
                    Console.WriteLine("ProcessId: {0}", elementNode.Current.ProcessId);
                    
                    Console.WriteLine();
                    elementNode = TreeWalker.ControlViewWalker.GetNextSibling(elementNode);
                }
                

                Console.WriteLine();
                //WalkControlElements(mainForm);
                Console.WriteLine();
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();

            }
        }

        #region Comment
        /* static void WalkControlElements(AutomationElement element) {
            AutomationElement elementNode = TreeWalker.ControlViewWalker.GetFirstChild(element);
            Console.WriteLine("Name: {0}",elementNode.Current.Name);

            while(elementNode != null) {
                Console.WriteLine("LocalizedControlType: {0}",elementNode.Current.ControlType.LocalizedControlType);
                WalkControlElements(elementNode);
                elementNode = TreeWalker.ControlViewWalker.GetNextSibling(elementNode);
            }
        }*/
        #endregion
    }
}
