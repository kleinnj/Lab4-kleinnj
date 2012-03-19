using Expedia;
using System;

namespace ExpediaTest
{
	public class ObjectMother
	{
        		
        public static Car BMW()
        {
            return new Car(10) { Name = "Fancy BMW" };
        }
        public static Car Saab()
        {
            return new Car(7) { Name = "Saab 9-5 Sports Sedan" };
        }
		
	}
}
