using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Markdig;
using Markdig.Extensions.MediaLinks;
using Markdig.Parsers;
using Markdig.Renderers;
using Markdig.Renderers.Html;
using Markdig.Syntax;

namespace Discuzit.Shared
{
    public class MarkdownRenderer
    {
        MarkdownPipeline _pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .UseBootstrap()
            .Build();

        public string RenderHtmlFromMd(string mdString)
        {
            var result = Markdown.ToHtml(mdString, _pipeline);
            return result;
        }
    }
}