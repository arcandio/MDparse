using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDparse
{
    public class MDparser
    {
        public static string GetXamlFromMD(string mdInput)
        {
            // set up variables
            List<char> letters;
            List<TagFlags> flags;
            string xamlOutput = "";
            // if we have a valid input
            if (mdInput != null && mdInput.Length > 0)
            {
                // rip input into chars
                letters = mdInput.ToCharArray().ToList<char>();
                flags = new List<TagFlags>();
                foreach (char c in letters)
                {
                    flags.Add(TagFlags.None);
                }
                int lastNewline = 0;
                #region Mode Setting
                // http://geekswithblogs.net/BlackRabbitCoder/archive/2010/07/22/c-fundamentals-combining-enum-values-with-bit-flags.aspx
                // iterate through each letter, setting mode after checking for an event
                for (int i = 0; i < letters.Count; i++)
                {
                    // cache current
                    char c = letters[i];
                    // cache last
                    char? l = null;
                    if(i > 0)
                        l = letters[i - 1];
                    // get last mode
                    TagFlags lastMode = TagFlags.None;
                    TagFlags thisMode = TagFlags.None;
                    if (i > 0)
                        lastMode = flags[i - 1];
                    // check our mode against our current char
                    if (lastMode == TagFlags.None)
                    {
                        // NO LAST FLAG
                        //thisMode = TagFlags.None;
                        if (c == '\n' || c == '\r')
                            thisMode = TagFlags.None;
                        else if (c == '#' || c == '=')
                            thisMode = TagFlags.Header;
                        else if (c == '>' || c == ' ' || c == '\t')
                            thisMode = TagFlags.Block;
                        else if (c == '-')
                            thisMode = TagFlags.Separator;
                        else if (c == '`')
                            thisMode = TagFlags.CodeBlock;
                        else if (c == '<')
                            thisMode = TagFlags.Comment;
                        else
                            thisMode = TagFlags.Paragraph;

                        
                    }
                    else
                    {
                        thisMode = TagFlags.Paragraph;
                        if (c == '\n' || c == '\r')
                            thisMode = TagFlags.None;
                    }

                    //xamlOutput += c;
                    flags[i] = thisMode;
                    // set our mode and move on
                    string r = c.ToString();
                    if (r == "\n" || r == "\r")
                        r = "\tnewline";
                    if (r == " ")
                        r = "\tspace";
                    System.Diagnostics.Debug.WriteLine(r + "-" + thisMode.ToString() + "\t\t last mode was: "+lastMode.ToString());
                }
                #endregion
                #region Syntax Insertion

                #endregion
            }
            return xamlOutput;
        }

        // setup xaml tags
        public MDparseTags xamlTags;
        public MDparseTags htmlTags;
        MDparser () 
        {
            xamlTags.headerOpen = "<Paragraph FontSize=\"20\" FontWeight=\"Bold\" Background=\"Orange\">";
            xamlTags.headerClose = "</Paragraph>";

            xamlTags.paragraphOpen = "<Paragraph>";
            xamlTags.paragraphClose = "</Paragraph>";

            xamlTags.listOpen = "<List>";
            xamlTags.listClose = "</List>";
            xamlTags.listItemOpen = "<ListItem>";
            xamlTags.listItemClose = "</ListItem>";

            xamlTags.emOpen = "<Italic Background=\"#330000FF\">";
            xamlTags.emClose = "</Italic>";
            xamlTags.strongOpen = "<Bold Background=\"#660000FF\">";
            xamlTags.strongClose = "</Bold>";
            xamlTags.strikeOpen = "<Strike>";
            xamlTags.strikeClose = "</Strike>";
            xamlTags.monoOpen = "<Span FontFamily=\"Courier New\">";
            xamlTags.monoClose = "</Span>";

            xamlTags.commentOpen = "<Span FontFamily=\"Courier New\" Background=\"#3300FF00\">";
            xamlTags.commentClose = "</Span>";

            xamlTags.codeBlockOpen = "<Span FontFamily=\"Courier New\">";
            xamlTags.codeBlockClose = "</Span>";

            xamlTags.linkOpen = "<Underline Foreground=\"#0000FF\">";
            xamlTags.linkClose = "</Underline>";

            xamlTags.htmlTagOpen = "<Span FontFamily=\"Courier New\" Foreground=\"#0000FF\">";
            xamlTags.htmlTagClose = "</Span>";

            // html tags
            xamlTags.headerOpen = "<Paragraph FontSize=\"20\" FontWeight=\"Bold\" Background=\"Orange\">";
            xamlTags.headerClose = "</Paragraph>";

            xamlTags.paragraphOpen = "<>";
            xamlTags.paragraphClose = "";

            xamlTags.listOpen = "";
            xamlTags.listClose = "";
            xamlTags.listItemOpen = "";
            xamlTags.listItemClose = "";

            xamlTags.emOpen = "<Italic>";
            xamlTags.emClose = "</Italic>";
            xamlTags.strongOpen = "<Bold>";
            xamlTags.strongClose = "</Bold>";
            xamlTags.strikeOpen = "<Strike>";
            xamlTags.strikeClose = "</Strike>";
            xamlTags.monoOpen = "";
            xamlTags.monoClose = "";

            xamlTags.commentOpen = "";
            xamlTags.commentClose = "";

            xamlTags.codeBlockOpen = "";
            xamlTags.codeBlockClose = "";

            xamlTags.linkOpen = "";
            xamlTags.linkClose = "";

            xamlTags.htmlTagOpen = "";
            xamlTags.htmlTagClose = "";
        }
        [Flags]
        public enum TagFlags
        {
            None = 0,
            Emphasis = 1 << 1,
            Header = 1 << 2,
            HtmlTag = 1 << 3,
            Link = 1 << 4,
            ListItem = 1 << 5,
            Mono = 1 << 6,
            Paragraph = 1 << 7,
            Separator = 1 << 8,
            Strike = 1 << 9,
            Strong = 1 << 10,
            Block = 1 << 11,
            CodeBlock = 1 << 12,
            Comment = 1 << 13,
            List = 1 << 14
        }
    }
    public class MDparseTags
    {
        public string headerOpen;
        public string headerClose;

        public string paragraphOpen;
        public string paragraphClose;

        public string listOpen;
        public string listClose;
        public string listItemOpen;
        public string listItemClose;

        public string emOpen;
        public string emClose;

        public string strongOpen;
        public string strongClose;

        public string strikeOpen;
        public string strikeClose;

        public string monoOpen;
        public string monoClose;

        public string commentOpen;
        public string commentClose;

        public string codeBlockOpen;
        public string codeBlockClose;

        public string linkOpen;
        public string linkClose;

        public string htmlTagOpen;
        public string htmlTagClose;

    }
}
