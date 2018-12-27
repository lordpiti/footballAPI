using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using RazorLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Football.PDFGenerator
{
    public class PDFGeneratorService : IPDFGeneratorService
    {
        private readonly Assembly _assembly;

        public PDFGeneratorService()
        {
            _assembly = Assembly.GetExecutingAssembly();
        }

        private async Task<string> generateHTMLforModel<T>(string resourceRazorViewName, T model)
        {
            var debug = false;

            if (!debug)
            {
                using (Stream stream = _assembly.GetManifestResourceStream(resourceRazorViewName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    var templateKey = Guid.NewGuid().ToString();

                    var engine = new RazorLightEngineBuilder()
                      .UseMemoryCachingProvider()
                      .Build();

                    var parsedTemplate = await engine.CompileRenderAsync(templateKey, result, model);

                    return parsedTemplate;
                }
                    
            }
            else
            {
                //string razorViewPath = "d:\\repos\\spacehivelive-one\\Spacehive.ApplicationServices.PDFGenerator\\Templates\\GrantTermsAndConditions.cshtml";
                //string result = File.ReadAllText(razorViewPath);

                //string templateNameTest = Guid.NewGuid().ToString();

                //var parsedTemplate = Engine.Razor.RunCompile(result, templateNameTest, null, model);

                using (Stream stream = _assembly.GetManifestResourceStream(resourceRazorViewName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string result = reader.ReadToEnd();

                    //    string templateNameTest = Guid.NewGuid().ToString();

                    //    var parsedTemplate = Engine.Razor.RunCompile(result, templateNameTest, null, model);

                    //    return parsedTemplate;
                    var engine = new RazorLightEngineBuilder()
                      .UseMemoryCachingProvider()
                      .Build();

                    var parsedTemplate = await engine.CompileRenderAsync(result, model);

                    return parsedTemplate;
                }
            }
        }

        private XMLParser createXMLParser(List<string> cssResourceNames, Document document, PdfWriter writer)
        {
            var cssStreamList = new DisposableCollection<Stream>();
            var streamReaderList = new DisposableCollection<StreamReader>();
            foreach (var cssFile in cssResourceNames)
            {
                var stream = _assembly.GetManifestResourceStream(cssFile);
                cssStreamList.Add(stream);
            }

            using (cssStreamList)
            {
                foreach (var cssStream in cssStreamList)
                {
                    var streamReader = new StreamReader(cssStream);
                    streamReaderList.Add(streamReader);
                }


                using (streamReaderList)
                {
                    var cssStringContentList = new List<string>();

                    foreach (var streamReader in streamReaderList)
                    {
                        var cssStringContent = streamReader.ReadToEnd();
                        cssStringContentList.Add(cssStringContent);
                    }


                    //create the default Font provider, this should load all font in the windows/fonts folder but sometimes we will need fonts which are not installed in the server
                    XMLWorkerFontProvider xmlWorkerFontProvider = new XMLWorkerFontProvider();

                    var htmlContext = new HtmlPipelineContext(new CssAppliersImpl());

                    #region replace default image tag processor

                    //Replace the default image tag processor for another one which will process base64 images and will set the image to have a circle shape if relevant

                    var tagProcessors = (DefaultTagProcessorFactory)Tags.GetHtmlTagProcessorFactory();
                    tagProcessors.RemoveProcessor(HTML.Tag.IMG); // remove the default processor for img tags
                    tagProcessors.AddProcessor(iTextSharp.tool.xml.html.HTML.Tag.IMG, new CustomImageTagProcessor(writer)); // use the base64 img tag processor

                    htmlContext.SetAcceptUnknown(true).AutoBookmark(true).SetTagFactory(tagProcessors);

                    #endregion


                    //htmlContext.SetTagFactory(iTextSharp.tool.xml.html.Tags.GetHtmlTagProcessorFactory());
                    var cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(true);

                    foreach (var cssStringContent in cssStringContentList)
                    {
                        cssResolver.AddCss(cssStringContent, true);
                    }

                    var pipeline = new CssResolverPipeline(cssResolver,
                                new HtmlPipeline(htmlContext,
                                    new PdfWriterPipeline(document, writer)));

                    XMLWorker worker = new XMLWorker(pipeline, true);

                    var p = new XMLParser(worker);

                    return p;
                }
            }
        }


        public async Task<MemoryStream> GenerateMatchReportPDF<T>(T reportData)
        {
            var resourceNameForRazorTemplate = "Football.PDFGenerator.Templates.MatchReport.cshtml";
            var resourceNameForCSSfile = "Football.PDFGenerator.css.bootstrap.css";
            //var resourceNameForCSSfile2 = "Spacehive.ApplicationServices.PDFGenerator.css.termsAndConditions.css";

            var ms = new MemoryStream();
            //To create a PDF document, create an instance of the class Document and pass the page size and the page margins to the constructor.Then use that object and the file stream to create the PdfWriter instance enabling us to output text and other elements to the PDF file.

            // Create an instance of the document class which represents the PDF document itself.
            var document = new Document(PageSize.A4, 25, 25, 30, 30);

            // Create an instance to the PDF file by creating an instance of the PDF 
            // Writer class using the document and the filestrem in the constructor.
            var writer = PdfWriter.GetInstance(document, ms);

            //A good thing is always to add meta information to files, this does it easier to index the file in a proper way.You can easilly add meta information by using these methods. (NOTE: This is optional, you don't have to do it, just keep in mind that it's good to do it!)

            // Add meta information to the document
            document.AddAuthor("Pablo");
            document.AddCreator("Pablo");
            //document.AddKeywords("PDF tutorial education");
            //document.AddSubject("Document subject - Describing the steps creating a PDF document");
            document.AddTitle("Match report");

            //Before we can write to the document, we need to open it.

            // Open the document to enable you to write to the document
            document.Open();

            PdfContentByte cb = writer.DirectContent;

            #region HTML

            var example_html = await generateHTMLforModel(resourceNameForRazorTemplate, reportData);

            //In order to read CSS as a string we need to switch to a different constructor
            //that takes Streams instead of TextReaders.
            //Below we convert the strings into UTF8 byte array and wrap those in MemoryStreams

            using (var msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_html)))
            {
                // var p = createXMLParser(new List<string>() { resourceNameForCSSfile, resourceNameForCSSfile2 }, document, writer);
                var p = createXMLParser(new List<string>() { resourceNameForCSSfile }, document, writer);
                p.Parse(msHtml);

                //There is a way to parse HTML and CSS in one line, however, when parsing the whole thing, the user agent css styles for
                //the browser (like for example to display bulletpoints) won't be included

                #region Simple way to parse HTML and CSS in one line, don't remove it just in case

                //using (var msCss = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_css)))
                //{
                //Parse the HTML
                //XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, msHtml, msCss);
                //}

                #endregion

            }

            #endregion

            // Close the document
            document.Close();
            // Close the writer instance
            writer.Close();
            // Always close open filehandles explicity
            ms.Close();

            return ms;
        }
    }
}
