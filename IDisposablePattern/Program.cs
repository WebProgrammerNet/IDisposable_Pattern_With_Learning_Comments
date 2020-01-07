using System;
using System.Collections.Generic;

namespace IDisposablePattern
{
    class Program
    {
        private bool disposed;

        static void Main(string[] args)
        {
            //Cars cars = new Cars();
            //cars.GetCars();
            Resource resource = new Resource();
            
            resource.Dispose();
        }
    }
    public class Cars
    {
        string[] cars = {"BMV","Hunday","Jeep","Nissan","Naz" };

        public void GetCars()
        {
            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine(cars[i]);
            }
        }
    }
}

