using System;
using NUnit.Framework;
using Expedia;
using Rhino.Mocks;

namespace ExpediaTest
{
	[TestFixture()]
	public class CarTest
	{	
		private Car targetCar;
		private MockRepository mocks;
		
		[SetUp()]
		public void SetUp()
		{
			targetCar = new Car(5);
			mocks = new MockRepository();
		}
        
		
		[Test()]
		public void TestThatCarInitializes()
		{
			Assert.IsNotNull(targetCar);
		}	
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForFiveDays()
		{
			Assert.AreEqual(50, targetCar.getBasePrice()	);
		}
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForTenDays()
		{
            var target = new Car(10);
			Assert.AreEqual(80, target.getBasePrice());	
		}
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForSevenDays()
		{
			var target = new Car(7);
			Assert.AreEqual(10*7*.8, target.getBasePrice());
		}
		
		[Test()]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestThatCarThrowsOnBadLength()
		{
			new Car(-5);
		}

        [Test()]
        public void TestCarLocation()
        {
            IDatabase mockDatabase = mocks.Stub<IDatabase>();
            String carLoc1 = "Neverland";
            String carLoc2 = "Dark Side of the Moon";
            using (mocks.Record())
            {
                mockDatabase.getCarLocation(1);
                LastCall.Return(carLoc1);
                mockDatabase.getCarLocation(2);
                LastCall.Return(carLoc2);
            }
            var target = new Car(1);
       
            target.Database = mockDatabase;

            String result;
            result = target.getCarLocation(1);
            Assert.AreEqual(result, carLoc1);
            result = target.getCarLocation(2);
            Assert.AreEqual(result, carLoc2);
            
        }
        [Test()]
        public void TestCarMilage()
        {

            IDatabase mockDatabase = mocks.Stub<IDatabase>();
            Int32 mi = 13422;
            mockDatabase.Miles = mi;
            
            var target = new Car(10);
            target.Database = mockDatabase;
            int milecount = target.Mileage;
            Assert.AreEqual(mi, milecount);


        }
        [Test()]
        public void TestingObjectMother()
        {
            var target = ObjectMother.BMW();


        }



	}
}
