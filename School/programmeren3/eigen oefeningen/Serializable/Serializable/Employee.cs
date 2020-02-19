using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializable
{
    [Serializable]
    public class Employee
    {
        public int Age { get; set; }
        public string Name { get; set; }
        [NonSerialized]
        public string Password;


        static void Serialize(Employee employee, string fileName)
        {
            Stream stream = File.Open(fileName, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Console.WriteLine("Writing employee information");
            try
            {
                binaryFormatter.Serialize(stream, employee);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Exception when serializing: " + ex.Message);
                throw;
            }
            finally
            {
                stream.Close();
                Console.WriteLine("Closing stream");
            }
        }
        static Employee Deserialize(string fileName)
        {
            Employee employee = null;
            Stream stream = File.Open(fileName, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Console.WriteLine("Writing employee information");
            try
            {
                employee = (Employee)binaryFormatter.Deserialize(stream);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Exception when deserializing: " + ex.Message);
                throw;
            }
            finally
            {
                stream.Close();
                Console.WriteLine("Closing stream");
            }
            return employee;
        }
    }
}
