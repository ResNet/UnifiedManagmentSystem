﻿/********************************************************************************************
 * InterIMAP
 * Copyright (C) 2008-2009 Jason Miesionczek
 * Original Author: Rohit Joshi
 * Based on this article on codeproject.com:
 * IMAP Client library using C#
 * http://www.codeproject.com/KB/IP/imaplibrary.aspx?msg=2498332
 * Posted: August 16th 2004
 * 
 * ZipStorer code written by Jaime Olivares
 * http://www.codeproject.com/KB/recipes/ZipStorer.aspx
 * 
 * InterIMAP is free software; you can redistribute it and/or modify it under the terms
 * of the GNU Lesser General Public License as published by the Free Software Foundation,
 * either version 3 of the License, or (at your option) any later version.
 * 
 * InterIMAP is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public License along with
 * InterIMAP. If not, see http://www.gnu.org/licenses/.
 * 
 * *****************************************************************************************/

using InterIMAP.Common.Commands;
using InterIMAP.Common.Interfaces;
using InterIMAP.Common.Processors;

namespace InterIMAP.Common.Requests
{
    /// <summary>
    /// Request certain data about a folder
    /// </summary>
    public class FolderDataRequest : BaseRequest
    {
        /// <summary>
        /// Create a new folder data request
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="callback"></param>
        public FolderDataRequest(IFolder folder, RequestCompletedCallback callback)
            : base(callback)
        {
            Command = new ExamineFolderCommand(folder, null);
            ProcessorType = typeof (FolderDataProcessor);
        }
    }
}
