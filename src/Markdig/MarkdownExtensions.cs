﻿// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Markdig.Extensions.Abbreviations;
using Markdig.Extensions.AutoIdentifiers;
using Markdig.Extensions.Bootstrap;
using Markdig.Extensions.Cites;
using Markdig.Extensions.CustomContainers;
using Markdig.Extensions.DefinitionLists;
using Markdig.Extensions.Emoji;
using Markdig.Extensions.EmphasisExtra;
using Markdig.Extensions.Figures;
using Markdig.Extensions.Footers;
using Markdig.Extensions.Footnotes;
using Markdig.Extensions.GenericAttributes;
using Markdig.Extensions.Hardlines;
using Markdig.Extensions.ListExtra;
using Markdig.Extensions.Mathematics;
using Markdig.Extensions.Medias;
using Markdig.Extensions.SmartyPants;
using Markdig.Extensions.Tables;

namespace Markdig
{
    /// <summary>
    /// Provides extension methods for <see cref="MarkdownPipeline"/> to enable several Markdown extensions.
    /// </summary>
    public static class MarkdownExtensions
    {
        /// <summary>
        /// Uses all extensions except the Emoji.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipeline UseAllExtensions(this MarkdownPipeline pipeline)
        {
            return pipeline
                .UseAbbreviation()
                .UseAutoIdentifier()
                .UseBootstrap()
                .UseCite()
                .UseCustomContainer()
                .UseDefinitionList()
                .UseEmphasisExtra()
                .UseFigure()
                .UseFooter()
                .UseFootnotes()
                .UseGridTable()
                .UseMath()
                .UseMedia()
                .UsePipeTable()
                .UseSoftlineBreakAsHardlineBreak()
                .UseSmartyPants()
                .UseGenericAttributes(); // Must be last as it is one parser that is modifying other parsers
        }

        /// <summary>
        /// Uses the custom container extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipeline UseCustomContainer(this MarkdownPipeline pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<CustomContainerExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the media extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// The modified pipeline
        /// </returns>
        public static MarkdownPipeline UseMedia(this MarkdownPipeline pipeline, MediaOptions options = null)
        {
            if (!pipeline.Extensions.Contains<MediaExtension>())
            {
                pipeline.Extensions.Add(new MediaExtension(options));
            }
            return pipeline;
        }

        /// <summary>
        /// Uses the auto-identifier extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// The modified pipeline
        /// </returns>
        public static MarkdownPipeline UseAutoIdentifier(this MarkdownPipeline pipeline, AutoIdentifierOptions options = AutoIdentifierOptions.Default)
        {
            if (!pipeline.Extensions.Contains<AutoIdentifierExtension>())
            {
                pipeline.Extensions.Add(new AutoIdentifierExtension(options));
            }
            return pipeline;
        }

        /// <summary>
        /// Uses the SmartyPants extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// The modified pipeline
        /// </returns>
        public static MarkdownPipeline UseSmartyPants(this MarkdownPipeline pipeline, SmartyPantOptions options = null)
        {
            if (!pipeline.Extensions.Contains<SmartyPantsExtension>())
            {
                pipeline.Extensions.Add(new SmartyPantsExtension(options));
            }
            return pipeline;
        }

        /// <summary>
        /// Uses the boostrap extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipeline UseBootstrap(this MarkdownPipeline pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<BootstrapExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the math extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipeline UseMath(this MarkdownPipeline pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<MathExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the figure extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipeline UseFigure(this MarkdownPipeline pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<FigureExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the custom abbreviation extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipeline UseAbbreviation(this MarkdownPipeline pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<AbbreviationExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the definition lists extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipeline UseDefinitionList(this MarkdownPipeline pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<DefinitionListExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the pipe table extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// The modified pipeline
        /// </returns>
        public static MarkdownPipeline UsePipeTable(this MarkdownPipeline pipeline, PipeTableOptions options = null)
        {
            if (!pipeline.Extensions.Contains<PipeTableExtension>())
            {
                pipeline.Extensions.Add(new PipeTableExtension(options));
            }
            return pipeline;
        }

        /// <summary>
        /// Uses the grid table extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipeline UseGridTable(this MarkdownPipeline pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<GridTableExtension>();
            return pipeline;
        }


        /// <summary>
        /// Uses the cite extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipeline UseCite(this MarkdownPipeline pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<CiteExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the footer extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipeline UseFooter(this MarkdownPipeline pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<FooterExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the footnotes extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipeline UseFootnotes(this MarkdownPipeline pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<FootnoteExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the softline break as hardline break extension
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipeline UseSoftlineBreakAsHardlineBreak(this MarkdownPipeline pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<SoftlineBreakAsHardlineExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the strikethrough superscript, subscript, inserted and marked text extensions.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <param name="options">The options to enable.</param>
        /// <returns>
        /// The modified pipeline
        /// </returns>
        public static MarkdownPipeline UseEmphasisExtra(this MarkdownPipeline pipeline, EmphasisExtraOptions options = EmphasisExtraOptions.Default)
        {
            if (!pipeline.Extensions.Contains<EmphasisExtraExtension>())
            {
                pipeline.Extensions.Add(new EmphasisExtraExtension(options));
            }
            return pipeline;
        }

        /// <summary>
        /// Uses the list extra extension to add support for `a.`, `A.`, `i.` and `I.` ordered list items.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>
        /// The modified pipeline
        /// </returns>
        public static MarkdownPipeline UseListExtra(this MarkdownPipeline pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<ListExtraExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the generic attributes extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipeline UseGenericAttributes(this MarkdownPipeline pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<GenericAttributesExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the emoji and smiley extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipeline UseEmojiAndSmiley(this MarkdownPipeline pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<EmojiExtension>();
            return pipeline;
        }
    }
}