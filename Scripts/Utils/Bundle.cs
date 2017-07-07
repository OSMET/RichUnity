using System;
using System.Collections.Generic;


namespace RichUnity.Utils {
    [Serializable]
    public class Bundle : Dictionary<string, object> {
        public bool GetOrElseBool(string key, bool value) {
            try {
                var obj = this[key];
                if (obj == null) {
                    return value;
                }
                return (bool) obj;
            } catch (InvalidCastException) {
                return value;
            }
        }

        public bool GetBool(string key) {
            return GetOrElseBool(key, false);
        }

        public bool[] GetBoolArray(string key) {
            try {
                var obj = this[key];
                return (bool[]) obj;
            } catch (InvalidCastException) {
                return null;
            }
        }

        public byte GetOrElseByte(string key, byte value) {
            try {
                var obj = this[key];
                if (obj == null) {
                    return value;
                } else {
                    return (byte) obj;
                }
            } catch (InvalidCastException) {
                return value;
            }
        }

        public byte GetByte(string key) {
            return GetOrElseByte(key, 0);
        }

        public byte[] GetByteArray(string key) {
            try {
                var obj = this[key];
                return (byte[]) obj;
            } catch (InvalidCastException) {
                return null;
            }
        }

        public char GetOrElseChar(string key, char value) {
            try {
                var obj = this[key];
                if (obj == null) {
                    return value;
                } else {
                    return (char) obj;
                }
            } catch (InvalidCastException) {
                return value;
            }
        }

        public char GetChar(string key) {
            return GetOrElseChar(key, '\u0000');
        }

        public char[] GetCharArray(string key) {
            try {
                var obj = this[key];
                return (char[]) obj;
            } catch (InvalidCastException) {
                return null;
            }
        }

        public double GetOrElseDouble(string key, double value) {
            try {
                var obj = this[key];
                if (obj == null) {
                    return value;
                } else {
                    return (double) obj;
                }
            } catch (InvalidCastException) {
                return value;
            }
        }

        public double GetDouble(string key) {
            return GetOrElseDouble(key, 0.0);
        }

        public double[] GetDoubleArray(string key) {
            try {
                var obj = this[key];
                return (double[]) obj;
            } catch (InvalidCastException) {
                return null;
            }
        }

        public float GetOrElseFloat(string key, float value) {
            try {
                var obj = this[key];
                if (obj == null) {
                    return value;
                } else {
                    return (float) obj;
                }
            } catch (InvalidCastException) {
                return value;
            }
        }

        public float GetFloat(string key) {
            return GetOrElseFloat(key, 0.0f);
        }

        public float[] GetFloatArray(string key) {
            try {
                var obj = this[key];
                return (float[]) obj;
            } catch (InvalidCastException) {
                return null;
            }
        }

        public int GetOrElseInt(string key, int value) {
            try {
                var obj = this[key];
                if (obj == null) {
                    return value;
                }
                return (int) obj;
            } catch (InvalidCastException) {
                return value;
            }
        }

        public int GetInt(string key) {
            return GetOrElseInt(key, 0);
        }

        public int[] GetIntArray(string key) {
            try {
                var obj = this[key];
                return (int[]) obj;
            } catch (InvalidCastException) {
                return null;
            }
        }

        public long GetOrElseLong(string key, long value) {
            try {
                var obj = this[key];
                if (obj == null) {
                    return value;
                }
                return (long) obj;
            } catch (InvalidCastException) {
                return value;
            }
        }

        public long GetLong(string key) {
            return GetOrElseLong(key, 0);
        }

        public long[] GetLongArray(string key) {
            try {
                var obj = this[key];
                return (long[]) obj;
            } catch (InvalidCastException) {
                return null;
            }
        }

        public short GetOrElseShort(string key, short value) {
            try {
                var obj = this[key];
                if (obj == null) {
                    return value;
                }
                return (short) obj;
            } catch (InvalidCastException) {
                return value;
            }
        }

        public short GetShort(string key) {
            return GetOrElseShort(key, 0);
        }

        public short[] GetShortArray(string key) {
            try {
                var obj = this[key];
                return (short[]) obj;
            } catch (InvalidCastException) {
                return null;
            }
        }

        public string GetOrElseString(string key, string value) {
            try {
                var obj = this[key];
                if (obj == null) {
                    return value;
                }
                return (string) obj;
            } catch (InvalidCastException) {
                return value;
            }
        }

        public string GetString(string key) {
            return GetOrElseString(key, null);
        }

        public string[] GetStringArray(string key) {
            try {
                var obj = this[key];
                return (string[]) obj;
            } catch (InvalidCastException) {
                return null;
            }
        }
    }
}
