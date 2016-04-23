/*
 The MIT License (MIT)

Copyright (c) 2016 Tom Needham

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bundle_Library
{
    /// <summary>
    /// This class represents an exception which is thrown when the key was not found within the bundle
    /// </summary>
    public class InvalidKeyException : InvalidBundleException
    {
        /// <summary>
        /// The passed key
        /// </summary>
        private string key = "";

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        /// <summary>
        /// Standard Constructor
        /// </summary>
        public InvalidKeyException() : base()
        {

        }

        /// <summary>
        /// Contructor which takes a message 
        /// </summary>
        /// <param name="Message">The message to display when the exception is thrown</param>
        public InvalidKeyException(string key) : base()
        {
            this.key = key;
        }

        /// <summary>
        /// The default message displayed when the exception is thrown. 
        /// This message is displayed if no message was passed in the constructor
        /// </summary>
        public override string Message
        {
            get
            {
                return "The key " + this.key + " was not present in the bundle, make sure you have entered the correct key and try again";
            }
        }
    }
}
