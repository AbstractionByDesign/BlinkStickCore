using BlinkStickCore;
using NUnit.Framework;

namespace IntegrationTests
{
    public class Tests
    {
        private const string PlugInMessage = "Is the BlinkStick plugged in?";
        
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
            var device = BlinkStick.FindFirst();
            if(device?.Connected ?? false)
                device.CloseDevice();
        }

        [Test]
        public void FindFirst_DeviceAttached_ShouldNotBenull()
        {
            //Arrange / Act
            var device = BlinkStick.FindFirst();
            
            //Assert
            Assert.IsNotNull(device, PlugInMessage);
        }
        
        [Test]
        public void FindAll_DeviceAttached_ShouldFindAtleastOneDevice()
        {
            //Arrange / Act
            var device = BlinkStick.FindAll();
            
            //Assert
            Assert.IsTrue(device.Length > 0, PlugInMessage);
        }
        
        
        [Test]
        public void OpenDevice_DeviceAttached_ConnectedIsTrue()
        {
            //Arrange
            var device = BlinkStick.FindFirst();
            
            //Act
            device.OpenDevice();
            
            //Assert
            Assert.IsTrue(device.Connected);
            
            device.CloseDevice();
        }
    }
}