using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA_CHECKER.util
{
    class ProgramUtil
    {

        public static string DataTruncate(string Program) 
        {
            int ProgramBegin = Program.IndexOf("/MN") + 3;
            int ProgramEnd = Program.IndexOf("/POS");
            int ProgramLength = ProgramEnd - ProgramBegin;
            return Program.Substring(ProgramBegin, ProgramLength);
        }


        public static List<string> FindProgramElementByString(string Program,string Element)
        {
            List<string> ElementStrings = new List<string>();

            while (Program.IndexOf(Element) != -1)
            {
                
                int ElementIndex = Program.IndexOf(Element);

                string BeforeElement = Program.Substring(0, ElementIndex);
                string AfterElement = Program.Substring(ElementIndex, Program.Length - 1 - ElementIndex);

                int SemicolonBefore = BeforeElement.LastIndexOf(';');
                int SemicolonAfter = AfterElement.IndexOf(';');
            
                string CommandBefore = BeforeElement.Substring(SemicolonBefore+1, BeforeElement.Length - 1 - SemicolonBefore);
                string CommandAfter = AfterElement.Substring(0, SemicolonAfter);

                string CommandLine = CommandBefore + CommandAfter;
                
                ElementStrings.Add(CommandLine);
                Program = Program.Substring(ElementIndex + Element.Length);
                
            }

            return ElementStrings;
        }

        public static IEnumerable<string>  FindProgramElementByCollection(string Program, string Element)
        {
            List<string> CommandLines = new List<string>(Program.Split(';'));

            IEnumerable<string> SelectedCommandLines = CommandLines.Where(i => i.IndexOf(Element) != -1);
            return SelectedCommandLines;
            //return CommandLines;
        }


    }
}
