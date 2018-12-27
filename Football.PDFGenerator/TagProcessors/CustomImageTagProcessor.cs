namespace Football.PDFGenerator
{
    using iTextSharp.text.pdf;
    using System;
    using System.Collections.Generic;

    public class CustomImageTagProcessor : iTextSharp.tool.xml.html.Image
    {
        private PdfWriter _writer;

        public CustomImageTagProcessor(PdfWriter writer)
        {
            _writer = writer;
        }

        public override IList<iTextSharp.text.IElement> End(iTextSharp.tool.xml.IWorkerContext ctx, iTextSharp.tool.xml.Tag tag, IList<iTextSharp.text.IElement> currentContent)
        {
            IDictionary<string, string> attributes = tag.Attributes;

            string classesList;

            attributes.TryGetValue(iTextSharp.tool.xml.html.HTML.Attribute.CLASS, out classesList);


            string src;
            if (!attributes.TryGetValue(iTextSharp.tool.xml.html.HTML.Attribute.SRC, out src))
                return new List<iTextSharp.text.IElement>(1);

            if (string.IsNullOrEmpty(src))
                return new List<iTextSharp.text.IElement>(1);

            //This is to deal with base64 images, which are the ones that will be used when rendering html in this component
            if (src.StartsWith("data:image/", StringComparison.InvariantCultureIgnoreCase))
            {
                // data:[<MIME-type>][;charset=<encoding>][;base64],<data>
                var base64Data = src.Substring(src.IndexOf(",") + 1);
                var imagedata = Convert.FromBase64String(base64Data);
                var image = iTextSharp.text.Image.GetInstance(imagedata);

                #region circle image

                //PdfContentByte canvas = currentContent.
                //PdfTemplate template = canvas.CreateTemplate(40, 40);
                //template.SetLineWidth(1f);
                //template.Circle(15f, 15f, 15);
                //template.Stroke();

                //If the img element contains the class "img-circle", the image shape will be a circle
                if (classesList != null && classesList.Contains("img-circle"))
                {
                    var minDim = image.Width > image.Height ? image.Height : image.Width;

                    PdfTemplate temp = PdfTemplate.CreateTemplate(_writer, minDim, minDim);
                    temp.Ellipse(0, 0, minDim, minDim);
                    temp.Clip();
                    temp.NewPath();
                    temp.AddImage(image, minDim, 0, 0, minDim, 0, 0);
                    iTextSharp.text.Image clipped = iTextSharp.text.Image.GetInstance(temp);
                    //clipped.Rotation = 180;
                    image = clipped;
                }

                #endregion

                var list = new List<iTextSharp.text.IElement>();
                var htmlPipelineContext = GetHtmlPipelineContext(ctx);
                list.Add(GetCssAppliers().Apply(new iTextSharp.text.Chunk((iTextSharp.text.Image)GetCssAppliers().Apply(image, tag, htmlPipelineContext), 0, 0, true), tag, htmlPipelineContext));
                return list;
            }
            else
            {
                return base.End(ctx, tag, currentContent);
            }
        }
    }
}