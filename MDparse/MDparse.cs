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
                // http://geekswithblogs.net/BlackRabbitCoder/archive/2010/07/22/c-fundamentals-combining-enum-values-with-bit-flags.aspx
                // iterate through each letter, setting mode after checking for an event
                for (int i = 0; i < letters.Count; i++)
                {
                    // cache current
                    char c = letters[i];
                    // get last mode
                    TagFlags lastMode = TagFlags.None;
                    if (i > 0)
                        lastMode = flags[i];
                    // check our mode against our current char
                    switch (lastMode)
                    {
                        // this is the mode that we were in when we started this letter.
                        case TagFlags.CodeBlock:

                            break;
                        case TagFlags.Comment:

                            break;
                        case TagFlags.Em:

                            break;
                        case TagFlags.Header:

                            break;
                        case TagFlags.HtmlTag:

                            break;
                        case TagFlags.Link:

                            break;
                        case TagFlags.List:

                            break;
                        case TagFlags.ListItem:

                            break;
                        case TagFlags.Mono:

                            break;
                        case TagFlags.Paragraph:

                            break;
                        case TagFlags.Strike:

                            break;
                        case TagFlags.Strong:

                            break;
                        default:
                            xamlOutput += c;
                            break;
                    }
                    flags[i] = TagFlags.None;
                    // set our mode and move on
                }
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
            CodeBlock = 1,
            Comment = 2,
            Em = 4,
            Header = 8,
            HtmlTag = 16,
            Link = 32,
            List = 64,
            ListItem = 128,
            Mono = 256,
            Paragraph = 512,
            Strike = 1024,
            Strong = 2048
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
