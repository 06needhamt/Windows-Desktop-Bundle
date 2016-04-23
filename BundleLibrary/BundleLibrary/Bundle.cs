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
    /// This class represents a bundle. A bundle is a collection of other objects all stored together.
    /// objects within a bundle can be accessed using the key they were stored under.
    /// </summary>
    public class Bundle : IBundleable
    {
        /// <summary>
        /// An empty bundle used to check if a bundle is empty
        /// </summary>
        public static readonly Bundle EMPTY = new Bundle("");
        /// <summary>
        /// The passed identifier for this bundle
        /// </summary>
        private readonly string identifier;
        /// <summary>
        /// List to hold all of the strings contained in this bundle
        /// </summary>
        private List<Tuple<string, string>> strings = new List<Tuple<string, string>>();
        /// <summary>
        /// List to hold all of the integers contained in this bundle
        /// </summary>
        private List<Tuple<string, int>> ints = new List<Tuple<string, int>>();
        /// <summary>
        /// List to hold all of the longs contained in this bundle
        /// </summary>
        private List<Tuple<string, long>> longs = new List<Tuple<string, long>>();
        /// <summary>
        /// List to hold all of the floats contained in this bundle
        /// </summary>
        private List<Tuple<string, float>> floats = new List<Tuple<string, float>>();
        /// <summary>
        /// List to hold all of the doubels contained in this bundle
        /// </summary>
        private List<Tuple<string, double>> doubles = new List<Tuple<string, double>>();
        /// <summary>
        /// List to hold all of the booleans contained in this bundle
        /// </summary>
        private List<Tuple<string, bool>> bools = new List<Tuple<string, bool>>();
        /// <summary>
        /// List to hold all of the charaters contained in this bundle
        /// </summary>
        private List<Tuple<string, char>> chars = new List<Tuple<string, char>>();
        /// <summary>
        /// List to hold all of the IBundleable objects contained in this bundle
        /// </summary>
        private List<Tuple<string, IBundleable>> bundleableObjects = new List<Tuple<string, IBundleable>>();
        /// <summary>
        /// List to hold all of the string arrays contained in this bundle
        /// </summary>
        private List<Tuple<string, string[]>> stringArrays = new List<Tuple<string, string[]>>();
        /// <summary>
        /// List to hold all of the integer arrays contained in this bundle
        /// </summary>
        private List<Tuple<string, int[]>> intArrays = new List<Tuple<string, int[]>>();
        /// <summary>
        /// List to hold all of the long arrays contained in this bundle
        /// </summary>
        private List<Tuple<string, long[]>> longArrays = new List<Tuple<string, long[]>>();
        /// <summary>
        /// List to hold all of the float contained in this bundle
        /// </summary>
        private List<Tuple<string, float[]>> floatArrays = new List<Tuple<string, float[]>>();
        /// <summary>
        /// List to hold all of the double arrays contained in this bundle
        /// </summary>
        private List<Tuple<string, double[]>> doubleArrays = new List<Tuple<string, double[]>>();
        /// <summary>
        /// List to hold all of the boolean arrays contained in this bundle
        /// </summary>
        private List<Tuple<string, bool[]>> boolArrays = new List<Tuple<string, bool[]>>();
        /// <summary>
        /// List to hold all of the character arrays contained in this bundle
        /// </summary>
        private List<Tuple<string, char[]>> charArrays = new List<Tuple<string, char[]>>();
        /// <summary>
        /// List to hold all of the IBundleable object arrays contained in this bundle
        /// </summary>
        private List<Tuple<string, IBundleable[]>> bundleableObjectArrays = new List<Tuple<string, IBundleable[]>>();

        public string Identifier
        {
            get { return identifier; }
        }
        /// <summary>
        /// Default contructor for this bundle
        /// </summary>
        /// <param name="from"> string identifier to specify where this bundle came from </param>
        public Bundle(string from)
        {
            this.identifier = from;
        }
        /// <summary>
        /// Pack this object into a bundle
        /// </summary>
        /// <param name="key">the key that it will be stored with in the bundle</param>
        /// <param name="B"> The bundle to pack it in</param>
        public void packObject(string key, Bundle B)
        {
            IBundleable temp = this;
            B.putBundleable(key, temp);
        }
        /// <summary>
        /// Unpack this object from the bundle
        /// </summary>
        /// <param name="key">the key that it was stored with in the bundle</param>
        /// <param name="B">The bundle that it is packed in</param>
        /// <returns> the unpacked object from the bundle</returns>
        public IBundleable unpackOoject(string key, Bundle B)
        {
            IBundleable temp = null;
            temp = B.getBundleable(key);
            return temp;
        }
        /// <summary>
        /// Package an IBundleable object into this bundle
        /// </summary>
        /// <param name="key">the key to store the object under</param>
        /// <param name="obj">The object to package</param>
        private void putBundleable(string key, IBundleable obj)
        {
            bundleableObjects.Add(new Tuple<string, IBundleable>(key, obj));
        }
        /// <summary>
        /// Unpack an IBundleable object from this bundle
        /// </summary>
        /// <param name="key">The key which this object was stored under</param>
        /// <returns></returns>
        private IBundleable getBundleable(string key)
        {
            for (int i = 0; i < bundleableObjects.Count; i++)
            {
                if (bundleableObjects[i].Item1.Equals(key))
                {
                    return bundleableObjects[i].Item2;
                }
            }
            throw new InvalidKeyException(key);

        }
        /// <summary>
        /// Private internal method call used by the IBundleable interfaces packObject(key,obj) method
        /// </summary>
        /// <param name="key">the key passed to the packObject method</param>
        /// <param name="obj">the onject passed to the packObject method</param>
        public void storePackedObject(string key, IBundleable obj)
        {
            putBundleable(key, obj);
        }
        /// <summary>
        /// Private internal method call used by the IBundleable interfaces unpackObject(key) method
        /// </summary>
        /// <param name="key">the key passed to the unpackObject method</param>
        /// <returns>The unpacked object stored under the packed key</returns>
        public IBundleable getPackedObject(string key)
        {
            IBundleable temp = getBundleable(key);
            return temp;
        }
        /// <summary>
        /// gets a string from this bundle
        /// </summary>
        /// <param name="key">The key that the string was stored under</param>
        /// <returns>The string that was stored under that key</returns>
        public String getString(string key)
        {
            for (int i = 0; i < strings.Count; i++)
            {
                if (strings[i].Item1.Equals(key))
                {
                    return strings[i].Item2;
                }
            }
            throw new InvalidKeyException(key);

        }
        /// <summary>
        /// gets a integer from this bundle
        /// </summary>
        /// <param name="key">The key that the integer was stored under</param>
        /// <returns>The integer that was stored under that key</returns>
        public int getInt(string key)
        {
            for (int i = 0; i < ints.Count; i++)
            {
                if (ints[i].Item1.Equals(key))
                {
                    return ints[i].Item2;
                }
            }
            throw new InvalidKeyException(key);

        }
        /// <summary>
        /// gets a long from this bundle
        /// </summary>
        /// <param name="key">The key that the long was stored under</param>
        /// <returns>The integer that was stored under that key</returns>
        public long getLong(string key)
        {
            for (int i = 0; i < longs.Count; i++)
            {
                if (longs[i].Item1.Equals(key))
                {
                    return longs[i].Item2;
                }
            }
            throw new InvalidKeyException(key);

        }
        /// <summary>
        /// gets a float from this bundle
        /// </summary>
        /// <param name="key">The key that the float was stored under</param>
        /// <returns>The float that was stored under that key</returns>
        public float getFloat(string key)
        {
            for (int i = 0; i < floats.Count; i++)
            {
                if (floats[i].Item1.Equals(key))
                {
                    return floats[i].Item2;
                }
            }
            throw new InvalidKeyException(key);
        }
        /// <summary>
        /// gets a double from this bundle
        /// </summary>
        /// <param name="key">The key that the double was stored under</param>
        /// <returns>The double that was stored under that key</returns>
        public double getDouble(string key)
        {
            for (int i = 0; i < doubles.Count; i++)
            {
                if (doubles[i].Item1.Equals(key))
                {
                    return doubles[i].Item2;
                }
            }
            throw new InvalidKeyException(key);

        }
        /// <summary>
        /// gets a boolean from this bundle
        /// </summary>
        /// <param name="key">The key that the boolean was stored under</param>
        /// <returns>The boolean that was stored under that key</returns>
        public bool getBool(string key)
        {
            for (int i = 0; i < bools.Count; i++)
            {
                if (bools[i].Item1.Equals(key))
                {
                    return bools[i].Item2;
                }
            }
            throw new InvalidKeyException(key);
        }
        /// <summary>
        /// gets a character from this bundle
        /// </summary>
        /// <param name="key">The key that the character was stored under</param>
        /// <returns>The double that was stored under that key</returns>
        public char getChar(string key)
        {
            for (int i = 0; i < chars.Count; i++)
            {
                if (chars[i].Item1.Equals(key))
                {
                    return chars[i].Item2;
                }
            }
            throw new InvalidKeyException(key);
        }
        /// <summary>
        /// gets a string array from this bundle
        /// </summary>
        /// <param name="key">The key that the string array was stored under</param>
        /// <returns>The string array that was stored under that key</returns>
        public String[] getStringArray(string key)
        {
            for (int i = 0; i < stringArrays.Count; i++)
            {
                if (stringArrays[i].Item1.Equals(key))
                {
                    return stringArrays[i].Item2;
                }
            }
            throw new InvalidKeyException(key);

        }
        /// <summary>
        /// gets a integer array from this bundle
        /// </summary>
        /// <param name="key">The key that the integer array was stored under</param>
        /// <returns>The integer array that was stored under that key</returns>
        public int[] getIntArray(string key)
        {
            for (int i = 0; i < intArrays.Count; i++)
            {
                if (intArrays[i].Item1.Equals(key))
                {
                    return intArrays[i].Item2;
                }
            }
            throw new InvalidKeyException(key);

        }
        /// <summary>
        /// gets a long array from this bundle
        /// </summary>
        /// <param name="key">The key that the long array was stored under</param>
        /// <returns>The long array that was stored under that key</returns>
        public long[] getLongArray(string key)
        {
            for (int i = 0; i < longArrays.Count; i++)
            {
                if (longArrays[i].Item1.Equals(key))
                {
                    return longArrays[i].Item2;
                }
            }
            throw new InvalidKeyException(key);

        }
        /// <summary>
        /// gets a float array from this bundle
        /// </summary>
        /// <param name="key">The key that the float array was stored under</param>
        /// <returns>The float array that was stored under that key</returns>
        public float[] getFloatArray(string key)
        {
            for (int i = 0; i < floatArrays.Count; i++)
            {
                if (floatArrays[i].Item1.Equals(key))
                {
                    return floatArrays[i].Item2;
                }
            }
            throw new InvalidKeyException(key);
        }
        /// <summary>
        /// gets a double array from this bundle
        /// </summary>
        /// <param name="key">The key that the double array was stored under</param>
        /// <returns>The double array that was stored under that key</returns>
        public double[] getDoubleArray(string key)
        {
            for (int i = 0; i < doubleArrays.Count; i++)
            {
                if (doubleArrays[i].Item1.Equals(key))
                {
                    return doubleArrays[i].Item2;
                }
            }
            throw new InvalidKeyException(key);

        }
        /// <summary>
        /// gets a boolean array from this bundle
        /// </summary>
        /// <param name="key">The key that the boolean array was stored under</param>
        /// <returns>The boolean array that was stored under that key</returns>
        public bool[] getBoolArrays(string key)
        {
            for (int i = 0; i < boolArrays.Count; i++)
            {
                if (boolArrays[i].Item1.Equals(key))
                {
                    return boolArrays[i].Item2;
                }
            }
            throw new InvalidKeyException(key);
        }
        /// <summary>
        /// gets a character array from this bundle
        /// </summary>
        /// <param name="key">The key that the character array was stored under</param>
        /// <returns>The character array that was stored under that key</returns>
        public char[] getCharArrays(string key)
        {
            for (int i = 0; i < charArrays.Count; i++)
            {
                if (charArrays[i].Item1.Equals(key))
                {
                    return charArrays[i].Item2;
                }
            }
            throw new InvalidKeyException(key);
        }
        /// <summary>
        /// Puts a string into this bundle
        /// </summary>
        /// <param name="key"> the key to store the string under</param>
        /// <param name="value"> the string to store in the bundle</param>
        public void putString(string key, string value)
        {
            strings.Add(new Tuple<string,string>(key,value));
        }

        /// <summary>
        /// Puts a integer into this bundle
        /// </summary>
        /// <param name="key"> the key to store the integer under</param>
        /// <param name="value"> the integer to store in the bundle</param>
        public void putInt(string key, int value)
        {
            ints.Add(new Tuple<string, int>(key, value));
        }
        /// <summary>
        /// Puts a long into this bundle
        /// </summary>
        /// <param name="key"> the key to store the long under</param>
        /// <param name="value"> the long to store in the bundle</param>
        public void putLong(string key, long value)
        {
            longs.Add(new Tuple<string, long>(key, value));
        }
        /// <summary>
        /// Puts a float into this bundle
        /// </summary>
        /// <param name="key"> the key to store the float under</param>
        /// <param name="value"> the float to store in the bundle</param>
        public void putFloat(string key, float value)
        {
            floats.Add(new Tuple<string, float>(key, value));
        }
        /// <summary>
        /// Puts a double into this bundle
        /// </summary>
        /// <param name="key"> the key to store the double under</param>
        /// <param name="value"> the double to store in the bundle</param>
        public void putDouble(string key, double value)
        {
            doubles.Add(new Tuple<string, double>(key, value));
        }
        /// <summary>
        /// Puts a boolean into this bundle
        /// </summary>
        /// <param name="key"> the key to store the boolean under</param>
        /// <param name="value"> the boolean to store in the bundle</param>
        public void putBool(string key, bool value)
        {
            bools.Add(new Tuple<string, bool>(key, value));
        }
        /// <summary>
        /// Puts a character into this bundle
        /// </summary>
        /// <param name="key"> the key to store the character under</param>
        /// <param name="value"> the character to store in the bundle</param>
        public void putChar(string key, char value)
        {
            chars.Add(new Tuple<string, char>(key, value));
        }
        /// <summary>
        /// Puts a string array into this bundle
        /// </summary>
        /// <param name="key"> the key to store the string array under</param>
        /// <param name="value"> the string array to store in the bundle</param>
        public void putStringArray(string key, string[] value)
        {
            stringArrays.Add(new Tuple<string, string[]>(key, value));
        }
        /// <summary>
        /// Puts a integer array into this bundle
        /// </summary>
        /// <param name="key"> the key to store the integer array under</param>
        /// <param name="value"> the integer array to store in the bundle</param>
        public void putIntArray(string key, int[] value)
        {
            intArrays.Add(new Tuple<string, int[]>(key, value));
        }
        /// <summary>
        /// Puts a long array into this bundle
        /// </summary>
        /// <param name="key"> the key to store the long array under</param>
        /// <param name="value"> the long array to store in the bundle</param>
        public void putLongArray(string key, long[] value)
        {
            longArrays.Add(new Tuple<string, long[]>(key, value));
        }
        /// <summary>
        /// Puts a float array into this bundle
        /// </summary>
        /// <param name="key"> the key to store the float array under</param>
        /// <param name="value"> the float array to store in the bundle</param>
        public void putFloatArray(string key, float[] value)
        {
            floatArrays.Add(new Tuple<string, float[]>(key, value));
        }
        /// <summary>
        /// Puts a double array into this bundle
        /// </summary>
        /// <param name="key"> the key to store the double array under</param>
        /// <param name="value"> the double array to store in the bundle</param>
        public void putDoubleArray(string key, double[] value)
        {
            doubleArrays.Add(new Tuple<string, double[]>(key, value));
        }
        /// <summary>
        /// Puts a boolean array into this bundle
        /// </summary>
        /// <param name="key"> the key to store the boolean array under</param>
        /// <param name="value"> the boolean array to store in the bundle</param>
        public void putBoolArray(string key, bool[] value)
        {
            boolArrays.Add(new Tuple<string, bool[]>(key, value));
        }
        /// <summary>
        /// Puts a character array into this bundle
        /// </summary>
        /// <param name="key"> the key to store the charcter array under</param>
        /// <param name="value"> the character array to store in the bundle</param>
        public void putCharArray(string key, char[] value)
        {
            charArrays.Add(new Tuple<string, char[]>(key, value));
        }
        /// <summary>
        /// Custom overload of the binary plus operator which allows two bundle structures to be merged
        /// </summary>
        /// <param name="lhs">The first bundle to merge</param>
        /// <param name="rhs">the second bundle to merge</param>
        /// <returns> The result of the tw0 bundles once merged. 
        /// Or NULL if one of the input bundles was NULL</returns>
        public static Bundle operator +(Bundle lhs, Bundle rhs)
        {
            if (lhs == null || rhs == null)
            {
                throw new InvalidBundleException("One or both of the bundles passed to the merge operation was NULL");
            }
            if (lhs == Bundle.EMPTY)
            {
                return rhs;
            }
            else if (rhs == Bundle.EMPTY)
            {
                return lhs;
            }

            lhs.strings.AddRange(rhs.strings);
            lhs.ints.AddRange(rhs.ints);
            lhs.longs.AddRange(rhs.longs);
            lhs.floats.AddRange(rhs.floats);
            lhs.doubles.AddRange(rhs.doubles);
            lhs.bools.AddRange(rhs.bools);
            lhs.chars.AddRange(rhs.chars);
            lhs.bundleableObjects.AddRange(rhs.bundleableObjects);
            lhs.stringArrays.AddRange(rhs.stringArrays);
            lhs.intArrays.AddRange(rhs.intArrays);
            lhs.longArrays.AddRange(rhs.longArrays);
            lhs.floatArrays.AddRange(rhs.floatArrays);
            lhs.doubleArrays.AddRange(rhs.doubleArrays);
            lhs.boolArrays.AddRange(rhs.boolArrays);
            lhs.charArrays.AddRange(rhs.charArrays);
            lhs.bundleableObjectArrays.AddRange(rhs.bundleableObjectArrays);
            return lhs;

        }
    }
}

