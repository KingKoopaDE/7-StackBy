using System;
using System.Xml.Linq;

namespace Win7_Plus_StackBy

{
    public class SearchQuerySaver
    {
        public string Path { get; set; }
        public Property Property { get; set; }

        public XDocument SearchMS { get; set; }

        public SearchQuerySaver(string path,Property property)
        {
            Path = path;
            Property = property;
            GenerateSearchMS();
        }

        private void GenerateSearchMS()
        {
            // Create the XML structure
            XDocument searchXML = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("persistedQuery",
                    new XAttribute("version", "1.0"),
                    new XElement("viewInfo",
                        new XAttribute("stackViewMode", "icons"),
                        new XAttribute("stackIconSize", "96"),
                        new XAttribute("displayName", "Searchresults in &quot;"+ System.IO.Path.GetFileName(Path) +"&quot;"),
                        new XAttribute("autoListFlags", "0"),
                        new XElement("visibleColumns",
                            new XElement("column", new XAttribute("viewField", "System.ItemNameDisplay")),
                            new XElement("column", new XAttribute("viewField", "System.DateModified")),
                            new XElement("column", new XAttribute("viewField", "System.ItemType")),
                            new XElement("column", new XAttribute("viewField", "System.ItemFolderPathDisplayNarrow")),
                            new XElement("column", new XAttribute("viewField", "System.Author")),
                            new XElement("column", new XAttribute("viewField", "System.Keywords"))
                        ),
                        new XElement("stackList",
                            // Replace "System.ItemType" with CanonicalName of Property to get Stack :)
                            new XElement("stack", new XAttribute("viewField", Property.CanonicalName))
                        ),
                        new XElement("sortList",
                            // Same for sorting
                            new XElement("sort", new XAttribute("viewField", Property.CanonicalName), new XAttribute("direction", "ascending"))
                        )
                    ),
                    new XElement("query",
                        new XElement("kindList",
                            new XElement("kind", new XAttribute("name", "item"))
                        ),
                        new XElement("providers",
                            new XElement("provider", new XAttribute("clsid", "{88CF4A86-5D7A-48EB-B53E-EA388A390096}"))
                        ),
                        new XElement("scope",
                            new XElement("include", new XAttribute("path", Path))
                        )
                    ),
                    new XElement("properties",
                        new XElement("author", new XAttribute("Type", "string"), Environment.UserName)
                    )
                )
            );

       
            SearchMS = searchXML;
        }

        public override string ToString()
        {
            return SearchMS.ToString();
        }
    }
}
