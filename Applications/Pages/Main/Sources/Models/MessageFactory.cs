﻿/* ------------------------------------------------------------------------- */
//
// Copyright (c) 2010 CubeSoft, Inc.
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
/* ------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Linq;
using Cube.FileSystem;

namespace Cube.Pdf.Pages
{
    /* --------------------------------------------------------------------- */
    ///
    /// MessageFactory
    ///
    /// <summary>
    /// Provides functionality to create message objects.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    internal static class MessageFactory
    {
        #region OpenOrSaveMessage

        /* ----------------------------------------------------------------- */
        ///
        /// CreateForAdd
        ///
        /// <summary>
        /// Creates a message to show an OpenFileDialog dialog.
        /// </summary>
        ///
        /// <returns>OpenFileMessage object.</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static OpenFileMessage CreateForAdd() => new OpenFileMessage
        {
            Text            = Properties.Resources.TitleAdd,
            CheckPathExists = true,
            Multiselect     = true,
            Filter          = new[]
            {
                new ExtensionFilter(Properties.Resources.FilterSupported, true,
                    "*.pdf", "*.bmp", "*.gif", "*.jpg", "*.jpeg", "*.png", "*.tiff"),
                new ExtensionFilter(Properties.Resources.FilterAll, true, ".*"),
            }.GetFilter(),
        };

        /* ----------------------------------------------------------------- */
        ///
        /// CreateForMerge
        ///
        /// <summary>
        /// Creates a message to show a SaveFileDialog dialog.
        /// </summary>
        ///
        /// <returns>SaveFileMessage object.</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static SaveFileMessage CreateForMerge() => new SaveFileMessage
        {
            Text            = Properties.Resources.TitleMerge,
            OverwritePrompt = true,
            CheckPathExists = false,
            Filter          = new[]
            {
                new ExtensionFilter(Properties.Resources.FilterPdf, true, ".pdf"),
                new ExtensionFilter(Properties.Resources.FilterAll, true, ".*"),
            }.GetFilter(),
        };

        /* ----------------------------------------------------------------- */
        ///
        /// CreateForSplit
        ///
        /// <summary>
        /// Creates a message to show a BrowserFolder dialog.
        /// </summary>
        ///
        /// <returns>OpenDirectoryMessage object.</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static OpenDirectoryMessage CreateForSplit() => new OpenDirectoryMessage
        {
            Text      = Properties.Resources.TitleSplit,
            NewButton = true,
        };

        /* ----------------------------------------------------------------- */
        ///
        /// CreateForSelect
        ///
        /// <summary>
        /// Creates a message to select items of the specified indices.
        /// </summary>
        ///
        /// <param name="indices">Source selected indices.</param>
        /// <param name="offset">Offset to move.</param>
        /// <param name="count">Number of files.</param>
        ///
        /// <returns>SelectMessage object.</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static SelectMessage CreateForSelect(IEnumerable<int> indices, int offset, int count) => new SelectMessage
        {
            Text  = string.Empty,
            Value = indices.Select(e => Math.Max(Math.Min(e + offset, count - 1), 0)),
        };

        #endregion
    }
}
