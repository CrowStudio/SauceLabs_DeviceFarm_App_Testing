using NUnit.Framework;

namespace DeviceFarm.TestFixtures
{
    public abstract class BaseFixture : AppInitializer
    {
        protected const string UserMail = "test@test.com",
                               UserPassword = "0000",
                               UserName = "Tester",
                               SystemName = "Allegra Geller",
                               
                               InstallerMail = "installer@test.com",
                               InstallerPassword = "1234",
                               InstallerName = "Yevgeny Nourish";

        [SetUp]
        public virtual void SetUp()
        {
            StartApp();
            StartScreenRecording();
        }

        [TearDown]
        public virtual void QuitApp()
        {
            StopScreenRecording();
            StopApp();
        }
    }
}