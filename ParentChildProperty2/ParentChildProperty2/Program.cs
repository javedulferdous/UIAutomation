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

namespace ParentChildProperty2
{
    class Program
    {
        static AutomationElement FindElementById(AutomationElement rootElement, string automationId)
        {
            return rootElement.FindFirst(TreeScope.Element | TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));
        }
       
        static void Main(string[] args)
        {
            #region Title
            // Set the Title to UI Automation 
            Console.Title = "UI Automation";
            #endregion

            try
            {

                if (Process.GetProcessesByName("notepad.exe").Count() <= 0)
                {
                    Console.WriteLine("Launch notepad");
                }

                var mainForm = AutomationElement.FromHandle(Process.GetProcessesByName("notepad").First().MainWindowHandle);
                WalkControlElements(mainForm);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();

            }
        }
        static void WalkControlElements(AutomationElement element)
        {
            int counter = 0;
            AutomationElement elementNode = TreeWalker.ControlViewWalker.GetFirstChild(element);
            while (elementNode != null)
            {
                Console.WriteLine("{0} Name: {1}",counter+1, elementNode.Current.Name);
                
                WalkControlElements(elementNode);
                elementNode = TreeWalker.ControlViewWalker.GetNextSibling(elementNode);
                counter++;
            }
        }

    }
}
