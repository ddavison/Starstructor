/*Starstructor, the Starbound Toolet 
Copyright (C) 2013-2014 Chris Stamford
Contact: cstamford@gmail.com

Source file contributers:
 Chris Stamford     contact: cstamford@gmail.com

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
*/

using System;
using System.IO;
using System.Windows.Forms;

namespace Starstructor
{
    public class Logger
    {
        private readonly StreamWriter m_file;

        public Logger(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    string dir = Path.GetDirectoryName(path);
                    Directory.CreateDirectory(dir);
                }

                m_file = new StreamWriter(path, true) { AutoFlush = true };
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to create log file. Report this on the forums.\n\n" + e.ToString());
            }
        }

        public void Write(string text)
        {
            if (m_file == null || text == null)
                return;

            m_file.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss fff") + "] " + text);
        }
    }
}