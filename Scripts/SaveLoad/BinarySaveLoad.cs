using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RichUnity.SaveLoad
{
    public static class BinarySaveLoad
    {
        public static bool Save<T>(string filePath, T data)
        {
            FileStream fileStream = null;
            bool saved;
            try
            {
                var binaryFormatter = new BinaryFormatter();
                fileStream = File.Create(filePath);
                binaryFormatter.Serialize(fileStream, data);
                saved = true;
            }
            catch (Exception)
            {
                saved = false;
            }
            finally
            {
                if (fileStream != null)
                {
                    try
                    {
                        fileStream.Close();
                    }
                    catch (Exception)
                    {
                        saved = false;
                    }
                }
            }

            return saved;
        }
        
        public static T Load<T>(string filePath)
        {
            var binaryFormatter = new BinaryFormatter();
            FileStream fileStream = null;
            T data;
            try
            {
                fileStream = File.Open(filePath, FileMode.Open);
                data = (T) binaryFormatter.Deserialize(fileStream);
            }
            catch (Exception)
            {
                data = default(T);
            }
            finally
            {
                if (fileStream != null)
                {
                    try
                    {
                        fileStream.Close();
                    }
                    catch (Exception)
                    {
                        data = default(T);
                    }
                }
            }

            return data;
        }
    }

}