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
using Bundle_Library;

namespace Bundle_Library
{
    /// <summary>
    /// This class represents a simple object that can be packed and unpacked from a bundle.
    /// </summary>
    public class TestBundleable : IBundleable
    {
        private string testString = "Hello";

        public string TestString
        {
            get { return testString; }
            set { testString = value; }
        }
        private int testInt = 12345;

        public int TestInt
        {
            get { return testInt; }
            set { testInt = value; }
        }
        /// <summary>
        /// Contructor for this object
        /// </summary>
        public TestBundleable()
        {
        }
        /// <summary>
        /// Pack this object into a bundle
        /// </summary>
        /// <param name="key">the key that it will be stored with in the bundle</param>
        /// <param name="B"> The bundle to pack it in</param>
        void IBundleable.packObject(string key, Bundle B)
        {
            IBundleable temp = this;
            B.storePackedObject(key, temp);
        }
        /// <summary>
        /// Unpack this object from the bundle
        /// </summary>
        /// <param name="key">the key that it was stored with in the bundle</param>
        /// <param name="B">The bundle that it is packed in</param>
        /// <returns> the unpacked object from the bundle</returns>
        IBundleable IBundleable.unpackOoject(string key, Bundle B)
        {
            IBundleable temp = B.getPackedObject(key);
            return temp;
        }
    }
}
